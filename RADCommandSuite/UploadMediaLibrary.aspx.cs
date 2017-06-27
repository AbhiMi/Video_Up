using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADBusinessLogicLayer;
using RADCommonServices;
using System.IO;
using RADCommandSuite;
using System.Drawing;
using AjaxControlToolkit;
using System.Data;
using NReco.VideoConverter;

public partial class UploadMediaLibrary : System.Web.UI.Page
{
    private DataTable dtAssociateMedia = new DataTable();
    private DataTable dtAssociatedPlayList = new DataTable();
    protected DataTableWrapper dtwAssociateMedia;
    protected DataTableWrapper dtwAssociatePlayList;
    List<Values> MediaAssociationList = new List<Values>();

    protected void Page_Load(object sender, EventArgs e)
    {
        odsAssociateMedia.ObjectCreating += odsAssociateMedia_ObjectCreating;
        odsAssociatePLToCampaingns.ObjectCreating += odsAssociatePLToCampaingns_ObjectCreating;
        WZ_VideoUp.PreRender += new EventHandler(WZ_VideoUp_PreRender);
        BusinessLogic objBusinessLogic = new BusinessLogic();
        int companyID = GetUsersCompanyID();
        DataTable dtMediaFiles = objBusinessLogic.GetUploadedMediaFiles(companyID);
        DataTable dtPlayLists = GetPlayLists();
        ViewState["vsPlayLists"] = dtPlayLists;
        ViewState["vsAssociateMedia"] = dtMediaFiles;
        ////Grid view
        // The field columns need to be created only when the page is first loaded.             

        if (ViewState["vsAssociateMedia"] != null)
        {
            dtAssociateMedia = (DataTable)ViewState["vsAssociateMedia"];

            if (dtAssociateMedia != null)
            {
                grdMediaPlaylist.AutoGenerateColumns = false;
                dtwAssociateMedia = new DataTableWrapper(dtAssociateMedia);
                Type type = dtwAssociateMedia.GetType();
                odsAssociateMedia.TypeName = type.AssemblyQualifiedName;
                odsAssociateMedia.SelectMethod = "GetTable";
                CreateColumn();
                grdMediaPlaylist.DataSourceID = odsAssociateMedia.ID;
                grdMediaPlaylist.DataBind();
            }
        }
        if (ViewState["vsPlayLists"] != null)
        {
            dtAssociatedPlayList = (DataTable)ViewState["vsPlayLists"];

            if (dtAssociatedPlayList != null)
            {
                grdPlayListCampaigns.AutoGenerateColumns = false;
                dtwAssociatePlayList = new DataTableWrapper(dtAssociatedPlayList);
                Type type = dtwAssociatePlayList.GetType();
                odsAssociatePLToCampaingns.TypeName = type.AssemblyQualifiedName;
                odsAssociatePLToCampaingns.SelectMethod = "GetTable";
                CreateColumn();
                grdPlayListCampaigns.DataSourceID = odsAssociatePLToCampaingns.ID;
                grdPlayListCampaigns.DataBind();
            }
        }

        lblFileUploadStatus.Visible = false;
        lblAssociateMediatoPLStatus.Visible = false;
        lblAssociatePlayListToCampaign.Visible = false;
    }
    void odsAssociateMedia_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        dtwAssociateMedia = new DataTableWrapper(dtAssociateMedia);
        e.ObjectInstance = dtwAssociateMedia;
    }
    void odsAssociatePLToCampaingns_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        dtwAssociatePlayList = new DataTableWrapper(dtAssociatedPlayList);
        e.ObjectInstance = dtwAssociatePlayList;
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
    protected sealed override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);

        if (Context.Request.Form["__EVENTARGUMENT"] != null &&
             Context.Request.Form["__EVENTARGUMENT"].EndsWith("__ClearFilter__"))
        {
            // Clear FilterExpression
            ViewState.Remove("FilterExpression");
        }
    }

    /// <summary>
    /// Bind the playlist in step 2 to associate media
    /// </summary>
    public DataTable GetPlayLists()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtPLayLists = objBussLogic.GetPlayLists(GetUsersCompanyID());
        return dtPLayLists;
    }
    public DataTable GetCampaigns()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCampaigns = objBussLogic.GetCampaigns(GetUsersCompanyID());
        return dtCampaigns;
    }
    private void CreateColumn()
    {
        #region MediaPlayList
        if (grdMediaPlaylist.Columns.Count > 0)
        {
            grdMediaPlaylist.Columns.Clear();
        }
        BoundField boundIDField = new BoundField();
        boundIDField.HeaderText = "Media ID";
        boundIDField.DataField = "MediaID";
        this.grdMediaPlaylist.Columns.Add(boundIDField);

        BoundField boundByField = new BoundField();
        boundByField.HeaderText = "Uploaded By";
        boundByField.DataField = "UploadedBy";
        this.grdMediaPlaylist.Columns.Add(boundByField);

        BoundField boundFileField = new BoundField();
        boundFileField.HeaderText = "File Name";
        boundFileField.DataField = "Location";
        this.grdMediaPlaylist.Columns.Add(boundFileField);

        DataTable dtPlayLists = this.GetPlayLists();

        if (dtPlayLists != null && dtPlayLists.Rows.Count > 0)
        {
            foreach (DataRow drRow in dtPlayLists.Rows)
            {

                TemplateField customField = new TemplateField();
                customField.ShowHeader = true;
                customField.HeaderTemplate = new MyGridViewTemplate(DataControlRowType.Header, drRow["PlayListName"].ToString());
                customField.ItemTemplate = new MyGridViewTemplate(DataControlRowType.DataRow, drRow["PlayListName"].ToString());
                grdMediaPlaylist.Columns.Add(customField);
            }
        }
        #endregion

        #region PlayListCampaign
        if (grdPlayListCampaigns.Columns.Count > 0)
        {
            grdPlayListCampaigns.Columns.Clear();
        }

        BoundField boundIDPField = new BoundField();
        boundIDPField.HeaderText = "PlayList ID";
        boundIDPField.DataField = "PlayListID";
        this.grdPlayListCampaigns.Columns.Add(boundIDPField);

        BoundField boundByPField = new BoundField();
        boundByPField.HeaderText = "PlayList Name";
        boundByPField.DataField = "PlayListName";
        this.grdPlayListCampaigns.Columns.Add(boundByPField);

        DataTable dtCampaigns = this.GetCampaigns();

        if (dtCampaigns != null && dtCampaigns.Rows.Count > 0)
        {
            foreach (DataRow drRow in dtCampaigns.Rows)
            {

                TemplateField customField = new TemplateField();
                customField.ShowHeader = true;
                customField.HeaderTemplate = new MyGridViewTemplate(DataControlRowType.Header, drRow["CampaignName"].ToString());
                customField.ItemTemplate = new MyGridViewTemplate(DataControlRowType.DataRow, drRow["CampaignName"].ToString());
                grdPlayListCampaigns.Columns.Add(customField);
            }
        }
        #endregion
    }
    protected void WZ_VideoUp_PreRender(object sender, EventArgs e)
    {
        Repeater SideBarList = WZ_VideoUp.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
        SideBarList.DataSource = WZ_VideoUp.WizardSteps;
        SideBarList.DataBind();
    }
    protected void WZ_VideoUp_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {

    }
    protected void StartNextButton_Click(object sender, EventArgs e)
    {
        //BindDropDownLists();
        //BindMediaPlayListsGrid();
    }
    protected void StepNextButton_Click(object sender, EventArgs e)
    {
        // BindPlayListsGridData();
    }
    protected void grdMediaPlaylist_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected string GetClassForWizardStep(object wizardStep)
    {
        WizardStep step = wizardStep as WizardStep;
        if (step == null)
        {
            return "";
        }
        int stepIndex = WZ_VideoUp.WizardSteps.IndexOf(step);

        if (stepIndex < WZ_VideoUp.ActiveStepIndex)
        {
            return "prevStep";
        }
        else if (stepIndex > WZ_VideoUp.ActiveStepIndex)
        {
            return "nextStep";
        }
        else
        {
            return "currentStep";
        }
    }


    /// <summary>
    /// Code to associte Media to a playlist
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAssociateMediatoPL_Click(object sender, EventArgs e)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        int companyID = 0;
        string userName = Context.User.Identity.Name;
        string userId = objBusinessLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            DataTable dtCompanies = objBusinessLogic.GetUserCompany(userId);
            if (dtCompanies != null && dtCompanies.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCompanies.Rows)
                {
                    companyID = Convert.ToInt32(dr["CompanyID"]);
                }
            }
        }
        foreach (GridViewRow row in grdMediaPlaylist.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                DataTable dtPlayLists = GetPlayLists();

                if (dtPlayLists != null && dtPlayLists.Rows.Count > 0)
                {
                    foreach (DataRow drRow in dtPlayLists.Rows)
                    {
                        string strPlayListName = drRow["PlayListName"].ToString().Replace(" ", string.Empty);
                        CheckBox chk = (row.FindControl("chk_" + strPlayListName)) as CheckBox;
                        if (chk != null && chk.Checked)
                        {
                            Values val = new Values();
                            val.MediaID = Convert.ToInt32(row.Cells[0].Text);
                            val.PlayListID = Convert.ToInt32(drRow["PlayListID"]);
                            MediaAssociationList.Add(val);
                        }
                    }
                }
            }
        }
        if (MediaAssociationList != null && MediaAssociationList.Count > 0)
        {
            bool blnResult = false;
            foreach (Values AssociationVal in MediaAssociationList)
            {
                blnResult = objBusinessLogic.AssociateMediaToPlayList(AssociationVal.MediaID, AssociationVal.PlayListID, companyID);
            }
            if (blnResult)
            {
                lblAssociateMediatoPLStatus.Visible = true;
                lblAssociateMediatoPLStatus.Text = "Media file(s) are successfully associated with the selected playlist(s). ";
            }
        }

    }
    protected void WZ_VideoUp_FinishButtonClick1(object sender, WizardNavigationEventArgs e)
    {

    }

    //Associate Playlist to a campaign
    protected void btnAssociatePLtoCmpgn_Click(object sender, EventArgs e)
    {
        try
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            foreach (GridViewRow row in grdPlayListCampaigns.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dtCampaigns = GetCampaigns();

                    if (dtCampaigns != null && dtCampaigns.Rows.Count > 0)
                    {
                        foreach (DataRow drRow in dtCampaigns.Rows)
                        {
                            string strCampaignName = drRow["CampaignName"].ToString().Replace(" ", string.Empty);
                            CheckBox chk = (row.FindControl("chk_" + strCampaignName)) as CheckBox;
                            if (chk != null && chk.Checked)
                            {
                                Values val = new Values();
                                val.PlayListID = Convert.ToInt32(row.Cells[0].Text);
                                val.CampaignID = Convert.ToInt32(drRow["CampaignID"]);
                                MediaAssociationList.Add(val);
                            }
                        }
                    }
                }
            }
            if (MediaAssociationList != null && MediaAssociationList.Count > 0)
            {
                bool blnResult = false;
                foreach (Values AssociationVal in MediaAssociationList)
                {
                    blnResult = objBusinessLogic.AssociatePlayListToCampaign(AssociationVal.PlayListID, AssociationVal.CampaignID, GetUsersCompanyID());
                }
                if (blnResult)
                {
                    lblAssociatePlayListToCampaign.Visible = true;
                    lblAssociatePlayListToCampaign.Text = "PlayList(s) successfully associated with the selected Campaign(s). ";
                }
            }
        }
        catch
        {
            lblAssociatePlayListToCampaign.Visible = true;
            lblAssociatePlayListToCampaign.ForeColor = Color.Red;
            lblAssociatePlayListToCampaign.Text = "PlayList(s) association with campaign failed.";
        }
    }

    public class MyGridViewTemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;

        public MyGridViewTemplate(DataControlRowType type, string colname)
        {
            templateType = type;
            columnName = colname;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            // Create the content for the different row types.
            switch (templateType)
            {
                case DataControlRowType.Header:
                    //int index = 0;
                    CheckBox cbHeader = new CheckBox();
                    cbHeader.Text = columnName;
                    string strHeaderPlayListName = columnName.Replace(" ", string.Empty);
                    cbHeader.Attributes.Add("onclick", string.Format("SelectAllCheckboxes(this, '.{0}');", strHeaderPlayListName));
                    cbHeader.ID = "chkHeader_" + strHeaderPlayListName;
                    container.Controls.Add(cbHeader);
                    //index++;
                    break;
                case DataControlRowType.DataRow:
                    // Create the controls to put in a data row
                    // section and set their properties.
                    CheckBox m_chk = new CheckBox();

                    // To support data binding, register the event-handling methods
                    // to perform the data binding. Each control needs its own event
                    // handler.
                    string strPlayListName = columnName.Replace(" ", string.Empty);
                    m_chk.EnableViewState = true;
                    //m_chk.ID = "chk" + i;
                    m_chk.ID = "chk_" + strPlayListName;
                    m_chk.AutoPostBack = false;

                    // Add the controls to the Controls collection
                    // of the container.
                    container.Controls.Add(m_chk);
                    //}
                    break;

                // Insert cases to create the content for the other row types, if desired.

                default:
                    // Insert code to handle unexpected values.
                    break;
            }
        }
    }
    public class Values
    {
        public int MediaID
        {
            get;
            set;
        }
        public int PlayListID
        {
            get;
            set;
        }
        public int CampaignID
        {
            get;
            set;
        }
    }

}