using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_UserManagement_ManageRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check page postback
        if (!Page.IsPostBack)
            DisplayRolesInGrid();
    }

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
        RoleList.DataSource = Roles.GetAllRoles();
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
}