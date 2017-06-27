using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADCommonServices;
using RADBusinessLogicLayer;

public partial class Pages_AddNewLocation : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    string[] states = new[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
    CommonFunctions commFunc = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlArea.Items.Add(new ListItem("-Please Select-", "0"));
            ddlArea.DataSource = GetAreas(commFunc.GetUsersCompanyID(Context));
            ddlArea.DataBind();

            ddlRegion.DataSource = GetRegions(commFunc.GetUsersCompanyID(Context));
            ddlRegion.DataBind();

            ddlState.DataSource = states;
            ddlState.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessLogic objBussLogic = new BusinessLogic();
            CommonFunctions commFunc = new CommonFunctions();
            int region = 0;
            int area = 0;
            if(ddlRegion != null && ddlRegion.Items.Count > 0)
            {
                region = Convert.ToInt32(ddlRegion.SelectedItem.Value);
            }
            if(ddlArea != null && ddlArea.Items.Count > 0)
            {
                area = Convert.ToInt32(ddlArea.SelectedItem.Value);
            }
            bool result = objBussLogic.AddNewLocation(txtLocation.Text, txtAddress.Text, ddlCountry.SelectedItem.Text, ddlState.SelectedItem.Text, Convert.ToInt32(txtZipCode.Text), region, area, txtCustomeTags.Text, Context.User.Identity.Name, commFunc.GetUsersCompanyID(Context));
            if(result)
            {
                lblMessage.Text = "New Location added successfully !";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Failed to add new location.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtLocation.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtZipCode.Text = string.Empty;
        txtCustomeTags.Text = string.Empty;
        ddlArea.SelectedIndex = -1;
        ddlCountry.SelectedIndex = -1;
        ddlRegion.SelectedIndex = -1;
        ddlState.SelectedIndex = -1;
    }
    private DataTable GetAreas(int companyID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand(string.Format("select AreaName,AreaID from Area WHERE CompanyID = {0}",companyID), cn))
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
    private DataTable GetRegions(int companyID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand(string.Format("select RegionName,RegionID from Regions WHERE CompanyID = {0}",companyID), cn))
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
}