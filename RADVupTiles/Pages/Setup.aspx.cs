using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADBusinessLogicLayer;
using System.Web.Security;
using RADVupTiles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Drawing;
using RADCommonServices;

public partial class Pages_Setup : System.Web.UI.Page
{
    private DataTable teams;
    private DataTable employees;

    protected override void OnInit(EventArgs e)
    {
        //added to prevent incorrect reorder (e.g if it is navigated to another page and returns with back button - IE issue)
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Context.User.Identity.Name;
        if (!Roles.IsUserInRole(userName, "VUP Admin"))
        {
            radStepCompany.Visible = false;
            radStepCompany.CssClass = "hidden";
            RadWizard1.ActiveStepIndex = 1;
            lblCreateNewRole.Visible = false;
            RoleName.Visible = false;
            CreateRoleButton.Visible = false;
        }
        if (!IsPostBack)
        {
            //avoiding sharing Session variables between tabs in one browser
            SessionID.Value = Guid.NewGuid().ToString();
            GetCompanies();
            GetRegion();
            DisplayRolesInGrid();

            DataTable dtUserWithRoles = DisplayAllUsers();
            GridView1.DataSource = dtUserWithRoles.DefaultView;
            GridView1.DataBind();

            // Bind the users and roles 
            BindUsersToUserList();
            BindRolesToList();

            // Check the selected user's roles 
            CheckRolesForSelectedUser();

            // Display those users belonging to the currently selected role 
            DisplayUsersBelongingToRole();
        }
        Session.Timeout = 30;
        RadOrgChart1.NodeDrop += new Telerik.Web.UI.OrgChartNodeDropEventHandler(RadOrgChart1_NodeDrop);
        RadOrgChart1.GroupItemDrop += new Telerik.Web.UI.OrgChartGroupItemDropEventHandler(RadOrgChart1_GroupItemDrop);

        if (Session[SessionID.Value + "TeamsGroupEnabledBindingCS"] == null || Session[SessionID.Value + "EmployeesGroupEnabledBindingCS"] == null || !IsPostBack)
        {
            CreateTeams();

            CreateEmployees();
        }
        else
        {
            teams = Session[SessionID.Value + "TeamsGroupEnabledBindingCS"] as DataTable;
            employees = Session[SessionID.Value + "EmployeesGroupEnabledBindingCS"] as DataTable;
        }

        RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataFieldID = "TeamID";
        RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataFieldParentID = "ReportsTo";
        RadOrgChart1.RenderedFields.NodeFields.Add(new Telerik.Web.UI.OrgChartRenderedField() { DataField = "Team" });
        RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataSource = teams;

        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataFieldID = "EmployeeID";
        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataFieldNodeID = "TeamID";
        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataTextField = "Name";
        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataImageUrlField = "ImageUrl";

        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataSource = employees;

        RadOrgChart1.DataBind();      
        if (!Roles.IsUserInRole(userName, "Guest"))
        {
            RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("SecurityQuestionAndAnswer").Visible = Membership.Provider.RequiresQuestionAndAnswer;
            if (!IsPostBack)
            {
                if (Roles.IsUserInRole("VUP Admin"))
                    BindCompany();
                else
                {
                    DropDownList ddl = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("SelectCompany");
                    Label lbl = (Label)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Label1");
                    ddl.Visible = false;
                    lbl.Visible = false;
                }
            }
        }
        else
            RegisterUser.Visible = false;
    }

    private void CreateEmployees()
    {
        employees = new DataTable();
        employees.Columns.Add("EmployeeID");
        employees.Columns.Add("TeamID");
        employees.Columns.Add("Name");
        employees.Columns.Add("ImageUrl");

        employees.Rows.Add(new string[] { "1", "1", "Bed Bath & Beyond", "~/Img/Company.png" });
        employees.Rows.Add(new string[] { "2", "2", "Region 1", "~/Img/Region.png" });
        employees.Rows.Add(new string[] { "3", "2", "Region 2", "~/Img/Region.png" });
        employees.Rows.Add(new string[] { "4", "3", "Area 1", "~/Img/Area.png" });
        employees.Rows.Add(new string[] { "5", "3", "Area 1", "~/Img/Area.png" });
        employees.Rows.Add(new string[] { "6", "4", "Store 1", "~/Img/Store.png" });
        employees.Rows.Add(new string[] { "7", "4", "Store 2", "~/Img/Store.png" });
        employees.Rows.Add(new string[] { "8", "5", "RAD Device 1", "~/Img/RADDevice.png" });

        //employees.Rows.Add(new string[] { "1", "1", "Bed Bath & Beyond" });
        //employees.Rows.Add(new string[] { "2", "2", "Region 1"});
        //employees.Rows.Add(new string[] { "3", "2", "Region 2"});
        //employees.Rows.Add(new string[] { "4", "3", "Area 1"});
        //employees.Rows.Add(new string[] { "5", "4", "Store 1"});
        Session[SessionID.Value + "EmployeesGroupEnabledBindingCS"] = employees;
    }

    private void CreateTeams()
    {
        teams = new DataTable();
        teams.Columns.Add("TeamID");
        teams.Columns.Add("ReportsTo");
        teams.Columns.Add("Team");
        teams.Rows.Add(new string[] { "1", null, "Company" });
        teams.Rows.Add(new string[] { "2", "1", "Region" });
        teams.Rows.Add(new string[] { "3", "2", "Areas" });
        teams.Rows.Add(new string[] { "4", "3", "Stores" });
        teams.Rows.Add(new string[] { "5", "4", "RAD Devices" });
        Session[SessionID.Value + "TeamsGroupEnabledBindingCS"] = teams;
    }

    void RadOrgChart1_GroupItemDrop(object sender, Telerik.Web.UI.OrgChartGroupItemDropEventArguments e)
    {
        var rows = from myRow in employees.AsEnumerable() where myRow.Field<string>("EmployeeID") == e.SourceGroupItem.ID select new { values = myRow };

        foreach (var row in rows)
        {
            row.values.SetField<string>("TeamID", e.DestinationNode.ID);
        }

        Session[SessionID.Value + "EmployeesGroupEnabledBindingCS"] = employees;

        RadOrgChart1.DataBind();
    }

    void RadOrgChart1_NodeDrop(object sender, Telerik.Web.UI.OrgChartNodeDropEventArguments e)
    {
        var rows = from myRow in teams.AsEnumerable() where myRow.Field<string>("TeamID") == e.SourceNode.ID select new { values = myRow };

        foreach (var row in rows)
        {
            row.values.SetField<string>("ReportsTo", e.DestinationNode.ID);
        }

        Session[SessionID.Value + "TeamsGroupEnabledBindingCS"] = teams;

        RadOrgChart1.DataBind();
    }
    protected void btnCreateCompany_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        BusinessLogic objBussLogic = new BusinessLogic();
        blnResult = objBussLogic.CreateCompany(txtCreateCompany.Text);
        if (blnResult)
        {
            lblCompanyStatus.Visible = true;
            lblCompanyStatus.ForeColor = Color.Green;
            lblCompanyStatus.Text = "Company created successfully.";
        }
        else
        {
            lblCompanyStatus.Visible = true;
            lblCompanyStatus.ForeColor = Color.Red;
            lblCompanyStatus.Text = "Company creation failed. Please Contact Administrator.";
        }

    }
    protected void btnCreateStore_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        if (!string.IsNullOrEmpty(txtCreateStore.Text))
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            blnResult = objBusinessLogic.CreateStore(txtCreateStore.Text, txtLocation.Text, Convert.ToInt32(ddlCompanies.SelectedItem.Value));
            if (blnResult)
            {
                lblStoreStatus.Visible = true;
                lblStoreStatus.ForeColor = Color.Green;
                lblStoreStatus.Text = "Store created successfully.";
            }
            else
            {
                lblStoreStatus.Visible = true;
                lblStoreStatus.ForeColor = Color.Red;
                lblStoreStatus.Text = "Store creation failed. Please Contact Administrator.";
            }
        }
    }
    public DataTable GetStores()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtCompanies = objBussLogic.GetStores(commFunc.GetUsersCompanyID(Context));
        return dtCompanies;
    }

    public void GetCompanies()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCompanies = objBussLogic.GetCompanies();
        ddlCompanies.DataSource = dtCompanies.DefaultView;
        ddlCompanies.DataBind();
    }
    public void GetRegion()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtRegions = objBussLogic.GetRegions(commFunc.GetUsersCompanyID(Context));
        ddlRegion.DataSource = dtRegions.DefaultView;
        ddlRegion.DataBind();
    }
    protected void btnCreateArea_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        if (!string.IsNullOrEmpty(txtCreateArea.Text))
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            blnResult = objBusinessLogic.CreateArea(txtCreateArea.Text, Convert.ToInt32(ddlRegion.SelectedItem.Value));
            if (blnResult)
            {
                lblAreaStatus.Visible = true;
                lblAreaStatus.ForeColor = Color.Green;
                lblAreaStatus.Text = "Area created successfully.";
            }
            else
            {
                lblAreaStatus.Visible = true;
                lblAreaStatus.ForeColor = Color.Red;
                lblAreaStatus.Text = "Area creation failed. Please Contact Administrator.";
            }
        }
    }
    protected void btnCreateRegion_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        blnResult = objBussLogic.CreateRegions(txtRegion.Text, commFunc.GetUsersCompanyID(Context));
        if (blnResult)
        {
            lblRegionStatus.Visible = true;
            lblRegionStatus.ForeColor = Color.Green;
            lblRegionStatus.Text = "Region created successfully.";
        }
        else
        {
            lblRegionStatus.Visible = true;
            lblRegionStatus.ForeColor = Color.Red;
            lblRegionStatus.Text = "Region creation failed. Please Contact Administrator.";
        }
    }

    #region User Management
    /// <summary>
    /// Create Role in database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CreateRoleButton_Click(object sender, EventArgs e)
    {
        string newRoleName = RoleName.Text.Trim();
        if (newRoleName != "")
        {
            if (!Roles.RoleExists(newRoleName))
            {
                // Create the role
                Roles.CreateRole(newRoleName);

                // Refresh the RoleList Grid    
                DisplayRolesInGrid();
            }

            RoleName.Text = string.Empty;
        }


    }

    /// <summary>
    /// Display the roles in a grid
    /// </summary>
    private void DisplayRolesInGrid()
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        RoleList.DataSource = objBusinessLogic.GetRoleWithDescription();
        RoleList.DataBind();
    }

    /// <summary>
    /// On Grid view row deleting action 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the RoleNameLabel
        Label RoleNameLabel = RoleList.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;

        // Delete the role
        Roles.DeleteRole(RoleNameLabel.Text, false);

        // Rebind the data to the RoleList grid
        DisplayRolesInGrid();
    }

    /// <summary>
    /// Display all users in the system, get data from database and display on the screen with checkboxes.
    /// </summary>
    /// <returns></returns>
    private DataTable DisplayAllUsers()
    {
        DataTable dtUpdated = new DataTable();
        var context = new ApplicationDbContext();
        {
            //Create business layer object
            BusinessLogic objBussLogic = new BusinessLogic();
            //Create new datatable
            DataTable dtUsersWithRoles = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "UserName";
            dc.Unique = true;
            dtUpdated.Columns.Add(dc);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = dc;
            dtUpdated.PrimaryKey = PrimaryKeyColumns;

            //Adding roles as columns in the datatable
            dtUpdated.Columns.Add("CompanyAdmin");
            dtUpdated.Columns.Add("StoreAdmin");
            dtUpdated.Columns.Add("VUPAdmin");
            dtUpdated.Columns.Add("Guest");
            dtUpdated.AcceptChanges();
            CommonFunctions commFunc = new CommonFunctions();
            dtUsersWithRoles = objBussLogic.GetUserWithRole(commFunc.GetUsersCompanyID(Context));
            DataRow drNewRow = null;
            if (dtUsersWithRoles != null && dtUsersWithRoles.Rows.Count > 0)
            {
                foreach (DataRow drRow in dtUsersWithRoles.Rows)
                {
                    try
                    {
                        bool blnFlag = false;
                        DataRow[] drRowResults = dtUsersWithRoles.Select(string.Format("UserName = '{0}'", Convert.ToString(drRow[0])));
                        if (drRowResults != null && drRowResults.Count() > 0)
                        {
                            foreach (DataRow drRowResult in drRowResults)
                            {
                                if (!dtUpdated.Rows.Contains(drRowResult["UserName"]))
                                {
                                    blnFlag = false;
                                    drNewRow = dtUpdated.NewRow();
                                    drNewRow["UserName"] = drRowResult["UserName"];
                                }
                                switch (Convert.ToString(drRowResult["RoleName"]).ToUpperInvariant())
                                {
                                    case "COMPANY ADMIN":
                                        drNewRow["CompanyAdmin"] = "true";
                                        break;
                                    case "STORE ADMIN":
                                        drNewRow["StoreAdmin"] = "true";
                                        break;
                                    case "VUP ADMIN":
                                        drNewRow["VUPAdmin"] = "true";
                                        break;
                                    case "GUEST":
                                        drNewRow["Guest"] = "true";
                                        break;
                                }
                                if (!dtUpdated.Rows.Contains(drNewRow) && !blnFlag)
                                {
                                    blnFlag = true;
                                    dtUpdated.Rows.Add(drNewRow);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.ToLowerInvariant().Contains("This row already belongs to this table."))
                        {

                        }
                    }
                }
                dtUpdated.AcceptChanges();
            }
        }
        return dtUpdated;
    }

    /// <summary>
    /// Grid view row databound, to show the checkboxes with exact values fro database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            String strCompanyAdmin = row.Field<String>("CompanyAdmin");
            String strStoreAdmin = row.Field<String>("StoreAdmin");
            String strVUPAdmin = row.Field<String>("VUPAdmin");
            String strGuest = row.Field<String>("Guest");

            if (Convert.ToBoolean(strCompanyAdmin) == true)
            {
                CheckBox chkisdefault = (CheckBox)e.Row.FindControl("ChkCompanyAdmin");
                chkisdefault.Checked = true;
            }
            if (Convert.ToBoolean(strStoreAdmin) == true)
            {
                CheckBox chkisact = (CheckBox)e.Row.FindControl("ChkStoreAdmin");
                chkisact.Checked = true;
            }
            if (Convert.ToBoolean(strVUPAdmin) == true)
            {
                CheckBox chkVUPAdmin = (CheckBox)e.Row.FindControl("ChkVUPAdmin");
                chkVUPAdmin.Checked = true;
            }
            if (Convert.ToBoolean(strGuest) == true)
            {
                CheckBox chkGuest = (CheckBox)e.Row.FindControl("ChkGuest");
                chkGuest.Checked = true;
            }
        }
    }

    /// <summary>
    /// Functionality for Save button click on multiple checkboxes selected.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            string strUserName = gvRow.Cells[0].Text;
            if (((CheckBox)(gvRow.Cells[1].FindControl("ChkCompanyAdmin"))).Checked)
            {
                if (!Roles.IsUserInRole(strUserName, "Company Admin"))
                {
                    Roles.AddUserToRole(strUserName, "Company Admin");
                }
            }
            else
            {
                if (Roles.IsUserInRole(strUserName, "Company Admin"))
                {
                    Roles.RemoveUserFromRole(strUserName, "Company Admin");
                }
            }
            if (((CheckBox)(gvRow.Cells[2].FindControl("ChkStoreAdmin"))).Checked)
            {
                if (!Roles.IsUserInRole(strUserName, "Store Admin"))
                {
                    Roles.AddUserToRole(strUserName, "Store Admin");
                }
            }
            else
            {
                if (Roles.IsUserInRole(strUserName, "Store Admin"))
                {
                    Roles.RemoveUserFromRole(strUserName, "Store Admin");
                }
            }
            if (((CheckBox)(gvRow.Cells[3].FindControl("ChkVUPAdmin"))).Checked)
            {
                if (!Roles.IsUserInRole(strUserName, "VUP Admin"))
                {
                    Roles.AddUserToRole(strUserName, "VUP Admin");
                }
            }
            else
            {
                if (Roles.IsUserInRole(strUserName, "VUP Admin"))
                {
                    Roles.RemoveUserFromRole(strUserName, "VUP Admin");
                }
            }
            if (((CheckBox)(gvRow.Cells[4].FindControl("ChkGuest"))).Checked)
            {
                if (!Roles.IsUserInRole(strUserName, "Guest"))
                {
                    Roles.AddUserToRole(strUserName, "Guest");
                }
            }
            else
            {
                if (Roles.IsUserInRole(strUserName, "Guest"))
                {
                    Roles.RemoveUserFromRole(strUserName, "Guest");
                }
            }
        }
    }
    private void BindUsersToUserList()
    {
        // Get all of the user accounts 
        //var context = new ApplicationDbContext();
        //{
        //MembershipUserCollection users = Membership.GetAllUsers();            
        var users = Membership.GetAllUsers();
        if (users != null)
        {
            UserList.DataSource = users;
            UserList.DataTextField = null;
            UserList.DataValueField = null;
            UserList.DataBind();
        }
        //}
    }

    private void BindRolesToList()
    {
        // Get all of the roles 
        string[] roles = Roles.GetAllRoles();
        UsersRoleList.DataSource = roles;
        UsersRoleList.DataBind();

        ddlRoleList.DataSource = roles;
        ddlRoleList.DataBind();
    }

    private void CheckRolesForSelectedUser()
    {
        // Determine what roles the selected user belongs to 
        string selectedUserName = UserList.SelectedValue;
        string[] selectedUsersRoles = Roles.GetRolesForUser(selectedUserName);

        // Loop through the Repeater's Items and check or uncheck the checkbox as needed 

        foreach (RepeaterItem ri in UsersRoleList.Items)
        {
            // Programmatically reference the CheckBox 
            CheckBox RoleCheckBox = ri.FindControl("RoleCheckBox") as CheckBox;
            // See if RoleCheckBox.Text is in selectedUsersRoles 
            if (selectedUsersRoles.Contains<string>(RoleCheckBox.Text))
                RoleCheckBox.Checked = true;
            else
                RoleCheckBox.Checked = false;
        }
    }
    protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRolesForSelectedUser();
    }
    protected void RoleCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        // Reference the CheckBox that raised this event 
        CheckBox RoleCheckBox = sender as CheckBox;

        // Get the currently selected user and role 
        string selectedUserName = UserList.SelectedValue;

        string roleName = RoleCheckBox.Text;

        // Determine if we need to add or remove the user from this role 
        if (RoleCheckBox.Checked)
        {
            // Add the user to the role 
            Roles.AddUserToRole(selectedUserName, roleName);
            // Display a status message 
            ActionStatus.Text = string.Format("User {0} was added to role {1}.", selectedUserName, roleName);
        }
        else
        {
            // Remove the user from the role 
            Roles.RemoveUserFromRole(selectedUserName, roleName);
            // Display a status message 
            ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName);

        }
        // Refresh the "by role" interface 
        DisplayUsersBelongingToRole();
    }

    private void DisplayUsersBelongingToRole()
    {
        // Get the selected role 
        string selectedRoleName = ddlRoleList.SelectedValue;

        // Get the list of usernames that belong to the role 
        string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);

        // Bind the list of users to the GridView 
        RolesUserList.DataSource = usersBelongingToRole;
        RolesUserList.DataBind();
    }
    protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayUsersBelongingToRole();
    }
    protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the selected role 
        string selectedRoleName = ddlRoleList.SelectedValue;

        // Reference the UserNameLabel 
        Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;

        // Remove the user from the role 
        Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName);

        // Refresh the GridView 
        DisplayUsersBelongingToRole();
        CheckRolesForSelectedUser();

        // Display a status message 
        ActionStatus.Text = string.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName);
    }
    protected void AddUserToRoleButton_Click(object sender, EventArgs e)
    {
        // Get the selected role and username 

        string selectedRoleName = ddlRoleList.SelectedValue;
        string userNameToAddToRole = UserNameToAddToRole.Text;

        // Make sure that a value was entered 
        if (userNameToAddToRole.Trim().Length == 0)
        {
            ActionStatus.Text = "You must enter a username in the textbox.";
            return;
        }

        // Make sure that the user exists in the system 
        //var context = new ApplicationDbContext();
        var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //var userInfo = manager.Users.First(u => u.UserName == userNameToAddToRole);               
        var userInfo = manager.FindByName(userNameToAddToRole);
        //MembershipUser userInfo = Membership.GetUser(userNameToAddToRole);
        if (userInfo == null)
        {
            ActionStatus.Text = string.Format("The user {0} does not exist in the system.", userNameToAddToRole);

            return;
        }

        // Make sure that the user doesn't already belong to this role 
        if (Roles.IsUserInRole(userNameToAddToRole, selectedRoleName))
        {
            ActionStatus.Text = string.Format("User {0} already is a member of role {1}.", userNameToAddToRole, selectedRoleName);
            return;
        }

        // If we reach here, we need to add the user to the role 
        Roles.AddUserToRole(userNameToAddToRole, selectedRoleName);

        // Clear out the TextBox 
        UserNameToAddToRole.Text = string.Empty;

        // Refresh the GridView 
        DisplayUsersBelongingToRole();
        // Refresh the "by user" interface 
        CheckRolesForSelectedUser();

        // Display a status message 
        ActionStatus.Text = string.Format("User {0} was added to role {1}.", userNameToAddToRole, selectedRoleName);
    }

    protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
    {
        string trimmedUserName = RegisterUser.UserName.Trim();
        if (RegisterUser.UserName.Length != trimmedUserName.Length)
        {
            // Show the error message
            InvalidUserNameOrPasswordMessage.Text = "The username cannot contain leading or trailing spaces.";
            InvalidUserNameOrPasswordMessage.Visible = true;

            // Cancel the create user workflow
            e.Cancel = true;
        }
        else
        {
            // Username is valid, make sure that the password does not contain the username

            if (RegisterUser.Password.IndexOf(RegisterUser.UserName, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // Show the error message
                InvalidUserNameOrPasswordMessage.Text = "The username may not appear anywhere in the password.";
                InvalidUserNameOrPasswordMessage.Visible = true;
                // Cancel the create user workflow
                e.Cancel = true;
            }
        }
    }



    protected void BindCompany()
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        DataTable dt = objBusinessLogic.GetCompanies();
        DropDownList ddl = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("SelectCompany");
        ddl.DataTextField = "CompanyName";
        ddl.DataValueField = "CompanyID";
        ddl.DataSource = dt;
        ddl.DataBind();
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        TextBox txtUser = (TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
        DropDownList ddl = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("SelectCompany");

        MembershipUser user = Membership.GetUser(txtUser.Text);
        object userGUID = user.ProviderUserKey;

        int company = Convert.ToInt32(ddl.SelectedValue);

        BusinessLogic objBusinessLogic = new BusinessLogic();
        objBusinessLogic.UserCompanyAssociation(userGUID.ToString(), company);
    }
    #endregion

    protected void RoleList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string userName = Context.User.Identity.Name;
            if(!Roles.IsUserInRole(userName, "VUP Admin"))
            {
                Button btnDelete = (Button)e.Row.Cells[3].Controls[0];
                btnDelete.Visible = false;
            }
        }
    }
}