using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_CreateStore : System.Web.UI.Page
{
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Context.User.Identity.Name;
        if (!Roles.IsUserInRole(userName, "Guest"))
        {
            if (!IsPostBack)
            {
                BindGrid();
                GetCompanies();
            }
        }
        else
        {
            tblStore.Visible = false;
            BindGrid();
            GetCompanies();
        }
    }
    public void GetCompanies()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCompanies = objBussLogic.GetCompanies();
        ddlCompanies.DataSource = dtCompanies.DefaultView;
        ddlCompanies.DataBind();
    }
    protected void btnCreateStore_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        if (!string.IsNullOrEmpty(txtCreateStore.Text))
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            blnResult = objBusinessLogic.CreateStore(txtCreateStore.Text, txtLocation.Text, Convert.ToInt32(ddlCompanies.SelectedItem.Value));
            if (blnResult)
            {
                lblCreateStoreStatus.Visible = true;
                lblCreateStoreStatus.ForeColor = Color.Green;
                lblCreateStoreStatus.Text = "Store created successfully.";
            }
            else
            {
                lblCreateStoreStatus.Visible = true;
                lblCreateStoreStatus.ForeColor = Color.Red;
                lblCreateStoreStatus.Text = "Operation Failed. Please Contact Administrator.";
            }
        }
        BindGrid();
    }
    public DataTable GetStores()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCompanies = objBussLogic.GetStores(GetUsersCompanyID());
        return dtCompanies;
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
    protected void grdStore_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdStore.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void grdStore_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strStoreID = grdStore.DataKeys[e.RowIndex].Values["StoreID"].ToString();
        TextBox txtStore = (TextBox)grdStore.Rows[e.RowIndex].FindControl("txtStoreName");
        TextBox txtLocation = (TextBox)grdStore.Rows[e.RowIndex].FindControl("txtLocation");
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdateStore(Convert.ToInt32(strStoreID), txtStore.Text, txtLocation.Text);
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtStore.Text + " updated successfully.";
            grdStore.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
            grdStore.EditIndex = -1;
        }
        BindGrid();
    }
    protected void grdStore_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdStore.EditIndex = -1;
        BindGrid();
    }
    protected void grdStore_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strStoreID = grdStore.DataKeys[e.RowIndex].Values["StoreID"].ToString();
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.DeleteStore(Convert.ToInt32(strStoreID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "Store deleted successfully.";
            grdStore.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Deletion failed. Please contact system administrator.";
            grdStore.EditIndex = -1;
        }
        BindGrid();

    }
    protected void grdStore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string StoreID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StoreID"));
            Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
            Button lnkbtnCancel = (Button)e.Row.FindControl("ButtonCancel");
            if (lnkbtnCancel != null)
            {
                lnkbtnCancel.Attributes.Add("onclick", " ");
            }
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + StoreID + "')");
            }
        }
        e.Row.Height = Unit.Pixel(20);
    }
    protected void grdStore_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void BindGrid()
    {
        DataTable dataTable = GetStores();
        if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                grdStore.DataSource = dataView;
                grdStore.DataBind();
            }
        }
        else
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                grdStore.DataSource = dataTable.DefaultView;
                grdStore.DataBind();
            }
            else
            {
                dataTable.NewRow();
                grdStore.DataSource = dataTable.DefaultView;
                grdStore.DataBind();

            }
        }
    }
    protected void grdStore_RowCreated(object sender, GridViewRowEventArgs e)
    {
        int sortColumnIndex = 0;

        if (e.Row.RowType == DataControlRowType.Header)
            sortColumnIndex = GetSortColumnIndex();

        if (sortColumnIndex != 1)
        {
            AddSortImage(sortColumnIndex, e.Row);
        }

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != grdStore.EditIndex)
        {
            // Programmatically reference the Edit and Delete LinkButtons
            Button EditButton = e.Row.FindControl("ButtonEdit") as Button;

            Button DeleteButton = e.Row.FindControl("ButtonDelete") as Button;

            EditButton.Visible = (User.IsInRole("VUP Admin") || User.IsInRole("Company Admin") || User.IsInRole("Store Admin"));
            DeleteButton.Visible = (User.IsInRole("VUP Admin") || User.IsInRole("Company Admin") || User.IsInRole("Store Admin"));
        }
    }
    protected int GetSortColumnIndex()
    {
        foreach (DataControlField field in grdStore.Columns)
        {
            if (field.SortExpression == grdStore.SortExpression)
                return grdStore.Columns.IndexOf(field);
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
            //grdStore.HeaderRow.Cells[0].Controls.Add(sortImage);
        }
    }
    protected void grdStore_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdStore.PageIndex = e.NewPageIndex;

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
            SortGridView("StoreName", ASCENDING);

        }
        else // this will get exectued if user clicks paging
        // after cliclking descending order
        {
            SortGridView("StoreName", DESCENDING);
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
        DataTable dataTable = GetStores();
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + direction;

            grdStore.DataSource = dataView;
            grdStore.DataBind();
        }
    }
    protected void grdStore_Sorting(object sender, GridViewSortEventArgs e)
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