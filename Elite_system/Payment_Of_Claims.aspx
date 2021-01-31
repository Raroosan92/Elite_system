<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Payment_Of_Claims.aspx.cs" Inherits="Elite_system.Payment_Of_Claims" %>

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

                                            <asp:DropDownList ID="DDL_Main_Company" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" Width="300px"  OnSelectedIndexChanged="DDL_Main_Company_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sub_Company" runat="server" AutoPostBack="True" Width="300px" DataTextField="Sub_Company" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة الفرعية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr style="direction: rtl;">
                                        <td>
                                            <%--<asp:Button ID="Btn_Save" runat="server" Text="تسديد" OnClick="Btn_Save_Click" />--%>
                                        </td>

                                        <td></td>
                                    </tr>


                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                
                        <div id="GV_Subclaim" style="height: 450px;">
                            <%--<asp:GridView ID="GridView_SubClaims" DataKeyNames="التسلسل" runat="server" CssClass="Grid" AllowPaging="False" OnSelectedIndexChanged="GridView_SubClaims_SelectedIndexChanged1"  PagerSettings-PageButtonCount="4">--%>
                            <asp:GridView ID="GridView_SubClaims" runat="server" >
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="اختر" ControlStyle-ForeColor="Black" />
                                </Columns>
                            </asp:GridView>
                        </div>


            </section>

        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="Btn_Save" />--%>
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

