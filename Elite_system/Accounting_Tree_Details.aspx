<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Accounting_Tree_Details.aspx.cs" Inherits="Elite_system.Accounting_Tree_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .Drop {
            background-color: gold;
            font-weight: 600;
            border-style: groove;
        }

        .auto-style1 {
            width: 107%;
        }

        .COLR {
            width: 50%;
        }

        @media only screen and (max-width: 1000px) {
            .COLR {
                width: 50%;
                display: contents;
            }
        }

        .Grid {
            width: 100%;
            text-align: center;
            direction: rtl;
        }
    </style>




    <link href="Content/css/select2.min.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>


            <section class="text-center" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right; direction: rtl">
                            <div class="table-responsive">
                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label2" runat="server" Text="إدخال تفصيلات الشجرة المحاسبية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DDL_Medical_Name"
                                                CssClass="alertFont" ErrorMessage="الرجاء اختيار الجهة الطبية" Operator="NotEqual"
                                                ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">الرجاء اختيار الجهة الطبية</asp:CompareValidator>
                                            <asp:DropDownList ID="DDL_Medical_Name" runat="server" DataTextField="Name" DataValueField="ID" AutoPostBack="True" Width="200px"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الحساب الرئيسي"></asp:Label>
                                        </td>
                                        <td class="auto-style1">

                                            <asp:DropDownList runat="server" ID="DDL_Parent" DataTextField="Description" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DDL_Parent_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="المستوى"></asp:Label>
                                        </td>
                                        <td class="auto-style1">

                                            <asp:DropDownList runat="server" ID="DDL_Parent_Level" DataTextField="Description" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DDL_Parent_Level_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الحساب"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_Account" DataTextField="Description" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DDL_Account_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="إدخال" OnClick="Btn_Save_Click" Height="26px" />
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Update" runat="server" Text="تعديل" OnClick="Btn_Update_Click" />
                                        </td>


                                    </tr>

                                </table>


                            </div>
                        </div>


                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table-responsive">

                                    <asp:GridView ID="GV" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GV_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" SelectText="اختر" />
                                            <asp:BoundField DataField="Medical_Types_ID" HeaderText="التسلسل" ReadOnly="True" SortExpression="Medical_Types_ID" />
                                            <asp:BoundField DataField="Medical_Types" HeaderText="الجهة الطبية " SortExpression="Medical_Types" />
                                            <asp:BoundField DataField="Sub_Account" HeaderText="الحساب " SortExpression="Sub_Account" />
                                        </Columns>
                                    </asp:GridView>

                                </table>
                                <br />

                            </div>
                        </div>
                    </div>
                </div>
            </section>

        </ContentTemplate>
    </asp:UpdatePanel>


    <script src="scripts/select2.min.js"></script>
    <script>
        $(function () {

            $("#<%=DDL_Medical_Name.ClientID%>").select2();

        })
    </script>
</asp:Content>
