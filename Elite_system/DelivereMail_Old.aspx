﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="DelivereMail_Old.aspx.cs" Inherits="Elite_system.DelivereMail" %>



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
    <link href="css/thumbnail-slider.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

            <section class="text-center" style="padding-top: 1%; direction: ltr;">

                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped">
                                     <tr style="background-color: #2f323a;">
                                        <td class="auto-style1">

                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label ID="Label4" runat="server" Text="الدفع" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="DDL_Medical_Name" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DDL_Medical_Name_SelectedIndexChanged" Width="300px"></asp:DropDownList>


                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>

                                            <asp:DropDownList ID="DDL_Main_Company" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" Width="300px" OnSelectedIndexChanged="DDL_Main_Company_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="مرسل الى"></asp:Label>
                                        </td>
                                    </tr>

                                     <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Mail_Type" runat="server" Width="300px" AutoPostBack="True" DataTextField="Description" DataValueField="ID" OnSelectedIndexChanged="DDL_Mail_Type_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="نوع البريد"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="تسليم" OnClick="Btn_Save_Click" />
                                        </td>

                                        <td></td>
                                    </tr>

                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="Medical_Name" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LL" runat="server" Text="الجهة الطبية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="Send_To" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="مرسل الى"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="Mail_type" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="نوع البريد"></asp:Label>
                                        </td>
                                    </tr>
                                     <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="lbl_count" runat="server" Text=" " Font-Size="26px" ForeColor="red"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="العدد الكلي"></asp:Label>
                                        </td>
                                         
                                    </tr>
                                     <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="Mail_ID" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="التسلسل"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="text-center my-5" style="direction: ltr; margin-right:10%">
                <div class="container">
                    <div class="row">
                    </div>
                    <div id="Main_GV" style="overflow-y: scroll; height: 572px;">
                        <asp:GridView ID="GridView" runat="server" CssClass="Grid" AllowPaging="false" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="اختر" ControlStyle-ForeColor="Black" />
                                <%--<asp:BoundField DataField="id" HeaderText="التسلسل" ReadOnly="True" HeaderStyle-CssClass="ColumnGV" ItemStyle-CssClass="ColumnGV" SortExpression="ID" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </section>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="Btn_Save" />--%>
        </Triggers>
    </asp:UpdatePanel>
    <script src="scripts/jquery-1.7.min.js"></script>
    <script src="scripts/select2.min.js"></script>
    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {

            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Main_Company.ClientID%>").select2();
            $("#<%=DDL_Mail_Type.ClientID%>").select2();
        }

    </script>
    <script>
        $(function () {

            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Main_Company.ClientID%>").select2();
            $("#<%=DDL_Mail_Type.ClientID%>").select2();
        })
    </script>


</asp:Content>


