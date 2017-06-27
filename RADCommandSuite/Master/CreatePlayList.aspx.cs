using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_CreatePlayList : System.Web.UI.Page
{
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        DataTable dtRADDevices = objBusinessLogic.GetPlayLists(GetUsersCompanyID());
        if (!IsPostBack)
        {
            BindGrid();
        }

    }
    protected void grdPlayList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdPlayList.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void grdPlayList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strPlayListID = grdPlayList.DataKeys[e.RowIndex].Values["PlayListID"].ToString();
        TextBox txtPlayListName = (TextBox)grdPlayList.Rows[e.RowIndex].FindControl("txtPlayListName");
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdatePlayList(txtPlayListName.Text, Convert.ToInt32(strPlayListID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtPlayListName.Text + " updated successfully.";
            grdPlayList.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
            grdPlayList.EditIndex = -1;
        }
        BindGrid();
    }
    protected void grdPlayList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdPlayList.EditIndex = -1;
        BindGrid();
    }
    protected void grdPlayList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strCompanyID = grdPlayList.DataKeys[e.RowIndex].Values["PlayListID"].ToString();
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.DeletePlayList(Convert.ToInt32(strCompanyID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "PlayList deleted successfully.";
            grdPlayList.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Deletion failed. Please contact system administrator.";
            grdPlayList.EditIndex = -1;
        }
        BindGrid();

    }
    protected void grdPlayList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string CompanyID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PlayListID"));
            Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
            Button lnkbtnCancel = (Button)e.Row.FindControl("ButtonCancel");
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
    protected void grdPlayList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void BindGrid()
    {
        DataTable dataTable = GetPlayLists();
        if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                grdPlayList.DataSource = dataView;
                grdPlayList.DataBind();
            }
        }
        else
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                grdPlayList.DataSource = dataTable.DefaultView;
                grdPlayList.DataBind();
            }
            else
            {
                dataTable.NewRow();
                grdPlayList.DataSource = dataTable.DefaultView;
                grdPlayList.DataBind();

            }
        }
    }
    protected void grdPlayList_RowCreated(object sender, GridViewRowEventArgs e)
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
        foreach (DataControlField field in grdPlayList.Columns)
        {
            if (field.SortExpression == grdPlayList.SortExpression)
                return grdPlayList.Columns.IndexOf(field);
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
            //grdPlayList.HeaderRow.Cells[0].Controls.Add(sortImage);
        }
    }
    protected void grdPlayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPlayList.PageIndex = e.NewPageIndex;

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
            SortGridView("PlayListName", ASCENDING);

        }
        else // this will get exectued if user clicks paging
        // after cliclking descending order
        {
            SortGridView("PlayListName", DESCENDING);
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
        DataTable dataTable = GetPlayLists();
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + direction;

            grdPlayList.DataSource = dataView;
            grdPlayList.DataBind();
        }
    }
    protected void grdPlayList_Sorting(object sender, GridViewSortEventArgs e)
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
    public DataTable GetPlayLists()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        int companyID = GetUsersCompanyID();
        DataTable dtCompanies = objBussLogic.GetPlayLists(companyID);
        return dtCompanies;
    }
    protected void btnCreatePlayList_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        int companyID = GetUsersCompanyID();
        if (!string.IsNullOrEmpty(txtCreatePlayList.Text))
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            blnResult = objBusinessLogic.CreatePlayList(txtCreatePlayList.Text,companyID);
            if (blnResult)
            {
                lblCreatePlayListStatus.Visible = true;
                lblCreatePlayListStatus.ForeColor = Color.Green;
                lblCreatePlayListStatus.Text = "PlayList created successfully.";
            }
            else
            {
                lblCreatePlayListStatus.Visible = true;
                lblCreatePlayListStatus.ForeColor = Color.Red;
                lblCreatePlayListStatus.Text = "Operation Failed. Please Contact Administrator.";
            }
        }
        BindGrid();
    }
}