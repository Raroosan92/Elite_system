<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Rpt_Receivables.aspx.cs" Inherits="Elite_system.Rpt_Receivables" %>

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
            MARGIN-LEFT: -6%;
            width: 76% !important;
            height:500PX;
        }

        @media only screen and (max-width: 1000px) {
            .Report {
                MARGIN-LEFT: 2%;
                width: 100% !important;
                /*table-layout:auto !important;*/
            }
        }

        .auto-style2 {
            width: 107%;
            text-align: right;
            float: right;
            margin-right: -71%;
            width: 100%;
        }
    </style>





    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <link href="css/thumbnail-slider.css" rel="stylesheet" />


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="text-center" style="padding-top: 1%; direction: ltr;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="row">
                <div class="COLR" style="float: right">
                    <div class="table-responsive">
                        <table class="table table-striped">
                            <tr style="background-color: #2f323a;">
                                <td class="auto-style1"></td>
                                <td style="width: 98px">
                                    <asp:Label ID="Label3" runat="server" Text="كشف اسماء الجهات الطبية المتعاقدة مع الشركة" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                </td>
                            </tr>
                            

                                <td class="auto-style2">
                                    <asp:DropDownList ID="DDL_Medical_Name" runat="server" DataTextField="Name" DataValueField="ID" Width="220px"></asp:DropDownList>
                                </td>
                                <td class="auto-style1">
                                    <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                </td>
                            </tr>

                              <tr>

                                <td class="auto-style2">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_FromDate" runat="server" Width="150px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_FromDate" />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text=" : التاريخ من"></asp:Label></td>

                            </tr>

                            <tr>

                                <td class="auto-style2">
                                    <asp:TextBox AutoCompleteType="Disabled" ID="Txt_ToDate" runat="server" Width="150px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_ToDate" />
                                </td>
                                <td style="width: 98px">

                                    <asp:Label ID="Label4" runat="server" Text=": إلى"></asp:Label></td>

                            </tr>
                            <tr>

                                <td class="auto-style2">
                                    <asp:DropDownList runat="server" ID="DDL_Employee" DataTextField="Employee_Name" DataValueField="ID" Width="300px"></asp:DropDownList>
                                </td>
                                <td class="auto-style1">
                                    <asp:Label runat="server" Text="اسم المندوب"></asp:Label>
                                </td>
                            </tr>


                            <tr>
                                <td class="auto-style2">
                                    <asp:DropDownList runat="server" ID="DDL_Region1" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                    <%-- <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Region" Width="300px"></asp:TextBox>--%>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="المنطقة"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Commission" runat="server">
                                <td class="auto-style2">
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Commission" Width="300px" ToolTip="العمولة"></asp:TextBox>
                                </td>
                                <td class="auto-style1">
                                    <asp:Label runat="server" Text="العمولة"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <%--<asp:Button ID="Print" runat="server" Text="بحث" Height="28px" Width="152px" OnClick="Print_Click" />--%>
                                    <%--<asp:ImageButton ID="printreport" runat="server" />--%>
                                    <%-- <input type="button" value="print" id="printreport" />
                                    <asp:Button ID="PrintButton" runat="server" Text="Print Report" OnClientClick="MyPrint(); return false;" />
                                    --%>
                                </td>
                                <td style="width: 98px">
                                    <asp:Button ID="Button2" runat="server" Text="طباعة" Height="28px" Width="100px" OnClick="Button2_Click" />
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
        <rsweb:ReportViewer ID="ReportViewer1" CssClass="Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1131px" Height="800px" ShowPrintButton="true">
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
            $("#<%=DDL_Employee.ClientID%>").select2();
            $("#<%=DDL_Region1.ClientID%>").select2();
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Employee.ClientID%>").select2();
            $("#<%=DDL_Region1.ClientID%>").select2();
            $("#<%=DDL_Medical_Name.ClientID%>").select2();

        })
    </script>

    <%--   <script>
        debugger;
        // Linking the print function to the print button
        $('#printreport').click(function () {
            PrintFunc('ReportViewer');
        });
    </script>
    <script>
        debugger;
        function printReport() {  //works with IE/Edge, not with Chrome/FF
            //alert("print");
            var rv1 = $('#' + 'ReportViewer2');
            var iDoc = rv1.parents('html');

            // Reading the report styles
            var styles = iDoc.find("head style[id$='ReportControl_styles']").html();
            if ((styles == undefined) || (styles == '')) {
                iDoc.find('head script').each(function () {
                    var cnt = $(this).html();
                    var p1 = cnt.indexOf('ReportStyles":"');
                    if (p1 > 0) {
                        p1 += 15;
                        var p2 = cnt.indexOf('"', p1);
                        styles = cnt.substr(p1, p2 - p1);
                    }
                });
            }
            if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }
            styles = '<style type="text/css">' + styles + "</style>";

            // Reading the report html
            var table = rv1.find("div[id$='_oReportDiv']");
            if (table == undefined) {
                alert("Report source not found.");
                return;
            }

            // Generating a copy of the report in a new window 
            var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';
            var docCnt = styles + table.parent().html();
            var docHead = '<head><title></title><style>body{margin:5;padding:0;}</style></head>';
            var winAttr = "location=yes, statusbar=no, directories=no, menubar=no, titlebar=no, toolbar=no, dependent=no, width=720, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";;
            var newWin = window.open("", "_blank", winAttr);
            writeDoc = newWin.document;
            writeDoc.open();
            writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');
            writeDoc.close();

            // The print event will fire as soon as the window loads
            newWin.focus();
            //newWin.close();
            setTimeout(function () {
                newWin.close();
                document.location.reload(true);
            }, 2500);
        };
    </script>--%>

  <%--  <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            if ($.browser.mozilla || $.browser.webkit) {

                try {

                    showPrintButton();

                }

                catch (e) { alert(e); }

            }

        });



        function showPrintButton() {

            var table = $("table[title='Refresh']");

            var parentTable = $(table).parents('table');

            var parentDiv = $(parentTable).parents('div').parents('div').first();

            parentDiv.append('<select name="ctl00$ContentPlaceHolder1$reportViewer$ReportViewer1$ctl01$ctl03$ctl00" title="Zoom" id="ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl03_ctl00" style="font-family: Verdana; font-size: 8pt; onclick="PrintReport(); onChange="showzoom();"> <OPTION value=PageWidth>Page Width</OPTION> <OPTION value=FullPage>Whole Page</OPTION> <OPTION value=500>500%</OPTION> <OPTION value=200>200%</OPTION> <OPTION value=150>150%</OPTION> <OPTION selected value=100>100%</OPTION> <OPTION value=75>75%</OPTION> <OPTION value=50>50%</OPTION> <OPTION value=25>25%</OPTION> <OPTION value=10>10%</OPTION>');
            parentDiv.append('<input name="ctl00$ContentPlaceHolder1$reportViewer$ReportViewer1$ctl01$ctl04$ctl00" title="Find Text" id="ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl00" style="font-family: Verdana; font-size: 8pt;" onkeypress="keyprs();" onpropertychange="propertychnge();" type="text" size="10" maxLength="255"/>');
            parentDiv.append('<a title="Find" id="ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl01" style="font-family: Verdana; color: gray; font-size: 8pt; text-decoration: none;" href="#" onclick="Find();" onmouseover="mouseover();" onmouseout="mouseout();"  Controller="[object Object]">Find</a>');
            parentDiv.append('<a title="Find Next" id="ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl03" style="font-family: Verdana; color: gray; font-size: 8pt; text-decoration: none;" onmouseover="this.Controller.OnLinkHover();" onmouseout="this.Controller.OnLinkNormal();" onclick="Next();" href="#" Controller="[object Object]"> | Next</a>');
            parentDiv.append('<input type="image" style="border-width: 0px;  padding: 3px;margin-top:2px; height:16px; width: 16px;" alt="Print" src="/Reserved.ReportViewerWebControl.axd?OpType=Resource&amp;Version=12.0.0.0&amp;Name=Microsoft.Reporting.WebForms.Icons.Print.gif";title="Print" onclick="PrintReport();">');



        }

        function Next() {

            document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1').ClientController.HandleSearchNext();

            return false;
        }
        function mouseout() {
            this.Controller.OnLinkNormal();
        }
        function mouseover() {
            this.Controller.OnLinkHover();
        }

        function keyprs() {
            if (event.keyCode == 10 || event.keyCode == 13) {
                document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1').ClientController.ActionHandler('Search', document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl00').value);; return false;
            }
        }
        function propertychnge() {

            if (event.propertyName == 'value') {
                document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl01').Controller.SetViewerLinkActive(this.value != null && this.value != '');
                document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl03').Controller.SetViewerLinkActive(false);
            }
        }
        function Find() {
            document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1').ClientController.ActionHandler('Search', document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl00').value); return false;
            //            document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl01').Controller = new ReportViewerLink("ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl01", false, "", "", "#3366CC", "Gray", "#FF3300");
        }
        function clicks() {

            document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1').ClientController.ActionHandler('Search', document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1_ctl01_ctl04_ctl00').value); return false;
        }
        //zoom effect
        function showzoom() {

            document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_ReportViewer1').ClientController.SetZoom(event.srcElement.value);
        }
        // Print Report function

        function PrintReport() {

            //Code for adding HTML content to report viwer
            var headstr = "<html><head><title></title></head><body>";
            //End of body tag
            var footstr = "</body></html>";
            //This the main content to get the all the html content inside the report viewer control
            //"ReportViewer1_ctl10" is the main div inside the report viewer
            //controls who helds all the tables and divs where our report contents or data is available
            var newstr = $("#P815ffe575f254de58391abbac30b2a2c_1_oReportCell").html();
            alert(newstr);
            //open blank html for printing
            var popupWin = window.open('', '_blank');
            //paste data of printing in blank html page
            popupWin.document.write(headstr + newstr + footstr);
            //print the page and see is what you see is what you get
            popupWin.print();
            return false;



        };


        $(document).ready(function () {


            if ($.browser.webkit) {
                $(".reportViewerCtrl table").css('display', 'inline-block');


            }
        });

        $(DocReady);
        function DocReady() {
            $('option[value = PDF]').remove();
        }
    </script>--%>


</asp:Content>
