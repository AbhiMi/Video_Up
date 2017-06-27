using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_RADDevice : System.Web.UI.Page
{
    string RADDevice_Sort_Direction = "DeviceInfo ASC";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["RADDevice_Sort_Direction"] = RADDevice_Sort_Direction;
            BusinessLogic objBussLogic = new BusinessLogic();
            CommonFunctions commFunc = new CommonFunctions();
            hdnCompanyID.Value = commFunc.GetUsersCompanyID(Context).ToString();
            DataView dvRADDevices = GetRADDevices(Convert.ToInt32(hdnCompanyID.Value));
            grdRADDevice.DataSource = dvRADDevices;
            grdRADDevice.DataBind();
        }
    }

    public DataView GetRADDevices(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtRADDevices = objBussLogic.GetRADDevices(commFunc.GetUsersCompanyID(Context));
        DataView dvRADDevices = dtRADDevices.DefaultView;
        dvRADDevices.Sort = ViewState["RADDevice_Sort_Direction"].ToString();
        return dvRADDevices;
    }
}