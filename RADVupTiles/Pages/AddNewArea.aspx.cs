﻿using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddNewArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic obj = new BusinessLogic();
        ddlRegions.DataSource = obj.GetRegions(commFunc.GetUsersCompanyID(Context));
        ddlRegions.DataBind();
    }
    protected void btnCreateArea_Click(object sender, EventArgs e)
    {
        bool blnResult = false;

        BusinessLogic objBusinessLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        blnResult = objBusinessLogic.CreateArea(txtCreateArea.Text, Convert.ToInt32(ddlRegions.SelectedItem.Value), commFunc.GetUsersCompanyID(Context));
        if (blnResult)
        {
            lblCreateAreaStatus.Visible = true;
            lblCreateAreaStatus.ForeColor = Color.Green;
            lblCreateAreaStatus.Text = "Area created successfully.";
            txtCreateArea.Text = "";
        }
        else
        {
            lblCreateAreaStatus.Visible = true;
            lblCreateAreaStatus.ForeColor = Color.Red;
            lblCreateAreaStatus.Text = "Operation Failed. Please Contact Administrator.";
        }
    }
}