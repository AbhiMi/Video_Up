using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ScheduleCampaign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions commFunc = new CommonFunctions();
        ddlChannel.DataSource = GetChannels(commFunc.GetUsersCompanyID(Context));
        ddlChannel.DataTextField = "ChannelName";
        ddlChannel.DataValueField = "ChannelID";
        ddlChannel.DataBind();
    }

    public DataTable GetChannels(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCampaigns = objBussLogic.GetChannels(CompanyID);
        return dtCampaigns;
    }

    protected void editButton_Click(object sender, EventArgs e)
    {
        #region Service Code
        //bool recordAdded = false;
        //string requestMethod = "SaveCampaignPlayOrder";
        //var serviceUrl = ConfigurationManager.AppSettings["SchedulerServiceUrl"];
        //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(serviceUrl + requestMethod));
        //httpWebRequest.ContentType = "text/json";
        //httpWebRequest.Method = "POST";        
        //try
        //{
        //    StringBuilder jsonString = new StringBuilder();
        //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //    {

        //        jsonString.Append(@"{"); jsonString.Append("\"");
        //        jsonString.Append("CampaignID"); jsonString.Append("\":\""); jsonString.Append(campaignddl.SelectedValue); jsonString.Append("\",\"");
        //        jsonString.Append("ChannelID"); jsonString.Append("\":\""); jsonString.Append("17"); jsonString.Append("\",\"");
        //        jsonString.Append("StartTime"); jsonString.Append("\":\""); jsonString.Append(hdndtpicker1.Value); jsonString.Append("\",\"");
        //        jsonString.Append("EndTime"); jsonString.Append("\":\""); jsonString.Append(hdndtpicker2.Value); jsonString.Append("\",\"");
        //        jsonString.Append("IsAllDay"); jsonString.Append("\":\""); jsonString.Append(chkBox.Checked); jsonString.Append("\",\"");
        //        jsonString.Append("CompanyID"); jsonString.Append("\":\""); jsonString.Append(GetUsersCompanyID()); jsonString.Append("\"}");
        //        streamWriter.Write(jsonString);
        //    }
        //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //    if (httpResponse.StatusCode == HttpStatusCode.OK)
        //    {
        //        recordAdded = true;
        //    }

        //}
        //catch (Exception ex)
        //{ }
        ////return recordAdded; 
        #endregion
        BusinessLogic objBusiness = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();

        DateTime srtDate = Convert.ToDateTime(RadDateTimePicker1.SelectedDate.ToString());
        DateTime endDate = Convert.ToDateTime(RadDateTimePicker2.SelectedDate.ToString());
        objBusiness.CreateCampaignForScheduler(Convert.ToInt32(hdnField.Value), Convert.ToInt32(ddlChannel.SelectedValue), commFunc.GetUsersCompanyID(Context), srtDate, endDate, chkBox.Checked);
        //objBusiness.CreateCampaignForScheduler(0, Convert.ToInt32(ddlChannel.SelectedValue), commFunc.GetUsersCompanyID(Context), srtDate, endDate, chkBox.Checked);
        lbl1.Text = "Campaign Scheduled created successfully.";
    }
    [System.Web.Services.WebMethod]
    public static bool CheckExistData(string channel, string date1, string date2)
    {
        BusinessLogic objBusiness = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DateTime srtDate = Convert.ToDateTime(date1);
        DateTime endDate = Convert.ToDateTime(date2);
        bool result = objBusiness.CheckExistCampaignForScheduler(0, Convert.ToInt32(channel), srtDate, endDate);
        return result;
    }
}