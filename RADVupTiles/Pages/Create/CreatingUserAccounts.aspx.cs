using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Create_CreatingUserAccounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Context.User.Identity.Name;
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
}