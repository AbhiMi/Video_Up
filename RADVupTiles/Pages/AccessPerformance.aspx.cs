using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using RADBusinessLogicLayer;
using Telerik.Web.UI;
using RADCommonServices;
using System.Collections.Generic;
using Telerik.Charting;

public partial class Pages_AccessPerformance : System.Web.UI.Page
{
    public int campaignID
    {
        get
        {
            if (ViewState["campaignID"] == null)
            {
                return 0;
            }
            return (int)ViewState["campaignID"];
        }
        set
        {
            ViewState["campaignID"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var relativePath = "~/api/export/file";

        RadClientExportManager1.PdfSettings.ProxyURL = ResolveUrl(relativePath);
        RadClientExportManager1.PdfSettings.Author = "Telerik ASP.NET AJAX";
    }

    public DataTable GetCampaignData()
    {
        DataTable dtCampaign = new DataTable();
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic objBL = new BusinessLogic();

        return dtCampaign = objBL.GetCampaignViewReport(commFunc.GetUsersCompanyID(Context), RadDateTimePicker1.SelectedDate.Value, RadDateTimePicker2.SelectedDate.Value);        

    }

    public DataTable GetLineCampaignData()
    {
        DataTable dtCampaign = new DataTable();
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic objBL = new BusinessLogic();

        return dtCampaign = objBL.GetLineCampaignViewReport(commFunc.GetUsersCompanyID(Context), RadDateTimePicker1.SelectedDate.Value, RadDateTimePicker2.SelectedDate.Value);

    }

    public DataTable GetScatterCampaignData()
    {
        DataTable dtCampaign = new DataTable();
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic objBL = new BusinessLogic();

        return dtCampaign = objBL.GetScatterCampaignViewReport(commFunc.GetUsersCompanyID(Context), RadDateTimePicker1.SelectedDate.Value, RadDateTimePicker2.SelectedDate.Value);

    }

    public DataTable GetPlaylistData(int campaignId)
    {
        DataTable dtPlayList = new DataTable();
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic objBL = new BusinessLogic();

        dtPlayList = objBL.GetPlaylistViewReport(commFunc.GetUsersCompanyID(Context), campaignId, RadDateTimePicker1.SelectedDate.Value, RadDateTimePicker2.SelectedDate.Value);
        return dtPlayList;

    }

    public DataTable GetVideoData(int playlistId)
    {
        DataTable dtVideo = new DataTable();
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic objBL = new BusinessLogic();

        dtVideo = objBL.GetVideoViewReport(commFunc.GetUsersCompanyID(Context), playlistId, RadDateTimePicker1.SelectedDate.Value, RadDateTimePicker2.SelectedDate.Value);
        return dtVideo;

    }

    //public DataTable GetRegionData()
    //{ 
    //    DataTable dtRegion = new DataTable();
    //    CommonFunctions commFunc = new CommonFunctions();
    //    BusinessLogic objBL = new BusinessLogic();        
    //    return dtRegion = objBL.GetRegionReport(commFunc.GetUsersCompanyID(Context), RadDateTimePicker1.SelectedDate.Value, RadDateTimePicker2.SelectedDate.Value);
    //} 

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        CommonFunctions commFunc = new CommonFunctions();
        e.Command.Parameters["@CompanyID"].Value = commFunc.GetUsersCompanyID(Context);
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (ddlReportType.SelectedValue == "1")
        {
            chartPie.Visible = false;
            chartBar.Visible = true;
            chartLine.Visible = false;
            chartScatter.Visible = false;
        }
        if (ddlReportType.SelectedValue == "2")
        {
            chartPie.Visible = true;
            chartBar.Visible = false;
            chartLine.Visible = false;
            chartScatter.Visible = false;
        }
        if (ddlReportType.SelectedValue == "3")
        {
            chartPie.Visible = false;
            chartBar.Visible = false;
            chartScatter.Visible = false;
            chartLine.Visible = true;
        }
        if (ddlReportType.SelectedValue == "4")
        {
            chartPie.Visible = false;
            chartBar.Visible = false;
            chartLine.Visible = false;
            chartScatter.Visible = true;
        }
        RadHtmlChart1.DataSource = GetCampaignData();
        RadHtmlChart1.DataBind();
        //DateTime date = Convert.ToDateTime(RadDateTimePicker1.SelectedDate);
        //DateTime date1 = Convert.ToDateTime(RadDateTimePicker2.SelectedDate);
        string temp = String.Format("{0:m}", RadDateTimePicker1.SelectedDate);
        string temp1 = String.Format("{0:m}", RadDateTimePicker2.SelectedDate);
        RadHtmlChart1.ChartTitle.Text = "Campaign View from " + temp + " to " + temp1;
        List<Campaign> campaigns = new List<Campaign>();
        DataTable dtTable = GetCampaignData();
        foreach (DataRow row in dtTable.Rows)
        {
            campaigns.Add(new Campaign
            {
                Name = row["CampaignName"].ToString(),
                Views = Convert.ToDouble(row["CampaignViews"]),
                IsExploded = true
            });
        }
        RadHtmlChart2.DataSource = campaigns;
        RadHtmlChart2.DataBind();
        RadHtmlChart2.ChartTitle.Text = "Campaign View from " + temp + " to " + temp1;

        RadHtmlChart4.DataSource = GetLineCampaignData();
        RadHtmlChart4.DataBind();
        RadHtmlChart4.ChartTitle.Text = "Campaign View from " + temp + " to " + temp1;
        RadHtmlChart4.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;        


        dynamic ls = null;
        DataRow[] result = null;
        RadHtmlChart3.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Right;
        RadHtmlChart3.ChartTitle.Text = "Campaign View from " + temp + " to " + temp1;
        RadHtmlChart3.PlotArea.XAxis.BaseUnitStep = 6;
        RadHtmlChart3.PlotArea.XAxis.Items.Clear();        
        DataTable dt = GetLineCampaignData();
        DataTable dtCampaign = GetLineCampaignData();
        foreach (DataRow dr in dtCampaign.Rows)
        {
            //dt.DefaultView.Sort = "Start ASC";
            result = dt.Select(string.Format("CampaignName ='{0}'", dr["CampaignName"].ToString()));

            if (result != null)
            {
                ls = new LineSeries();                
                foreach (DataRow row in result)
                {
                    //SeriesItem cs = new SeriesItem(Convert.ToDecimal(row["Start"].ToString()), Convert.ToDecimal(row["CampaignViews"].ToString()));
                    CategorySeriesItem cs = new CategorySeriesItem();
                    cs.Y = Convert.ToDecimal(row["CampaignViews"].ToString());
                    ls.SeriesItems.Add(cs);                    
                }                
                RadHtmlChart3.PlotArea.Series.Add(ls);
            }
            AxisItem axisItem = new AxisItem(Convert.ToDateTime(dr["Start"]).ToString("M"));
            RadHtmlChart3.PlotArea.XAxis.Items.Add(axisItem);
            RadHtmlChart3.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
        }

    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        string seriesName = RadHtmlChart1.PlotArea.Series[0].Name;
        BusinessLogic objBL = new BusinessLogic();
        if (seriesName == "Campaigns")
        {
            campaignID = objBL.GetCampaignID(e.Argument);
            RadHtmlChart1.PlotArea.XAxis.DataLabelsField = "PlayListName";
            RadHtmlChart1.PlotArea.Series[0].DataFieldY = "Views";
            RadHtmlChart1.PlotArea.Series[0].Name = "PlayList";
            RadHtmlChart1.DataSource = GetPlaylistData(campaignID);
            RadHtmlChart1.DataBind();

            RadHtmlChart3.PlotArea.XAxis.DataLabelsField = "PlayListName";
            RadHtmlChart3.PlotArea.Series[0].DataFieldY = "Views";
            RadHtmlChart3.PlotArea.Series[0].Name = "PlayList";
            RadHtmlChart3.DataSource = GetPlaylistData(campaignID);
            RadHtmlChart3.DataBind();


            RadHtmlChart2.PlotArea.XAxis.DataLabelsField = "PlayListName";
            RadHtmlChart2.PlotArea.Series[0].DataFieldY = "Views";
            RadHtmlChart2.PlotArea.Series[0].Name = "PlayList";
            //RadHtmlChart2.PlotArea.Series[0].Appearance.L
            RadHtmlChart2.PlotArea.CommonTooltipsAppearance.DataFormatString = "PlayList"; 
            RadHtmlChart2.DataSource = GetPlaylistData(campaignID);
            RadHtmlChart2.DataBind();
        }
        else
        {
            if (seriesName == "PlayList")
            {
                int playlistId = objBL.GetPlaylistID(e.Argument);
                RadHtmlChart1.PlotArea.XAxis.DataLabelsField = "Videos";
                RadHtmlChart1.PlotArea.Series[0].DataFieldY = "Views";
                RadHtmlChart1.PlotArea.Series[0].Name = "Videos";
                RadHtmlChart1.DataSource = GetVideoData(playlistId);
                RadHtmlChart1.DataBind();

                RadHtmlChart3.PlotArea.XAxis.DataLabelsField = "Videos";
                RadHtmlChart3.PlotArea.Series[0].DataFieldY = "Views";
                RadHtmlChart3.PlotArea.Series[0].Name = "Videos";
                RadHtmlChart3.DataSource = GetVideoData(playlistId);
                RadHtmlChart3.DataBind();

                RadHtmlChart2.PlotArea.XAxis.DataLabelsField = "Videos";
                RadHtmlChart2.PlotArea.Series[0].DataFieldY = "Views";
                RadHtmlChart2.PlotArea.Series[0].Name = "Videos";
                RadHtmlChart2.DataSource = GetVideoData(playlistId);
                RadHtmlChart2.DataBind();
            }
        }
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            TimeSpan myTS = TimeSpan.Parse(item["Durata"].Text);
            item["Durata"].Text = String.Format("{0}h {1}m {2}s", myTS.Hours, myTS.Minutes, myTS.Seconds);
        }
    }
}

public class Campaign
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    private double _views;
    public double Views
    {
        get { return _views; }
        set { _views = value; }
    }
    private bool _isExploded;
    public bool IsExploded
    {
        get { return _isExploded; }
        set { _isExploded = value; }
    }
}