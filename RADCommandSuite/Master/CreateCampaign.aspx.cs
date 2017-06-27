using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_CreateCampaign : System.Web.UI.Page
{
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    protected void btnCreateCampaign_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        if (!string.IsNullOrEmpty(txtCreateCampaign.Text))
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            blnResult = objBusinessLogic.CreateCampaign(txtCreateCampaign.Text, GetUsersCompanyID());
            if (blnResult)
            {
                lblCreateCampaignStatus.Visible = true;
                lblCreateCampaignStatus.ForeColor = Color.Green;
                lblCreateCampaignStatus.Text = "Campaign created successfully.";
            }
            else
            {
                lblCreateCampaignStatus.Visible = true;
                lblCreateCampaignStatus.ForeColor = Color.Red;
                lblCreateCampaignStatus.Text = "Operation Failed. Please Contact Administrator.";
            }
        }
        BindGrid();
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
    public DataTable GetCampaigns(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCompanies = objBussLogic.GetCampaigns(GetUsersCompanyID());
        return dtCompanies;
    }
    protected void grdCampaign_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdCampaign.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void grdCampaign_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strCampaignID = grdCampaign.DataKeys[e.RowIndex].Values["CampaignID"].ToString();
        TextBox txtCampaignName = (TextBox)grdCampaign.Rows[e.RowIndex].FindControl("txtCampaignName");
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdateCampaign(Convert.ToInt32(strCampaignID), txtCampaignName.Text);
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtCampaignName.Text + " updated successfully.";
            grdCampaign.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
            grdCampaign.EditIndex = -1;
        }
        BindGrid();
    }
    protected void grdCampaign_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdCampaign.EditIndex = -1;
        BindGrid();
    }
    protected void grdCampaign_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strStoreID = grdCampaign.DataKeys[e.RowIndex].Values["CampaignID"].ToString();
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.DeleteCampaign(Convert.ToInt32(strStoreID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "Campaign deleted successfully.";
            grdCampaign.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Deletion failed. Please contact system administrator.";
            grdCampaign.EditIndex = -1;
        }
        BindGrid();

    }
    protected void grdCampaign_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string CampaignID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CampaignID"));
            Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
            Button lnkbtnCancel = (Button)e.Row.FindControl("ButtonCancel");
            if (lnkbtnCancel != null)
            {
                lnkbtnCancel.Attributes.Add("onclick", " ");
            }
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + CampaignID + "')");
            }
        }
        e.Row.Height = Unit.Pixel(20);
    }
    protected void grdCampaign_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void BindGrid()
    {
        DataTable dataTable = GetCampaigns(GetUsersCompanyID());
        if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                grdCampaign.DataSource = dataView;
                grdCampaign.DataBind();
            }
        }
        else
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                grdCampaign.DataSource = dataTable.DefaultView;
                grdCampaign.DataBind();
            }
            else
            {
                dataTable.NewRow();
                grdCampaign.DataSource = dataTable.DefaultView;
                grdCampaign.DataBind();

            }
        }
    }
    protected void grdCampaign_RowCreated(object sender, GridViewRowEventArgs e)
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
        foreach (DataControlField field in grdCampaign.Columns)
        {
            if (field.SortExpression == grdCampaign.SortExpression)
                return grdCampaign.Columns.IndexOf(field);
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
            //grdCampaign.HeaderRow.Cells[0].Controls.Add(sortImage);
        }
    }
    protected void grdCampaign_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCampaign.PageIndex = e.NewPageIndex;

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
            SortGridView("CampaignName", ASCENDING);

        }
        else // this will get exectued if user clicks paging
        // after cliclking descending order
        {
            SortGridView("CampaignName", DESCENDING);
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
        DataTable dataTable = GetCampaigns(GetUsersCompanyID());
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + direction;

            grdCampaign.DataSource = dataView;
            grdCampaign.DataBind();
        }
    }
    protected void grdCampaign_Sorting(object sender, GridViewSortEventArgs e)
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
}