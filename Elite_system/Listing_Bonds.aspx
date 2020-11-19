<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Listing_Bonds.aspx.cs" Inherits="Elite_system.Listing_Bonds" %>

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
            <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">

                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1"></td>
                                        <td style="width: 98px">
                                            <asp:Label ID="Label3" runat="server" Text="سندات القيد" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Company" Width="46%" runat="server" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الشركة"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_Type" Width="46%" DataTextField="Description" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="نوع السند"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="height: 26px">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ID"></asp:TextBox>

                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="رقم السند"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="height: 26px">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Bond_Date"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Bond_Date" />
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="تاريخ السند"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_UpdateBonds" runat="server" Text="تعديل" Height="26px" OnClick="Btn_UpdateBonds_Click" />
                                        </td>

                                        <td>
                                            <asp:Button ID="Btn_SaveBonds" runat="server" Text="حفظ" Height="26px" OnClick="Btn_SaveBonds_Click" />

                                        </td>
                                    </tr>

                                </table>
                            </div>
                        </div>

                        <div class="COLR">
                            <div class="table-responsive">
                                <table class="table-responsive">
                                    <asp:DropDownList ID="DDL_Company_Search" Width="46%" runat="server" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                    <asp:Button ID="Btn_Search" runat="server" Text="بحث" OnClick="Btn_Search_Click" />

                                    <asp:GridView ID="GridView_Bonds" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_Bonds" OnSelectedIndexChanged="GridView_Bonds_SelectedIndexChanged" PageSize="3" PagerSettings-PageButtonCount="4">

                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                                            <asp:BoundField DataField="ID" HeaderText="رقم السند" ReadOnly="True" SortExpression="ID"></asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="اسم الشركة" SortExpression="Name"></asp:BoundField>
                                            <asp:BoundField DataField="Description" HeaderText="نوع السند" SortExpression="Description"></asp:BoundField>
                                            <asp:BoundField DataField="Bond_Date" HeaderText="تاريخ السند" SortExpression="Bond_Date" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>

                                        </Columns>
                                    </asp:GridView>

                                    <asp:SqlDataSource runat="server" ID="SqlDataSource_Bonds" ConnectionString='<%$ ConnectionStrings:CONN %>' SelectCommand="SELECT [ID], [Name], [Description], [Bond_Date] FROM [Bonds_GridView]"></asp:SqlDataSource>
                                </table>
                            </div>
                        </div>
                    </div>
                    <%-- <div style="float: right;    margin-right: 10%;">
                <asp:Label ID="Label2" runat="server" Text="---------------  الجزء الثاني   -------------------" Font-Bold="True" Font-Size="Larger"></asp:Label>
                    </div>--%>
                </div>

            </section>

            <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">

                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <%-- <div style="float: right; margin-right: 10%;">--%>

                                    <%--</div>--%>

                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1"></td>
                                        <td style="width: 98px">

                                            <asp:Label ID="Label4" runat="server" Text=" سندات القيد الفرعية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Trans"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الحركة"></asp:Label>
                                        </td>
                                        <td style="display: none">
                                            <asp:TextBox AutoCompleteType="Disabled" ID="Txt_SubID" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Debtor" Height="22px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="مدين"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Creditor"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="دائن"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Acounting_No"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم الحساب"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Accounting_Name"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="اسم الحساب"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Statement"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="البيان"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_UpdateSubBonds" runat="server" Text="تعديل" Height="26px" OnClick="Btn_UpdateSubBonds_Click" />
                                        </td>

                                        <td>
                                            <asp:Button ID="Btn_SaveSubBonds" runat="server" Text="حفظ" Height="26px" OnClick="Btn_SaveSubBonds_Click" />

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="COLR">
                            <div class="table-responsive">
                                <table class="table-responsive">


                                    <asp:GridView ID="GridView_SubBonds" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView_SubBonds_SelectedIndexChanged" OnPageIndexChanging="GridView_SubBonds_PageIndexChanging" PageSize="3" PagerSettings-PageButtonCount="4"></asp:GridView>
                                </table>
                            </div>
                        </div>
                    </div>
                    <%-- <div style="float: right;    margin-right: 10%;">
                <asp:Label ID="Label2" runat="server" Text="---------------  الجزء الثاني   -------------------" Font-Bold="True" Font-Size="Larger"></asp:Label>
                    </div>--%>
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
            $("#<%=DDL_Company.ClientID%>").select2();
            $("#<%=DDL_Company_Search.ClientID%>").select2();
            $("#<%=DDL_Type.ClientID%>").select2();

        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Company.ClientID%>").select2();
            $("#<%=DDL_Company_Search.ClientID%>").select2();
            $("#<%=DDL_Type.ClientID%>").select2();
        })
    </script>


      <%--rami لتغيير التاريخ من لوحة المفاتيح--%>
    <script>
        function DateField_KeyDown(dateField, CalendarExtender3) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender3);
                var enteredDate = dtbehav.get_selectedDate();


                if (enteredDate == null) {
                    enteredDate = new Date();
                }
                else {
                    advanceValue = 0;
                    switch (lastKeyCodeEntered) {
                        case 37:
                            advanceDays = -1;
                            break;
                        case 38:
                            advanceDays = -30;
                            break;
                        case 39:
                            advanceDays = 1;
                            break;
                        case 40:
                            advanceDays = 30;
                            break;
                    }
                    enteredDate.setDate(enteredDate.getDate() + advanceDays);
                }
                dateField.value = (enteredDate.getMonth() + 1) + "/" + enteredDate.getDate() + "/" + enteredDate.getFullYear();
                dtbehav.set_selectedDate(dateField.value);
            }
        }
    </script>
    <%--rami لتغيير التاريخ من لوحة المفاتيح--%>
</asp:Content>
