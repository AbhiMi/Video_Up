using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssociationViews_RADDeviceChannelAssociation : System.Web.UI.Page
{
    List<int> radDevice = new List<int>();
    List<int> channel = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRADDeviceData();
            LoadChannelData();
        }
        LoadAssociationGrid();
    }

    private void LoadChannelData()
    {
        DataTable dt = GetChannels(GetUsersCompanyID());
        if (dt != null)
        {
            grdChannel.DataSource = dt;
            grdChannel.DataBind();
        }
    }

    private void LoadRADDeviceData()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtRADDevices = objBussLogic.GetRADDevices(GetUsersCompanyID());
        if (dtRADDevices != null)
        {
            grdRADDevice.DataSource = dtRADDevices;
            grdRADDevice.DataBind();
        }
    }

    public DataTable GetChannels(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtChannels = objBussLogic.GetChannels(GetUsersCompanyID());
        return dtChannels;
    }
    public int GetUsersCompanyID()
    {
        int companyID = 0;
        string userName = Context.User.Identity.Name;
        BusinessLogic objBussLogic = new BusinessLogic();
        string userId = objBussLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            DataTable dtCompanies = objBussLogic.GetUserCompany(userId);
            if (dtCompanies != null && dtCompanies.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCompanies.Rows)
                {
                    companyID = Convert.ToInt32(dr["CompanyID"]);
                }
            }
        }
        return companyID;
    }
    public DataTable GetCampaigns(int CompanyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        return dtMediaFiles;
    }
    protected void btnAssociateChannel_Click(object sender, EventArgs e)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        foreach (GridViewRow row in grdRADDevice.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (row.FindControl("cbSelectRADDevice")) as CheckBox;
                if (chk != null && chk.Checked)
                {
                    radDevice.Add(Convert.ToInt32(row.Cells[1].Text));
                }
            }
        }

        foreach (GridViewRow row in grdChannel.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (row.FindControl("cbSelectChannel")) as CheckBox;
                if (chk != null && chk.Checked)
                {
                    channel.Add(Convert.ToInt32(row.Cells[1].Text));
                }
            }
        }

        if (radDevice != null && radDevice.Count > 0)
        {
            if (channel != null && channel.Count > 0)
            {
                bool blnResult = false;
                foreach (int radDeviceID in radDevice)
                {
                    foreach (int channelID in channel)
                    {
                        blnResult = objBusinessLogic.AssociateRADDeviceToChannel(radDeviceID, channelID, GetUsersCompanyID());
                    }
                }

                if (blnResult)
                {
                    ActionStatus.Text = string.Format("RADDevices(s) are successfully associated with the selected channel(s). ");
                    ActionStatus.ForeColor = Color.Green;
                    LoadAssociationGrid();
                }
            }
        }
    }

    private void LoadAssociationGrid()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dt = objBussLogic.GetRADDeviceChannelAssociation(GetUsersCompanyID());
        if (dt != null)
        {
            grdRADDeviceChannel.DataSource = dt;
            grdRADDeviceChannel.DataBind();
        }
    }
}