using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADCommonServices;
using System.Net;
using System.Net.Mail;

public partial class Droptiles : System.Web.UI.MasterPage
{
    protected MembershipUser UserProfile
    {
        get
        {
            return SecurityContextManager.GetUserProfile(Context);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            hdnIsAuthenticated.Value = "1";
            ScriptManager.RegisterStartupScript(this, GetType(), "hide", "hideLogin();", true);
            int companyID = 0;
            string userName = Membership.GetUserNameByEmail(Context.User.Identity.Name);
            BusinessLogic objBussLogic = new BusinessLogic();
            string userId = objBussLogic.GetUserId(Context.User.Identity.Name);
            if (userId != "0")
            {
                //lblUserName.Text = userName;
                Guid userGuid = Guid.Parse(userId);
                DataTable dtCompanies = objBussLogic.GetUserCompany(userGuid);
                if (dtCompanies != null && dtCompanies.Rows.Count > 0)
                {
                    companyID = Convert.ToInt32(dtCompanies.Rows[0]["CompanyID"].ToString());
                    lblCompanyName.Text = dtCompanies.Rows[0]["CompanyName"].ToString();                    
                }
                lblWelcome.Text = string.Concat("Hello ", userName);
            }
            else
            {
                lblWelcome.Text = "Hello Guest !";
            }
        }
        else
        {
            lblWelcome.Text = "Hello Guest !";
            hdnIsAuthenticated.Value = "0";
            //Response.Redirect(FormsAuthentication.LoginUrl, true);
        }      
        
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //this.Validate();

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
            string userName = Membership.GetUserNameByEmail(Context.User.Identity.Name);
            if (!string.IsNullOrEmpty(userName))
            {
                lblWelcome.Text = string.Concat("Hello ", userName);
                hdnIsAuthenticated.Value = "1";
            }
            else
            {
                lblWelcome.Text = string.Concat("Hello ", "Guest !");
            }
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
        //this.Validate();
        //if (!Page.IsValid)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showRegisterTogglePopup", "<script type='text/javascript'>showRegisterTogglePopup();</script>", false);
        //}
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        Sendemail();
    }
    public void Sendemail()
    {
        string strToEmail = txtEmail.Text;
        string fromEmail = "mail@video-up.com";
        CDO.Message message = new CDO.Message();
        CDO.IConfiguration configuration = message.Configuration;
        ADODB.Fields fields = configuration.Fields;

        ADODB.Field field = fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"];
        field.Value = "smtp.zoho.com";

        field = fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"];
        field.Value = 465;

        field = fields["http://schemas.microsoft.com/cdo/configuration/sendusing"];
        field.Value = CDO.CdoSendUsing.cdoSendUsingPort;

        field = fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"];
        field.Value = CDO.CdoProtocolsAuthentication.cdoBasic;

        field = fields["http://schemas.microsoft.com/cdo/configuration/sendusername"];
        field.Value = fromEmail;

        field = fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"];
        field.Value = "123mail123";

        field = fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"];
        field.Value = "true";

        fields.Update();

        message.From = fromEmail;
        message.To = strToEmail;
        message.Subject = "Schedule Demo";
        message.TextBody = "Name: " + txtName.Text + "<br/> Company:" + txtCompany.Text + "<br/> Company Site Url:" + txtCompanySiteUrl.Text + "<br/>Subject: " + ddlSubject.SelectedItem.Text + "<br/> Contact No. " + txtContactNo.Text + "<br/> Office Contact:" + txtOfficeExtn.Text + "<br />Email: " + txtEmail.Text; ;

        BusinessLogic objBusinessLogic = new BusinessLogic();
        bool blnResult = objBusinessLogic.AddNewScheduleDemoRequest(txtName.Text, txtCompany.Text, txtCompanySiteUrl.Text, ddlSubject.SelectedItem.Text, Convert.ToInt32(txtContactNo.Text), Convert.ToInt32(txtOfficeExtn.Text), txtEmail.Text);

        // Send message.
        message.Send();
    }
}
