using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using RADCommandSuite;
using RADBusinessLogicLayer;
using System.Data;
using System.Web.Security;

public partial class Account_Register : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCompany();
        }
    }
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        int company = Convert.ToInt32(SelectCompany.SelectedValue);
        if (result.Succeeded)
        {

            UserCompanyAssociation(user.Id, company);
            // Add the user to the role 
            Roles.AddUserToRole(user.UserName, "Company Admin");

            ActionStatus.Text = string.Format("User : {0} was added to company : {1}.", user.UserName, SelectCompany.SelectedItem.ToString());
            //IdentityHelper.SignIn(manager, user, isPersistent: false);
            //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }


    protected void BindCompany()
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        DataTable dt = objBusinessLogic.GetCompanies();
        SelectCompany.DataTextField = "CompanyName";
        SelectCompany.DataValueField = "CompanyID";
        SelectCompany.DataSource = dt;
        SelectCompany.DataBind();
    }

    protected bool UserCompanyAssociation(string userId, int companyId)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        bool isAdded = objBusinessLogic.UserCompanyAssociation(userId, companyId);

        return isAdded;
    }
}