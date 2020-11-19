<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="Elite_system.Companies" %>

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

        .Ch {
            direction: rtl;
        }

        .Radio {
            margin-left: 70%;
        }
    </style>




    <link href="Content/css/select2.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <%--<asp:Label ID="Label1" runat="server" Text="الشركات" Font-Bold="True" Font-Size="Larger"></asp:Label> 

    <br />
    <br />--%>

    <section class="text-center my-5" style="padding-top: 1%;">
        <div class="container">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; direction: ltr; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label1" runat="server" Text="إدخال الشركات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Name" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الاسم"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Contract_Date"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Contract_Date" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="تاريخ التعاقد"></asp:Label>

                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="CBL_Contracting_Type" runat="server" CssClass="Ch">
                                                <asp:ListItem Value="279">الشركات المتعاقدة مع الجهات الطبية</asp:ListItem>
                                                <asp:ListItem Value="280">الشركات المتعاقدة مع الشركة لتوزيع البريد</asp:ListItem>
                                                <asp:ListItem Value="281">الشركات المتعاقدة مع الشركة لاحضار المطالبات</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="نوع التعاقد"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Address"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="العنوان"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Phone"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الهاتف"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Mobile"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الخلوي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 26px">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Fax"></asp:TextBox>
                                        </td>
                                        <td style="height: 26px">
                                            <asp:Label runat="server" Text="الفاكس"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_P_O_Box"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الرمز البريدي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList runat="server" CssClass="Ch Radio" ID="RB_Stamps">
                                                <asp:ListItem Value="1">يضع طوابع</asp:ListItem>
                                                <asp:ListItem Value="0">لا يضع طوابع</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الطوابع"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="حفظ" OnClick="Btn_Save_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                                            <%--<asp:Button ID="Btn_Update" runat="server" Text="تعديل" OnClick="Btn_Update_Click" />--%>
                                        </td>
                                    </tr>

                                </table>

                            </div>
                        </div>
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">

                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; direction: ltr; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label4" runat="server" Text="تعديل الشركات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Main_Company" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DDL_Main_Company_SelectedIndexChanged" Width="300px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Name2" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الاسم"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Contract_Date2"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Contract_Date2" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="تاريخ التعاقد"></asp:Label>

                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="CBL_Contracting_Type2" runat="server" CssClass="Ch">
                                                <asp:ListItem Value="279">الشركات المتعاقدة مع الجهات الطبية</asp:ListItem>
                                                <asp:ListItem Value="280">الشركات المتعاقدة مع الشركة لتوزيع البريد</asp:ListItem>
                                                <asp:ListItem Value="281">الشركات المتعاقدة مع الشركة لاحضار المطالبات</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="نوع التعاقد"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Address2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="العنوان"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Phone2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الهاتف"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Mobile2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الخلوي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 26px">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Fax2"></asp:TextBox>
                                        </td>
                                        <td style="height: 26px">
                                            <asp:Label runat="server" Text="الفاكس"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_P_O_Box2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الرمز البريدي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList runat="server" ID="RB_Stamps2" CssClass="Ch Radio">
                                                <asp:ListItem Value="1">يضع طوابع</asp:ListItem>
                                                <asp:ListItem Value="0">لا يضع طوابع</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الطوابع"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <%--<td>
                                    <asp:Button ID="Btn_Save" runat="server" Text="حفظ" OnClick="Btn_Save_Click" />
                                </td>--%>
                                        <td>
                                            <asp:Button ID="Btn_Update" runat="server" Text="تعديل" OnClick="Btn_Update_Click" />
                                            <asp:Button ID="Btn_Delete" runat="server" Text="حذف" OnClick="Btn_Delete_Click" />
                                        </td>
                                        <td></td>
                                    </tr>

                                </table>


                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
    <script src="scripts/jquery-1.7.min.js"></script>
    <script src="scripts/select2.min.js"></script>
    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Main_Company.ClientID%>").select2();

        }

    </script>
    <script>
        $("#<%=DDL_Main_Company.ClientID%>").select2();
    </script>




      <%--rami لتغيير التاريخ من لوحة المفاتيح--%>
    <script>
        function DateField_KeyDown(dateField, CalendarExtender1) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender1);
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
