using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elmah;
using System.Data;
using RADBusinessLogicLayer;
using System.Web.Security;

public partial class Roles_RoleBasedAuthorization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] selectedUsersRoles = Roles.GetRolesForUser(User.Identity.Name);
        if(selectedUsersRoles != null)
        {
            foreach (string userRole in selectedUsersRoles)
            {
                if (userRole.ToLower().Equals("vup admin"))
                {
                    if (!IsPostBack)
                    {
                        BindCompany();
                    }
                    BindGrid();
                }
            }
        
        }
    }

    protected void BindCompany()
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        DataTable dt = objBusinessLogic.GetCompanies();
        ddlCompany.DataTextField = "CompanyName";
        ddlCompany.DataValueField = "CompanyID";
        ddlCompany.DataSource = dt;
        ddlCompany.DataBind();
    }

    protected void BindGrid()
    {
        int companyID = Convert.ToInt32(ddlCompany.SelectedValue);
        BusinessLogic objBusinessLogic = new BusinessLogic();
        DataTable dtUsers = objBusinessLogic.GetUserOfCompany(companyID);
        grdAllUserCompany.DataSource = dtUsers;
        grdAllUserCompany.DataBind();
        grdAllUserCompany.Visible = true;
    }
    protected void grdAllUserCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAllUserCompany.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}