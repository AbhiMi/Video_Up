using RADBusinessLogicLayer;
using RADCommonServices;
using RADVupTiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Pages_UserManagement_ManageUserPermissions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check page post back and bind the grid
        if (!IsPostBack)
        {
            DataTable dtUserWithRoles = DisplayAllUsers();
            GridView1.DataSource = dtUserWithRoles.DefaultView;
            GridView1.DataBind();
        }
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
}