<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="spendings.aspx.cs" Inherits="Elite_system.spendings" %>

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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
        <div class="container">
            <div class="row">
                <div class="COLR" style="float: right">
                    <div class="table-responsive">
                        <table class="table table-striped">
                            <tr style="background-color: #2f323a;">
                                <td class="auto-style1"></td>
                                <td style="width: 98px">

                                    <asp:Label ID="Label3" runat="server" Text="سندات الصرف" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                </td>
                            </tr>
                            <tr style="direction: rtl;">
                                <td>
                                    <asp:RadioButtonList runat="server" ID="RB_Sent_To" Width="170px">
                                        <asp:ListItem Value="صندوق" Selected="True">صندوق</asp:ListItem>
                                        <asp:ListItem Value="بنك">بنك</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="السند الى"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">

                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" Enabled="false" ID="Txt_Company" Text="شركة النخبة للمطالبات - طبربور" Width="300px"></asp:TextBox>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="عن شركة"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">

                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_VoucherNo" Width="300px"></asp:TextBox>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="رقم السند"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">

                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Voucher_Date" Width="300px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Voucher_Date" />
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="تاريخ السند"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Ammount" runat="server">
                                <td class="auto-style1">

                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Voucher_Value" Width="300px"></asp:TextBox>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="قيمة السند"></asp:Label>
                                </td>
                            </tr>
                            
                            <%--<tr id="Statement" runat="server">
                                <td class="auto-style1">

                                    <asp:TextBox AutoCompleteType="Enabled" runat="server" ID="Txt_Description" TextMode="MultiLine" Width="300px"> </asp:TextBox>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="الوصف"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="auto-style1">

                                    <asp:DropDownList ID="DDL_Description" runat="server" DataTextField="Description" DataValueField="ID" Width="300px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="الوصف"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td style="height: 26px">
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Invoice_No"  Width="300px"></asp:TextBox>

                                </td>
                                <td style="height: 26px; width: 98px;">
                                    <asp:Label runat="server" Text="رقم الفاتورة"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr id="Acounting_No" runat="server">
                                <td class="auto-style1">

                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Acounting_No" Width="300px"></asp:TextBox>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="رقم الحساب"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="LblErrors" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                </td>
                                <td></td>
                            </tr>

                            <tr style="direction: rtl;">
                                <td>
                                    <asp:Button ID="Btn_SaveReceipt" runat="server" Text="إدخال" Height="26px" OnClick="Btn_SaveReceipt_Click" />
                                    &nbsp; 	&nbsp; 
                                                <asp:Button ID="Btn_UpdateReceipt" runat="server" Text="تعديل" Height="26px" OnClick="Btn_UpdateReceipt_Click" />
                                    &nbsp; 	&nbsp; 
                                                
                                            <asp:Button ID="Btn_Delete" runat="server" Text="حذف" Height="26px" OnClick="Btn_Delete_Click" />
                                </td>
                                <td></td>
                            </tr>
                            <tr style="visibility:hidden" runat="server">
                                <td class="auto-style1">

                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_MainID" Width="300px"></asp:TextBox>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="Txt_MainID"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="COLR">
                    <div class="table-responsive" style="height: 500px;">
                        <table class="table-responsive">
                            <%--<asp:DropDownList ID="DDL_Medical_Name_Search" runat="server" DataTextField="Name" DataValueField="ID" Width="300px"></asp:DropDownList>
                            <asp:Button ID="Btn_Search" runat="server" Text="بحث" OnClick="Btn_Search_Click" />--%>

                            <asp:TextBox AutoCompleteType="Disabled" PlaceHolder="بحث من خلال رقم السند او رقم الفاتورة" runat="server" ID="Txt_SearchBondNo" Width="300px"></asp:TextBox>
                            <asp:Button ID="Btn_SearchBondNo" runat="server" Text="بحث" OnClick="Btn_SearchBondNo_Click" />
                            <asp:SqlDataSource runat="server" ID="SqlDataSource_Receipt" ConnectionString='<%$ ConnectionStrings:CONN %>' SelectCommand="select S.ID,C.Description,S.Invoice_No,S.Voucher_Date,S.Voucher_No,S.Voucher_Value from  [dbo].[Spendings] S inner join [Codes] C on S.Description=C.ID order by ID desc"></asp:SqlDataSource>
                            <asp:GridView ID="GridView_receipt" runat="server" CssClass="Grid" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_Receipt" OnSelectedIndexChanged="GridView_receipt_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="اختر" ControlStyle-ForeColor="Black" />
                                    <asp:BoundField DataField="ID" HeaderText=" ID" ReadOnly="True" SortExpression="ID" HeaderStyle-Width="150px"></asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="البيان" SortExpression="Description" HeaderStyle-Width="480px"></asp:BoundField>
                                    <asp:BoundField DataField="Invoice_No" HeaderText="رقم الفاتورة" SortExpression="Invoice_No" HeaderStyle-Width="230px"></asp:BoundField>
                                    <asp:BoundField DataField="Voucher_Date" HeaderText="تاريخ الصرف" SortExpression="Voucher_Date" HeaderStyle-Width="230px" DataFormatString="{0:dd-MM-yyyy }" ></asp:BoundField>
                                    <asp:BoundField DataField="Voucher_No" HeaderText="رقم السند" SortExpression="Voucher_No" HeaderStyle-Width="230px"></asp:BoundField>

                                    <asp:BoundField DataField="Voucher_Value" HeaderText="قيمة السند" ReadOnly="True" SortExpression="Voucher_Value" HeaderStyle-Width="150px"></asp:BoundField>


                                </Columns>
                            </asp:GridView>

                        </table>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <script src="scripts/select2.min.js"></script>


    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Description.ClientID%>").select2();
            <%--$("#<%=DDL_Medical_Name_Search.ClientID%>").select2();--%>
        }

    </script>
    <script>
        $(function () {

            $("#<%=DDL_Description.ClientID%>").select2();
            <%--$("#<%=DDL_Medical_Name_Search.ClientID%>").select2();--%>
        })
    </script>
</asp:Content>
