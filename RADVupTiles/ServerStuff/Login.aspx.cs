using System;
using System.Web.Security;
using RADCommonServices;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Web.UI;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
             // initialize the Captcha validation error label
            //CaptchaErrorLabel.Text = "Incorrect CAPTCHA code !";
            //CaptchaErrorLabel.Visible = false;
        }

        // setup client-side input processing
        //captchaBox.UserInputID = CaptchaCode.ClientID;

        if (IsPostBack)
        {
            // validate the Captcha to check we're not dealing with a bot
            //string userInput = CaptchaCode.Text;
            //bool isHuman = captchaBox.Validate(userInput);
            //CaptchaCode.Text = null; // clear previous user input

            //if (isHuman)
            //{
            //    CaptchaErrorLabel.Visible = false;
            //    // TODO: proceed with protected action
            //}
            //else
            //{
            //    CaptchaErrorLabel.Visible = true;
            //}
        }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        this.Validate();
        
            //string userInput = CaptchaCode.Text;
            // Validate the user against the Membership framework user store
            
        string a = Membership.GetUserNameByEmail(txtUserName.Text);
            //bool isCaptchaValid = captchaBox.Validate(userInput);
            //CaptchaCode.Text = null;
            //if (!isCaptchaValid)
            //{

            //}
        if (Membership.ValidateUser(a, txtPassword.Text))
        {

            // Log the user into the site
            //  FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);
            FormsAuthentication.SetAuthCookie(txtUserName.Text, true);
            CommonFunctions commFunc = new CommonFunctions();
            int strCompanyID = commFunc.GetUsersCompanyID(Context);
            if (!string.IsNullOrEmpty(strCompanyID.ToString()))
            {
                Response.Redirect("~/Pages/MissionControl.aspx");
            }
        }
        else
        {
            //lblError.Visible = true; 
            // If we reach here, the user's credentials were invalid
            //MessagePanel.Visible = true;
            //Message.Visible = true;
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        this.Validate();
        if (!Page.IsValid)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showRegisterTogglePopup", "<script type='text/javascript'>showRegisterTogglePopup();</script>", false);
        }
    }
}