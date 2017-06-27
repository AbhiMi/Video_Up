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
using Telerik.Web.UI;
using RADCommonServices;
using ClosedXML.Excel;

public partial class ImportExport : System.Web.UI.Page
{
    int companyID = 0;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (Request.QueryString["CompanyID"] != null)
        {
            companyID = Convert.ToInt32(Request.QueryString["CompanyID"].ToString());
            hdnCompnayID.Value = companyID.ToString();
        }
    }

    public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    string[] states = new[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = string.Empty;
        if (!IsPostBack)
        {
            PopulateData();
        }
    }
    private void PopulateData()
    {
        ddlState.DataSource = states.ToList();
        ddlState.DataBind();
        DataSet ds = new DataSet();
        ds = GetAreaRegionData();
        ddlArea.DataSource = ds.Tables[0];
        ddlArea.DataBind();
        ddlRegion.DataSource = ds.Tables[1];
        ddlRegion.DataBind();
    }

    private DataTable GetLocationData(int companyID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetLocationData", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(dt);
                }
            }
        }
        return dt;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand("SP_LocationDataInsert", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationName", txtLocation.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@State", ddlState.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Zipcode", Convert.ToInt32(txtZipCode.Text.ToString().Trim()));
                cmd.Parameters.AddWithValue("@RegionName", ddlRegion.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@AreaName", ddlArea.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@CreatedBy", Context.User.Identity.Name);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@CustomTags", txtCustomeTags.Text.Trim());
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        lblmsg.Text = "Record Saved successfully !";
        this.PopulateData();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtAddress.Text = txtLocation.Text = txtCustomeTags.Text = txtZipCode.Text = string.Empty;
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                lblmsg.Visible = false;
                string downloadPath = "C:\\Windows\\Temp\\"; //root + "\\Downloads\\";
                string fullpath = downloadPath + FileUpload1.FileName;
                if (FileUpload1.HasFile)
                {
                    FileUpload1.SaveAs(fullpath);
                }
                Excel.ExcelUtlity obj = new Excel.ExcelUtlity();
                //DataTable dt = obj.exceldata(path);
                DataTable dt = obj.exceldata(fullpath);
                if (File.Exists(fullpath))
                {
                    File.Delete(fullpath);
                }
                CommonFunctions commFunc = new CommonFunctions();
                int companyID = commFunc.GetUsersCompanyID(Context);
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertLocationsFromExcel"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblLocationType", dt);
                        cmd.Parameters.AddWithValue("@companyID", companyID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                File.Delete(downloadPath + FileUpload1.FileName);
                lblmsg.Text = "Data Imported Sucessfully.";
                PopulateData();
                ScriptManager.RegisterStartupScript(this, GetType(), "close", "CloseModal();", true);
            }
            else
            {
                lblmsg.Text = "Please select a file to import";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
            ExceptionLogging.SendExcepToDB(ex);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel(false);
            //lblmsg.Visible = false;
            //string root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //string downloadPath = root + "\\Downloads\\Locations.xls";

            //string path = ConfigurationManager.AppSettings["locationExportPath"].ToString();
            //RADCommonServices.CommonFunctions commFunc = new RADCommonServices.CommonFunctions();
            ////DataTable dt = GetLocationData(commFunc.GetUsersCompanyID(Context));
            ////Excel.ExcelUtlity obj = new Excel.ExcelUtlity();
            ////obj.WriteDataTableToExcel(dt, "Location Details", downloadPath, "Location Details");
            //lblmsg.Text = "Data Exported Sucessfully.";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
            ExceptionLogging.SendExcepToDB(ex);
        }
    }
    private void ExportToExcel(bool isTemplateDownload)
    {
        string root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string downloadPath = root + "\\Downloads\\Locations.xlsx";

        //string path = ConfigurationManager.AppSettings["locationExportPath"].ToString();

        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dt = objBussLogic.GetLocations(commFunc.GetUsersCompanyID(Context));
        //Excel.ExcelUtlity obj = new Excel.ExcelUtlity();
        //obj.WriteDataTableToExcel(dt, "Location Details", downloadPath, "Location Details");
        dt.Columns.RemoveAt(0);
        dt.AcceptChanges();

        using (XLWorkbook wb = new XLWorkbook())
        {

            wb.Worksheets.Add(dt, "Locations");

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Locations.xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        lblmsg.Text = "Data Exported Sucessfully.";
    }
    protected void lnkDownloadTemplate_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel(true);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
            ExceptionLogging.SendExcepToDB(ex);
        }

    }
}