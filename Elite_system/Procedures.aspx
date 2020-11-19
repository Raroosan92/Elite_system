<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Procedures.aspx.cs" Inherits="Elite_system.Procedures" %>


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


            <section class="text-center" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right; direction: rtl">
                            <div class="table-responsive">
                                <table class="table table-striped" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label2" runat="server" Text="إدخال الإجراءات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="التخصص"></asp:Label>
                                        </td>
                                        <td class="auto-style1">

                                            <asp:DropDownList runat="server" ID="DDL_Specialization" DataTextField="Description" DataValueField="ID" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="DDL_Specialization_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الإجراء"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ProcedureDesc" Width="300px"></asp:TextBox>

                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="عدد النقاط"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Points" Width="300px"></asp:TextBox>

                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="إدخال" OnClick="Btn_Save_Click" Height="26px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_Result1" runat="server" Text="" ForeColor="Red"></asp:Label>

                                        </td>
                                    </tr>
                                </table>


                            </div>
                        </div>


                        <div class="COLR" style="float: right">
                            <div class="table-responsive" style="height: 300px;">
                                <table class="table-responsive">
                                    <strong>
                                        <asp:Label ID="Lbl_Specialization" runat="server" Text=""></asp:Label>
                                    </strong>

                                    <br>
                                    <asp:GridView ID="GV" runat="server" AllowPaging="false" AutoGenerateColumns="False" CssClass="Grid" DataKeyNames="ID">
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="التسلسل" ReadOnly="True" SortExpression="ID" />
                                            <asp:BoundField DataField="ProcedureDesc" HeaderText="الإجراء " SortExpression="ProcedureDesc" />
                                            <asp:BoundField DataField="Points" HeaderText="عدد النقاط " SortExpression="Points" />
                                        </Columns>
                                    </asp:GridView>



                                </table>
                                <br />

                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <section class="text-center" style="padding-top: 1%;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped" cellpadding="3" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label3" runat="server" Text="تعديل الإجراءات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="التخصص"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_Specialization2" DataTextField="Description" DataValueField="ID" Width="300px" OnSelectedIndexChanged="DDL_Specialization2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الإجراء"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_ProcedureDesc" DataTextField="ProcedureDesc" DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DDL_ProcedureDesc_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>


                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الإجراء"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ProcedureDesc2" Width="300px"></asp:TextBox>

                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="عدد النقاط"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Points2" Width="300px"></asp:TextBox>

                                        </td>

                                    </tr>

                                    <tr style="direction: rtl;">



                                        <td>
                                            <asp:Button ID="Btn_Delete" runat="server" Text="حذف" Height="26px" OnClick="Btn_Delete_Click" />
                                            &nbsp; 	&nbsp; &nbsp; 
                                            <asp:Button ID="Btn_Update" runat="server" Text="تعديل" Height="26px" OnClick="Btn_Update_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_Result2" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                                    </tr>
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
            $("#<%=DDL_ProcedureDesc.ClientID%>").select2();
            $("#<%=DDL_Specialization2.ClientID%>").select2();
            $("#<%=DDL_Specialization.ClientID%>").select2();

        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_ProcedureDesc.ClientID%>").select2();
            $("#<%=DDL_Specialization2.ClientID%>").select2();
            $("#<%=DDL_Specialization.ClientID%>").select2();
        })
    </script>

    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {

            $("#<%=DDL_Specialization2.ClientID%>").select2();

        }

    </script>

</asp:Content>
