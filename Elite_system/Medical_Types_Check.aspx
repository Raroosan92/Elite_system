<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Medical_Types_Check.aspx.cs" Inherits="Elite_system.Medical_Types_Check" %>



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


            <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right; direction: rtl;width: 51%;">
                            <div class="table-responsive">
                                <table class="table table-striped" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">

                                        <td style="width: 98px">
                                            <asp:Label ID="Label2" runat="server" Text="إدخال التسعيرات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>

                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                        </td>
                                        <td class="auto-style1">

                                            <asp:DropDownList ID="DDL_Medical_Name" runat="server" DataTextField="Name" DataValueField="ID" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="DDL_Medical_Name_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr>


                                        <td>
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:DropDownList ID="DDL_Main_Company" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DDL_Main_Company_SelectedIndexChanged" Width="300px">
                                            </asp:DropDownList>
                                        </td>

                                    </tr>



                                    <tr>

                                        <td>
                                            <asp:Label runat="server" Text="الشركة الفرعية"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sub_Company" runat="server" Width="300px" DataTextField="Sub_Company" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="DDL_Sub_Company_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>


                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="التخصص"></asp:Label>
                                        </td>

                                        <td class="auto-style1">

                                            <asp:DropDownList runat="server" ID="DDL_Specialization" DataTextField="Description" DataValueField="ID" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDL_Specialization_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr>


                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الإجراء"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_ProcedureDesc" DataTextField="ProcedureDesc" DataValueField="ID" Width="300px"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Lbl_TransactionPrice" runat="server" Text="تسعيرة الإجراء"></asp:Label>
                                        </td>

                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_TransactionPrice" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Lbl_CheckPrice" runat="server" Text="تسعيرة الكشفية"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_CheckPrice" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Lbl_DiscountRatio" runat="server" Text="نسبة الخصم التعاقدي للإجراء"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_DiscountRatio" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Lbl_DiscountRatio2" runat="server" Text="نسبة الخصم التعاقدي للكشفية"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_DiscountRatio22" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="إدخال" Height="26px" Style="width: 55px" OnClick="Btn_Save_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_Result1" runat="server" Text="" ForeColor="Red"></asp:Label>

                                        </td>
                                    </tr>

                                </table>


                            </div>
                        </div>


                        <div class="COLR" style="float: right;width:49%;" >
                            <div class="table-responsive">
                                <div id="GV_Procedurs" style="height: 500px;">
                                    <%-- <table class="table-responsive">--%>
                                    <strong>
                                        <asp:Label ID="Lbl_Medical_Name" runat="server" Text=""></asp:Label>
                                    </strong>
                                    <br>
                                    <strong>
                                        <asp:Label ID="Lbl_Main_Company" runat="server" Text=""></asp:Label>
                                    </strong>
                                    <br>
                                    <strong>
                                        <asp:Label ID="Lbl_Sub_Company" runat="server" Text=""></asp:Label>
                                    </strong>
                                    <br>
                                    <strong>
                                        <asp:Label ID="Lbl_Specialization" runat="server" Text=""></asp:Label>
                                    </strong>
                                    <br>


                                    <asp:GridView ID="GV" runat="server" CssClass="Grid" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="ID">
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="التسلسل" ReadOnly="True" SortExpression="ID" />
                                            <asp:BoundField DataField="ProcedureDesc" HeaderText="الإجراء" SortExpression="ProcedureDesc" />
                                            <asp:BoundField DataField="Points" HeaderText="عدد النقاط" SortExpression="Points" />
                                            <asp:BoundField DataField="TransactionPrice" HeaderText=" تسعيرة الإجراء" SortExpression="TransactionPrice" />
                                            <asp:BoundField DataField="CheckPrice" HeaderText=" تسعيرة الكشفية" SortExpression="CheckPrice" />
                                            <asp:BoundField DataField="DiscountRatio" HeaderText="نسبة الخصم التعاقدي للإجراء" SortExpression="DiscountRatio" />
                                            <asp:BoundField DataField="DiscountRatio2" HeaderText="نسبة الخصم التعاقدي للكشفية" SortExpression="DiscountRatio2" />
                                        </Columns>
                                    </asp:GridView>

                                    <%-- </table>--%>
                                </div>
                                <br />

                            </div>
                        </div>


                    </div>
                </div>
            </section>

            <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right; direction: rtl; width: 55%;">
                            <div class="table-responsive">
                                <table class="table table-striped" border="0" style="width: 97%; float: right; margin-right: 3%; max-width: 100%; margin-bottom: 20px;">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label3" runat="server" Text="تعديل التسعيرات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>

                                    <tr>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                        </td>
                                        <td class="auto-style1">

                                            <asp:DropDownList ID="DDL_Medical_Name2" runat="server" DataTextField="Name" DataValueField="ID" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="DDL_Medical_Name2_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>


                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:DropDownList ID="DDL_Main_Company2" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DDL_Main_Company2_SelectedIndexChanged" Width="300px">
                                            </asp:DropDownList>
                                        </td>

                                    </tr>



                                    <tr>

                                        <td>
                                            <asp:Label runat="server" Text="الشركة الفرعية"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sub_Company2" runat="server" Width="300px" DataTextField="Sub_Company" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="DDL_Sub_Company2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>


                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="التخصص"></asp:Label>
                                        </td>

                                        <td class="auto-style1">

                                            <asp:DropDownList runat="server" ID="DDL_Specialization2" DataTextField="Description" DataValueField="ID" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="DDL_Specialization2_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr>


                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الإجراء"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_ProcedureDesc2" DataTextField="ProcedureDesc" DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DDL_ProcedureDesc2_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                    </tr>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="تسعيرة الإجراء"></asp:Label>
                                        </td>

                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_TransactionPrice2" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="تسعيرة الكشفية"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_CheckPrice2" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="نسبة الخصم التعاقدي للإجراء"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_DiscountRatio2" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>


                                    <tr>

                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="نسبة الخصم التعاقدي للكشفية"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_DiscountRatio3" Width="300px"></asp:TextBox>
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
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Main_Company.ClientID%>").select2();
            $("#<%=DDL_Sub_Company.ClientID%>").select2();
            $("#<%=DDL_Specialization.ClientID%>").select2();

            $("#<%=DDL_Medical_Name2.ClientID%>").select2();
            $("#<%=DDL_Main_Company2.ClientID%>").select2();
            $("#<%=DDL_Sub_Company2.ClientID%>").select2();
            $("#<%=DDL_Specialization2.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc2.ClientID%>").select2();

        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Main_Company.ClientID%>").select2();
            $("#<%=DDL_Sub_Company.ClientID%>").select2();
            $("#<%=DDL_Specialization.ClientID%>").select2();

            $("#<%=DDL_Medical_Name2.ClientID%>").select2();
            $("#<%=DDL_Main_Company2.ClientID%>").select2();
            $("#<%=DDL_Sub_Company2.ClientID%>").select2();
            $("#<%=DDL_Specialization2.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc2.ClientID%>").select2();
        })
    </script>


</asp:Content>
