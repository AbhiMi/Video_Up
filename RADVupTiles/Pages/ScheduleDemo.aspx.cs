using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class Pages_ScheduleDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        //MailMessage mm = new MailMessage("mail@video-up.com", txtEmail.Text);
        //mm.Subject = ddlSubject.SelectedItem.Text;
        //mm.Body = "Name: " + txtName.Text + "<br/> Company:" +txtCompany.Text +"<br/>Subject: "+ ddlSubject.SelectedItem.Text +"<br/> Contact No. " + txtContactNo.Text +"<br />Email: " + txtEmail.Text;
        //mm.CC.Add(new MailAddress(txtEmail.Text));
        //mm.IsBodyHtml = true;
        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "smtp.zoho.com";
        //smtp.EnableSsl = true;
        //System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
        //NetworkCred.UserName = "mail@video-up.com";
        //NetworkCred.Password = "123mail123";
        //smtp.UseDefaultCredentials = true;
        //smtp.Credentials = NetworkCred;
        //smtp.Port = 25;
        //smtp.Send(mm);
        //lblMessage.Text = "Email Sent SucessFully.";
        Sendemail();
    }

    public void Sendemail()
    {
        string yourEmail = "abhishek@video-up.com";
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
        message.To = yourEmail;
        message.Subject = "Password Changed";
        message.TextBody = "Name: " + txtName.Text + "<br/> Company:" + txtCompany.Text + "<br/> Company Site Url:" + txtCompanySiteUrl.Text + "<br/>Subject: " + ddlSubject.SelectedItem.Text + "<br/> Contact No. " + txtContactNo.Text +"<br/> Office Contact:" + txtOfficeExtn.Text + "<br />Email: " + txtEmail.Text; ;

        // Send message.
        message.Send();
    }
}