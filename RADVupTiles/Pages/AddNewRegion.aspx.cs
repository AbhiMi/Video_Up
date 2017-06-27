using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddNewRegion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreateRegion_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        
        BusinessLogic objBusinessLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        blnResult = objBusinessLogic.CreateRegions(txtCreateRegion.Text, txtDescription.Text, Context.User.Identity.Name, commFunc.GetUsersCompanyID(Context));
        if (blnResult)
        {
            lblCreateRegionStatus.Visible = true;
            lblCreateRegionStatus.ForeColor = Color.Green;
            lblCreateRegionStatus.Text = "Region created successfully.";
            txtCreateRegion.Text = "";
        }
        else
        {
            lblCreateRegionStatus.Visible = true;
            lblCreateRegionStatus.ForeColor = Color.Red;
            lblCreateRegionStatus.Text = "Operation Failed. Please Contact Administrator.";
        }

        //BindGrid();
    
    }
}