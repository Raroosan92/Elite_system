<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="Elite_system.Receipt" %>

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

                                            <asp:Label ID="Label3" runat="server" Text="سندات القبض" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
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
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="Txt_SubID"></asp:RequiredFieldValidator>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_SubID" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم السند الفرعي"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style1">
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="Txt_Receipt_Date"></asp:RequiredFieldValidator>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Receipt_Date" Width="300px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Receipt_Date" />
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="تاريخ السند"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="Ammount" runat="server">
                                        <td class="auto-style1">
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="Txt_Value"></asp:RequiredFieldValidator>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Value" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="المبلغ"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="auto-style1">
                                            <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DDL_Medical_Name"
                                                CssClass="alertFont" ErrorMessage="*" Operator="NotEqual"
                                                ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">*</asp:CompareValidator>--%>
                                            <asp:DropDownList ID="DDL_Medical_Name" runat="server" DataTextField="Name" DataValueField="ID" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDL_Medical_Name_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الاسم"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="Acounting_No" runat="server">
                                        <td class="auto-style1">
                                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="Txt_Acounting_No"></asp:RequiredFieldValidator>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Acounting_No" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم الحساب"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="Statement" runat="server">
                                        <td class="auto-style1">
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="Txt_Statement"></asp:RequiredFieldValidator>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Statement" TextMode="MultiLine" Width="300px"> </asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="البيان"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             <asp:Label ID="LblErrors" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 26px">
                                            <asp:TextBox AutoCompleteType="Disabled" Visible="false" runat="server" ID="Txt_MainID" BackColor="#CCCCCC" ReadOnly="True" Width="300px"></asp:TextBox>

                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="  رقم السند الرئيسي" Visible="false"></asp:Label>
                                        </td>
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
                                </table>
                            </div>
                        </div>

                        <div class="COLR">
                            <div class="table-responsive" style="height: 500px;">
                                <table class="table-responsive">
                                    <asp:DropDownList ID="DDL_Medical_Name_Search" runat="server" DataTextField="Name" DataValueField="ID" Width="300px"></asp:DropDownList>
                                    <asp:Button ID="Btn_Search" runat="server" Text="بحث" OnClick="Btn_Search_Click"  />
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource_Receipt" ConnectionString='<%$ ConnectionStrings:CONN %>' SelectCommand="SELECT [ID],[Medical_TypeName],[TypeDescription],[Bond_Date],[Debtor],[Creditor],[Description],[Claim_ID] FROM [dbo].[V_Listing_Bonds] Where TypeDescription=N'قبض' order by ID desc"></asp:SqlDataSource>
                                    <asp:GridView ID="GridView_receipt" runat="server" CssClass="Grid" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_Receipt" OnSelectedIndexChanged="GridView_receipt_SelectedIndexChanged" >
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" SelectText="اختر" ControlStyle-ForeColor="Black" />
                                            <asp:BoundField DataField="Medical_TypeName" HeaderText="الجهة الطبية" SortExpression="Medical_TypeName" HeaderStyle-Width="430px"></asp:BoundField>
                                             <%--<asp:BoundField DataField="Claim_ID" HeaderText=" السند الفرعي" ReadOnly="True" SortExpression="Claim_ID" HeaderStyle-Width="150px"></asp:BoundField>--%>
                                            <%--<asp:BoundField DataField="Debtor" HeaderText="المدين" ReadOnly="True" SortExpression="Debtor"></asp:BoundField>--%>
                                            <asp:BoundField DataField="Creditor" HeaderText="الدائن" SortExpression="Creditor"></asp:BoundField>
                                            <asp:BoundField DataField="Description" HeaderText="البيان" SortExpression="Description" HeaderStyle-Width="280px"></asp:BoundField>
                                            <asp:BoundField DataField="ID" HeaderText=" الرقم الرئيسي" ReadOnly="True" SortExpression="ID" HeaderStyle-Width="150px"></asp:BoundField>
                                           <%-- <asp:BoundField DataField="Bond_Date" HeaderText="تاريخ السند" SortExpression="Bond_Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-Width="150px"></asp:BoundField>--%>
                                            <%--<asp:BoundField DataField="TypeDescription" HeaderText="نوع السند" SortExpression="TypeDescription"></asp:BoundField>--%>





                                        </Columns>
                                    </asp:GridView>

                                </table>
                            </div>
                        </div>

                    </div>
                </div>

            </section>


            <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="text-center my-5" runat="server" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">

                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1"></td>
                                        <td style="width: 98px">

                                            <asp:Label ID="Label4" runat="server" Text=" الفواتير الفرعية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ID2"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم السند"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="height: 26px">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Receipt_Date"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Receipt_Date" />
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="تاريخ السند"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Value" Height="22px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="المبلغ"></asp:Label>
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
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Statement"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="البيان"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:Button ID="Btn_Update_SubReceipt" runat="server" Text="تعديل" Height="26px" OnClick="Btn_Update_SubReceipt_Click" />
                                        </td>

                                        <td>
                                            <asp:Button ID="Btn_Save_SubReceipt" runat="server" Text="حفظ" Height="26px" OnClick="Btn_Save_SubReceipt_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="COLR">
                            <div class="table-responsive">
                                <table class="table-responsive">

                                    <asp:GridView ID="GridView_SubReceipt" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView_SubReceipt_SelectedIndexChanged"  OnPageIndexChanging="GridView_SubReceipt_PageIndexChanging" PageSize="3" PagerSettings-PageButtonCount="4"></asp:GridView>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </section>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="scripts/select2.min.js"></script>


    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Medical_Name_Search.ClientID%>").select2();
        }

    </script>
    <script>
        $(function () {

            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Medical_Name_Search.ClientID%>").select2();
        })
    </script>

    
        <%--rami لتغيير التاريخ من لوحة المفاتيح--%>
    <script>
        function DateField_KeyDown(dateField, CalendarExtender2) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender2);
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
