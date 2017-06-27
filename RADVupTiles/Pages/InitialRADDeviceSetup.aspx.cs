using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RADBusinessLogicLayer;
using RADCommonServices;

public partial class Pages_InitialRADDeviceSetup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BusinessLogic objBussLogic = new BusinessLogic();
            CommonFunctions commFunc = new CommonFunctions();
            DataTable dtStores = objBussLogic.GetStores(commFunc.GetUsersCompanyID(Context));
            ddlStore.DataSource = dtStores.DefaultView;
            ddlStore.DataBind();
            ddlRegions.DataSource = objBussLogic.GetRegions(commFunc.GetUsersCompanyID(Context));
            ddlRegions.DataBind();
            ddlAreas.DataSource = objBussLogic.GetAreas(commFunc.GetUsersCompanyID(Context));
            ddlAreas.DataBind();
            ddlConnections.DataSource = objBussLogic.GetNetworkProfiles(commFunc.GetUsersCompanyID(Context));
            ddlConnections.DataBind();
        }
    }
    protected void btnHidden_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessLogic objBussLogic = new BusinessLogic();
            CommonFunctions commFunc = new CommonFunctions();
            objBussLogic.AddNewStore(hdnStore.Value, hdnLocation.Value, commFunc.GetUsersCompanyID(Context), Convert.ToInt32(ddlRegions.SelectedValue), Convert.ToInt32(ddlAreas.SelectedValue));
            
            DataTable dtStores = objBussLogic.GetStores(commFunc.GetUsersCompanyID(Context));
            ddlStore.DataSource = dtStores.DefaultView;
            ddlStore.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnHidden1_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessLogic objBussLogic = new BusinessLogic();
            CommonFunctions commFunc = new CommonFunctions();
            objBussLogic.CreateNetworkProfile(hdnProfileName.Value, hdnWirelessName.Value, commFunc.GetUsersCompanyID(Context), hdnConnectionType.Value, hdnPassword.Value);

            ddlConnections.DataSource = objBussLogic.GetNetworkProfiles(commFunc.GetUsersCompanyID(Context));
            ddlConnections.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
}