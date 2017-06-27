using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

public partial class Pages_AddRegionArea : System.Web.UI.Page
{

    int companyID = 0;
    string regionName = string.Empty;
    public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        divArea.Visible = false;
        divRegion.Visible = false;
        if (Request.QueryString["CompanyID"] != null)
        {
            string values = Request.QueryString["CompanyID"].ToString();
            string[] splitValues = values.Split(',');
            hdnCompanyId.Value = splitValues[0];
            companyID = Convert.ToInt32(splitValues[0]);
            if (!string.IsNullOrEmpty(splitValues[1]))
            {
                regionName = splitValues[1];
                divArea.Visible = true;
            }
            else
                divRegion.Visible = true;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSaveArea_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand("SP_InsertAreaData", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AreaName", txtArea.Text);
                cmd.Parameters.AddWithValue("@RegionName", regionName);
                cmd.Parameters.AddWithValue("@IsDefault", chkIsDefaultArea.Checked);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        lblMsg.ForeColor = System.Drawing.Color.Green;
        lblMsg.Text = "Area Added Successfully !";
        //Thread.Sleep(1500);
        ScriptManager.RegisterStartupScript(this, GetType(), "close", "CloseModal();", true);
    }
    protected void btnsaveRegion_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand("[dbo].[SP_CreateRegions]", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegionName", txtRegionName.Text);
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                //cmd.Parameters.AddWithValue("@IsDefault", chkIsDefaultregion.Checked);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        lblMsg.Text = "Region Added Successfully !";
        lblMsg.ForeColor = System.Drawing.Color.Green;
        //Thread.Sleep(1500);
        ScriptManager.RegisterStartupScript(this, GetType(), "close", "CloseModal();", true);
    }
}