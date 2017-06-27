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
using System.IO;
using RADBusinessLogicLayer;
using System.Drawing;
public partial class Pages_Create_AddNewCmpgn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreateCampaign_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        string strFileName = string.Empty;
        string strFilePath = string.Empty;
        string tempPath = string.Empty;
        string savepath = string.Empty;
        string fileName = string.Empty;
        string filename = string.Empty;
        if (!string.IsNullOrEmpty(txtCreateCampaign.Text))
        {
            if (imgFileUpload.HasFile)
            {
                filename = imgFileUpload.PostedFile.FileName;
                string fullPath = Path.GetFullPath(filename);
                string strfilename = Path.GetFileName(filename);
                fileName = strfilename;

                strFilePath = HttpContext.Current.Server.MapPath("../../img/") + filename;
                imgFileUpload.SaveAs(strFilePath);
            }
            else
            {
                strFilePath = HttpContext.Current.Server.MapPath("../../img/") + "Default.png";
                strFileName = "Default.png";
            }
            string selectedColor = RadColorPicker1.SelectedColor.Name; 
            imgFileUpload.SaveAs(strFilePath);
            BusinessLogic objBusinessLogic = new BusinessLogic();
            CommonFunctions commFunc = new CommonFunctions();
            //blnResult = objBusinessLogic.CreateCampaign(txtCreateCampaign.Text, commFunc.GetUsersCompanyID(Context), strFilePath, filename, ColorTranslator.ToHtml(new Color()));
            blnResult = objBusinessLogic.CreateCampaign(txtCreateCampaign.Text, commFunc.GetUsersCompanyID(Context), strFilePath, filename, ColorTranslator.ToHtml(RadColorPicker1.SelectedColor));
            if (blnResult)
            {
                lblCreateCampaignStatus.Visible = true;
                lblCreateCampaignStatus.ForeColor = Color.Green;
                lblCreateCampaignStatus.Text = "Campaign created successfully.";
                txtCreateCampaign.Text = "";
            }
            else
            {
                lblCreateCampaignStatus.Visible = true;
                lblCreateCampaignStatus.ForeColor = Color.Red;
                lblCreateCampaignStatus.Text = "Operation Failed. Please Contact Administrator.";
            }
        }
    }
   
}