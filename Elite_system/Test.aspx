<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Elite_system.Test" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
      <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1"></td>
                                        <td style="width: 98px">
                                            <asp:Label ID="Label1" runat="server" Text="المطالبات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Batch_No" BackColor="#CCCCCC" ReadOnly="True">1</asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="رقم الدفعة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ID" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>

                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="التسلسل"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Month_Year" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="مطالبات: شهر/سنة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Entry_Date" ReadOnly="True" BackColor="#CCCCCC"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Entry_Date" />
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="تاريخ الادخال"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DDL_Medical_Name"
                                                CssClass="alertFont" ErrorMessage="الرجاء اختيار الجهة الطبية" Operator="NotEqual"
                                                ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">الرجاء اختيار الجهة الطبية</asp:CompareValidator>
                                            <asp:DropDownList ID="DDL_Medical_Name" runat="server" DataTextField="Name" DataValueField="ID" Width="200px"></asp:DropDownList>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الجهة الطبية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Received_Date"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Received_Date" />
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="تاريخ الاستلام"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="DDL_Receiver_Employee"
                                                CssClass="alertFont" ErrorMessage="الرجاء اختيار المستلم" Operator="NotEqual"
                                                ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">الرجاء اختيار اسم المستلم</asp:CompareValidator>
                                            <asp:DropDownList ID="DDL_Receiver_Employee" runat="server" DataTextField="Employee_Name" DataValueField="ID" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 98px; height: 26px;">
                                            <asp:Label runat="server" Text="المستلم"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:DropDownList ID="DDL_Main_Company" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DDL_Main_Company_SelectedIndexChanged" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sub_Company" runat="server" Width="200px" DataTextField="Sub_Company" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة الفرعية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                ControlToValidate="Txt_Claims_Count" runat="server"
                                                ErrorMessage="Only Numbers allowed"
                                                ValidationExpression="((\d+)((\.\d{1,2})?))$">
                                            </asp:RegularExpressionValidator>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Claims_Count"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="عدد المطالبات"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                ControlToValidate="Txt_Value" runat="server"
                                                ErrorMessage="Only Numbers allowed"
                                                ValidationExpression="((\d+)((\.\d{1,2})?))$">
                                            </asp:RegularExpressionValidator>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Value" AutoPostBack="True" OnTextChanged="Txt_Value_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="قيمة المطالبة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Stamps"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الطوابع"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList runat="server" ID="RB_Delivered">
                                                <asp:ListItem Value="1">تم التسليم</asp:ListItem>
                                                <asp:ListItem Value="0">لم يتم التسليم</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="التسليم"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--Rami--%>
                                    <tr>
                                        <td class="auto-style2" style="direction: rtl;">
                                            <asp:FileUpload ID="fileImages" Multiple="Multiple" runat="server" />
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="الملفات المرفقة"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--Rami--%>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:Button ID="Btn_Save" runat="server" Text="حفظ" OnClick="Btn_Save_Click" Width="54px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Btn_Update" runat="server" Text="تعديل" OnClick="Btn_Update_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>

                        <div class="COLR">
                            <div class="table-responsive">
                                <table class="table-responsive">
                                    <asp:DropDownList ID="DDL_Medical_Name_Search" runat="server" DataTextField="Name" DataValueField="ID" Width="200px"></asp:DropDownList>
                                    <asp:Button ID="Btn_Search" runat="server" Text="بحث" OnClick="Btn_Search_Click" />                                  
                                    <asp:GridView ID="GridView2" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" PagerSettings-PageButtonCount="4">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" SelectText="اختر" />
                                            <asp:BoundField DataField="ID" HeaderText="التسلسل" ReadOnly="True" SortExpression="ID" />
                                            <asp:BoundField DataField="Medical_Name_Desc" HeaderText="اسم الجهة الطبية " SortExpression="Medical_Name_Desc" />
                                            <asp:BoundField DataField="Month_Year" HeaderText="السنة والشهر" SortExpression="Month_Year" />
                                            <%-- <asp:BoundField DataField="Main_Company_Desc" HeaderText="الشركة" SortExpression="Main_Company_Desc" />
                                            <asp:BoundField DataField="Claims_Count" HeaderText="عدد المطالبات" SortExpression="Claims_Count" />
                                            <asp:BoundField DataField="Value" HeaderText="قيمة المطالبة" SortExpression="Value" />
                                            <asp:BoundField DataField="Stamps" HeaderText="الطوابع" SortExpression="Stamps" />--%>
                                        </Columns>
                                    </asp:GridView>

                                </table>
                                <br />
                                <%--Rami--%>
                                <!--start-->
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

                                <%--Rami--%>
                            </div>
                            <br />
                            <div class="table-responsive">

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
                            </div>
                        </div>
                    </div>
                </div>

            </section>
             </ContentTemplate>
             </asp:UpdatePanel>
    </form>
</body>
</html>
