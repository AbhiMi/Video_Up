using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Configuration;

public partial class ServerStuff_ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void loginPasswordRecovery_SendingMail(object sender, MailMessageEventArgs e)
    {
        string yourEmail = "srikant@video-up.com";

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
        field.Value = yourEmail;

        field = fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"];
        field.Value = "sri789kant";

        field = fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"];
        field.Value = "true";

        fields.Update();

        message.From = yourEmail;
        message.To = yourEmail;
        message.Subject = "Password Reset";
        message.TextBody = e.Message.Body;

        // Send message.
        message.Send();
    }
}