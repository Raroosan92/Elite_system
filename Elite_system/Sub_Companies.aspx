﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Sub_Companies.aspx.cs" Inherits="Elite_system.Sub_Companies" %>



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

        .auto-style2 {
            height: 26px;
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
            <section class="text-center" style="padding-top: 1%;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label2" runat="server" Text="إدخال الشركات الفرعية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:DropDownList runat="server" Width="172px" ID="DDL_Main_Company_ID" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Sub_Company_Name"></asp:TextBox>

                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الشركة الفرعية"></asp:Label>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="يرجى ادخال اسم الشركة الفرعية" ControlToValidate="Txt_Sub_Company_Name" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lbl_Result" runat="server" Text="" ForeColor="Red"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="حفظ" OnClick="Btn_Save_Click" Height="26px" />
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="text-center" style="padding-top: 1%;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label1" runat="server" Text="تعديل الشركات الفرعية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:DropDownList runat="server" Width="172px" ID="DDL_Main_Company_ID2" DataTextField="Name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DDL_Main_Company_ID2_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_Company_Branch" Width="172px" DataTextField="Sub_Company" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DDL_Company_Branch_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة الفرعية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Sub_Company_Name2"></asp:TextBox>

                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الشركة الفرعية"></asp:Label>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="يرجى ادخال اسم الشركة الفرعية" ControlToValidate="Txt_Sub_Company_Name2" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>


                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Button ID="Btn_Update" runat="server" Text="تعديل" OnClick="Btn_Update_Click" Height="26px" />

                                        </td>
                                         <td>
                                            <asp:Button ID="BTN_Delete" runat="server" Text="حذف"  Height="26px" OnClick="BTN_Delete_Click" />

                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_Result2" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="scripts/jquery-1.7.min.js"></script>
    <script src="scripts/select2.min.js"></script>

    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Company_Branch.ClientID%>").select2();
            $("#<%=DDL_Main_Company_ID.ClientID%>").select2();
            $("#<%=DDL_Main_Company_ID2.ClientID%>").select2();
        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Company_Branch.ClientID%>").select2();
            $("#<%=DDL_Main_Company_ID.ClientID%>").select2();
            $("#<%=DDL_Main_Company_ID2.ClientID%>").select2();
        })
    </script>
</asp:Content>
