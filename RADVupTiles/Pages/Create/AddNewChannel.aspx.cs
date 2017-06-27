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

public partial class Pages_Create_AddNewChannel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreateChannel_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        string strFileName = string.Empty;
        string strFilePath = string.Empty;
        string tempPath = string.Empty;
        string savepath = string.Empty;
        string filename = string.Empty;
        string fileName = string.Empty;
        if (!string.IsNullOrEmpty(txtCreateChannel.Text))
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
        }
        string selectedColor = RadColorPicker1.SelectedColor.Name;
        BusinessLogic objBusinessLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        //blnResult = objBusinessLogic.CreateChannel(txtCreateChannel.Text, commFunc.GetUsersCompanyID(Context), strFilePath, filename, ColorTranslator.ToHtml(new Color()));
        blnResult = objBusinessLogic.CreateChannel(txtCreateChannel.Text, commFunc.GetUsersCompanyID(Context), strFilePath, filename, ColorTranslator.ToHtml(RadColorPicker1.SelectedColor));
        if (blnResult)
        {
            lblCreateChannelStatus.Visible = true;
            lblCreateChannelStatus.ForeColor = Color.Green;
            lblCreateChannelStatus.Text = "Channel created successfully.";
            txtCreateChannel.Text = "";
        }
        else
        {
            lblCreateChannelStatus.Visible = true;
            lblCreateChannelStatus.ForeColor = Color.Red;
            lblCreateChannelStatus.Text = "Operation Failed. Please Contact Administrator.";
        }

        //BindGrid();
    }
}