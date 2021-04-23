<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Payment_Of_Claims.aspx.cs" Inherits="Elite_system.Payment_Of_Claims" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"  UpdateMode="Conditional">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <section class="text-center" style="padding-top: 1%; direction: ltr;">

                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table id="SubClaimTable" runat="server" class="table table-striped">
                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1"></td>
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
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <%--  <asp:DropDownList ID="DDL_Sub_Company" runat="server" AutoPostBack="True" Width="300px" DataTextField="Sub_Company" DataValueField="ID">
                                            </asp:DropDownList>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_PayAmmount" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="المبلغ المدفوع"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="nav-justified" style="direction: rtl;">
                                            <asp:FileUpload ID="fileImages" Multiple="Multiple" runat="server" Width="236px" />
                                            <asp:Repeater ID="Rpt_Download" Visible="false" runat="server">
                                                <ItemTemplate>
                                                    <a href="Download.ashx?file=\\UploadedImages<%# DataBinder.Eval(Container, "DataItem.attach_Path") %>" style="font-size: large; color: black;">تنزيل</a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>

                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="الملفات المرفقة"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="دفع" OnClick="Btn_Save_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Btn_Upload" runat="server" Text="تحميل المرفق" OnClick="Btn_Upload_Click" />
                                        </td>
                                    </tr>

                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="main_ClaimID" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LL" runat="server" Text="رقم المطالبة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="Sub_ClaimID" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="رقم المطالبة الفرعية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="Patient_Name" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="اسم المريض"></asp:Label>
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
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="text-center my-5" style="direction: ltr; margin-right: 10%">
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
            <asp:PostBackTrigger ControlID="Btn_Upload" />
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
        }

    </script>
    <script>
        $(function () {

            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Main_Company.ClientID%>").select2();
        })
    </script>


</asp:Content>

