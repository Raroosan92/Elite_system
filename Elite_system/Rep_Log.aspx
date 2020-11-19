<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Rep_Log.aspx.cs" Inherits="Elite_system.Rep_Log" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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

        .Report {
            MARGIN-LEFT: -14%;
            width: 75% !important;
        }

        @media only screen and (max-width: 1000px) {
            .Report {
                MARGIN-LEFT: 2%;
                width: 100% !important;
            }
        }
    </style>





    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <link href="css/thumbnail-slider.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="text-center " style="padding-top: 1%; direction: ltr;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="row">
                <div class="COLR" style="float: right">
                    <div class="table-responsive">
                        <table class="table table-striped">
                            <tr style="background-color: #2f323a;">
                                <td class="auto-style1"></td>
                                <td style="width: 98px">
                                    <asp:Label ID="Label3" runat="server" Text="حركات النظام" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td class="auto-style1">
                                    <asp:TextBox ID="Txt_FromDate" runat="server" Width="300px" Height="21px" AutoCompleteType="Disabled"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_FromDate" />
                                </td>
                                <td style="width: 98px">
                                    <asp:Label ID="Label1" runat="server" Text=" : التاريخ من"></asp:Label></td>

                            </tr>
                            <tr>

                                <td class="auto-style1">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_ToDate" runat="server" Width="300px" Height="21px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_ToDate" />
                                </td>
                                <td style="width: 98px">

                                    <asp:Label ID="Label2" runat="server" Text=" : إلى"></asp:Label></td>

                            </tr>
                              <tr>

                              <td class="auto-style2">
                                    <asp:DropDownList runat="server" ID="DDL_Users" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label ID="Label4" runat="server" Text=": اسم المستخدم"></asp:Label></td>

                            </tr>
                            <tr>
                                <td class="auto-style1"></td>
                                <td style="width: 98px">
                                    <asp:Button ID="Button2" runat="server" target="_blank" Text="طباعة" Height="28px" Width="100px" OnClick="Button2_Click" />
                                    <asp:Button ID="Button1" runat="server" Text="بحث" Height="28px" Width="152px" OnClick="Button1_Click" />
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <section class="text-center Report" style="padding-top: 1%; direction: ltr;">


        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" CssClass="Report">
            <LocalReport ReportPath="Rpt_Log.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DS_Log" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="Elite_system.DS_LogTableAdapters.LogTableAdapter"></asp:ObjectDataSource>

    </section>

     <script src="scripts/jquery-1.7.min.js"></script>
    <script src="scripts/select2.min.js"></script>

    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Users.ClientID%>").select2();
           
        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Users.ClientID%>").select2();
            

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
    <script>
        function DateField_KeyDown(dateField, CalendarExtender) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender);
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
