<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserToRole.aspx.cs" Inherits="Elite_system.Admin.UserToRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="form-horizontal">
        <h2 style="direction: rtl;">ربط المستخدم مع الصلاحية
        </h2>
    </div>
    <fieldset class="register" style="direction: rtl;">
        <legend>المستخدم والصلاحية</legend>
        <p>
            اختر صلاحية:
            <asp:DropDownList ID="ddlRole" Width="15%" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvRole" runat="server"
                ControlToValidate="ddlRole" Display="Dynamic"
                ErrorMessage="*"></asp:RequiredFieldValidator>
        </p>

        <p>
            اختر مستخدم:
            <asp:DropDownList ID="ddlUser" Width="15%" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvUser" runat="server"
                ControlToValidate="ddlUser" Display="Dynamic"
                ErrorMessage="*"></asp:RequiredFieldValidator>
        </p>
    </fieldset>
    <p style="direction: rtl;">
        <asp:Button ID="btnRoleAssign" runat="server" CssClass="btn btn-default" Text="حفظ"
            OnClick="btnRoleAssign_Click" />
    </p>
    <p style="direction: rtl;">
        <asp:GridView ID="grdUserRoles" Style="margin-top: -14%;" runat="server" AutoGenerateColumns="False" OnRowDeleting="grdRoleList_RowDeleting">
            <Columns>
                <asp:CommandField DeleteText="Delete Assign" ShowDeleteButton="True" />
                <asp:TemplateField HeaderText="المستخدم">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="UserNameLabel" Text=' <%# Eval("User.UserName")%>' />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="الصلاحية">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Eval("Role.RoleName")%>' />

                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="الوصف">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="DescriptionLabel" Text='<%# Eval("Role.Description")%>' />

                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
    <br />
    <br />
    <br />
</asp:Content>
