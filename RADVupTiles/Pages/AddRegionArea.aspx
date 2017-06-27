<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRegionArea.aspx.cs" Inherits="Pages_AddRegionArea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" />
    <link href="../css/demo_style.css" rel="stylesheet" />
    <link href="../css/smart_wizard_vertical.css" rel="stylesheet" />
    <script src="../js/jquery-1.4.2.min.js"></script>
    <script src="../js/jquery.smartWizard-2.0.min.js"></script>
    <script src="../Scripts/jquery.autocomplete.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>
    <link href='https://fonts.googleapis.com/css?family=Carrois+Gothic+SC' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
    <script type="text/javascript">

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement && window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
        function CloseModal() {
            GetRadWindow().close();
            refreshParentPage();
            //RadLocationDialog.close();
            // alert(2)
            //locationDialogOpen();
        }

        function locationDialogOpen() {
            var a = document.getElementById('hdnCompanyId').value;
            window.radopen("Locations.aspx?CompanyID=" + a, "RadLocationDialog");
            //window.radopen("Location.aspx?CompanyID=" + 4, "RadLocationDialog");
            return false;
        }

        function refreshParentPage() {
            GetRadWindow().BrowserWindow.location.reload();
        }

        function redirectParentPage(url) {
            GetRadWindow().BrowserWindow.document.location.href = "Locations.aspx?CompanyID=" + a, "RadLocationDialog";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
            <asp:HiddenField runat="server" ID="hdnCompanyId" Value="0" />
            <center><asp:Label runat="server" ID="lblMsg" Font-Bold="true" /></center>
            <div id="divRegion" runat="server">
                <table align="center">
                    <caption style="color: #ef7c31; font-size: larger; font-weight: bold;">
                        Add New Region
                    <tr>
                        <td>Region Name:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtRegionName" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRegionName" ErrorMessage="*" ForeColor="Red" />
                        </td>
                    </tr>
                        <tr>
                            <td><%--IsDefault:--%></td>
                            <td>
                                <asp:CheckBox runat="server" ID="chkIsDefaultArea" Visible="false" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button runat="server" ID="btnsaveRegion" Text="Save" CssClass="button" OnClick="btnsaveRegion_Click" />
                            </td>
                        </tr>
                    </caption>
                </table>
            </div>

            <div id="divArea" runat="server">
                <table align="center">
                    <caption style="color: #ef7c31; font-size: larger; font-weight: bold;">
                        Add New Area
                    <tr>
                        <td>Area Name:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtArea" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtArea" ErrorMessage="*" ForeColor="Red" />
                        </td>
                    </tr>
                        <tr>
                            <td><%--IsDefault:--%></td>
                            <td>
                                <asp:CheckBox runat="server" ID="chkIsDefaultregion" Visible="false" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="button" OnClick="btnSaveArea_Click" />
                            </td>
                        </tr>
                    </caption>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
