using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

public partial class Pages_RADdeviceDialog : System.Web.UI.Page
{
    int storedID = 0;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (Request.QueryString["StoreID"] != null)
        {
            storedID = Convert.ToInt32(Request.QueryString["StoreID"].ToString());
        }
        this.Page.Title = "Add RAD Licence";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        BindRADData();
    }

    private void BindRADData()
    {
        DataTable dt = GetRADDiviceDetails(storedID);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private DataTable GetRADDiviceDetails(int StoreId)
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                objCon.Open();
                string CommandText = "select S.StoreID,R.RADDeviceID, R.DeviceInfo,R.[Description],r.RADDeviceType,'' as RADLicence from RADDevice R inner join Store S on S.StoreID = R.StoreID WHERE S.StoreID = " + StoreId;
                using (SqlCommand objCmd = new SqlCommand(CommandText, objCon))
                {
                    objCmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(objCmd))
                    {
                        ad.Fill(dt);
                    }
                }
            }
        }
        catch
        {
            throw;
        }
        return dt;
    }

    protected void btnAddRadLicence_click(object sender, EventArgs e)
    {
        if (checkRadDeviceCount())
        {
            InsertRadDeviceInfo();
            Clear();
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Threshold Reached RAD License Count,Please Contact admin";
        }

    }

    private bool InsertRadDeviceInfo()
    {
        bool result = false;
        try
        {
            using (SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                objCon.Open();
                using (SqlCommand objCmd = new SqlCommand("SP_InsertRADDevices", objCon))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@DeviceInfo", txtDeviceInfo.Text.Trim());
                    objCmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    objCmd.Parameters.AddWithValue("@RadDeviceType", txtRadDeviceType.Text.Trim());
                    objCmd.Parameters.AddWithValue("@StoreID", storedID);
                    result = Convert.ToBoolean(objCmd.ExecuteNonQuery());
                    if (result)
                    {
                        lblmsg.ForeColor = Color.Green;
                        lblmsg.Text = "Data Inserted Sucessfully";
                        BindRADData();
                    }
                }
            }
        }
        catch
        {
            throw;
        }
        return result;
    }

    private void Clear()
    {
        txtDescription.Text = txtDeviceInfo.Text = txtRadDeviceType.Text = string.Empty;
    }

    private bool checkRadDeviceCount()
    {
        bool result = false;
        try
        {
            using (SqlConnection objCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                objCon.Open();
                using (SqlCommand objCmd = new SqlCommand("SP_CheckRadDeviceCount", objCon))
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@StoreID", storedID);
                    result = Convert.ToBoolean(objCmd.ExecuteScalar());
                }
            }
        }
        catch
        {
            throw;
        }
        return result;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
