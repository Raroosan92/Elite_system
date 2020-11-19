<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Rpt_GetContractingValue.aspx.cs" Inherits="Elite_system.Rpt_GetContractingValue" %>


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
            MARGIN-LEFT: 14%;
            width: 65% !important;
            height: 500PX;
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
                                    <asp:Label ID="Label3" runat="server" Text="كشف الإشتراكات الشهرية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 98px">
                                    <asp:Button ID="Button2" runat="server" Text="طباعة" Height="28px" Width="100px" OnClick="Button2_Click" />
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

</asp:Content>
