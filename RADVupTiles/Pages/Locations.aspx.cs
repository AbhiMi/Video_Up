using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADBusinessLogicLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Drawing;
using RADCommonServices;
using Telerik;
using Telerik.Web.UI;

public partial class Pages_Locations : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    string[] states = new[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rgRegion.Rebind();
            rgArea.Rebind();
            rgLocation.Rebind();
        }
    }
    protected void RadWizard1_ActiveStepChanged(object sender, EventArgs e)
    {
        //int activeStepIndex = (sender as RadWizard).ActiveStep.Index;
    }

    private DataSet GetAreaRegionData()
    {
        DataSet dt = new DataSet();
        using (SqlConnection cn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand("select AreaName,AreaID from Area;select RegionName,RegionID from Regions", cn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(dt);
                }
            }
        }
        return dt;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        //ExportToExcel();
        //return;
        string root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string downloadPath = root + "\\Downloads\\Locations.xlsx";

        //string path = ConfigurationManager.AppSettings["locationExportPath"].ToString();

        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dt = objBussLogic.GetLocations(commFunc.GetUsersCompanyID(Context));
        Excel.ExcelUtlity obj = new Excel.ExcelUtlity();
        obj.WriteDataTableToExcel(dt, "Location Details", downloadPath, "Location Details");
        lblmsg.Text = "Data Exported Sucessfully.";

    }
    private void ExportToExcel()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dt = objBussLogic.GetLocations(commFunc.GetUsersCompanyID(Context));
        GridView gridview = new GridView();
        gridview.HeaderStyle.BackColor = ColorTranslator.FromHtml("#ef7c31");
        gridview.AlternatingRowStyle.BackColor = ColorTranslator.FromHtml("#F7F6F3");
        gridview.AlternatingRowStyle.ForeColor = ColorTranslator.FromHtml("#333333");

        gridview.DataSource = dt;
        gridview.DataBind();

        // Clear all the content from the current response
        Response.ClearContent();
        Response.Buffer = true;
        // set the header
        Response.AddHeader("content-disposition", "attachment;filename=Locations.xls");
        Response.ContentType = "application/ms-excel";
        Response.Charset = "";
        // create HtmlTextWriter object with StringWriter
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                // render the GridView to the HtmlTextWriter
                gridview.RenderControl(htw);
                // Output the GridView content saved into StringWriter
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
    protected void rgLocation_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dt = objBussLogic.GetLocations(commFunc.GetUsersCompanyID(Context));
        rgLocation.DataSource = dt;
    }


    protected void rgRegion_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic obj = new BusinessLogic();
        rgRegion.DataSource = obj.GetRegions(commFunc.GetUsersCompanyID(Context));
    }
    protected void rgRegion_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        //Get the GridEditableItem of the RadGrid      
        GridEditableItem editedItem = e.Item as GridEditableItem;
        //Get the primary key value using the DataKeyValue.      
        int RegionID = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["RegionID"]);
        //Access the textbox from the edit form template and store the values in string variables.    
        string RegionName = (editedItem["RegionName"].Controls[0] as TextBox).Text;
        try
        {
            BusinessLogic objBuss = new BusinessLogic();
            objBuss.UpdateRegion(RegionID, RegionName);
        }
        catch (Exception ex)
        {
            rgRegion.Controls.Add(new LiteralControl("Unable to update Region. Reason: " + ex.Message));
            e.Canceled = true;
        }
    }
    protected void btnEditArea_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in rgArea.SelectedItems)
        {
            string AreaID = item.GetDataKeyValue("AreaID").ToString(); // Works if you set the DataKeyValue as CustomerID             
            item.Edit = true;
            rgArea.MasterTableView.Rebind();
        }
    }
    protected void rgArea_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        //Get the GridEditableItem of the RadGrid      
        GridEditableItem editedItem = e.Item as GridEditableItem;
        //Get the primary key value using the DataKeyValue.      
        int AreaID = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["AreaID"]);
        //Access the textbox from the edit form template and store the values in string variables.   
        string AreaName = (editedItem["AreaName"].Controls[0] as TextBox).Text;
        try
        {
            BusinessLogic objBuss = new BusinessLogic();
            objBuss.UpdateArea(AreaID, AreaName);
        }
        catch (Exception ex)
        {
            rgArea.Controls.Add(new LiteralControl("Unable to update Area. Reason: " + ex.Message));
            e.Canceled = true;
        }
    }
    protected void btnDeleteArea_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in rgArea.SelectedItems)
        {
            //Get the primary key value using the DataKeyValue.       
            int AreaID = Convert.ToInt32(item.GetDataKeyValue("AreaID").ToString());
            try
            {
                BusinessLogic objBuss = new BusinessLogic();
                objBuss.DeleteArea(AreaID);
                rgArea.Rebind();
            }
            catch (Exception ex)
            {
                rgArea.Controls.Add(new LiteralControl("Unable to delete Region. Reason: " + ex.Message));
            }
        }
    }
    protected void rgArea_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic obj = new BusinessLogic();
        rgArea.DataSource = obj.GetAreas(commFunc.GetUsersCompanyID(Context));

    }
    protected void btnEditRegion_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in rgRegion.SelectedItems)
        {
            string RegionID = item.GetDataKeyValue("RegionID").ToString(); // Works if you set the DataKeyValue as CustomerID             
            item.Edit = true;
            rgRegion.MasterTableView.Rebind();
        }
    }
    protected void btnDeleteRegion_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in rgRegion.SelectedItems)
        {
            //Get the primary key value using the DataKeyValue.       
            int RegionID = Convert.ToInt32(item.GetDataKeyValue("RegionID").ToString());
            try
            {
                BusinessLogic objBuss = new BusinessLogic();
                objBuss.DeleteRegion(RegionID);
                rgRegion.Rebind();
            }
            catch (Exception ex)
            {
                rgRegion.Controls.Add(new LiteralControl("Unable to delete Region. Reason: " + ex.Message));
            }
        }
    }
}