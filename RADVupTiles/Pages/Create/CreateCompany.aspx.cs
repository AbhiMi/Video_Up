using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADBusinessLogicLayer;
using System.Drawing;
using System.Data;
using RADVupTiles;
using System.Web.Security;

public partial class Pages_CreateCompany : System.Web.UI.Page
{
    private DataTable dtAssociateRADDevices = new DataTable();
    protected DataTableWrapper dtwAssociateRADDevices;
    List<Values> RADDeviceAssociationList = new List<Values>();
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;
    public static DataTable dataTable = new DataTable();
    /// <summary>
    /// Data to be loaded when the page renders on the screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Membership.GetUserNameByEmail(Context.User.Identity.Name);
        if (Roles.IsUserInRole(userName, "VUP Admin"))
        {
            //WZ_Company.PreRender += new EventHandler(WZ_Company_PreRender);
            //odsAssociateRAD.ObjectCreating += odsAssociateRAD_ObjectCreating;
            BusinessLogic objBusinessLogic = new BusinessLogic();
            DataTable dtRADDevices = objBusinessLogic.GetRADDevices(GetUsersCompanyID());
            ViewState["vsAssociateRADDevices"] = dtRADDevices;
            ////Grid view
            // The field columns need to be created only when the page is first loaded.    
            if (!IsPostBack)
            {
                BindGrid();
            }

            if (ViewState["vsAssociateRADDevices"] != null)
            {
                dtAssociateRADDevices = (DataTable)ViewState["vsAssociateRADDevices"];

                if (dtAssociateRADDevices != null)
                {
                    //grdRADCompany.AutoGenerateColumns = false;
                    dtwAssociateRADDevices = new DataTableWrapper(dtAssociateRADDevices);
                    Type type = dtwAssociateRADDevices.GetType();
                    //odsAssociateRAD.TypeName = type.AssemblyQualifiedName;
                    //odsAssociateRAD.SelectMethod = "GetTable";
                    // CreateColumn();
                    //grdRADCompany.DataSourceID = odsAssociateRAD.ID;
                    //grdRADCompany.DataBind();
                }
            }
            //lblAssteRADDevicetoCompanyStatus.Visible = false;
        }
        else
        {
           // tblCompany.Visible = false;
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
    }

    public int GetUsersCompanyID()
    {
        int companyID = 0;
        string userName = Context.User.Identity.Name;
        BusinessLogic objBussLogic = new BusinessLogic();
        string userId = objBussLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            Guid userGuid = Guid.Parse(userId);
            DataTable dtCompanies = objBussLogic.GetUserCompany(userGuid);
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
    void odsAssociateRAD_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        dtwAssociateRADDevices = new DataTableWrapper(dtAssociateRADDevices);
        e.ObjectInstance = dtwAssociateRADDevices;
    }
    public DataTable GetCompanies()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCompanies = objBussLogic.GetCompanies();
        return dtCompanies;
    }
    /// <summary>
    /// Create a new company to be saved in database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    

    /// <summary>
    /// Add a new RAD device
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>


    /// <summary>
    /// Creation of Wizard step
    /// </summary>
    /// <param name="wizardStep"></param>
    /// <returns></returns>
    //protected string GetClassForWizardStep(object wizardStep)
    //{
    //    WizardStep step = wizardStep as WizardStep;
    //    if (step == null)
    //    {
    //        return "";
    //    }
    //    int stepIndex = WZ_Company.WizardSteps.IndexOf(step);

    //    if (stepIndex < WZ_Company.ActiveStepIndex)
    //    {
    //        return "prevStep";
    //    }
    //    else if (stepIndex > WZ_Company.ActiveStepIndex)
    //    {
    //        return "nextStep";
    //    }
    //    else
    //    {
    //        return "currentStep";
    //    }
    //}

    //protected void WZ_Company_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    //{

    //}
    //protected void StartNextButton_Click(object sender, EventArgs e)
    //{

    //}
    //protected void StepNextButton_Click(object sender, EventArgs e)
    //{
    //}
    //protected void WZ_Company_PreRender(object sender, EventArgs e)
    //{
    //    Repeater SideBarList = WZ_Company.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;
    //    SideBarList.DataSource = WZ_Company.WizardSteps;
    //    SideBarList.DataBind();
    //}
    protected void grdCompany_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdCompany.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void grdCompany_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strCompanyID = grdCompany.DataKeys[e.RowIndex].Values["CompanyID"].ToString();
        TextBox txtCompanyName = (TextBox)grdCompany.Rows[e.RowIndex].FindControl("txtCompanyName");
        TextBox txtCompanyCode = (TextBox)grdCompany.Rows[e.RowIndex].FindControl("txtCompanyCode");
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdateCompany(txtCompanyName.Text, Convert.ToInt32(strCompanyID), Convert.ToInt32(txtCompanyCode.Text));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtCompanyName.Text + " updated successfully.";
            grdCompany.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
            grdCompany.EditIndex = -1;
        }
        BindGrid();
    }
    protected void grdCompany_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdCompany.EditIndex = -1;
        BindGrid();
    }
    protected void grdCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strCompanyID = grdCompany.DataKeys[e.RowIndex].Values["CompanyID"].ToString();
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.DeleteCompany(Convert.ToInt32(strCompanyID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "Company deleted successfully.";
            grdCompany.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Deletion failed. Please contact system administrator.";
            grdCompany.EditIndex = -1;
        }
        BindGrid();

    }
    protected void grdCompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string CompanyID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CompanyID"));
            ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("ButtonDelete");
            ImageButton lnkbtnCancel = (ImageButton)e.Row.FindControl("ButtonCancel");
            if (lnkbtnCancel != null)
            {
                lnkbtnCancel.Attributes.Add("onclick", " ");
            }
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + CompanyID + "')");
            }
        }
        e.Row.Height = Unit.Pixel(20);
    }
    protected void grdCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void BindGrid()
    {
        dataTable = GetCompanies();
        if (!IsPostBack)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = "DateCreated desc";

                grdCompany.DataSource = dataView;
                grdCompany.DataBind();
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

                    grdCompany.DataSource = dataView;
                    grdCompany.DataBind();
                }
            }
            else
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    grdCompany.DataSource = dataTable.DefaultView;
                    grdCompany.DataBind();
                }
                else
                {
                    dataTable.NewRow();
                    grdCompany.DataSource = dataTable.DefaultView;
                    grdCompany.DataBind();

                }
            }
        }
    }
    protected void grdCompany_RowCreated(object sender, GridViewRowEventArgs e)
    {
        int sortColumnIndex = 0;

        if (e.Row.RowType == DataControlRowType.Header)
            sortColumnIndex = GetSortColumnIndex();

        if (sortColumnIndex != 1)
        {
            AddSortImage(sortColumnIndex, e.Row);
        }
    }
    protected int GetSortColumnIndex()
    {
        foreach (DataControlField field in grdCompany.Columns)
        {
            if (field.SortExpression == grdCompany.SortExpression)
                return grdCompany.Columns.IndexOf(field);
            else
                return -1;
        }
        return -1;
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
            //grdCompany.HeaderRow.Cells[0].Controls.Add(sortImage);
        }
    }
    protected void btnAssteRADtoCompany_Click(object sender, EventArgs e)
    {
        //    BusinessLogic objBusinessLogic = new BusinessLogic();
        //    foreach (GridViewRow row in grdRADCompany.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            DataTable dtCompanies= GetCompanies();

        //            if (dtCompanies != null && dtCompanies.Rows.Count > 0)
        //            {
        //                foreach (DataRow drRow in dtCompanies.Rows)
        //                {
        //                    string strPlayListName = drRow["CompanyName"].ToString().Replace(" ", string.Empty);
        //                    CheckBox chk = (row.FindControl("chk_" + strPlayListName)) as CheckBox;
        //                    if (chk != null && chk.Checked)
        //                    {
        //                        Values val = new Values();
        //                        val.RADDeviceID = Convert.ToInt32(row.Cells[0].Text);
        //                        val.CompanyID = Convert.ToInt32(drRow["CompanyID"]);
        //                        RADDeviceAssociationList.Add(val);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (RADDeviceAssociationList != null && RADDeviceAssociationList.Count > 0)
        //    {
        //        bool blnResult = false;
        //        foreach (Values AssociationVal in RADDeviceAssociationList)
        //        {
        //            blnResult = objBusinessLogic.AssociateRADDeviceToCompany(AssociationVal.CompanyID, AssociationVal.RADDeviceID);
        //        }
        //        if (blnResult)
        //        {
        //            lblAssteRADDevicetoCompanyStatus.Visible = true;
        //            lblAssteRADDevicetoCompanyStatus.Text = "RAD Device(s) are successfully associated with the selected Companies. ";
        //        }
        //    }
    }
    protected void grdCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCompany.PageIndex = e.NewPageIndex;

        if (!isSort) // this will get exectued if user clicks paging
        {            // before sorting istelf

            BindGrid();    //instance. Provide your datasource
            // to bind the data
        }

        else if (isAscend)// this will get exectued if user clicks paging
        // after cliclking ascending order
        {

            // I am passing only "DateRequest" as sortexpression for instance. because
            // i am implementing sorting for only one column. You can generalize it to 
            // pass that particular column on sorting.
            SortGridView("CompanyName", ASCENDING);

        }
        else // this will get exectued if user clicks paging
        // after cliclking descending order
        {
            SortGridView("CompanyName", DESCENDING);
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
        DataTable dataTable = GetCompanies();
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + direction;

            grdCompany.DataSource = dataView;
            grdCompany.DataBind();
        }
    }
    protected void grdCompany_Sorting(object sender, GridViewSortEventArgs e)
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
        public int CompanyID
        {
            get;
            set;
        }
        public int RADDeviceID
        {
            get;
            set;
        }
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        lblSearchText.Text = txtSearch.Text;
        IEnumerable<DataRow> query = from dr in dataTable.AsEnumerable()
                                     where dr.Field<string>("CompanyName").Contains(txtSearch.Text)
                                     select dr;
        if (query.Count() > 0)
        {
            // Create a table from the query.
            DataTable boundTable = query.CopyToDataTable<DataRow>();
            BindGrid_Search(boundTable);
        }
        else
        {
            BindGrid_Search(new DataTable());
        }
    }
    protected void ClearSearch_Click(object sender, EventArgs e)
    {
        txtSearch.Text = string.Empty;
        lblSearchText.Text = string.Empty;
        BindGrid();
    }
    private void BindGrid_Search(DataTable dataTable)
    {
        // dataTable = GetCampaigns(GetUsersCompanyID());
        if (!IsPostBack)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = "DateCreated desc";

                grdCompany.DataSource = dataView;
                grdCompany.DataBind();
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

                    grdCompany.DataSource = dataView;
                    grdCompany.DataBind();
                }
            }
            else
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    grdCompany.DataSource = dataTable.DefaultView;
                    grdCompany.DataBind();
                }
                else
                {
                    dataTable.NewRow();
                    grdCompany.DataSource = dataTable.DefaultView;
                    grdCompany.DataBind();

                }
            }
        }

    }
}