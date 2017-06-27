using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_CreateChannel : System.Web.UI.Page
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
    protected void btnCreateChannel_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        if (!string.IsNullOrEmpty(txtCreateChannel.Text))
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            blnResult = objBusinessLogic.CreateChannel(txtCreateChannel.Text, GetUsersCompanyID());
            if (blnResult)
            {
                lblCreateChannelStatus.Visible = true;
                lblCreateChannelStatus.ForeColor = Color.Green;
                lblCreateChannelStatus.Text = "Channel created successfully.";
            }
            else
            {
                lblCreateChannelStatus.Visible = true;
                lblCreateChannelStatus.ForeColor = Color.Red;
                lblCreateChannelStatus.Text = "Operation Failed. Please Contact Administrator.";
            }
        }
        BindGrid();
    }
    public DataTable GetChannels()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCompanies = objBussLogic.GetChannels(GetUsersCompanyID());
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
    protected void grdChannel_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdChannel.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void grdChannel_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strChannelID = grdChannel.DataKeys[e.RowIndex].Values["ChannelID"].ToString();
        TextBox txtChannelName = (TextBox)grdChannel.Rows[e.RowIndex].FindControl("txtChannelName");
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdateChannel(Convert.ToInt32(strChannelID), txtChannelName.Text);
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtChannelName.Text + " updated successfully.";
            grdChannel.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
            grdChannel.EditIndex = -1;
        }
        BindGrid();
    }
    protected void grdChannel_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdChannel.EditIndex = -1;
        BindGrid();
    }
    protected void grdChannel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strChannelID = grdChannel.DataKeys[e.RowIndex].Values["ChannelID"].ToString();
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.DeleteChannel(Convert.ToInt32(strChannelID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "Channel deleted successfully.";
            grdChannel.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Deletion failed. Please contact system administrator.";
            grdChannel.EditIndex = -1;
        }
        BindGrid();

    }
    protected void grdChannel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ChannelID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ChannelID"));
            Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
            Button lnkbtnCancel = (Button)e.Row.FindControl("ButtonCancel");
            if (lnkbtnCancel != null)
            {
                lnkbtnCancel.Attributes.Add("onclick", " ");
            }
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + ChannelID + "')");
            }
        }
        e.Row.Height = Unit.Pixel(20);
    }
    protected void grdChannel_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void BindGrid()
    {
        DataTable dataTable = GetChannels();
        if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                grdChannel.DataSource = dataView;
                grdChannel.DataBind();
            }
        }
        else
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                grdChannel.DataSource = dataTable.DefaultView;
                grdChannel.DataBind();
            }
            else
            {
                dataTable.NewRow();
                grdChannel.DataSource = dataTable.DefaultView;
                grdChannel.DataBind();

            }
        }
    }
    protected void grdChannel_RowCreated(object sender, GridViewRowEventArgs e)
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
        foreach (DataControlField field in grdChannel.Columns)
        {
            if (field.SortExpression == grdChannel.SortExpression)
                return grdChannel.Columns.IndexOf(field);
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
            //grdChannel.HeaderRow.Cells[0].Controls.Add(sortImage);
        }
    }
    protected void grdChannel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdChannel.PageIndex = e.NewPageIndex;

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
            SortGridView("ChannelName", ASCENDING);

        }
        else // this will get exectued if user clicks paging
        // after cliclking descending order
        {
            SortGridView("ChannelName", DESCENDING);
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
        DataTable dataTable = GetChannels();
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + direction;

            grdChannel.DataSource = dataView;
            grdChannel.DataBind();
        }
    }
    protected void grdChannel_Sorting(object sender, GridViewSortEventArgs e)
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