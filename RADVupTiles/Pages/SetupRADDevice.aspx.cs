using NativeWifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADCommonServices;
using System.Data;
using RADBusinessLogicLayer;
using System.Xml;
using System.IO;

public partial class Pages_SetupRADDevice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BusinessLogic objBussLogic = new BusinessLogic();
            CommonFunctions commFunc = new CommonFunctions();
            DataTable dtEntID = objBussLogic.GetEncryptedID(commFunc.GetUsersCompanyID(Context));

            if (dtEntID != null && dtEntID.Rows.Count > 0)
            {
                foreach (DataRow dr in dtEntID.Rows)
                {
                    companyPass.Text = dr["EncryptedID"].ToString();
                }
            }

            lstNetworks.Items.Clear();

            WlanClient client = new WlanClient();
            DataTable dt = new DataTable();
            dt.Columns.Add("NetworkName");
            DataRow myDataRow;
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    Wlan.Dot11Ssid ssid = network.dot11Ssid;
                    string networkName = Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
                    myDataRow = dt.NewRow();
                    myDataRow["NetworkName"] = networkName;
                    dt.Rows.Add(myDataRow);
                }
            }
            lstNetworks.DataTextField = "NetworkName";
            lstNetworks.DataValueField = "NetworkName";
            lstNetworks.DataSource = dt;
            lstNetworks.DataBind();
        }
    }
    protected void btnGenerateConfig_Click(object sender, EventArgs e)
    {
        StringWriter stringwriter = new StringWriter();
        XmlTextWriter writer = new XmlTextWriter(stringwriter);
        writer.WriteStartElement("Configuration");
        writer.WriteElementString("Wireless", lstNetworks.SelectedValue);
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
}