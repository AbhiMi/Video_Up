using RADBusinessLogicLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class SetupNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strCompanyID = Convert.ToString(GetUsersCompanyID());
            SqlDataSource2.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
            SqlDataSource1.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
            SqlDataSource4.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
            SqlDataSource5.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
            SqlDataSource7.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
            SqlDataSource8.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
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
    
    private void DisplayMessage(bool isError, string text)
        {
            if (isError)
            {
                this.Label3.Text = text;
            }
            else
            {
                this.Label4.Text = text;
            }
        }
    
    
    private void DisplayMessage(string text)
    {
        rgRegions.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
    }

    private void SetMessage(string message)
    {
        gridMessage = message;
    }

    private string gridMessage = null;

    protected void rgCompany_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            if (!(e.Item is GridEditFormInsertItem))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                GridEditManager manager = item.EditManager;
                GridTextBoxColumnEditor editor = manager.GetColumnEditor("CompanyID") as GridTextBoxColumnEditor;
                editor.TextBoxControl.Enabled = false;
            }
        }
    }

    protected void rgRegions_PreRender(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(gridMessage))
        {
            DisplayMessage(gridMessage);
        }
    }
    protected void rgRegions_InsertCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridEditableItem)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            //here editedItem.SavedOldValues will be the dictionary which holds the
            //predefined values

            //Prepare new dictionary object
            Hashtable newValues = new Hashtable();
            e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
            //the newValues instance is the new collection of key -> value pairs
            //with the updated ny the user data
        }
    }
    protected void rgRegions_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.KeepInEditMode = true;
            e.ExceptionHandled = true;
            DisplayMessage(true, "Region " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RegionID"] + " cannot be updated due to invalid data.");
        }
        else
        {
            DisplayMessage(false, "Region " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RegionID"] + " updated");
        }
    }
    protected void rgRegions_ItemInserted(object sender, GridInsertedEventArgs e)
    {
            if (e.Exception != null)
            {

                e.ExceptionHandled = true;
                SetMessage("Region cannot be inserted. Reason: " + e.Exception.Message);

            }
            else
            {
                SetMessage("New Region is inserted!");
            }
    }
    protected void rgRegions_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            if (!(e.Item is GridEditFormInsertItem))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                GridEditManager manager = item.EditManager;
                GridTextBoxColumnEditor editor = manager.GetColumnEditor("RegionID") as GridTextBoxColumnEditor;
                editor.TextBoxControl.Enabled = false;
            }
        }
    }
    protected void rgRegions_ItemDeleted(object source, GridDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            DisplayMessage(true, "Region " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RegionID"] + " cannot be deleted");
        }
        else
        {
            DisplayMessage(false, "Region " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RegionID"] + " deleted");
        }
    }

    protected void rgArea_ItemInserted(object sender, GridInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            SetMessage("Area cannot be inserted. Reason: " + e.Exception.Message);

        }
        else
        {
            SetMessage("New Area is inserted!");
        }
    }
    protected void rgArea_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            if (!(e.Item is GridEditFormInsertItem))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                GridEditManager manager = item.EditManager;
                GridTextBoxColumnEditor editor = manager.GetColumnEditor("AreaID") as GridTextBoxColumnEditor;
                editor.TextBoxControl.Enabled = false;
            }
        }
    }
    protected void rgArea_InsertCommand(object sender, GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;
        DropDownList ddlRegion = editedItem.FindControl("ddlRegion") as DropDownList;
//        New.Value = ddlRegion.SelectedValue;
    }   
    protected void rgArea_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode && !(e.Item is GridEditFormInsertItem))              
        {
            GridEditableItem item = e.Item as GridEditableItem;
            // access/modify the edit item template settings here
            RadDropDownList ddlRegion = item.FindControl("ddlRegion") as RadDropDownList;
            GridEditableItem editForm = (GridEditableItem)e.Item;
            string strCurrentRegion;
            try
            {
                strCurrentRegion = ((System.Data.DataRowView)(editForm.DataItem)).Row.ItemArray[3].ToString();
                if (strCurrentRegion != null)
                {
                    ddlRegion.SelectedValue = strCurrentRegion.Trim();
                }
            }
            catch
            {
            }
        }
    }
    protected void rgArea_ItemDeleted(object source, GridDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            DisplayMessage(true, "Area " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AreaID"] + " cannot be deleted");
        }
        else
        {
            DisplayMessage(false, "Area " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AreaID"] + " deleted");
        }
    }
    protected void rgArea_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.KeepInEditMode = true;
            e.ExceptionHandled = true;
            DisplayMessage(true, "Area " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AreaID"] + " cannot be updated due to invalid data.");
        }
        else
        {
            DisplayMessage(false, "Area " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AreaID"] + " updated");
        }
    }

    protected void rgStores_InsertCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridEditableItem)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            //here editedItem.SavedOldValues will be the dictionary which holds the
            //predefined values

            //Prepare new dictionary object
            Hashtable newValues = new Hashtable();
            e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
            //the newValues instance is the new collection of key -> value pairs
            //with the updated ny the user data
        }
    }
    protected void rgStores_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.KeepInEditMode = true;
            e.ExceptionHandled = true;
            DisplayMessage(true, "Store " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["StoreID"] + " cannot be updated due to invalid data.");
        }
        else
        {
            DisplayMessage(false, "Store " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["StoreID"] + " updated");
        }
    }
    protected void rgStores_ItemInserted(object sender, GridInsertedEventArgs e)
    {
        if (e.Exception != null)
        {

            e.ExceptionHandled = true;
            SetMessage("Store cannot be inserted. Reason: " + e.Exception.Message);

        }
        else
        {
            SetMessage("New Store is inserted!");
        }
    }
    protected void rgStores_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            if (!(e.Item is GridEditFormInsertItem))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                GridEditManager manager = item.EditManager;
                GridTextBoxColumnEditor editor = manager.GetColumnEditor("StoreID") as GridTextBoxColumnEditor;
                editor.TextBoxControl.Enabled = false;
            }
        }
    }
    protected void rgStores_ItemDeleted(object source, GridDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            DisplayMessage(true, "Store " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["StoreID"] + " cannot be deleted");
        }
        else
        {
            DisplayMessage(false, "Store " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["StoreID"] + " deleted");
        }
    }

    protected void rgRADDevices_InsertCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridEditableItem)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            //here editedItem.SavedOldValues will be the dictionary which holds the
            //predefined values

            //Prepare new dictionary object
            Hashtable newValues = new Hashtable();
            e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
            //the newValues instance is the new collection of key -> value pairs
            //with the updated ny the user data
        }
    }
    protected void rgRADDevices_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.KeepInEditMode = true;
            e.ExceptionHandled = true;
            DisplayMessage(true, "RADDevice " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RADDeviceID"] + " cannot be updated due to invalid data.");
        }
        else
        {
            DisplayMessage(false, "RADDevice " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RADDeviceID"] + " updated");
        }
    }
    protected void rgRADDevices_ItemInserted(object sender, GridInsertedEventArgs e)
    {
        if (e.Exception != null)
        {

            e.ExceptionHandled = true;
            SetMessage("RADDevice cannot be inserted. Reason: " + e.Exception.Message);

        }
        else
        {
            SetMessage("New RADDevice is inserted!");
        }
    }
    protected void rgRADDevices_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            if (!(e.Item is GridEditFormInsertItem))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                GridEditManager manager = item.EditManager;
                GridTextBoxColumnEditor editor = manager.GetColumnEditor("RADDeviceID") as GridTextBoxColumnEditor;
                editor.TextBoxControl.Enabled = false;
            }
        }
    }
    protected void rgRADDevices_ItemDeleted(object source, GridDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            DisplayMessage(true, "RADDevice " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RADDeviceID"] + " cannot be deleted");
        }
        else
        {
            DisplayMessage(false, "RADDevice " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RADDeviceID"] + " deleted");
        }
    }

    protected void SqlDataSource2_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        e.Command.Parameters["@CompanyID"].Value = GetUsersCompanyID();
    }
    protected void SqlDataSource3_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        e.Command.Parameters["@RegionID"].Value = 104;
        RadDropDownList ddlRegion = rgArea.EditItems[0].FindControl("ddlRegion") as RadDropDownList;
    }
    protected void SqlDataSource5_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        e.Command.Parameters["@CompanyID"].Value = GetUsersCompanyID();
    }
    protected void SqlDataSource7_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        e.Command.Parameters["@CompanyID"].Value = GetUsersCompanyID();
    }

}
namespace MyControls
{
    public delegate object EvaluateParameterEventHandler(object sender, EventArgs e);

    public class DelegateParameter : Parameter
    {
        private System.Web.UI.Control _parent;
        public System.Web.UI.Control Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private event EvaluateParameterEventHandler _evaluateParameter;
        public event EvaluateParameterEventHandler EvaluateParameter
        {
            add { _evaluateParameter += value; }
            remove { _evaluateParameter -= value; }
        }

        protected override object Evaluate(System.Web.HttpContext context, System.Web.UI.Control control)
        {
            return _evaluateParameter(this, EventArgs.Empty);
        }
    }
}