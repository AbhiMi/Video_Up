using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if(recaptcha.IsValid)
        {
            try
            {
                MembershipCreateStatus createStatus;
                MembershipUser user = Membership.CreateUser(UserName.Text, Password.Text, Email.Text, txtQuestion.Text, txtAnswer.Text, true, out createStatus);
                switch (createStatus)
                {
                    //This Case Occured whenver User Created Successfully in database  
                    case MembershipCreateStatus.Success:
                        lblResult.ForeColor = Color.Green;
                        string strMessage = "The user account was created successfully. Do you wish to get redirected to the login page ?";
                        lblResult.Text = strMessage;
                        UserName.Text = string.Empty;
                        Email.Text = string.Empty;
                        txtQuestion.Text = string.Empty;
                        txtAnswer.Text = string.Empty;
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Popup", "<script>ConfirmApproval('" + strMessage + "');</script>");
                        break;
                    // This Case Occured whenver we send duplicate UserName  
                    case MembershipCreateStatus.DuplicateUserName:
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "The user with the same UserName already exists!";
                        break;
                    //This Case Occured whenver we give duplicate mail id  
                    case MembershipCreateStatus.DuplicateEmail:
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "The user with the same email address already exists!";
                        break;
                    //This Case Occured whenver we send invalid mail format  
                    case MembershipCreateStatus.InvalidEmail:
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "The email address you provided is invalid.";
                        break;
                    //This Case Occured whenver we send empty data or Invalid Data  
                    case MembershipCreateStatus.InvalidAnswer:
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "The security answer was invalid.";
                        break;
                    // This Case Occured whenver we supplied weak password  
                    case MembershipCreateStatus.InvalidPassword:
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "The password you provided is invalid. It must be 7 characters long and have at least 1 special character.";
                        break;
                    default:
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "There was an unknown error; the user account was NOT created.";
                        break;

                }
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            lblResult.Text = "The verification Code Is incorrect.";
            lblResult.ForeColor = Color.Red;
        }  
    }
}