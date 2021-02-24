<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Rpt_CheckLogStatus.aspx.cs" Inherits="Elite_system.CheckLogStatus" %>


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
            MARGIN-LEFT: 7%;
            width: 73% !important;
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
                                    <asp:Label ID="Label3" runat="server" Text=" كشف الشيكات المحالة والمسلمة والمرتجعة" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="DDL_Medical_Name" runat="server" DataTextField="Name" DataValueField="ID" Width="300px"></asp:DropDownList>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1"></td>
                                <td style="text-align: center; width: 98px">

                                    <asp:Button ID="Button2" runat="server" Text="طباعة" Height="28px" Width="100px" OnClick="Button2_Click" />

                                    <asp:Button ID="Button1" runat="server" Text="بحث" Height="28px" Width="100px" OnClick="Button1_Click" />



                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

            </div>
        </div>

    </section>

    <section class="text-center Report" style="padding-top: 1%; direction: ltr;">

        <rsweb:ReportViewer ID="ReportViewer1" CssClass="Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="750px">
            <LocalReport ReportPath="Rpt_CheckLogStatus.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="Elite_system.DS_ChecksLogStatusTableAdapters.Log_ChecksTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ID" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Check_Number" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_Type" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Check_EmpName" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_MedicalName" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_Barcode" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_CurrentDate" Type="DateTime"></asp:Parameter>
                <asp:Parameter Name="Check_Date" Type="DateTime"></asp:Parameter>
                <asp:Parameter Name="Check_Uname" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_Company" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Check_Number" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_Type" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Check_EmpName" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_MedicalName" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_Barcode" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_CurrentDate" Type="DateTime"></asp:Parameter>
                <asp:Parameter Name="Check_Date" Type="DateTime"></asp:Parameter>
                <asp:Parameter Name="Check_Uname" Type="String"></asp:Parameter>
                <asp:Parameter Name="Check_Company" Type="String"></asp:Parameter>
                <asp:Parameter Name="Original_ID" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:ObjectDataSource>
    </section>
    <script src="scripts/select2.min.js"></script>



    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            

        }
    </script>

    <script>
        $(function () {

            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            
        })


    </script>

</asp:Content>


