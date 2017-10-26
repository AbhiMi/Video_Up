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

public partial class Pages_CreateRADDevice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Context.User.Identity.Name;
        if (!Roles.IsUserInRole(userName, "Guest"))
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        else
        {
            tblRADDevice.Visible = false;
            BindGrid();
        }
    }
    private void BindGrid()
    {
        DataTable dtRADDevices = GetRADDevices();
        if (dtRADDevices != null && dtRADDevices.Rows.Count > 0)
        {
            grdRADDevice.DataSource = dtRADDevices.DefaultView;
            grdRADDevice.DataBind();
        }
        else
        {
            dtRADDevices.NewRow();
            grdRADDevice.DataSource = dtRADDevices.DefaultView;
            grdRADDevice.DataBind();
        }
    }
    public DataTable GetCompanies()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCompanies = objBussLogic.GetCompanies();
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
    public DataTable GetRADDevices()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtRADDevices = objBussLogic.GetRADDevices(GetUsersCompanyID());
        return dtRADDevices;
    }
    protected void btnAddRADDevice_Click(object sender, EventArgs e)
    {
        bool blnResult = false;
        //bool blnAsscteResult = false;
        if (!string.IsNullOrEmpty(txtRADDeviceName.Text) && !string.IsNullOrEmpty(txtRADDeviceInfo.Text))
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            blnResult = objBusinessLogic.InsertRADDeviceInfo(txtRADDeviceName.Text, txtRADDeviceInfo.Text, GetUsersCompanyID(), ddlScreenFlip.SelectedItem.Text, ddlScreenOrientation.SelectedItem.Text);
            //blnAsscteResult = objBusinessLogic.AssociateRADDeviceToCompany(Convert.ToInt32(ddlCompanies.SelectedValue), txtRADDeviceName.Text);
            if (blnResult)
            {
                lblAddRADDeviceStatus.Visible = true;
                lblAddRADDeviceStatus.ForeColor = Color.Green;
                lblAddRADDeviceStatus.Text = "RAD Device Info added successfully.";
            }
            else
            {
                lblAddRADDeviceStatus.Visible = true;
                lblAddRADDeviceStatus.ForeColor = Color.Red;
                lblAddRADDeviceStatus.Text = "Operation Failed. Please Contact Administrator.";
            }
            BindGrid();
        }
    }
    protected void grdRADDevice_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdRADDevice.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void grdRADDevice_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strRADDeviceID = grdRADDevice.DataKeys[e.RowIndex].Values["RADDeviceID"].ToString();
        TextBox txtRADDeviceName = (TextBox)grdRADDevice.Rows[e.RowIndex].FindControl("txtDeviceInfo");
        TextBox txtRADDeviceDesc = (TextBox)grdRADDevice.Rows[e.RowIndex].FindControl("txtDescription");
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdateRADDevice(Convert.ToInt32(strRADDeviceID), txtRADDeviceName.Text, txtRADDeviceDesc.Text);
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtRADDeviceName.Text + " updated successfully.";
            grdRADDevice.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
            grdRADDevice.EditIndex = -1;
        }
        BindGrid();
    }
    protected void grdRADDevice_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdRADDevice.EditIndex = -1;
        BindGrid();
    }
    protected void grdRADDevice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strRADDeviceID = grdRADDevice.DataKeys[e.RowIndex].Values["RADDeviceID"].ToString();
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.DeleteRADDevice(Convert.ToInt32(strRADDeviceID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "RAD Device deleted successfully.";
            grdRADDevice.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Deletion failed. Please contact system administrator.";
            grdRADDevice.EditIndex = -1;
        }
        BindGrid();
    }
    protected void grdRADDevice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string CompanyID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RADDeviceID"));
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
    }
    protected void grdRADDevice_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void grdRADDevice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdRADDevice.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void grdRADDevice_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
        }
        BindGrid();
    }
    protected void grdRADDevice_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != grdRADDevice.EditIndex)
        {
            // Programmatically reference the Edit and Delete LinkButtons
            ImageButton EditButton = e.Row.FindControl("ButtonEdit") as ImageButton;

            ImageButton DeleteButton = e.Row.FindControl("ButtonDelete") as ImageButton;

            EditButton.Visible = (User.IsInRole("VUP Admin") || User.IsInRole("Company Admin") || User.IsInRole("Store Admin"));
            DeleteButton.Visible = (User.IsInRole("VUP Admin") || User.IsInRole("Company Admin") || User.IsInRole("Store Admin"));
        }
    }
}