<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Elite_system.Admin.RegisterUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/css/select2.min.css" rel="stylesheet" />
    <div class="form-horizontal">
        <h2 style="direction: rtl;">انشاء مستخدم جديد
        </h2>
    </div>
    <p style="direction: rtl;">
        يجب ان يكون طول كلمة المرور  <%= Membership.MinRequiredPasswordLength %> حروف .
    </p>
    <asp:Label ID="Msg" ForeColor="Red" CssClass="control-label" Style="direction: rtl; font-size: larger; font-size: x-large;" runat="server" /><br />
    <asp:Label ID="lblWorning" ForeColor="Red" CssClass="control-label" Style="direction: rtl; font-size: larger; font-size: x-large;" runat="server" /><br />
    <div class="accountInfo">
        <fieldset class="register" style="direction: rtl;">
            <legend>معلومات المستخدم</legend>
            <p>
                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
                <asp:DropDownList ID="DDL_Medical_Name" runat="server" Enabled="false" DataTextField="Name" DataValueField="ID" Width="300px" AutoPostBack="True" OnTextChanged="DDL_Medical_Name_TextChanged"></asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lblUserName" runat="server" CssClass="control-label" AssociatedControlID="txtUserName">اسم المستخدم</asp:Label>
                <asp:TextBox AutoCompleteType="Disabled" ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                    CssClass="failureNotification" ErrorMessage="*" ToolTip="User Name is required."
                    ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
            </p>
            <%--<p>
                <asp:Label ID="lblEmail" runat="server" CssClass="control-label" AssociatedControlID="txtEmail">ايميل</asp:Label>
                <asp:TextBox AutoCompleteType="Disabled" ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    CssClass="failureNotification" ErrorMessage="*" ToolTip="E-mail is required."
                    ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
            </p>--%>
            <p>
                <asp:Label ID="lblPassword" runat="server" CssClass="control-label" AssociatedControlID="txtPassword">كلمة المرور</asp:Label>
                <asp:TextBox AutoCompleteType="Disabled" ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    CssClass="failureNotification" ErrorMessage="*" ToolTip="Password is required."
                    ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblConfirmPassword" runat="server" CssClass="control-label" AssociatedControlID="txtConfirmPassword">تأكيد كلمة المرور</asp:Label>
                <asp:TextBox AutoCompleteType="Disabled" ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                    ErrorMessage="*" ID="ConfirmPasswordRequired" runat="server"
                    ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cfvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                    CssClass="failureNotification" Display="Dynamic" ErrorMessage="كلمة المرور غير متطابقة"
                    ValidationGroup="RegisterUserValidationGroup"></asp:CompareValidator>
            </p>
        </fieldset>
        <p class="submitButton" style="direction: rtl;">
            <asp:Button ID="btnCreateUser" runat="server" CssClass="btn btn-default" OnClick="btnCreateUser_Click" Text="انشاء مستخدم"
                ValidationGroup="RegisterUserValidationGroup" />
        </p>
    </div>

    <div class="accountInfo">
        <div class="register" style="direction: rtl;">
            <legend>حذف مستخدم سابق</legend>
            اختر مستخدم:
            <asp:DropDownList ID="ddlUser" Width="15%" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvUser" runat="server"
                ControlToValidate="ddlUser" Display="Dynamic"
                ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
        <div class="submitButton" style="direction: rtl;">
            <asp:Button ID="Btn_Delete" runat="server" Text="حذف المستخدم" OnClick="Btn_Delete_Click" />
        </div>
    </div>


       <script src="../Scripts/jquery-1.7.min.js"></script>
    <script src="../scripts/select2.min.js"></script>



    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=ddlUser.ClientID%>").select2();
        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=ddlUser.ClientID%>").select2();
        })
    </script>
</asp:Content>
