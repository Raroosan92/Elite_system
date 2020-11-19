<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="RefundedCheckes.aspx.cs" Inherits="Elite_system.RefundedCheckes" %>




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
    </style>

    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <link href="css/thumbnail-slider.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <%--<asp:Label ID="Label1" runat="server" Text="إحالة الشيكات" Font-Bold="True" Font-Size="Larger"></asp:Label>--%>
            <section class="text-center " style="padding-top: 1%;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label2" runat="server" Text="إرجاع الشيكات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>




                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="الجهة المرسل لها الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label><br />

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sent_To" Width="180px" runat="server" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                            في حالة تكرار رقم الشيك
                                        </td>

                                    </tr>


                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم البار كود"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_BarCode" runat="server"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم الشيك"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txt_CheckNo" runat="server"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Save1" runat="server" Text="إرجاع عن طريق البار كود" Height="26px" OnClick="Btn_Save1_Click" />

                                        </td>
                                        <td>
                                            <asp:Button ID="Btn_Save2" runat="server" Text="إرجاع عن طريق رقم الشيك" Height="26px" OnClick="Btn_Save2_Click" />
                                            <asp:Button ID="Btn_Delete" runat="server" Text="حفظ وإفراغ المحتوى" OnClick="Btn_Delete_Click" />
                                        </td>
                                        

                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="text-center " style="padding-top: 1%;">
                <div class="container">
                    <div class="row">
                        <div class="COLR">
                            <div class="table-responsive" style="overflow-x: initial !important; margin-right: 59px;">
                                <table class="table-responsive" style="overflow-x: initial !important; margin-right: 59px;">
                                    <asp:GridView ID="GV_ChecksAssigned" Width="225%" runat="server" AllowPaging="false" CssClass="Grid"  OnSelectedIndexChanged="GV_ChecksAssigned_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" SelectText="تراجع" />
                                        </Columns>
                                    </asp:GridView>
                                </table>                                                               

                            </div>
                        </div>
                    </div>
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
           
            $("#<%=DDL_Sent_To.ClientID%>").select2();

        }

    </script>
    <script>
        $(function () {
            $
            $("#<%=DDL_Sent_To.ClientID%>").select2();
        })
    </script>



</asp:Content>
