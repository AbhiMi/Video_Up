<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InitialRADDeviceSetup.aspx.cs" Inherits="Pages_InitialRADDeviceSetup" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Setup New</title>
    <link href="../css/foundation.css" rel="stylesheet" />
    <link href="../css/mtree.css" rel="stylesheet" type="text/css">
    <style>
        .mtree-demo .mtree {
            background: transparent !important;
            margin: 20px auto;
            max-width: 320px;
            border-radius: 3px;
            color: #808080;
        }

        .mtree-skin-selector {
            text-align: center;
            background: transparent !important;
            padding: 10px 0 15px;
        }

            .mtree-skin-selector li {
                display: inline-block;
                float: none;
            }

            .mtree-skin-selector button {
                padding: 5px 10px;
                margin-bottom: 1px;
                background: #BBB;
            }

                .mtree-skin-selector button:hover {
                    background: #999;
                }

                .mtree-skin-selector button.active {
                    background: #999;
                    font-weight: bold;
                }

                .mtree-skin-selector button.csl.active {
                    background: #FFC000;
                }

        .h1 {
            font-family: 'Segoe UI', 'Century Gothic', 'Courier New';
            font-size: 48px;
            color: #808080;
            font-weight: 500;
        }

        .lilabel {
            margin-left: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="formCls" style="background: transparent !important;">
        <h1 align="center" class="h1">Welcome to Video-Up</h1>
        <br />
        <ul class="mtree transit">
            <li>
                <a href="#">Step 1: SetUp Location</a>
                <ul>
                    <li>
                        <span id="lbl">Pick a Store : </span>
                        <asp:DropDownList runat="server" ID="ddlStore" Width="250px" DataTextField="StoreName" DataValueField="StoreID">
                        </asp:DropDownList>
                        <input type="button" id="lnkAddSrote" class="button" value="Add New Store" />
                    </li>
                </ul>
            </li>
            <li>
                <a href="#">Step 2: Set up RAD Device Connection</a>
                <ul>
                    <li>
                        <span id="Label1" class="lilabel">Pick Connection Profile :  </span>
                        <asp:DropDownList runat="server" ID="ddlConnections" Width="200px" DataTextField="ProfileName" DataValueField="ProfileID">
                        </asp:DropDownList>
                        <input type="button" id="btnConnectionCreate" class="button" value="Add New Connection Profile" />
                    </li>
                </ul>
            </li>
            <li>
                <a href="#">Step 3: Export Connection Configurations to Thumb Drive</a>
                <ul>
                    <li>
                        <span id="lblStep3" class="lilabel">Please insert your thumb drive in the computer.</span>
                        <br />
                        <span id="lblStep31" class="lilabel" text="Now generate config file sand save to thumb drive." />
                        <asp:Button ID="Button1" runat="server" Text="Generate Config" CssClass="button" />
                    </li>
                </ul>
            </li>
            <li style="color: #808080;">
                <a href="#">Step 4: Power up RAD Devices</a>
                <ul>
                    <li>
                        <span id="lblStep4" runat="server" class="lilabel">Using supplied power adapter</span>
                    </li>
                </ul>

            </li>
            <li>
                <a href="#">Step 5: Transfer config file from Thumb drive to RAD Device</a>
                <ul>
                    <li>
                        <span id="lblStep5" class="lilabel">Now insert thumb drive into the RAD Devie and it will do the rest.</span>
                        <br />
                        <span id="lblStep51" class="lilbel">When transfer is complete, it will show green light on your RAD Device.</span>
                    </li>
                </ul>
            </li>
            <li>
                <a href="#">Step 6: Connect Rad Device to your Product Display Monitor</a>
                <ul>
                    <li>
                        <span id="lblStep6" class="lilabel">Now RAD Device can be turned off.</span>
                    </li>
                </ul>
            </li>
            <li>
                <a href="#">Step 7: Congratulations</a>
                <ul>
                    <li>
                        <span id="Label2" class="lilabel">Now you are ready to enter mission control of the RAD cycle and begin setting up you first video campaign.</span>
                    </li>
                </ul>
            </li>
        </ul>
        <script src="../js/jquery-1.9.1.min.js"></script>
        <link href="../css/jquery-ui.css" rel="stylesheet" />
        <script src="../js/jquery.velocity.min.js"></script>
        <script src="../js/jquery-ui.min.js"></script>
        <script src="../js/jquery-ui-1.10.2.custom.min.js"></script>
        <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
        <script src="../js/mtree.js"></script>
        <script type="text/javascript">
            function forceClick() {
                $("#hdnStore").val($("#txtStoreName").val())
                $("#hdnLocation").val($("#txtLocation").val())
                $("#btnHidden").click();
            }
            function forceClick1() {
                $("#hdnProfileName").val($("#TextBox3").val())
                $("#hdnWirelessName").val($("#TextBox4").val())
                $("#hdnConnectionType").val($("#TextBox5").val())
                $("#hdnPassword").val($("#TextBox6").val())
                $("#btnHidden1").click();
            }
            $("#crtStoreDialog").dialog({
                draggable: true
            });
            $("#crtStoreDialog").dialog({
                closeText: "hide"
            });
            $(function () {
                $("#crtStoreDialog").dialog({
                    autoOpen: false,
                });
                $("#lnkAddSrote").click(function () {
                    $("#crtStoreDialog").dialog({
                        autoOpen: true,
                        modal: false, resizable: true, draggable: true
                    });
                    return false;
                });
            });
            $("#crtStoreDialog").draggable('enable')
            $("#crtStoreDialog").resizable();

            /*2*/
            $("#crtConnectionDialog").dialog({
                draggable: true
            });
            $("#crtConnectionDialog").dialog({
                closeText: "hide"
            });
            $(function () {
                $("#crtConnectionDialog").dialog({
                    autoOpen: false,
                });
                $("#btnConnectionCreate").click(function () {
                    $("#crtConnectionDialog").dialog({
                        autoOpen: true, width: 400,
                        modal: false, resizable: true, draggable: true
                    });
                });
            });
            $("#crtConnectionDialog").parent().draggable().resizable();
        </script>
        <style>
            #btnHidden,#btnHidden1
            {
                display:none;
            }
            .button {
                background: #808080;
                color: #FFFFFF;
                /*border: solid 2px rgba(127, 128, 159, 1);*/
                border: none;
                border-radius: 5px;
                font-size: 14px;
                font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
                padding: 8px;
                font-weight: bold;
            }

            input[type="text"] {
                margin-bottom: 0px !important;
                line-height: 17px !important;
                padding: 5px 8px 6px 14px !important;
            }

            .ui-widget-header, .ui-state-default, ui-button {
                background: #ef7c31;
                border: 1px solid #b9cd6d;
                color: #FFFFFF;
                font-weight: bold;
            }
            /*
            .ui-icon {
                overflow: auto;
            }*/
            .dialog {
                height: 600px;
                width: 700px;
            }

            .ui-dialog {
                left: 100px !important;
                margin-top: 70px;
            }
        </style>
        <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" />
        <asp:Button ID="btnHidden1" runat="server" OnClick="btnHidden1_Click" />
        <asp:HiddenField runat="server" ID="hdnStore" />
         <asp:HiddenField runat="server" ID="hdnLocation" />

        <asp:HiddenField runat="server" ID="hdnProfileName" />
        <asp:HiddenField runat="server" ID="hdnWirelessName" />
        <asp:HiddenField runat="server" ID="hdnConnectionType" />
        <asp:HiddenField runat="server" ID="hdnPassword" />


        <div id="crtStoreDialog" title="Create New Store" class="dialog" style="width: 600px;">
            <table>
                <tr>
                    <td>StoreName:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtStoreName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Location:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLocation"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Region:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlRegions" DataTextField="RegionName" DataValueField="RegionID"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Area:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlAreas" DataTextField="AreaName" DataValueField="AreaID"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="button" OnClientClick="forceClick();" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="crtConnectionDialog" title="Create New Connection" class="dialog">
            <table>
                <tr>
                    <td>Connection Profile Name:</td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>WireLessName(SSID):</td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Connection Type:</td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBox5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBox6"></asp:TextBox>
                    </td>
                </tr>
                <tr style="visibility:hidden">
                    <td>Company Encrypted Id:</td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBox7"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button runat="server" ID="Button2" Text="Save" OnClientClick="forceClick1();" CssClass="button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
