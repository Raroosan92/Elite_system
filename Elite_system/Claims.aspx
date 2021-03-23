<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" MetaKeywords="Claims,مطالبات,Elite,النخبة" MetaDescription="Claims" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Claims.aspx.cs" Inherits="Elite_system.Claims" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .Drop {
            background-color: gold;
            font-weight: 600;
            border-style: groove;
        }

        .ColumnGV {
            /*visibility:hidden;*/
            display: none;
        }

        .auto-style1 {
            width: 107%;
        }

        .COLR {
            width: 50%;
        }

        .btn_listingbonds {
            width: 300px;
            /*            margin-top: 94px;*/
        }

        @media only screen and (max-width: 1000px) {
            .COLR {
                width: 50%;
                display: contents;
            }
        }

        .Grid {
            width: 100%;
            height: 10%;
            text-align: center;
            direction: rtl;
        }


        .CaptionEdited {
            height: 294px;
            width: 248% !important;
        }

        .CaptionEdited2 {
            height: 336px;
            width: 638px !important;
        }

        @media only screen and (max-width: 1000px) {
            .CaptionEdited2 {
                height: 294px;
                width: 100% !important;
            }
        }

        @media only screen and (max-width: 1000px) {
            .CaptionEdited {
                height: 294px;
                width: 100% !important;
            }
        }

        .my-5 {
            height: 1300px;
        }

        .Btn_Search {
            background: linear-gradient(359deg, #5b5d5e, #7595aa);
            border-radius: 1pc;
            color: white;
        }
    </style>

    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <link href="css/thumbnail-slider.css" rel="stylesheet" />


    <style type="text/css">
        #blur {
            width: 100%;
            background-color: black;
            moz-opacity: 0.5;
            khtml-opacity: .5;
            opacity: .5;
            filter: alpha(opacity=10);
            z-index: 120;
            height: 376%;
            position: absolute;
            top: 0;
            left: 0;
        }

        #progress {
            z-index: 200;
            /*background-color: White;
            position: absolute;
            top: 0pt;
            left: 0pt;
            border: solid 1px black;
            padding: 5px 5px 5px 5px;
            text-align: center;*/
            margin-top: 50%;
        }
    </style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--rami--%>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="text-center" style="padding-top: 1%; direction: ltr;">
        <div class="container">
            <div class="row">
                <div class="COLR" style="float: right">
                    <div class="table-responsive" style="display: contents">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="table table-striped">

                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1">
                                            <asp:Label ID="Label3" runat="server" Text=" العدد " ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                            &nbsp;&nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="Label5" runat="server" Text="" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label ID="Label1" runat="server" Text="المطالبات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Batch_No" Width="300px" onkeydown="return (event.keyCode!=13);">1</asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم الدفعة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DDL_Medical_Name"
                                                CssClass="alertFont" ErrorMessage="الرجاء اختيار الجهة الطبية" Operator="NotEqual"
                                                ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">الرجاء اختيار الجهة الطبية</asp:CompareValidator>--%>
                                            <asp:DropDownList ID="DDL_Medical_Name" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DDL_Medical_Name_SelectedIndexChanged" Width="300px"></asp:DropDownList>


                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Month_Year" BackColor="#CCCCCC" Width="300px" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="مطالبات: شهر/سنة"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Received_Date" Width="300px" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Received_Date" />
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="تاريخ الاستلام"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ID" BackColor="#CCCCCC" ReadOnly="True" Width="300px" onkeydown="return (event.keyCode!=13);"></asp:TextBox>

                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="التسلسل"></asp:Label>

                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style2">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Entry_Date" ReadOnly="True" BackColor="#CCCCCC" Width="300px" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Entry_Date" />
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="تاريخ الادخال"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td class="auto-style2">
                                            <%--  <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="DDL_Receiver_Employee"
                                                CssClass="alertFont" ErrorMessage="الرجاء اختيار المستلم" Operator="NotEqual"
                                                ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">الرجاء اختيار اسم المستلم</asp:CompareValidator>--%>
                                            <asp:DropDownList ID="DDL_Receiver_Employee" runat="server" DataTextField="Employee_Name" DataValueField="ID" Width="300px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 98px; height: 26px;">
                                            <asp:Label runat="server" Text="المستلم"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="Ch_Freez2" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="تجميد الاشتراك"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_FreezFrom"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_FreezFrom" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="تاريخ التجميد من"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_FreezTo"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_FreezTo" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Text="تاريخ التجميد الى"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr style="display: flex; direction: rtl;">
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Save" runat="server" Text="إدخال" OnClick="Btn_Save_Click" Width="60px" />
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Update" Visible="false" runat="server" Text="تعديل" Width="60px" OnClick="Btn_Update_Click" />
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Delete" Visible="false" runat="server" Text="حذف" Width="60px" OnClick="Btn_Delete_Click1" />
                                        </td>



                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="Btn_Save" />
                                <asp:PostBackTrigger ControlID="Btn_Update" />
                                <asp:PostBackTrigger ControlID="Btn_Delete" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <br />
                <div class="COLR" style="margin-left: -68px">
                    <div class="table-responsive" style="width: 100%; margin-left: -7px;">
                        <table class="table-responsive">

                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="السنة"></asp:Label>
                                    <asp:DropDownList ID="DDL_Year" runat="server" DataTextField="Name" DataValueField="ID" Width="150px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="الشهر"></asp:Label>
                                    <asp:DropDownList ID="DDL_Month" runat="server" DataTextField="Name" DataValueField="ID" Width="150px">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="الجهة الطبية"></asp:Label>
                                    <asp:DropDownList ID="DDL_Medical_Name_Search" runat="server" DataTextField="Name" DataValueField="ID" Width="200px"></asp:DropDownList>
                                </td>
                                <asp:Button ID="Btn_Search" runat="server" Width="100%" CssClass="Btn_Search" Text="بحث" OnClick="Btn_Search_Click" />

                            </tr>

                            <%--<caption class="CaptionEdited" id="GV">--%>
                            <%--<asp:GridView ID="GridView2" runat="server" CssClass="Grid" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_Claims" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">--%>


                            <%--</caption>--%>


                            <asp:SqlDataSource runat="server" ID="SqlDataSource_Claims" ConnectionString='<%$ ConnectionStrings:CONN %>' SelectCommand="SELECT ID,Claim_ID, Name, Employee_Name, Month_Year, Received_Date,Batch_No FROM Claims_GridView ORDER BY [ID] DESC"></asp:SqlDataSource>
                        </table>
                        <div id="GV_Mainclaim" style="height: 344px;">
                            <asp:GridView ID="GridView2" runat="server" CssClass="Grid" AllowPaging="false" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowCreated="GridView2_RowCreated">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="اختر" ControlStyle-ForeColor="Black" />
                                    <%-- <asp:BoundField DataField="ID" HeaderText="التسلسل" ReadOnly="True" HeaderStyle-CssClass="ColumnGV" ItemStyle-CssClass="ColumnGV" SortExpression="ID" />
                                        <asp:BoundField DataField="Claim_ID" HeaderText="التسلسل" ReadOnly="True" SortExpression="Claim_ID" />
                                        <asp:BoundField DataField="Name" HeaderText="اسم الجهة الطبية " SortExpression="Name" />
                                        <asp:BoundField DataField="Month_Year" HeaderText="السنة والشهر" SortExpression="Month_Year" />
                                        <asp:BoundField DataField="Batch_No" HeaderText="الدفعة" SortExpression="Month_Year" />--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <br />

                    </div>
                    <br />
                    <%-- <div class="table-responsive">

                        <asp:GridView ID="GridView1" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PagerSettings-PageButtonCount="4">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="اختر" />
                                <asp:BoundField DataField="ID" HeaderText="التسلسل" ReadOnly="True" SortExpression="ID" />
                                <asp:BoundField DataField="Main_Company_Desc" HeaderText="الشركة" SortExpression="Main_Company_Desc" />
                                <asp:BoundField DataField="Claims_Count" HeaderText="عدد المطالبات" SortExpression="Claims_Count" />
                                <asp:BoundField DataField="Value" HeaderText="قيمة المطالبة" SortExpression="Value" />
                                <asp:BoundField DataField="Stamps" HeaderText="الطوابع" SortExpression="Stamps" />
                            </Columns>
                        </asp:GridView>


                        
                    </div>--%>
                </div>
            </div>
        </div>


    </section>



    <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
        <div class="container">
            <div class="row">

                <div class="COLR" style="float: right">

                    <div class="table-responsive">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table id="SubClaimTable" runat="server" class="table table-striped">

                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1">
                                            <asp:Label ID="Label4" runat="server" Text=" العدد " ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                            &nbsp;&nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="Label10" runat="server" Text="" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td style="width: 98px">

                                            <asp:Label ID="Label2" runat="server" Text=" المطالبات الفرعية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_IN" runat="server" Text="IN" Width="200px" Style="text-align-last: center;" OnClick="Btn_IN_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Btn_Out" runat="server" Text="Out" Width="200px" Style="text-align-last: center;" OnClick="Btn_Out_Click" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>

                                            <asp:DropDownList ID="DDL_Main_Company" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DDL_Main_Company_SelectedIndexChanged" Width="300px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sub_Company" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Sub_Company_SelectedIndexChanged" Width="300px" DataTextField="Sub_Company" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة الفرعية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="Specializatio" runat="server">

                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_Specialization" DataTextField="Description" DataValueField="ID" Width="300px" OnSelectedIndexChanged="DDL_Specialization_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="التخصص"></asp:Label>
                                        </td>
                                    </tr>



                                    <tr>
                                        <td>
                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                ControlToValidate="Txt_Claims_Count" runat="server"
                                                ErrorMessage="خطأ في عدد المطالبات"
                                                ValidationExpression="((\d+)((\.\d{1,2})?))$">
                                            </asp:RegularExpressionValidator>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Claims_Count" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="عدد المطالبات"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                ControlToValidate="Txt_Value" runat="server"
                                                ErrorMessage="خطأ في قيمة المطالبة"
                                                ValidationExpression="((\d+)((\.\d{1,2})?))$">
                                            </asp:RegularExpressionValidator>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Value" AutoPostBack="True" OnTextChanged="Txt_Value_TextChanged" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="قيمة المطالبة"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="patient_name" runat="server">
                                        <td class="auto-style2" style="direction: rtl;">
                                            <asp:TextBox ID="Txt_patient_name" AutoCompleteType="Disabled" runat="server" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="اسم المريض"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="ProcedureDesc1" runat="server">

                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_ProcedureDesc1" DataTextField="ProcedureDesc" DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DDL_ProcedureDesc1_SelectedIndexChanged"></asp:DropDownList>

                                            <%--<br />
                                            <asp:Label ID="Lbl_ProcedureDesc1" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                                            <br />
                                            <asp:Label ID="Lbl_ProcedureDesc11" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>--%>
                                        </td>

                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="1 الإجراء"></asp:Label>
                                        </td>

                                    </tr>

                                    <tr id="ProcedureDesc2" runat="server">

                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_ProcedureDesc2" DataTextField="ProcedureDesc" DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DDL_ProcedureDesc2_SelectedIndexChanged"></asp:DropDownList>
                                            <%-- <br />
                                            <asp:Label ID="Lbl_ProcedureDesc2" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                                             <br />
                                            <asp:Label ID="Lbl_ProcedureDesc22" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>--%>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="2 الإجراء"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="ProcedureDesc3" runat="server">

                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_ProcedureDesc3" DataTextField="ProcedureDesc" DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DDL_ProcedureDesc3_SelectedIndexChanged"></asp:DropDownList>
                                            <%--<br />
                                            <asp:Label ID="Lbl_ProcedureDesc3" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                                             <br />
                                            <asp:Label ID="Lbl_ProcedureDesc33" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>--%>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="3 الإجراء"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="ProcedureDesc4" runat="server">

                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_ProcedureDesc4" DataTextField="ProcedureDesc" DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DDL_ProcedureDesc4_SelectedIndexChanged"></asp:DropDownList>
                                            <%--<br />
                                            <asp:Label ID="Lbl_ProcedureDesc4" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                                             <br />
                                            <asp:Label ID="Lbl_ProcedureDesc44" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>--%>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="4 الإجراء"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="ProcedureDesc5" runat="server">

                                        <td>

                                            <asp:DropDownList runat="server" ID="DDL_ProcedureDesc5" DataTextField="ProcedureDesc" DataValueField="ID" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DDL_ProcedureDesc5_SelectedIndexChanged"></asp:DropDownList>
                                            <%-- <br />
                                            <asp:Label ID="Lbl_ProcedureDesc5" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
                                             <br />
                                            <asp:Label ID="Lbl_ProcedureDesc55" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>--%>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="5 الإجراء"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="PatientRatio" runat="server">
                                        <td>

                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_PatientRatio" placeholder="5 تعني 5%" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="% نسبة تحمل المريض"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="Calculate" runat="server">
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Calculate" runat="server" Text="إحتساب" Width="60px" OnClick="Btn_Calculat_Click" />
                                        </td>
                                        <td></td>
                                    </tr>



                                    <tr id="Tax" runat="server">
                                        <td>

                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Tax" placeholder="5 تعني 5%" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="% ضريبة الدخل"></asp:Label>
                                        </td>
                                    </tr>




                                    <tr id="Module_No" runat="server">

                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Sample_Num" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم النموذج"></asp:Label>
                                        </td>

                                    </tr>


                                    <tr id="Card_No" runat="server">
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Card_Num" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم البطاقة"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="Approval_number" runat="server">
                                        <td class="auto-style2" style="direction: rtl;">
                                            <asp:TextBox ID="Txt_Approval_number" AutoCompleteType="Disabled" runat="server" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم الموافقة"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Stamps" BackColor="#CCCCCC" ReadOnly="True" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الطوابع"></asp:Label>
                                        </td>
                                    </tr>



                                    <tr>
                                        <td class="auto-style2" style="direction: rtl;">
                                            <asp:TextBox ID="Txt_Stamps_Total" ReadOnly="true" Enabled="false" runat="server" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="مجموع الطوابع"></asp:Label>
                                        </td>
                                    </tr>


                                    <%-- <tr style="direction: rtl;">
                                        <td>
                                            <asp:RadioButtonList runat="server" ID="RB_Delivered">
                                                <asp:ListItem Value="1">تم التسليم</asp:ListItem>
                                                <asp:ListItem Value="0">لم يتم التسليم</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="التسليم"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <%--Rami--%>


                                    <tr id="Date" runat="server">
                                        <td class="auto-style2" style="direction: rtl;">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="TxtDate_SubClaim" Width="300px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="TxtDate_SubClaim" />

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="التاريخ"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="procedures" runat="server">
                                        <td class="auto-style2" style="direction: rtl;">
                                            <asp:TextBox ID="Txt_procedures" TextMode="MultiLine" AutoCompleteType="Disabled" runat="server" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الملاحظات"></asp:Label>
                                        </td>
                                    </tr>

                                    <%--Receipt--%>
                                     <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_SubID" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم السند الفرعي"></asp:Label>
                                        </td>
                                    </tr>

                                    
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Receipt_Date" Width="300px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Receipt_Date" />
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="تاريخ السند"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="TextBox1" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="المبلغ"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Acounting_No" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم الحساب"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Statement" TextMode="MultiLine" Width="300px"> </asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="البيان"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--Receipt--%>


                                    <tr>
                                        <td class="nav-justified" style="direction: rtl;">
                                            <asp:FileUpload ID="fileImages" Multiple="Multiple" runat="server" Width="300px" />
                                            <asp:Repeater ID="Rpt_Download" Visible="false" runat="server">
                                                <ItemTemplate>
                                                    <a href="Download.ashx?file=\\UploadedImages<%# DataBinder.Eval(Container, "DataItem.attach_Path") %>" style="font-size: large; color: black;">تنزيل</a>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>

                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="الملفات المرفقة"></asp:Label>
                                        </td>
                                    </tr>


                                    <%--Rami--%>
                                    <tr style="display: flex; direction: rtl">
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Save_SubClaims" runat="server" Text="إدخال" Width="50px" OnClick="Btn_Save_SubClaims_Click" />
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Update_SubClaims" Visible="false" runat="server" Text="تعديل" OnClick="Btn_Update_SubClaims_Click" Width="60px" />
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Delete_SubClaims" Visible="false" runat="server" Text="حذف" Width="60px" OnClick="Btn_Delete_SubClaims_Click" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_InsertAll" runat="server" Text="حفظ جميع المدخلات" Width="301px" OnClick="Btn_InsertAll_Click" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%-- <tr>
                                        <td>
                                            <asp:Button ID="Btn_ListingBonds" Visible="false" runat="server" CssClass="btn_listingbonds" Text="إدخال حركة قيد لمجموع الطوابع" OnClick="Btn_ListingBonds_Click" />
                                        </td>

                                    </tr>--%>
                                    <%--  <tr>
                                        <td>
                                            <asp:Button ID="BTN_RAMI" runat="server" Text="حفظ جميع " Width="301px" OnClick="BTN_RAMI_Click" />
                                        </td>
                                        <td></td>
                                    </tr>--%>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="Btn_Save_SubClaims" />
                                <asp:PostBackTrigger ControlID="Btn_Update_SubClaims" />
                                <%--<asp:PostBackTrigger ControlID="BTN_RAMI" />--%>
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>



                <div class="COLR" style="margin-left: -60px">
                    <div class="table-responsive" style="width: 113%; margin-left: -67px;">


                        <table class="table-responsive">
                            <tr>

                                <td>

                                    <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Name" DataValueField="ID" Width="150px" Style="visibility: hidden"></asp:DropDownList>
                                    <asp:Label ID="Label9" runat="server" Text="الشركة2" Style="visibility: hidden"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="Btn_Search2" runat="server" CssClass="Btn_Search" Text="بحث" OnClick="Btn_Search2_Click" />
                                </td>
                                <td>

                                    <asp:DropDownList ID="DDL_Main_Company2" runat="server" DataTextField="Name" DataValueField="ID" Width="300px"></asp:DropDownList>
                                    <asp:Label ID="Label11" runat="server" Text="الشركة"></asp:Label>
                                </td>


                            </tr>
                        </table>


                        <div id="GV_Subclaim" style="height: 450px;">
                            <asp:GridView ID="GridView_SubClaims" DataKeyNames="التسلسل" runat="server" CssClass="Grid" AllowPaging="False" OnSelectedIndexChanged="GridView_SubClaims_SelectedIndexChanged1" OnPageIndexChanging="GridView_SubClaims_PageIndexChanging" PagerSettings-PageButtonCount="4" OnRowCreated="GridView_SubClaims_RowCreated" OnRowDataBound="GridView_SubClaims_RowDataBound">

                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="اختر" ControlStyle-ForeColor="Black" />
                                </Columns>
                            </asp:GridView>
                        </div>


                    </div>

                    <table class="table-responsive">
                        <tr>
                            <%--<caption class="CaptionEdited2" id="GV2">--%>

                            <%--</caption>--%>
                        </tr>



                        <%--Rami--%>
                        <!--start-->
                        <tr>
                            <div id="slider" runat="server" style="padding: 100px 0; background: #333; width: 100%; height: 12px;">
                                <div id="thumbnail-slider" style="display: none;">
                                    <div class="inner">
                                        <ul>
                                            <asp:Repeater ID="RP_ImagesLi" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <a class="thumb" href='UploadedImages<%# DataBinder.Eval(Container, "DataItem.attach_Path") %>'></a>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                    <div id="closeBtn">CLOSE</div>
                                </div>

                                <ul id="myGallery" style="display: inline-flex; margin-top: -99px;">
                                    <asp:Repeater ID="RP_Image" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <img style="margin-top: -39px; height: 87%;"
                                                    src="UploadedImages\<%# DataBinder.Eval(Container, "DataItem.attach_Path") %>" title="<%# DataBinder.Eval(Container, "DataItem.Attach_Id") %>" />
                                                <%--<a id="Btn_Delete_Image"  style="font-size: large;" onclick="Delete_Image(<%# DataBinder.Eval(Container, "DataItem.Attach_Id") %>)">حذف</a>--%>

                                                <asp:LinkButton ID="btnDelete" runat="server" Style="font-size: large;" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.Attach_Id") %>' OnClick="Btn_Delete_Click">
                                            حذف
                                                </asp:LinkButton>

                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>

                                <div style="clear: both;"></div>

                            </div>
                        </tr>
                        <%--Rami--%>
                    </table>
                </div>
            </div>

        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div id="blur" />
                <div id="progress">
                    &nbsp;<img src="img/unnamed.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </section>



    <script src="scripts/jquery-1.7.min.js"></script>
    <script src="scripts/select2.min.js"></script>
    <script src="js/thumbnail-slider.js"></script>
    <script>
        //Note: this script should be placed at the bottom of the page, or after the slider markup. It cannot be placed in the head section of the page.
        var thumbSldr = document.getElementById("thumbnail-slider");
        var closeBtn = document.getElementById("closeBtn");
        var galleryImgs = document.getElementById("myGallery").getElementsByTagName("img");
        for (var i = 0; i < galleryImgs.length; i++) {
            galleryImgs[i].index = i;
            galleryImgs[i].onclick = function (e) {
                var li = this;
                thumbSldr.style.display = "block";
                mcThumbnailSlider.init(li.index);
            };
        }

        thumbSldr.onclick = closeBtn.onclick = function (e) {
            //This event will be triggered only when clicking the area outside the thumbs or clicking the CLOSE button
            thumbSldr.style.display = "none";
        };
    </script>
    <script language="javascript" type="text/javascript">
        window.onload = function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
        }
        function jsFunctions() {
            $("#<%=DDL_Receiver_Employee.ClientID%>").select2();
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Main_Company.ClientID%>").select2();
            $("#<%=DDL_Main_Company2.ClientID%>").select2();
            $("#<%=DDL_Medical_Name_Search.ClientID%>").select2();
            $("#<%=DDL_Sub_Company.ClientID%>").select2();
            $("#<%=DDL_Specialization.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc5.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc4.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc3.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc2.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc1.ClientID%>").select2();
            $("#<%=DDL_Year.ClientID%>").select2();
            $("#<%=DDL_Month.ClientID%>").select2();



        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Receiver_Employee.ClientID%>").select2();
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            $("#<%=DDL_Main_Company.ClientID%>").select2();
            $("#<%=DDL_Main_Company2.ClientID%>").select2();
            $("#<%=DDL_Medical_Name_Search.ClientID%>").select2();
            $("#<%=DDL_Sub_Company.ClientID%>").select2();
            $("#<%=DDL_Specialization.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc5.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc4.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc3.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc2.ClientID%>").select2();
            $("#<%=DDL_ProcedureDesc1.ClientID%>").select2();
            $("#<%=DDL_Year.ClientID%>").select2();
            $("#<%=DDL_Month.ClientID%>").select2();
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
        function DateField_KeyDown(dateField, CalendarExtender3) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender3);
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



    <script language="javascript" type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(
            function () {
                if (document.getElementById) {
                    //var progress = document.getElementById('progress');
                    var blur = document.getElementById('blur');
                    //progress.style.width = '300px';
                    //progress.style.height = '30px';
                    blur.style.height = document.documentElement.clientHeight;
                    //progress.style.top = document.documentElement.clientHeight / 3 - progress.style.height.replace('px', '') / 2 + 'px';
                    //progress.style.left = document.body.offsetWidth / 2 - progress.style.width.replace('px', '') / 2 + 'px';
                }
            }
        )
    </script>
</asp:Content>

