<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AssignMail.aspx.cs" Inherits="Elite_system.AssignMail" %>

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

        .Btn_Save2 {
            margin-right: -85%;
        }

        @media only screen and (max-width: 1000px) {
            .Btn_Save2 {
                margin-right: -268px;
            }
        }




        @media print {

            .print {
                display: none
            }
        }
    </style>

    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <link href="css/thumbnail-slider.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="height: 350px;">
        <ContentTemplate>
            <%--<asp:Label ID="Label1" runat="server" Text="إحالة البريد" Font-Bold="True" Font-Size="Larger"></asp:Label>--%>
            <section class="print text-center " style="padding-top: 1%;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label2" runat="server" Text="إحالة البريد" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="اسم الموظف"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Employee" DataTextField="Employee_Name" DataValueField="ID" Width="180px"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="الجهة المرسل لها البريد" Font-Bold="True" Font-Size="Medium"></asp:Label><br />

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sent_To" Width="180px" runat="server" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                            في حالة تكرار رقم البريد
                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم الباركود"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_BarCode" runat="server"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <%--<tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم البريد"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_MailNo" runat="server"></asp:TextBox>
                                        </td>

                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Save1" runat="server" Text="  احالة عن طريق الباركود" Height="26px" OnClick="Btn_Save1_Click" />

                                        </td>

                                        <td>
                                            <%--<asp:Button ID="Btn_Save2" runat="server" Text="  احالة عن طريق رقم البريد" Height="26px" OnClick="Btn_Save2_Click" />--%>
                                            <asp:Button ID="Btn_Delete" runat="server" CssClass="print" Text="حفظ وإفراغ المحتوى" OnClick="Btn_Delete_Click" />
                                            <asp:Button ID="Btn_Print" runat="server" Text="طباعة" Height="28px" Width="100px" OnClick="Btn_Print_Click" />

                                        </td>

                                    </tr>
                                </table>
                            </div>
                        </div>

                        <div class="COLR" style="margin-left: -39px; float: left">
                            <div class="table-responsive" style="margin-left: -205px; height: 257px;">
                                <div id="GV_Mainclaim" style="height: 344px;" aria-sort="descending">
                                    <asp:GridView ID="GridView2" runat="server" CssClass="Grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" SelectText="اختر" ControlStyle-ForeColor="Black">
                                                <ControlStyle ForeColor="Black" />
                                            </asp:CommandField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </div>
                                <br />

                            </div>
                            <br />

                        </div>
                    </div>
                </div>


            </section>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Btn_Print" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="text-center" style="padding-top: 1%; padding-bottom: 200px;">
                <div class="container">
                    <div class="row">
                        <div class="COLR">
                            <div id="GV" class="table-responsive" style="overflow-x: initial !important; margin-right: 59px; height: 200px;">
                                <table class="table-responsive" style="overflow-x: initial !important; margin-right: 59px;">
                                    <asp:GridView ID="GV_ChecksAssigned" Width="225%" runat="server" CssClass="Grid" AllowPaging="false" OnSelectedIndexChanged="GV_ChecksAssigned_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" SelectText="تراجع" SortExpression="asc" />
                                        </Columns>
                                    </asp:GridView>
                                    <rsweb:ReportViewer CssClass="Report" ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="824px" DocumentMapWidth="100%" ExportContentDisposition="AlwaysInline">
                                        <LocalReport ReportPath="AssignedChecksView.rdlc">
                                            <DataSources>
                                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DS_Checks4" />
                                            </DataSources>
                                        </LocalReport>
                                    </rsweb:ReportViewer>
                                    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Elite_system.DS_Checks4TableAdapters.V_Main_CheckTableAdapter"></asp:ObjectDataSource>--%>

                                    <asp:ObjectDataSource runat="server" SelectMethod="GetData" TypeName="Elite_system.DS_Checks4TableAdapters.V_Main_CheckTableAdapter" ID="ObjectDataSource1"></asp:ObjectDataSource>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:CONN %>' SelectCommand="SELECT * FROM [V_Mails]"></asp:SqlDataSource>
                                </table>


                                <%--<input type="button" runat="server" class="print" id="btnPrint" value="Print" onclick="window.print()" aria-autocomplete="none" style="background-color: #8D6F62; font-family: Arial, Helvetica, sans-serif; color: #FFFFFF; font-size: medium; font-weight: bold; width: 112px; height: 35px;"  />--%>
                            </div>
                            <br />

                        </div>
                    </div>
                </div>
            </section>


        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="scripts/jquery-1.7.min.js"></script>
    <script src="scripts/select2.min.js"></script>



    <script type="text/javascript">
        $(document).ready(function () {
            //$("#Txt_MailNo").on("keypress", function (e) {
            //    if (e.keyCode == 13) {
            //        alert("asdasd");
            //    }
            //});


            $("#Txt_BarCode").on("keypress", function (e) {
                if (e.keyCode == 13) {
                    alert("asdasd");
                }
            });
        });
    </script>

    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Employee.ClientID%>").select2();
            $("#<%=DDL_Sent_To.ClientID%>").select2();

        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Employee.ClientID%>").select2();
            $("#<%=DDL_Sent_To.ClientID%>").select2();
        })
    </script>


</asp:Content>
