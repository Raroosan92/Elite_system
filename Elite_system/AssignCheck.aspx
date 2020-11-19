<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ViewStateMode="Enabled" CodeBehind="AssignCheck.aspx.cs" Inherits="Elite_system.AssignCheck" %>

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




    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <%--<asp:Label ID="Label1" runat="server" Text="إحالة الشيكات" Font-Bold="True" Font-Size="Larger"></asp:Label>--%>
            <section class="print text-center " style="padding-top: 1%;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label2" runat="server" Text="إحالة الشيكات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
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
                                            <asp:Label runat="server" Text="الجهة المرسل لها الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label><br />

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sent_To" Width="180px" runat="server" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                            في حالة تكرار رقم الشيك
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
                                            <asp:Button ID="Btn_Save1" runat="server" Text="  احالة عن طريق الباركود" Height="26px" OnClick="Btn_Save1_Click" />

                                        </td>

                                        <td>
                                            <asp:Button ID="Btn_Save2" runat="server" Text="  احالة عن طريق رقم الشيك" Height="26px" OnClick="Btn_Save2_Click" />
                                            <asp:Button ID="Btn_Delete" runat="server" CssClass="print" Text="حفظ وإفراغ المحتوى" OnClick="Btn_Delete_Click" />
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
            <section class="text-center" style="padding-top: 1%; padding-bottom: 200px;">
                <div class="container">
                    <div class="row">
                        <div class="COLR">
                            <div id="GV" class="table-responsive" style="overflow-x: initial !important; margin-right: 59px; height: 200px;">
                                <table class="table-responsive" style="overflow-x: initial !important; margin-right: 59px;">
                                    <asp:GridView ID="GV_ChecksAssigned" Width="225%" runat="server" CssClass="Grid" AllowPaging="false" OnSelectedIndexChanged="GV_ChecksAssigned_SelectedIndexChanged">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" SelectText="تراجع" />
                                        </Columns>
                                    </asp:GridView>
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



      <script  type="text/javascript">
          $(document).ready(function () {
              $("#Txt_CheckNo").on("keypress", function (e) {
                  if (e.keyCode == 13) {
                      alert("asdasd");
                  }
              });


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
