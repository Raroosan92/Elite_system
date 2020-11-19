<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="Elite_system.Admin.AddRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h2 style="direction: rtl;">انشاء صلاحية</h2>
    </div>
    <fieldset class="register" style="direction: rtl;">
        <legend>معلومات الصلاحيات</legend>
        <div>
            نوع الصلاحية
            </div>
        <div>
            <asp:TextBox AutoCompleteType="Disabled" ID="txtRoleName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvRoleName" runat="server"
                ControlToValidate="txtRoleName" Display="Dynamic" ValidationGroup="Role"
                ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
    </fieldset>
    <div style="direction: rtl;">
        <asp:Button ID="btnCreateRole" runat="server" CssClass="btn btn-default" Text="حفظ" ValidationGroup="Role"
            OnClick="btnCreateRole_Click" />
    </div>
    <div>

        <asp:GridView ID="grdRoleList" Style="width: 38%; margin-top: -40px;" runat="server" AutoGenerateColumns="False" OnRowDeleting="grdRoleList_RowDeleting" AllowPaging="True" OnPageIndexChanging="grdRoleList_PageIndexChanging">
            <Columns>
                <asp:CommandField DeleteText="Delete Role" ShowDeleteButton="True" />
                <asp:TemplateField HeaderText="نوع الصلاحية">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
