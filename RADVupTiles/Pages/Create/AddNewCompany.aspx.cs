using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddNewCompany : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreateCompany_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        if (!string.IsNullOrEmpty(txtCreateCompany.Text))
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            blnResult = objBusinessLogic.CreateCompany(txtCreateCompany.Text,Convert.ToInt32(txtCompanyCode.Text));
            if (blnResult)
            {
                lblCreateCompanyStatus.Visible = true;
                lblCreateCompanyStatus.ForeColor = Color.Green;
                lblCreateCompanyStatus.Text = "Company added successfully.";
            }
            else
            {
                lblCreateCompanyStatus.Visible = true;
                lblCreateCompanyStatus.ForeColor = Color.Red;
                lblCreateCompanyStatus.Text = "Operation Failed. Please Contact Administrator.";
            }
        }
    }
}