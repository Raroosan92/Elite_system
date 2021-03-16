<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Medical_Types.aspx.cs" EnableEventValidation="false" Inherits="Elite_system.Medical_Types" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .LblTotal {
            color: red;
            font-weight: 800;
            font-size: 20px;
            letter-spacing: 7px;
        }

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <section class="text-center my-5" style="padding-top: 1%; direction: ltr;    height: auto;">
                <div class="container">
                    <div class="row">

                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <div class="COLR" style="float: right">

                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label1" runat="server" Text="إدخال الجهات الطبية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lbl_Total" CssClass="LblTotal" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="المجموع الحالي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Name" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الاسم"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Type" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="النوع"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Specialization" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="التخصص"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Place" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="المكان"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Region1" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                            <%-- <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Region" Width="300px"></asp:TextBox>--%>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="المنطقة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Address" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="العنوان"></asp:Label>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Building"></asp:TextBox></td>
                                        <td>
                                            <asp:Label runat="server" Text="المجمع"></asp:Label></td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Email"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="البريد الالكتروني"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Phone"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الهاتف"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Mobile"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الخلوي"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Fax"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الفاكس"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_P_O_Box"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم البريد"></asp:Label>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Medical_Status" DataTextField="Description" DataValueField="ID" Width="180px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="حالة الجهة الطبية"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <%-- <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Reason"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="سبب الحالة"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" AutoPostBack="true" ID="DDL_Contracting_Status" DataTextField="Description" DataValueField="ID" Width="180px" OnSelectedIndexChanged="DDL_Contracting_Status_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="حالة التعاقد"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Save1" runat="server" Text="حفظ" OnClick="Btn_Save_Click" Style="border-radius: 15px; width: 50px; font-family: 'Ruda',sans-serif;" CssClass=" btn btn-large btn-primary" />

                                        </td>
                                        <td></td>
                                    </tr>



                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Contract_NO" ReadOnly="True" AutoPostBack="False" BackColor="Silver"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="LblContract_NO" runat="server" Text="رقم العقد"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Contract_Date"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Contract_Date" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Contract_Date" runat="server" Text="تاريخ التعاقد"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ContractExpiryDate"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_ContractExpiryDate" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_ContractExpiryDate" runat="server" Text="تاريخ انتهاء التعاقد"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Accounting_Date"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Accounting_Date" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Accounting_Date" runat="server" Text="تاريخ المحاسبة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Contracting_Value"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Contracting_Value" runat="server" Text="قيمة التعاقد"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr style="direction: rtl">
                                        <td>
                                            <asp:RadioButtonList runat="server" ID="RB_Stamps">
                                                <asp:ListItem Value="1">يضع طوابع</asp:ListItem>
                                                <asp:ListItem Value="0">لا يضع طوابع</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRB_Stamps" runat="server" Text="الطوابع"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Employee" DataTextField="Employee_Name" DataValueField="ID" Width="180px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDDL_Employee" runat="server" Text="الموظف"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Bank" DataTextField="Bank_Name" DataValueField="ID" Width="180px" OnSelectedIndexChanged="DDL_Bank_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDDL_Bank" runat="server" Text="البنك الرئيسي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Bank_Branch" DataTextField="Sub_Bank_Name" DataValueField="ID" Width="180px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDDL_Bank_Branch" runat="server" Text="الفرع"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" ReadOnly="false" runat="server" ID="Txt_Acounting_NO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Acounting_NO" runat="server" Text=" رقم الحساب البنكي"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_P_O_Box2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_P_O_Box2" runat="server" Text="الرمز البريدي"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Tax_NO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Tax_NO" runat="server" Text="الرقم الضريبي"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                      <%-- <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_TransactionPrice"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_TransactionPrice" runat="server" Text="تسعيرة الإجراء"></asp:Label>
                                        </td>
                                    </tr>

                                       <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_CheckPrice"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_CheckPrice" runat="server" Text="تسعيرة الكشفية"></asp:Label>
                                        </td>
                                    </tr>

                                       <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_DiscountRatio"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_DiscountRatio" runat="server" Text="نسبة الخصم التعاقدي"></asp:Label>
                                        </td>
                                    </tr>--%>

                                    <%-- <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Authorization_NO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم التفويض"></asp:Label>
                                        </td>
                                    </tr>--%>

                                    <%--Rami--%>
                                    <tr>
                                        <td class="auto-style2" style="direction: rtl;">
                                            <asp:FileUpload ID="fileImages" Multiple="Multiple" runat="server" />
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label ID="lblfileImages" runat="server" Text="الملفات المرفقة"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--Rami--%>



                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Save2" runat="server" Text="حفظ" OnClick="Btn_Save_Click" Style="border-radius: 15px; width: 50px; font-family: 'Ruda',sans-serif;" CssClass=" btn btn-large btn-primary" />

                                        </td>
                                        <td></td>
                                    </tr>

                                </table>
                            </div>
                        </div>

                        <div class="COLR" style="float: right" id="Update" runat="server">

                            <div class="table-responsive">
                                <table class="table table-striped">

                                    <tr style="background-color: #2f323a;">
                                        <td style="width: 98px">
                                            <asp:Label ID="Label111" runat="server" Text="تعديل الجهات الطبية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                        <td class="auto-style1"></td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style1">
                                            <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DDL_Medical_Name"
                                                CssClass="alertFont" ErrorMessage="الرجاء اختيار الجهة الطبية" Operator="NotEqual"
                                                ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">الرجاء اختيار الجهة الطبية</asp:CompareValidator>--%>
                                            <asp:DropDownList ID="DDL_Medical_Name" runat="server" DataTextField="Name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="DDL_Medical_Name_SelectedIndexChanged" Width="300px"></asp:DropDownList>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Name2" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الاسم"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Type2" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="النوع"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Specialization2" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="التخصص"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Place2" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="المكان"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Region2" DataTextField="Description" DataValueField="ID" Width="300px"></asp:DropDownList>
                                            <%--<asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Region2" Width="300px"></asp:TextBox>--%>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="المنطقة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Address2" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="العنوان"></asp:Label>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Building2"></asp:TextBox></td>
                                        <td>
                                            <asp:Label runat="server" Text="المجمع"></asp:Label></td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Email2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="البريد الالكتروني"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Phone2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الهاتف"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Mobile2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الخلوي"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Fax2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الفاكس"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_P_O_Box3"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم البريد"></asp:Label>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Medical_Status2" DataTextField="Description" DataValueField="ID" Width="180px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="حالة الجهة الطبية"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <%--<tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Reason2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="سبب الحالة"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" AutoPostBack="true" ID="DDL_Contracting_Status2" DataTextField="Description" DataValueField="ID" Width="180px" OnSelectedIndexChanged="DDL_Contracting_Status2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="حالة التعاقد"></asp:Label>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="TextBox1"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الهاتف"></asp:Label>
                                        </td>
                                    </tr>

                                    

                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Delete" runat="server" Text="حذف" OnClick="Btn_Delete_Click1" Style="border-radius: 15px; width: 50px; font-family: 'Ruda',sans-serif;" CssClass=" btn btn-large btn-primary" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Btn_Update1" runat="server" Text="تعديل" OnClick="Btn_Update_Click" Style="border-radius: 15px; width: 50px; font-family: 'Ruda',sans-serif;" CssClass=" btn btn-large btn-primary" />
                                        </td>
                                        
                                    </tr>



                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Contract_NO2" ReadOnly="True" AutoPostBack="False" BackColor="Silver"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblContract_NO2" runat="server" Text="رقم العقد"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Contract_Date2"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender11" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Contract_Date2" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Contract_Date2" runat="server" Text="تاريخ التعاقد"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ContractExpiryDate2"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender22" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_ContractExpiryDate2" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_ContractExpiryDate2" runat="server" Text="تاريخ انتهاء التعاقد"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Accounting_Date2"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender33" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Accounting_Date2" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Accounting_Date2" runat="server" Text="تاريخ المحاسبة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Contracting_Value2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Contracting_Value2" runat="server" Text="قيمة التعاقد"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td style="direction: rtl">
                                            <asp:RadioButtonList runat="server" ID="RB_Stamps2">
                                                <asp:ListItem Value="1">يضع طوابع</asp:ListItem>
                                                <asp:ListItem Value="0">لا يضع طوابع</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRB_Stamps2" runat="server" Text="الطوابع"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Employee2" DataTextField="Employee_Name" DataValueField="ID" Width="180px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDDL_Employee2" runat="server" Text="الموظف"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Bank2" DataTextField="Bank_Name" DataValueField="ID" Width="180px" OnSelectedIndexChanged="DDL_Bank2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDDL_Bank2" runat="server" Text="البنك الرئيسي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DDL_Bank_Branch2" DataTextField="Sub_Bank_Name" DataValueField="ID" Width="180px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDDL_Bank_Branch2" runat="server" Text="الفرع"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" ReadOnly="false" runat="server" ID="Txt_Acounting_NO2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Acounting_NO2" runat="server" Text=" رقم الحساب البنكي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_P_O_Box4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_P_O_Box4" runat="server" Text="الرمز البريدي"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Tax_NO2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTxt_Tax_NO2" runat="server" Text="الرقم الضريبي"></asp:Label>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <textarea id="Txt_Note" runat="server" cols="20" rows="2"></textarea>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="ملاحظات"></asp:Label>
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
                                            <asp:Label ID="Label2" runat="server" Text="تاريخ التجميد من"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_FreezTo"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_FreezTo" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="تاريخ التجميد الى"></asp:Label>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_TransactionPrice2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_TransactionPrice2" runat="server" Text="تسعيرة الإجراء"></asp:Label>
                                        </td>
                                    </tr>

                                       <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_CheckPrice2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_CheckPrice2" runat="server" Text="تسعيرة الكشفية"></asp:Label>
                                        </td>
                                    </tr>

                                       <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_DiscountRatio2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lbl_DiscountRatio2" runat="server" Text="نسبة الخصم التعاقدي"></asp:Label>
                                        </td>
                                    </tr>--%>

                                    <%-- <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Authorization_NO2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="رقم التفويض"></asp:Label>
                                        </td>
                                    </tr>--%>

                                    <%--Rami--%>
                                    <tr>
                                        <td class="auto-style2" style="direction: rtl;">
                                            <asp:FileUpload ID="FileUpload1" Multiple="Multiple" runat="server" />
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label ID="lblFileUpload1" runat="server" Text="الملفات المرفقة"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--Rami--%>


                                    <tr>

                                        <td>
                                            <asp:Button ID="Btn_Delete2" runat="server" Text="حذف" OnClick="Btn_Delete_Click1" Style="border-radius: 15px; width: 50px; font-family: 'Ruda',sans-serif;" CssClass=" btn btn-large btn-primary" />
                                        </td>
                                        <td>

                                            <asp:Button ID="Btn_Update2" runat="server" Text="تعديل" OnClick="Btn_Update_Click" Style="border-radius: 15px; width: 50px; font-family: 'Ruda',sans-serif;" CssClass=" btn btn-large btn-primary" />
                                        </td>
                                        <td></td>
                                    </tr>

                                </table>
                            </div>

                        </div>

                    </div>

                </div>

            </section>


            <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR">
                            <div class="table-responsive">
                                <table class="table-responsive">
                                     <tr>
                                    <%--Rami--%>
                                    <!--start-->
                                    <div id="slider" runat="server" style="padding: 100px 0; background: #333; width: 100%; height: 12px;">
                                        <div id="thumbnail-slider" style="display: none;">
                                            <div class="inner">
                                                <caption>
                                                    <ul>
                                                        <asp:Repeater ID="RP_ImagesLi" runat="server">
                                                            <ItemTemplate>
                                                                <li><a class="thumb" href='UploadedImages<%# DataBinder.Eval(Container, "DataItem.attach_Path") %>'></a></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </caption>
                                            </div>
                                            <div id="closeBtn">
                                                <caption>
                                                    CLOSE</caption>
                                            </div>
                                        </div>

                                        <ul id="myGallery" style="display: inline-flex; margin-top: -99px;">
                                            <asp:Repeater ID="RP_Image" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <img style="margin-top: -235px; height: 130%;"
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

                                    <%--Rami--%>
                                         </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Btn_Save1" />
            <asp:PostBackTrigger ControlID="Btn_Save2" />
            <asp:PostBackTrigger ControlID="Btn_Update1" />
            <asp:PostBackTrigger ControlID="Btn_Update2" />

        </Triggers>
    </asp:UpdatePanel>

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
            $("#<%=DDL_Specialization.ClientID%>").select2();
            $("#<%=DDL_Specialization2.ClientID%>").select2();
            $("#<%=DDL_Place.ClientID%>").select2();
            $("#<%=DDL_Place2.ClientID%>").select2();
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
           <%-- $("#<%=DDL_Medical_Status.ClientID%>").select2();
            $("#<%=DDL_Medical_Status2.ClientID%>").select2();--%>
            $("#<%=DDL_Contracting_Status.ClientID%>").select2();
            $("#<%=DDL_Contracting_Status2.ClientID%>").select2();
            $("#<%=DDL_Employee.ClientID%>").select2();
            $("#<%=DDL_Employee2.ClientID%>").select2();
            $("#<%=DDL_Bank.ClientID%>").select2();
            $("#<%=DDL_Bank2.ClientID%>").select2();
            $("#<%=DDL_Bank_Branch.ClientID%>").select2();
            $("#<%=DDL_Bank_Branch2.ClientID%>").select2();
            $("#<%=DDL_Type2.ClientID%>").select2();
            $("#<%=DDL_Type.ClientID%>").select2();
            $("#<%=DDL_Place.ClientID%>").select2();
            $("#<%=DDL_Region1.ClientID%>").select2();
            $("#<%=DDL_Region2.ClientID%>").select2();
        }


    </script>
    <script>
        $(function aa() {
            $("#<%=DDL_Specialization.ClientID%>").select2();
            $("#<%=DDL_Specialization2.ClientID%>").select2();
            $("#<%=DDL_Place.ClientID%>").select2();
            $("#<%=DDL_Place2.ClientID%>").select2();
            $("#<%=DDL_Medical_Name.ClientID%>").select2();
            <%--$("#<%=DDL_Medical_Status.ClientID%>").select2();
            $("#<%=DDL_Medical_Status2.ClientID%>").select2();--%>
            $("#<%=DDL_Contracting_Status.ClientID%>").select2();
            $("#<%=DDL_Contracting_Status2.ClientID%>").select2();
            $("#<%=DDL_Employee.ClientID%>").select2();
            $("#<%=DDL_Employee2.ClientID%>").select2();
            $("#<%=DDL_Bank.ClientID%>").select2();
            $("#<%=DDL_Bank2.ClientID%>").select2();
            $("#<%=DDL_Bank_Branch.ClientID%>").select2();
            $("#<%=DDL_Bank_Branch2.ClientID%>").select2();
            $("#<%=DDL_Type2.ClientID%>").select2();
            $("#<%=DDL_Type.ClientID%>").select2();
            $("#<%=DDL_Place.ClientID%>").select2();
            $("#<%=DDL_Region1.ClientID%>").select2();
            $("#<%=DDL_Region2.ClientID%>").select2();


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
    <script>
        function DateField_KeyDown(dateField, CalendarExtender1) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender1);
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
        function DateField_KeyDown(dateField, CalendarExtender11) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender11);
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
        function DateField_KeyDown(dateField, CalendarExtender22) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender22);
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
        function DateField_KeyDown(dateField, CalendarExtender33) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender33);
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
</asp:Content>
