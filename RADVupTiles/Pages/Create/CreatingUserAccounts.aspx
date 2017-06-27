<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="CreatingUserAccounts.aspx.cs" Inherits="Pages_Create_CreatingUserAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        div h3 {
            width: 105px;
            margin-top: -30px;
            margin-left: 50px;
        }

        .label {
            font-style: normal;
        }
        .CancelButton
        {
            float:left;
        }
        #footer, #footer a{
            width: 100%; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:SiteMapPath ID="SiteMap1" runat="server" CssClass="SiteMap" PathSeparator=" " />
    <div style="padding: 20px; border: 3px solid gray; border-radius: 10px; margin: 60px 25px 0 0px; background: transparent url(../img/wallpapers/Brushed-Metal.jpg);
         position: relative; background-repeat: repeat;width:71%;float:right;min-height:405px">
        <h3>Create User</h3>
        <div class="myClass">
            <table>
                <asp:CreateUserWizard ID="RegisterUser" runat="server" DisplayCancelButton="True" OnCreatingUser="RegisterUser_CreatingUser" OnCreatedUser="RegisterUser_CreatedUser"
                    ContinueDestinationPageUrl="~/Default.aspx" CancelButtonStyle-CssClass="button CancelButton" ContinueButtonStyle-CssClass="button" FinishPreviousButtonStyle-CssClass="button" CreateUserButtonStyle-CssClass="button">
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                            <ContentTemplate>
                                <table style="border: 1px solid black; width: 750px;">
                                    <tr style="border: 1px solid black">
                                        <td style="padding: 2px 20px 0 200px; border: 1px solid black" colspan="2" class="label">
                                            Sign Up for Your New Account
                                            <%--<asp:Label ID="lblSignUpText" runat="server" Text="" CssClass="label" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-right: 20px; padding-top: 2px; border: 1px solid black">
                                            <asp:Label runat="server" AssociatedControlID="UserName" ID="UserNameLabel" CssClass="label">User Name:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="UserName"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="RegisterUser" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid black">
                                            <asp:Label runat="server" AssociatedControlID="Password" ID="PasswordLabel" CssClass="label">Password:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" TextMode="Password" ID="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="RegisterUser" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid black">
                                            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="label" ID="ConfirmPasswordLabel">Confirm Password:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" TextMode="Password" ID="ConfirmPassword"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required." ValidationGroup="RegisterUser" ToolTip="Confirm Password is required." ID="ConfirmPasswordRequired">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid black">
                                            <asp:Label runat="server" AssociatedControlID="Email" ID="EmailLabel" CssClass="label">E-mail:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="Email"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required." ValidationGroup="RegisterUser" ToolTip="E-mail is required." ID="EmailRequired">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: 1px solid black">
                                            <asp:Label runat="server" AssociatedControlID="SelectCompany" ID="Label1" CssClass="label">Company:</asp:Label></td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="SelectCompany" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="SelectCompany" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="The Company is required"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <asp:PlaceHolder runat="server" ID="SecurityQuestionAndAnswer">
                                        <tr>
                                            <td style="border: 1px solid black">
                                                <asp:Label runat="server" AssociatedControlID="Question" ID="QuestionLabel" CssClass="label">Security Question:</asp:Label></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="Question"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Question" ErrorMessage="Security question is required." ValidationGroup="RegisterUser" ToolTip="Security question is required." ID="QuestionRequired">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: 1px solid black">
                                                <asp:Label runat="server" AssociatedControlID="Answer" ID="AnswerLabel" CssClass="label">Security Answer:</asp:Label></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="Answer"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Answer" ErrorMessage="Security answer is required." ValidationGroup="RegisterUser" ToolTip="Security answer is required." ID="AnswerRequired">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </asp:PlaceHolder>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ErrorMessage="The Password and Confirmation Password must match." Display="Dynamic" ValidationGroup="RegisterUser" ID="PasswordCompare"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal runat="server" ID="ErrorMessage" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>
                <asp:Label runat="server" ID="InvalidUserNameOrPasswordMessage"
                    Visible="false" ForeColor="Red" EnableViewState="false">
                </asp:Label>
            </table>
        </div>
    </div>
     <div id="footer">
        <span class="vupFooterText"><a href="..\ContactUs.aspx">Contact Us</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Privacy</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Terms of Use</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupCopyright"> &copy;Video-Up</span>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

