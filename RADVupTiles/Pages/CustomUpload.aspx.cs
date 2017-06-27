using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_CustomUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region ClientSideEvents
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "HideColumn", "<script language='javascript'>hideColumn();</script>");
        #endregion
        if (!IsPostBack)
        {
            ViewState["Media_Sort_Direction"] = Media_Sort_Direction;
            ViewState["AvblPlaylist_Sort_Direction"] = AvblPlaylist_Sort_Direction;
            ViewState["AssctedPlaylist_Sort_Direction"] = AssctedPlaylist_Sort_Direction;
            string userName = Context.User.Identity.Name;
            //if (!Roles.IsUserInRole(userName, "Guest"))
            //{
            //    if (!IsPostBack)
            //    {
            //        BindGrid();
            //    }
            //}
            //else
            //{
            //    BindGrid();
            //}
        }
        string innerHTML = string.Empty;
        DataTable dtMedia = GetSelectedVideo(12);
        if (dtMedia != null && dtMedia.Rows.Count > 0)
        {
            foreach (DataRow dr in dtMedia.Rows)
            {
                innerHTML = "<source src='" + dr["UrlLocation"].ToString() + "'></source>";
                //WebControl control = (WebControl)e.Row.Cells[4].FindControl("ctrlVideo");
                //myVideo.InnerHtml = innerHTML;
            }
        }
    }
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;
    string Media_Sort_Direction = "MediaID ASC";
    string AvblPlaylist_Sort_Direction = "PlayListName ASC";
    string AssctedPlaylist_Sort_Direction = "PlayListName ASC";
    public DataTable GetUnAssociatedPlayLists(int CompanyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        //DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataTable dtMediaFiles = objBussLogic.GetUnAssociatePlaylists(commFunc.GetUsersCompanyID(Context));
        return dtMediaFiles;
    }
    public DataView GetChannels(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtChannels = objBussLogic.GetChannels(commFunc.GetUsersCompanyID(Context));
        DataView dvChannels = dtChannels.DefaultView;
        dvChannels.Sort = ViewState["Media_Sort_Direction"].ToString();
        return dvChannels;
    }

    public DataTable GetMedia(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtMedia = objBussLogic.GetMedia(CompanyID);
        DataTable dtFilteredPlayLists = new DataTable();
        //if (!string.IsNullOrEmpty(txtMedia.Text.Trim()))
        //{
        //    DataRow[] drRows = dtMedia.Select(string.Format("Description = '{0}'", txtMedia.Text));
        //    if (drRows != null && drRows.Count() > 0)
        //    {
        //        dtFilteredPlayLists = drRows.CopyToDataTable();
        //    }
        //} 
        //if (dtFilteredPlayLists != null && dtFilteredPlayLists.Rows.Count > 0)
        //{
        //    return dtFilteredPlayLists;
        //}
        //else
        //{
        return dtMedia;
        //}
    }
    //protected void grdMedia_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    string strMediaID = grdMedia.DataKeys[e.RowIndex].Values["MediaID"].ToString();
    //    TextBox txtDescription = (TextBox)grdMedia.Rows[e.RowIndex].FindControl("txtDescription");
    //    BusinessLogic objBussLogic = new BusinessLogic();
    //    bool blnResult = objBussLogic.UpdateMedia(Convert.ToInt32(strMediaID), txtDescription.Text);
    //    if (blnResult)
    //    {
    //        lblmsg.ForeColor = Color.Green;
    //        lblmsg.Text = txtDescription.Text + " updated successfully.";
    //        grdMedia.EditIndex = -1;
    //    }
    //    else
    //    {
    //        lblmsg.ForeColor = Color.Red;
    //        lblmsg.Text = "Updated failed. Please contact system administrator.";
    //        grdMedia.EditIndex = -1;
    //    }
    //    BindGrid();
    //    lblTitle.Text = txtDescription.Text;
    //    hdnDescription.Value = txtDescription.Text;
    //}

    //protected void grdMedia_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    string strMediaID = grdMedia.DataKeys[e.RowIndex].Values["MediaID"].ToString();
    //    BusinessLogic objBussLogic = new BusinessLogic();
    //    bool blnResult = objBussLogic.DeleteCampaign(Convert.ToInt32(strMediaID));
    //    if (blnResult)
    //    {
    //        lblmsg.ForeColor = Color.Green;
    //        lblmsg.Text = "Campaign deleted successfully.";
    //        grdMedia.EditIndex = -1;
    //    }
    //    else
    //    {
    //        lblmsg.ForeColor = Color.Red;
    //        lblmsg.Text = "Deletion failed. Please contact system administrator.";
    //        grdMedia.EditIndex = -1;
    //    }
    //    BindGrid();

    //}
    protected void grdMedia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //// Set the hand mouse cursor for the selected row.
            //e.Row.Attributes.Add("style", "cursor: pointer");

            //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdMedia, "Select$" + e.Row.RowIndex);
            //e.Row.ToolTip = "Click to select this row.";

            string MediaID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MediaID"));
            Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
            Button lnkbtnCancel = (Button)e.Row.FindControl("ButtonCancel");
            if (lnkbtnCancel != null)
            {
                lnkbtnCancel.Attributes.Add("onclick", " ");
            }
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + MediaID + "')");
            }
        }
        e.Row.Height = Unit.Pixel(20); 
    }
    protected void grdMedia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //int index = Convert.ToInt32(e.CommandArgument);
        //BindGrid();//Your method to set datasource anddatabind GridView1
        //grdMedia.Rows[index].Attributes.Add("style", "background-color:#A1DCF2");
    }
    private void BindGrid()
    {
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dataTable = GetMedia(commFunc.GetUsersCompanyID(Context));
        if (!IsPostBack)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = "UploadedOn desc";

                grdMedia.DataSource = dataView;
                grdMedia.DataBind();
            }
        }
        else
        {
            if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
            {
                if (dataTable != null)
                {
                    DataView dataView = new DataView(dataTable);
                    dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                    grdMedia.DataSource = dataView;
                    grdMedia.DataBind();
                }
            }
            else
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    grdMedia.DataSource = dataTable.DefaultView;
                    grdMedia.DataBind();
                }
                else
                {
                    dataTable.NewRow();
                    grdMedia.DataSource = dataTable.DefaultView;
                    grdMedia.DataBind();

                }
            }
        }
    }

    private SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }
    protected void SortGridView(string sortExpression, string direction)
    {
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dataTable = GetMedia(commFunc.GetUsersCompanyID(Context));
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + direction;

            grdMedia.DataSource = dataView;
            grdMedia.DataBind();
        }
    }
    protected void grdMedia_Sorting(object sender, GridViewSortEventArgs e)
    {
        isSort = true;
        string sortExpression = e.SortExpression;

        ViewState["SortExpression"] = sortExpression;
        showImage = true;
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            isAscend = true;
            SortGridView(sortExpression, ASCENDING);
            ViewState["SortDirection"] = ASCENDING;
            GridViewSortDirection = SortDirection.Descending;
        }
        else
        {
            isAscend = false;
            SortGridView(sortExpression, DESCENDING);
            ViewState["SortDirection"] = DESCENDING;
            GridViewSortDirection = SortDirection.Ascending;
        }
    }
    protected override void Render(HtmlTextWriter writer)
    {
        // Register controls for event validation
        foreach (Control c in this.Controls)
        {
            this.Page.ClientScript.RegisterForEventValidation(
                    c.UniqueID.ToString()
            );
        }
        base.Render(writer);
    }
    protected void btnLoadSearchGrid_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void AddSortImage(int columnIndex, GridViewRow HeaderRow)
    {
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();
        if (showImage) // this is a boolean variable which should be false 
        {
            if (ViewState["sortDirection"] != null)
            {//  on page load so that image wont show up initially.
                if (ViewState["sortDirection"].ToString() == "Ascending")
                {
                    sortImage.ImageUrl = "~/Images/asc.gif";
                    sortImage.AlternateText = " Ascending Order";
                }
                else
                {
                    sortImage.ImageUrl = "~/Images/desc.gif";
                    sortImage.AlternateText = " Descending Order";
                }
            }
            //grdCampaign.HeaderRow.Cells[0].Controls.Add(sortImage);
        }
    }
    protected void SideBarList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        WizardStep dataItem = e.Item.DataItem as WizardStep;
        LinkButton linkButton = e.Item.FindControl("SideBarButton") as LinkButton;

        if (dataItem != null)
        {
            if (dataItem.Wizard.ActiveStepIndex == e.Item.ItemIndex)
            {
                linkButton.CssClass = "sidebarActiveLink";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>getCurTime();</script>", false);
            Process process = new Process();
            process.StartInfo.FileName = ConfigurationManager.AppSettings["ffmpegLocation"];
            //process.StartInfo.FileName = @"C:\Users\srprasad\Perforce\Srikant_laptop\Video_Up\RADVupTiles\Bin\ffmpeg\ffmpeg.exe";
            string imglocation = ConfigurationManager.AppSettings["imageLocation"];
            string filepath = string.Empty; //@"C:\Users\srprasad\Downloads\ParallaxSlider\test.mp4";
            string filename = string.Empty;
            double time;
            DataTable dtMedia = GetSelectedVideo(12);
            if (dtMedia != null && dtMedia.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMedia.Rows)
                {
                    filepath = dr["PhysicalLocation"].ToString();
                    filename = Path.GetFileNameWithoutExtension(filepath);
                    // Prepare a temporary file for ommandline usage
                    string tmpFileName = imglocation + filename + ".png";
                    //if (tmpFileName.Contains(' '))
                    //    tmpFileName = "\"" + tmpFileName + "\"";
                    //time = Convert.ToDouble(inpHide.Value);
                    //TimeSpan position = TimeSpan.FromSeconds(time);
                    //string cmdParams = String.Format("-hide_banner -ss {0} -i {1} -r 1 -t 1 -f image2 {2}", position, filepath, tmpFileName);
                    //process.StartInfo.Arguments = cmdParams;
                    //process.StartInfo.UseShellExecute = false;
                    //process.StartInfo.RedirectStandardOutput = true;
                    //process.Start();
                    //// Synchronously read the standard output of the spawned process. 
                    //StreamReader reader = process.StandardOutput;
                    //string output = reader.ReadToEnd();
                    //// Write the redirected output to this application's window.
                    //Console.WriteLine(output);
                    //process.WaitForExit();
                    //process.Close();
                }
            }
        }
        catch (Exception ex)
        { }
    }

    public DataTable GetSelectedVideo(int videoID)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        DataTable dtVideo = objBusinessLogic.GetMediaFromID(videoID);

        return dtVideo;
    }

    protected void grdMedia_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        CommonFunctions commFunc = new CommonFunctions();
        grdMedia.DataSource = GetMedia(commFunc.GetUsersCompanyID(Context));
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in grdMedia.SelectedItems)
        {
            //Get the primary key value using the DataKeyValue.       
            int mediaId = Convert.ToInt32(item.GetDataKeyValue("MediaID"));
            BusinessLogic objBussLogic = new BusinessLogic();
            try
            {
                bool blnResult = objBussLogic.DeleteMedia(mediaId);
                if (blnResult)
                {
                    //grdMedia.Controls.Add(new LiteralControl("Video Deleted Successfully."));
                    lblmsg.Text = "Video Deleted Successfully.";
                    grdMedia.MasterTableView.Rebind();
                }
                else
                    lblmsg.Text = "Unable to delete.";
            }
            catch (Exception ex)
            {
                grdMedia.Controls.Add(new LiteralControl("Unable to delete. Reason: " + ex.Message));
            }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in grdMedia.SelectedItems)
        {
            string campaignID = item.GetDataKeyValue("MediaID").ToString(); // Works if you set the DataKeyValue as CustomerID             
            item.Edit = true;
            grdMedia.MasterTableView.Rebind();
        }
    }

    protected void grdMedia_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;
        string strSelectedColor = string.Empty;
        int iMediaID = Convert.ToInt32(editedItem.GetDataKeyValue("MediaID"));
        TextBox txtMediaName = (TextBox)editedItem.FindControl("txtDescription");
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdateMedia(iMediaID, txtMediaName.Text);
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtMediaName.Text + " updated successfully.";
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
        }
    }

    //protected void playBtn_Click(object sender, ImageClickEventArgs e)
    //{
    //    foreach (GridDataItem item in grdMedia.SelectedItems)
    //    {
    //        string mediaID = item.GetDataKeyValue("MediaID").ToString(); // Works if you set the DataKeyValue as CustomerID             
    //        BusinessLogic objBussLogic = new BusinessLogic();
    //        DataTable dt = objBussLogic.GetMediaFromID(Convert.ToInt32(mediaID));
    //        //mediaplayerLtr.Text = InjectPlayer(dt.Rows[0][0].ToString());
    //        homevideo.Attributes.Add("src", dt.Rows[0][0].ToString());
    //    }
    //}

    string InjectPlayer(string filePath)
    {
        //Below works with IE 6,7 and Safari NOT FireFox. Use code below to include FireFox.

        StringBuilder sa = new StringBuilder();
        // sa.Append("<center>");
        sa.Append("<OBJECT ID=\"Player\" CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\" VIEWASTEXT width=\"320\" height=\"305\"> ");
        sa.Append("<PARAM name=\"autoStart\" value=\"True\">");
        sa.Append(string.Format("<PARAM name=\"URL\" value=\"{0}\">", filePath));
        sa.Append("<PARAM name=\"AutoSize\" value=\"false\"");
        sa.Append("<PARAM name=\"rate\" value=\"1\">");
        sa.Append("<PARAM name=\"balance\" value=\"0\">");
        sa.Append("<PARAM name=\"enabled\" value=\"true\">");
        sa.Append("<PARAM name=\"enabledContextMenu\" value=\"true\">");
        sa.Append("<PARAM name=\"fullScreen\" value=\"false\">");
        sa.Append("<PARAM name=\"playCount\" value=\"1\">");
        sa.Append("<PARAM name=\"volume\" value=\"50\">  ");
        sa.Append("</OBJECT>");
        //  sa.Append("</center>");
        return sa.ToString();

        //Below works with IE 6,7 Safari and FireFox, Its ugly but it works.

        //StringBuilder sa = new StringBuilder();
        //    // sa.Append("<center>");
        //    sa.Append("<OBJECT ID=\"Player\" Object Type=\"video/x-ms-wmv\" width=\"320\" height=\"305\" VIEWASTEXT > "); 
        //    sa.Append("<PARAM name=\"autoStart\" value=\"True\">");
        //    sa.Append(string.Format("<PARAM name=\"SRC\" value=\"{0}\">", filePath));// IE needs this extra push when using MIME type not class id
        //    sa.Append(string.Format("<PARAM name=\"URL\" value=\"{0}\">", filePath));
        //    sa.Append("<PARAM name=\"AutoSize\" value=\"False\"");
        //    sa.Append("<PARAM name=\"rate\" value=\"1\">");
        //    sa.Append("<PARAM name=\"balance\" value=\"0\">");
        //    sa.Append("<PARAM name=\"enabled\" value=\"true\">");
        //    sa.Append("<PARAM name=\"enabledContextMenu\" value=\"true\">");
        //    sa.Append("<PARAM name=\"fullScreen\" value=\"false\">");
        //    sa.Append("<PARAM name=\"playCount\" value=\"1\">");
        //    sa.Append("<PARAM name=\"volume\" value=\"30\">  ");
        //    sa.Append("</OBJECT>");
        //    //  sa.Append("</center>");
        //    return sa.ToString(); 
    }

    protected void RadAsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        RADDataAccessLayer.MediaLibrary objMediaLibrary = new RADDataAccessLayer.MediaLibrary();
        try
        {
            UploadedFile postedFile = e.File;

            string savepath = "";
            string tempPath = "";
            tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
            savepath = HttpContext.Current.Server.MapPath(tempPath);
            string filename = postedFile.FileName;
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);

            string fullPath = Path.GetFullPath(postedFile.FileName);
            string strfilename = Path.GetFileName(postedFile.FileName);
            string name = filename.Split('.')[0];

            objMediaLibrary.Description = filename;
            objMediaLibrary.UrlLocation = "http://" + HttpContext.Current.Request.Url.Authority + "/Media/" + filename;
            objMediaLibrary.PhysicalLocation = savepath + "\\" + filename;
            objMediaLibrary.MIMEType = postedFile.ContentType;
            objMediaLibrary.UploadedBy = HttpContext.Current.User.Identity.Name;
            objMediaLibrary.CompanyID = commFunc.GetUsersCompanyID(Context);

            //retrieve the HttpPostedFile object
            Stream fileStream = null;
            try
            {
                fileStream = e.File.InputStream;
                byte[] attachmentBytes = new byte[fileStream.Length];
                fileStream.Read(attachmentBytes, 0, Convert.ToInt32(fileStream.Length));


                objMediaLibrary.VideoBuffer = attachmentBytes;
            }
            finally
            {
                fileStream.Close();
            }

            objBusinessLogic.InsertMediaLibrary(objMediaLibrary);

            postedFile.SaveAs(savepath + @"\" + filename);

            HttpContext.Current.Response.Write(tempPath + "/" + filename);
            HttpContext.Current.Response.StatusCode = 200;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("Error: " + ex.Message);
        }
    }

    public byte[] GetFileBytes(Stream stream)
    {
        byte[] buffer;
        
            using (MemoryStream ms = new MemoryStream())
            {
                //return the current position in the stream at the beginning
                ms.Position = 0;

                buffer = new byte[ms.Length];
                ms.Read(buffer, 0, (int)ms.Length);
                return buffer;
            }        
    }
}
public class Media
{
    public int MediaID { get; set; }
    public string PlayListID { get; set; }
}
