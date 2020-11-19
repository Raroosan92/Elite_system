<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Elite_system.Admin.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h2 style="direction:rtl;">استرجاع كلمة المرور</h2>
    </div>

    <asp:Label ID="Msg" runat="server" Style="float:right; direction:rtl;font-size: x-large;" CssClass="control-label" ForeColor="maroon" /><br />
    <br />  
    <p style="direction: rtl;">
        اسم المستخدم
   <%-- <asp:TextBox AutoCompleteType="Disabled" ID="UsernameTextBox" CssClass="form-control" Columns="30" runat="server" AutoPostBack="true" />
        <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server"
            ControlToValidate="UsernameTextBox" ForeColor="red"
            Display="Static" ErrorMessage="Required" /><br />--%>

        اختر مستخدم:
            <asp:DropDownList ID="ddlUser" Width="15%" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvUser" runat="server"
                ControlToValidate="ddlUser" Display="Dynamic"
                ErrorMessage="*"></asp:RequiredFieldValidator>

          اكتب كلمة المرور:
        <asp:TextBox AutoCompleteType="Disabled" ID="PasswordTextBox" TextMode="Password" CssClass="form-control" Columns="30" runat="server" />
    <%--    <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server"
            ControlToValidate="PasswordTextBox" ForeColor="red"
            Display="Static" ErrorMessage="Required" />--%><br />

        <p class="submitButton" style="direction: rtl;">
            <asp:Button ID="ResetPasswordButton" CssClass="btn btn-default" Text="استعادة كلمة المرور"
                OnClick="ResetPassword_OnClick" runat="server" />
        </p>

    <p class="submitButton" style="direction: rtl;">
            <asp:Button ID="UnlockUser" CssClass="btn btn-default" Text="تفعيل المستخدم"
                OnClick="UnlockUser_Click" runat="server" />
        </p>
    <p />
</asp:Content>

