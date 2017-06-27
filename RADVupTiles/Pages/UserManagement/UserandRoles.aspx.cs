using RADBusinessLogicLayer;
using RADCommonServices;
using RADVupTiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_UserManagement_UserandRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserList.Rebind();
        }
    }

    protected void RoleList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            BusinessLogic objBuss = new BusinessLogic();
            RoleList.DataSource = objBuss.GetRoles("Video-Up"); //Roles.GetAllRoles();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void UserList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        BusinessLogic objBuss = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        UserList.DataSource = objBuss.GetUserStatus(commFunc.GetUsersCompanyID(Context));
        //UserList.DataSource = objBuss.GetUserStatus(42); 
    }

    protected void btnUserDelete_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in UserList.SelectedItems)
        {
            //Get the primary key value using the DataKeyValue.       
            string UserName = item.GetDataKeyValue("UserName").ToString();
            try
            {
                Membership.DeleteUser(UserName);
            }
            catch (Exception ex)
            {
                UserList.Controls.Add(new LiteralControl("Unable to delete. Reason: " + ex.Message));
                //e.Canceled = true;
            }
        }
    }

    protected void btnUserEdit_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in UserList.SelectedItems)
        {
            string userID = item.GetDataKeyValue("UserId").ToString(); // Works if you set the DataKeyValue as CustomerID             
            item.Edit = true;
            UserList.MasterTableView.Rebind();
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in RoleList.SelectedItems)
        {
            string roleName = item.GetDataKeyValue("RoleName").ToString(); // Works if you set the DataKeyValue as CustomerID             
            item.Edit = true;
            RoleList.MasterTableView.Rebind();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in RoleList.SelectedItems)
        {
            //Get the primary key value using the DataKeyValue.       
            //string RoleName = item.("RoleName").ToString();
            string RoleName = (item.FindControl("lblRole") as Label).Text;
            try
            {
                Roles.DeleteRole(RoleName);
                RoleList.MasterTableView.Rebind();
            }
            catch (Exception ex)
            {
                RoleList.Controls.Add(new LiteralControl("Unable to delete. Reason: " + ex.Message));
                //e.Canceled = true;
            }
        }
    }

    protected void RoleList_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        BusinessLogic objBuss = new BusinessLogic();
        DataTable _dt = new DataTable("RoleActions");
        _dt.Columns.Add("RoleId", typeof(Guid));
        _dt.Columns.Add("ActionId", typeof(string));
        //string oldValue = (string)Session["SavedOldValue"];
        //Get the GridEditableItem of the RadGrid      
        GridEditableItem editedItem = e.Item as GridEditableItem;
        Hashtable dictionary = new Hashtable();
        //editedItem.SavedOldValues.Items[0]
        dictionary = (Hashtable)editedItem.SavedOldValues;
        //string oldValue = dictionary.
        //Get the primary key value using the DataKeyValue.
        //Access the textbox from the edit form template and store the values in string variables.
        string oldRoleName = dictionary["RoleName"].ToString();
        TableCell cell = editedItem["RoleId"];
        string id = (cell.Controls[0] as TextBox).Text;
        Guid RoleId = Guid.Parse(id);
        string RoleName = (editedItem.FindControl("TextBox1") as TextBox).Text;
        RadListBox radList = (editedItem.FindControl("radList1") as RadListBox);
        foreach (RadListBoxItem item in radList.SelectedItems)
        {
            int actionId = objBuss.GetActionId(item.Text);
            _dt.Rows.Add(RoleId, actionId);
        }
        try
        {
            objBuss.UpdateRole("Video-Up", RoleName, oldRoleName);
            objBuss.ManageRoleActions(_dt, RoleId);
        }
        catch (Exception ex)
        {
            RoleList.Controls.Add(new LiteralControl("Unable to update Role. Reason: " + ex.Message));
            e.Canceled = true;
        }
    }

    protected void UserList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            //Get the instance of the right type
            GridDataItem dataBoundItem = e.Item as GridDataItem;
            Label lbtn = (Label)dataBoundItem.FindControl("lblUserStatus");
            if (lbtn.Text == "Disabled")
            {
                lbtn.ForeColor = System.Drawing.Color.Red;
                //e.Item.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            }
        }
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            GridEditableItem edititem = (GridEditableItem)e.Item;
            HiddenField hdnval = (HiddenField)edititem.FindControl("hdnUserRole");
            DropDownList DropDownList1 = (DropDownList)edititem.FindControl("ddlUserStatus");
            DropDownList DropDownList2 = (DropDownList)edititem.FindControl("ddlUserRole");

            DataRowView dr = edititem.DataItem as DataRowView;
            DropDownList1.DataSource = GetTable();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Name";
            DropDownList1.DataBind();
            DropDownList1.SelectedValue = dr[4].ToString();

            string userName = Membership.GetUserNameByEmail(Context.User.Identity.Name);
            BusinessLogic objBuss = new BusinessLogic();
            DataTable dtRoles = objBuss.GetRoles("Video-Up");
            if (!Roles.IsUserInRole(userName, "VUP Admin"))
            {
                foreach(DataRow drRole in dtRoles.Rows)
                {
                    if(drRole["RoleName"].ToString() == "VUP Admin")
                    {
                        drRole.Delete();
                    }
                }
            }                
            DropDownList2.DataSource = dtRoles;
            DropDownList2.DataTextField = "RoleName";
            DropDownList2.DataValueField = "RoleName";                        
            DropDownList2.DataBind();
            DropDownList2.SelectedValue = dr["RoleName"].ToString();            
        }
    }

    protected void UserList_UpdateCommand(object sender, GridCommandEventArgs e)
    {        
        BusinessLogic objBuss = new BusinessLogic();
        GridEditableItem editedItem = e.Item as GridEditableItem;
        DropDownList DropDownList1 = editedItem.FindControl("ddlUserStatus") as DropDownList;
        string ddlVal = DropDownList1.SelectedItem.Value;
        DropDownList DropDownList2 = editedItem.FindControl("ddlUserRole") as DropDownList;
        string ddlRole = DropDownList2.SelectedItem.Value;
        DataTable dtRoles = objBuss.GetRoles("Video-Up");
        bool b = false;
        if(ddlVal == "Disabled")
        {
            b = true;
        }
        // The trick is here...
        var roles = from p in dtRoles.AsEnumerable()
                     where p.Field<string>("RoleName") == ddlRole
                    select new
                     {
                         ID = p.Field<Guid>("RoleId"),
                         Title = p.Field<string>("RoleName")
                     };

        string userId = editedItem.GetDataKeyValue("UserId").ToString();
        try
        {
            foreach (var role in roles)
            {
                objBuss.UpdateUserStatus(userId, b, Convert.ToString(role.ID));
            }
        }
        catch (Exception ex)
        {
            UserList.Controls.Add(new LiteralControl("Unable to update User. Reason: " + ex.Message));
            e.Canceled = true;
        }
    }

    protected void RoleList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        BusinessLogic objBusiness = new BusinessLogic();
        string actions = string.Empty;
        if (e.Item is GridDataItem)
        {
            GridDataItem data = (GridDataItem)e.Item;
            string RoleName = (data.FindControl("lblRole") as Label).Text;
            Label labeltemplate = (Label)data.FindControl("lblActions"); //Access the label in the template column in view mode
            DataTable dt = objBusiness.GetRoleAction(RoleName); // query to get the "name" column from datasource
            foreach (DataRow dr in dt.Rows)
            {
                actions += " " + dr["ActionName"].ToString() + ",";
            }
            labeltemplate.Text = actions.TrimEnd(','); //set it to label text
        }
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            GridEditableItem edititem = (GridEditableItem)e.Item;
            RadListBox listBox = (RadListBox)edititem.FindControl("radList1");
            string RoleName = edititem.GetDataKeyValue("RoleName").ToString();
            DataTable dtSelected = objBusiness.GetRoleAction(RoleName);
            DataTable dt = objBusiness.GetAllAction();
            foreach (DataRow dr in dt.Rows)
            {
                listBox.Items.Add(dr["ActionName"].ToString());
            }
            foreach (DataRow drSelected in dtSelected.Rows)
            {
                listBox.SelectedValue = drSelected["ActionName"].ToString();
            }
        }
    }

   public DataTable GetTable()
    {
        // Here we create a DataTable with four columns.
        DataTable table = new DataTable();
        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));

        // Here we add five DataRows.
        table.Rows.Add(0, "Enabled");
        table.Rows.Add(1, "Disabled");
        return table;
    }

}