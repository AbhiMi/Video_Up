using RADBusinessLogicLayer;
using Telerik.Web.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADBusinessLogicLayer;
using System.Web.Security;
using RADVupTiles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.IO;
using NativeWifi;
using RADCommonServices;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_SetupNew : System.Web.UI.Page
{
    public string strCompanyID, userName = string.Empty;

    private DataTable GetusersData()
    {
        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetUsersByCompanyID", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_CompnayID", Convert.ToInt32(strCompanyID));
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(dt);
                }
            }
        }
        return dt;
    }
    private DataTable GetUsersInRole(int companyID, string selectedRoleName)
    {
        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetUsersInRole", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                cmd.Parameters.AddWithValue("@RoleName", selectedRoleName);
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(dt);
                }
            }
        }
        return dt;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userName = Membership.GetUserNameByEmail(Context.User.Identity.Name);
            if (!Roles.IsUserInRole(userName, "Company Admin") && !Roles.IsUserInRole(userName, "VUP Admin"))
            {
               
            }
            if (!Roles.IsUserInRole(userName, "VUP Admin"))
            {
                RadWizard1.ActiveStepIndex = 1;
                radStepCompany.Visible = false;
                radStepCompany.CssClass = "hidden";
            }
            if (!IsPostBack)
            {

                CommonFunctions commFunc = new CommonFunctions();
                strCompanyID = hdnCompnayID.Value = Convert.ToString(commFunc.GetUsersCompanyID(Context));

                //avoiding sharing Session variables between tabs in one browser
                //SessionID.Value = Guid.NewGuid().ToString();

                //var dr1 = (from d in dtUserWithRoles.AsEnumerable()
                //           where d["UserName"].ToString().Equals(userName)
                //           select d);
                //if (dr1 != null)
                //{
                //    DataTable dtt = dr1.CopyToDataTable();
                //}
                // Bind the users and roles 

                // Check the selected user's roles 

                // Display those users belonging to the currently selected role 
                if (!string.IsNullOrEmpty(strCompanyID) && strCompanyID != "0")
                {
                    SqlDataSource1.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
                    SqlDataSource2.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
                    SqlDataSource3.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
                    SqlDataSource4.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
                    SqlDataSource5.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
                    SqlDataSource7.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
                    SqlDataSource8.SelectParameters["CompanyID"].DefaultValue = strCompanyID;
                }
                #region RADDeviceSetup
                BusinessLogic objBussLogic = new BusinessLogic();
                DataTable dtEntID = objBussLogic.GetEncryptedID(commFunc.GetUsersCompanyID(Context));

                if (dtEntID != null && dtEntID.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtEntID.Rows)
                    {
                        companyPass.Text = dr["EncryptedID"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex);
        }
                #endregion
    }

    protected void btnGenerateConfig_Click(object sender, EventArgs e)
    {
        StringWriter stringwriter = new StringWriter();
        XmlTextWriter writer = new XmlTextWriter(stringwriter);
        writer.WriteStartElement("Configuration");
        writer.WriteElementString("Wireless", txtConnectionName.Text);
        writer.WriteElementString("Password", networkPassword.Text);
        writer.WriteElementString("EncryptedCompanyID", companyPass.Text);
        writer.WriteElementString("ConnectionType", ddlConnType.SelectedText);
        writer.WriteEndElement();
        XmlDocument docSave = new XmlDocument();
        docSave.LoadXml(stringwriter.ToString());
        writer.Flush();
        MemoryStream stream = new MemoryStream();
        docSave.Save(stream);

        byte[] byteArray = stream.ToArray();
        Response.AppendHeader("Content-Disposition", "filename=Configuration.xml");
        Response.AppendHeader("Content-Length", byteArray.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.BinaryWrite(byteArray);
        writer.Close();
        //write the path where you want to save the Xml file
        //docSave.Save(@"c:\Configuration.xml");        
    }

    private void DisplayMessage(bool isError, string text)
    {
        if (isError)
        {
        }
        else
        {
        }
    }


    private void DisplayMessage(string text)
    {
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
            //Button cancel = (Button)e.Item.FindControl("CancelButton");
            //cancel.Style["padding-left"] = "70px";

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


    protected void rgRADDevices_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridDataItem)
        //{
        //    GridDataItem dataItem = (GridDataItem)e.Item;
        //    TableCell myCell = dataItem["IsDefault"];
        //    if ((myCell.Text == "1"))
        //    {
        //        //dataItem.BackColor = System.Drawing.Color.Red;  
        //        dataItem.ForeColor = System.Drawing.Color.Red;
        //        dataItem.Font.Bold = true;
        //    }
        //}
        if (e.Item is GridEditableItem && e.Item.IsInEditMode && !(e.Item is GridEditFormInsertItem))
        {
            GridEditableItem item = e.Item as GridEditableItem;
            // access/modify the edit item template settings here
            RadDropDownList ddlStore = item.FindControl("ddlStores") as RadDropDownList;
            GridEditableItem editForm = (GridEditableItem)e.Item;
            string StrddlStore;
            try
            {
                StrddlStore = ((System.Data.DataRowView)(editForm.DataItem)).Row.ItemArray[4].ToString();
                if (StrddlStore != null)
                {
                    ddlStore.SelectedText = StrddlStore.Trim();
                }
            }
            catch
            {
            }
        }
    }

    protected void rgStores_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode && !(e.Item is GridEditFormInsertItem))
        {
            GridEditableItem item = e.Item as GridEditableItem;
            // access/modify the edit item template settings here
            RadDropDownList ddlRegion = item.FindControl("ddlRegion") as RadDropDownList;
            RadDropDownList ddlArea = item.FindControl("ddlArea") as RadDropDownList;
            GridEditableItem editForm = (GridEditableItem)e.Item;
            string strCurrentRegion, strCurrentArea;
            try
            {
                strCurrentRegion = ((System.Data.DataRowView)(editForm.DataItem)).Row.ItemArray[4].ToString();
                strCurrentArea = ((System.Data.DataRowView)(editForm.DataItem)).Row.ItemArray[6].ToString();
                if (strCurrentRegion != null)
                {
                    ddlRegion.SelectedText = strCurrentRegion.Trim();
                    ddlArea.SelectedText = strCurrentArea.Trim();
                }
            }
            catch
            {
            }
        }
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
                    ddlRegion.SelectedText = strCurrentRegion.Trim();
                }
            }
            catch
            {
            }
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
        if (e.Item is GridDataItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            TableCell myCell = dataItem["IsDefault"];
            if ((myCell.Text == "1"))
            {
                //dataItem.BackColor = System.Drawing.Color.Red;  
                dataItem.ForeColor = System.Drawing.Color.Red;
                dataItem.Font.Bold = true;
            }
        }

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
        CommonFunctions commFunc = new CommonFunctions();
        e.Command.Parameters["@CompanyID"].Value = commFunc.GetUsersCompanyID(Context);
    }
    protected void SqlDataSource3_InsertingAndUpdating(object sender, SqlDataSourceCommandEventArgs e)
    {
        if (ViewState["RegionId"] != null)
            e.Command.Parameters["@RegionID"].Value = Convert.ToInt32(ViewState["RegionId"].ToString());
        else
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            DataTable dt = objBusinessLogic.GetRegions(Convert.ToInt32(hdnCompnayID.Value));
            e.Command.Parameters["@RegionID"].Value = Convert.ToInt32(dt.Rows[0]["RegionID"].ToString());
        }
        e.Command.Parameters["@CompanyID"].Value = Convert.ToInt32(hdnCompnayID.Value.ToString());
    }
    protected void SqlDataSource5_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        if (ViewState["AreaID"] != null)
            e.Command.Parameters["@AreaID"].Value = Convert.ToInt32(ViewState["AreaID"].ToString());
        else
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            DataTable dt = objBusinessLogic.GetAreaStores(Convert.ToInt32(hdnCompnayID.Value));
            e.Command.Parameters["@AreaID"].Value = Convert.ToInt32(dt.Rows[0]["AreaID"].ToString());
        }
        if (ViewState["RegionId"] != null)
            e.Command.Parameters["@RegionID"].Value = Convert.ToInt32(ViewState["RegionId"].ToString());
        else
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            DataTable dt = objBusinessLogic.GetRegions(Convert.ToInt32(hdnCompnayID.Value));
            e.Command.Parameters["@RegionID"].Value = Convert.ToInt32(dt.Rows[0]["RegionID"].ToString());
        }
        e.Command.Parameters["@CompanyID"].Value = Convert.ToInt32(hdnCompnayID.Value.ToString());
    }
    protected void SqlDataSource7_InsertingAndUpdateting(object sender, SqlDataSourceCommandEventArgs e)
    {
        if (ViewState["StoreID"] != null)
        {
            e.Command.Parameters["@StoreID"].Value = Convert.ToInt32(ViewState["StoreID"].ToString());
        }
        else
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            DataTable dt = objBusinessLogic.GetStores(Convert.ToInt32(hdnCompnayID.Value));
            e.Command.Parameters["@StoreID"].Value = Convert.ToInt32(dt.Rows[0]["StoreID"].ToString());
        }
        e.Command.Parameters["@CompanyID"].Value = Convert.ToInt32(hdnCompnayID.Value.ToString());
    }
    protected void ddlStores_SelectedIndexChanged(object sender, DropDownListEventArgs e)
    {
        ViewState["StoreID"] = e.Value.ToString();
    }
    protected void ddlRegion_SelectedIndexChanged(object sender, DropDownListEventArgs e)
    {
        ViewState["RegionId"] = e.Value.ToString();
    }
    protected void ddlArea_SelectedIndexChanged(object sender, DropDownListEventArgs e)
    {
        ViewState["AreaID"] = e.Value.ToString();
    }
    protected void SqlDataSource5_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {
        if (ViewState["AreaID"] != null)
            e.Command.Parameters["@AreaID"].Value = Convert.ToInt32(ViewState["AreaID"].ToString());
        else
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            DataTable dt = objBusinessLogic.GetAreaStores(Convert.ToInt32(hdnCompnayID.Value));
            e.Command.Parameters["@AreaID"].Value = Convert.ToInt32(dt.Rows[0]["AreaID"].ToString());
        }
        if (ViewState["RegionId"] != null)
            e.Command.Parameters["@RegionID"].Value = Convert.ToInt32(ViewState["RegionId"].ToString());
        else
        {
            BusinessLogic objBusinessLogic = new BusinessLogic();
            DataTable dt = objBusinessLogic.GetRegions(Convert.ToInt32(hdnCompnayID.Value));
            e.Command.Parameters["@RegionID"].Value = Convert.ToInt32(dt.Rows[0]["RegionID"].ToString());
        }
        e.Command.Parameters["@CompanyID"].Value = Convert.ToInt32(hdnCompnayID.Value.ToString());
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

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {
                //rgStores.MasterTableView.SortExpressions.Clear();
                //rgStores.MasterTableView.GroupByExpressions.Clear();
                //rgStores.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                //rgStores.MasterTableView.SortExpressions.Clear();
                //rgStores.MasterTableView.GroupByExpressions.Clear();
                //rgStores.MasterTableView.CurrentPageIndex = rgStores.MasterTableView.PageCount - 1;
            }
        }

        protected override object Evaluate(System.Web.HttpContext context, System.Web.UI.Control control)
        {
            return _evaluateParameter(this, EventArgs.Empty);
        }

    }
}