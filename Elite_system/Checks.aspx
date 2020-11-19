<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Checks.aspx.cs" Inherits="Elite_system.Checks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
        <div class="container">
            <div class="row">
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="COLR" style="float: right; height: 900px;">

                    <div class="table-responsive">
                        <asp:HiddenField ID="MainID" runat="server" />
                        <table class="table table-striped" style="direction: ltr;">

                            <tr style="background-color: #2f323a;">
                                <td class="auto-style1"></td>
                                <td style="width: 98px">

                                    <asp:Label ID="Label5" runat="server" Text="الشيكات" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button ID="Btn_MedicalTypesChecks" runat="server" Text="شيكات الجهات الطبية" Width="200px" OnClick="Btn_MedicalTypesChecks_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="Btn_companiesChecks" runat="server" Text="شيكات الشركات" Width="200px" OnClick="Btn_companiesChecks_Click" />
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DDL_Company"
                                        CssClass="alertFont" ErrorMessage="*" Operator="NotEqual"
                                        ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">*</asp:CompareValidator>--%>
                                    <asp:DropDownList runat="server" ID="DDL_Company" Width="300px" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="الشركة" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Check_Date" Font-Bold="True" Font-Size="Medium" Width="300px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Check_Date" />

                                </td>
                                <td style="width: 98px">

                                    <asp:Label runat="server" Text="تاريخ الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Entry_Date" Font-Bold="True" Font-Size="Medium" Enabled="False" Width="300px" ForeColor="Black"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Entry_Date" />
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="تاريخ الادخال" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Received_Date" Font-Bold="True" Font-Size="Medium" Width="300px">

                                    </asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Received_Date" />
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="تاريخ الاستلام" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Delivery_Date" Enabled="false" Font-Bold="True" Font-Size="Medium" Width="300px">

                                    </asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Delivery_Date" />
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="تاريخ التسليم" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <%--<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="DDL_Bank"
                                        CssClass="alertFont" ErrorMessage="*" Operator="NotEqual"
                                        ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">*</asp:CompareValidator>--%>
                                    <asp:DropDownList runat="server" Width="300px" ID="DDL_Bank" DataTextField="Bank_Name" DataValueField="ID" OnSelectedIndexChanged="DDL_Bank_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="البنك" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:DropDownList runat="server" Width="300px" ID="DDL_Bank_Branch" DataTextField="Sub_Bank_Name" DataValueField="ID" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                </td>
                                <td style="width: 98px">
                                    <asp:Label runat="server" Text="الفرع" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <%--<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="DDL_Sent_To"
                                        CssClass="alertFont" ErrorMessage="*" Operator="NotEqual"
                                        ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">*</asp:CompareValidator>--%>
                                    <asp:DropDownList ID="DDL_Sent_To" Width="300px" runat="server" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                </td>
                                <td>

                                    <asp:Label runat="server" Text="الجهة المرسل لها الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label><br />

                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Value" Font-Bold="True" Font-Size="Medium" Width="300px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="قيمة الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                        ControlToValidate="Txt_Value" runat="server"
                                        ErrorMessage="*"
                                        ValidationExpression="((\d+)((\.\d{1,3})?))$" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Check_No" Font-Bold="True" Font-Size="Medium" Width="300px"></asp:TextBox>
                                </td>
                                <td>

                                    <asp:Label runat="server" Text="رقم الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Months" Font-Bold="True" Font-Size="Medium" Width="300px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="الشهر/الأشهر" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Notes" Font-Bold="True" Font-Size="Medium" Width="300px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="ملاحظات" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                </td>
                            </tr>

                            <%-- <tr style="direction: rtl;">
                                        <td>
                                            <asp:RadioButtonList runat="server" Enabled="false" ID="RB_Delivered">
                                                <asp:ListItem Value="1">تم التسليم</asp:ListItem>
                                                <asp:ListItem Value="0">لم يتم التسليم</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="التسليم"></asp:Label>
                                        </td>
                                    </tr>--%>

                            <%--Rami--%>
                            <tr>
                                <td class="auto-style2" style="direction: rtl;">
                                    <asp:FileUpload ID="fileImages" Multiple="Multiple" runat="server" />
                                </td>
                                <td style="height: 26px; width: 98px;">
                                    <asp:Label runat="server" Text="الملفات المرفقة" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                </td>
                            </tr>
                            <%--Rami--%>
                            <tr style="direction: rtl;">
                                <td>
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                                </td>
                                <td>
                                    <asp:Label runat="server" Text="BarCode" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                </td>
                            </tr>

                            <tr style="direction: rtl;">
                                <td style="width: 98px">
                                    <asp:Button ID="Btn_Save1" runat="server" Text="إدخال" OnClick="Btn_Save1_Click" Height="26px" />
                                    &nbsp; 	&nbsp; &nbsp;
                                             <asp:Button ID="Btn_Update1" runat="server" Text="تعديل" OnClick="Btn_Update1_Click" />
                                    &nbsp; &nbsp; &nbsp;
                                            <asp:Button ID="BtnDelete" runat="server" Text="حذف" OnClick="BtnDelete_Click" />
                                    &nbsp; &nbsp; &nbsp;
                                            <%--<asp:Button ID="Font" runat="server" Text="خط" OnClick="Font_Click" />--%>

                                </td>
                                <td style="width: 98px"></td>



                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Btn_InsertAll" runat="server" Text="حفظ جميع المدخلات" Width="301px" OnClick="Btn_InsertAll_Click" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <%-- <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label4" runat="server" Text="" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                </td>

                            </tr>--%>
                        </table>
                    </div>
                </div>

                <div class="COLR">

                    <div class="table-responsive" style="height: 780px;">
                        <table class="table table-striped" style="direction: ltr;">

                            <tr>

                                <td class="auto-style1">
                                    <asp:DropDownList runat="server" ID="DDL_Company_Search" Width="300px" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                </td>

                                <td style="width: 98px">

                                    <asp:Button ID="Btn_Search" runat="server" Text="بحث عن طريق الشركة" OnClick="Btn_Search_Click" />

                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:TextBox ID="Txt_CheckNo" runat="server" Width="300px"></asp:TextBox>
                                </td>
                                <td style="width: 98px">
                                    <asp:Button ID="Btn_Search2" runat="server" Text="بحث برقم الشيك" OnClick="Btn_Search2_Click" />
                                </td>
                            </tr>

                            <%-- <caption>--%>
                            <br />
                            <%--<asp:SqlDataSource ID="SqlDataSource_Checks" runat="server" ConnectionString="<%$ ConnectionStrings:CONN %>" SelectCommand="SELECT [ID] ,[Company],[Check_Date],SentTo,Value,Check_No FROM [dbo].[V_Main_Check] ORDER BY [ID] DESC" ProviderName="<%$ ConnectionStrings:CONN.ProviderName %>"></asp:SqlDataSource>--%><%--<asp:GridView ID="GV_Main_Check" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource_Checks" OnSelectedIndexChanged="GV_Main_Check_SelectedIndexChanged" PageSize="10" PagerSettings-PageButtonCount="4">--%>
                            <asp:GridView ID="GV_Main_Check" runat="server" AllowPaging="false" CssClass="Grid" OnPageIndexChanging="GV_Main_Check_PageIndexChanging" OnSelectedIndexChanged="GV_Main_Check_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField SelectText="اختر" ShowSelectButton="True" ControlStyle-ForeColor="Black" />
                                    <%--<asp:BoundField DataField="ID" HeaderText="التسلسل" ReadOnly="True" SortExpression="ID" />
                                            <asp:BoundField DataField="Company" HeaderText="اسم الشركة" SortExpression="Company" />
                                            <asp:BoundField DataField="Check_Date" HeaderText="تاريخ الشيك" HeaderStyle-Width="80px" SortExpression="Check_Date" DataFormatString="{0:yyyy-MM-dd}" />
                                            <asp:BoundField DataField="SentTo" HeaderText="الجهة الطبية" HeaderStyle-Width="150px" SortExpression="SentTo" />
                                            <asp:BoundField DataField="Value" HeaderText="المبلغ" SortExpression="Value" />
                                            <asp:BoundField DataField="Check_No" HeaderText="رقم الشيك" SortExpression="Check_No" />--%>
                                </Columns>
                            </asp:GridView>
                            <%-- </caption>--%>
                        </table>



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
                </div>

                <%--   </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Btn_Save1" />
                        <asp:PostBackTrigger ControlID="Btn_Update1" />
                    </Triggers>
                </asp:UpdatePanel>--%>
            </div>

        </div>

    </section>



    <%-- <section class="text-center my-5" runat="server" style="padding-top: 1%; direction: ltr;">
        <div class="container">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="COLR" style="float: right">

                            <div class="table-responsive">
                                <table class="table table-striped" style="direction: ltr;">


                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1"></td>
                                        <td style="width: 98px">

                                            <asp:Label ID="Label6" runat="server" Text=" الشيكات الفرعية" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="DDL_Sent_To"
                                                CssClass="alertFont" ErrorMessage="الرجاء اختيار الجهة المرسل لها الشيك" Operator="NotEqual"
                                                ValueToCompare="0" Display="Dynamic" ForeColor="Red" Font-Bold="true">الرجاء اختيار الجهة المرسل لها الشيك</asp:CompareValidator>
                                            <asp:DropDownList ID="DDL_Sent_To" Width="55%" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
                                        </td>
                                        <td>

                                            <asp:Label runat="server" Text="الجهة المرسل لها الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label><br />

                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Value" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="قيمة الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                ControlToValidate="Txt_Value" runat="server"
                                                ErrorMessage="Only Numbers allowed"
                                                ValidationExpression="((\d+)((\.\d{1,2})?))$" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RegularExpressionValidator><br />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Check_No" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                        </td>
                                        <td>

                                            <asp:Label runat="server" Text="رقم الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Check_Date2" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Check_Date2" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="تاريخ الشيك" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Months" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشهر/الأشهر" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Notes" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="ملاحظات" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                                        </td>
                                    </tr>
                                    <tr style="direction: rtl;">
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
                                    <tr>
                                        <td>
                                            <asp:Button ID="Btn_Save2" runat="server" Text="حفظ" OnClick="Btn_Save2_Click" Height="26px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Btn_Update2" runat="server" Text="تعديل" OnClick="Btn_Update2_Click" Height="26px" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>

                                </table>
                            </div>
                        </div>

                        <div class="COLR">
                            <div class="table-responsive">
                                <table class="table-responsive">


                                    <%--<asp:GridView ID="GV_SubChecks" HorizontalAlign="Center" PageSize="5" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GV_SubChecks_SelectedIndexChanged">
                            </asp:GridView>
 <asp:GridView ID="GV_SubChecks" runat="server" CssClass="Grid" AllowPaging="True" OnSelectedIndexChanged="GV_SubChecks_SelectedIndexChanged" OnPageIndexChanging="GV_SubChecks_PageIndexChanging" PageSize="3" PagerSettings-PageButtonCount="4" ViewStateMode="Enabled">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" SelectText="اختر" />
                                        </Columns>
                                    </asp:GridView>
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>

    </section>--%>

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

            $("#<%=DDL_Company.ClientID%>").select2();
            $("#<%=DDL_Company_Search.ClientID%>").select2();
            $("#<%=DDL_Bank.ClientID%>").select2();
            $("#<%=DDL_Bank_Branch.ClientID%>").select2();
            $("#<%=DDL_Sent_To.ClientID%>").select2();

        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Company.ClientID%>").select2();
            $("#<%=DDL_Company_Search.ClientID%>").select2();
            $("#<%=DDL_Bank.ClientID%>").select2();
            $("#<%=DDL_Bank_Branch.ClientID%>").select2();
            $("#<%=DDL_Sent_To.ClientID%>").select2();

        })
    </script>

  


    <%--rami لتغيير التاريخ من لوحة المفاتيح--%>
    <script>
        function DateField_KeyDown(dateField, CalendarExtender5) {
            lastKeyCodeEntered = window.event.keyCode;
            if ((lastKeyCodeEntered == '37')        //keyCode 37=left arrow
                || (lastKeyCodeEntered == '38')     //keyCode 38=up arrow
                || (lastKeyCodeEntered == '39')     //keyCode 39=right arrow
                || (lastKeyCodeEntered == '40'))    //keyCode 40=down arrow
            {
                var dtbehav = $find(CalendarExtender5);
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
    <%--rami لتغيير التاريخ من لوحة المفاتيح--%>
</asp:Content>
