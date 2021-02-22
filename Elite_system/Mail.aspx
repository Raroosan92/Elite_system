<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="Elite_system.Mail" %>

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

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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

                                            <asp:Label ID="Label3" runat="server" Text="البريد  " ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="height: 26px">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Entry_Date" Enabled="False" Width="300px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Entry_Date" />
                                        </td>
                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="تاريخ الادخال"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Company" runat="server" Width="300px" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="الشركة"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Received_Date" Width="300px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Received_Date" />
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="تاريخ الاستلام"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Delivery_Date" Width="300px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Delivery_Date" />
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="تاريخ التسليم"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sent_To" runat="server" Width="300px" DataTextField="Name" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الجهة المرسل لها البريد"></asp:Label>
                                        </td>
                                    </tr>

                                    <%--  <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Received_Date2"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Received_Date2" />
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="تاريخ الاستلام"></asp:Label>
                                        </td>
                                    </tr>--%>

                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Mail_Type" runat="server" Width="300px" DataTextField="Description" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="نوع البريد"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                ControlToValidate="Txt_Mails_Count" runat="server"
                                                ErrorMessage="*"
                                                ValidationExpression="((\d+)((\.\d{1,2})?))$">
                                            </asp:RegularExpressionValidator>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Mails_Count" Width="300px" AutoPostBack="True" OnTextChanged="Txt_Mails_Count_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="العدد"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Notes" TextMode="MultiLine" Width="300px"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_MainMailID" Visible="false" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>

                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Visible="false" Text="التسلسل"></asp:Label>

                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ID" ReadOnly="True" BackColor="#CCCCCC"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="مرجع رقم"></asp:Label>
                                        </td>
                                    </tr>--%>

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
                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="إدخال" OnClick="Btn_Save_Click" />
                                            &nbsp; 	&nbsp; &nbsp;
                                            <asp:Button ID="Btn_Update" runat="server" Text="تعديل" OnClick="Btn_Update_Click" />
                                            &nbsp; 	&nbsp; &nbsp;
                                              <asp:Button ID="BtnDelete" runat="server" Text="حذف" OnClick="BtnDelete_Click" />
                                        </td>

                                        <td></td>
                                    </tr>

                                     <tr>
                                <td>
                                    <asp:Button ID="Btn_InsertAll" runat="server" Text="حفظ جميع المدخلات" Width="301px" OnClick="Btn_InsertAll_Click" />
                                </td>
                                <td></td>
                            </tr>
                                </table>
                            </div>
                        </div>

                        <div class="COLR">
                            <div class="table-responsive" style="height: 600px;">
                                <table class="table-responsive">
                                    <asp:DropDownList ID="DDL_Company_Search" runat="server" DataTextField="Name" DataValueField="ID" Width="300px"></asp:DropDownList>
                                    <asp:Button ID="Btn_Search" runat="server" Text="بحث" OnClick="Btn_Search_Click" />
                                    <caption>
                                        <br />
                                        <br />
                                        <asp:SqlDataSource ID="SqlDataSource_Mails" runat="server" ConnectionString="<%$ ConnectionStrings:CONN %>" SelectCommand="SELECT [ID],[Company],[CompanyDesc],[Entry_Date],[Received_Date],[Delivery_Date],[Sent_To],[Sent_To_Desc],[Mail_Type],[Mail_Type_Desc],[Mails_Count],[Notes],[Delivered] FROM [dbo].[V_Mails] order by ID desc"></asp:SqlDataSource>
                                        <asp:GridView ID="GridView_Mails" runat="server" AllowPaging="false" AutoGenerateColumns="False" CssClass="Grid" DataKeyNames="ID" DataSourceID="SqlDataSource_Mails" OnSelectedIndexChanged="GridView_Mails_SelectedIndexChanged" SelectedRowStyle-VerticalAlign="NotSet" SortedAscendingCellStyle-HorizontalAlign="NotSet">
                                            <Columns>
                                                <asp:CommandField SelectText="اختر" ShowSelectButton="True" />
                                                <asp:BoundField DataField="ID" HeaderText="التسلسل" ReadOnly="True" SortExpression="ID" />
                                                <asp:BoundField DataField="CompanyDesc" HeaderText="الشركة" SortExpression="Name" />
                                                <asp:BoundField DataField="Entry_Date" DataFormatString="{0:yyyy-MM-dd}" HeaderStyle-Width="80px" HeaderText="تاريخ الادخال" SortExpression="Entry_Date" />
                                                <asp:BoundField DataField="Sent_To_Desc" DataFormatString="{0:yyyy-MM-dd}" HeaderText="الجهة الطبية" SortExpression="Sent_To_Desc" />
                                                <asp:BoundField DataField="Mail_Type_Desc" HeaderText="نوع البريد" SortExpression="Mail_Type_Desc" />
                                                <asp:BoundField DataField="Mails_Count" HeaderText="العدد" SortExpression="Mails_Count" />
                                                <%--<asp:BoundField DataField="Notes" HeaderText="الملاحظات" SortExpression="Notes"></asp:BoundField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </caption>


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
                    </div>
                </div>

            </section>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Btn_Save" />
            <asp:PostBackTrigger ControlID="Btn_Update" />
        </Triggers>
    </asp:UpdatePanel>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

    <%--  <section class="text-center my-5" style="padding-top: 1%; direction: ltr;">
                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">

                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1"></td>
                                        <td style="width: 98px">

                                            <asp:Label ID="Label4" runat="server" Text=" البريد الفرعي" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Sent_To" runat="server" Width="53%" AutoPostBack="True" DataTextField="Name" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الجهة المرسل لها البريد"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Received_Date2"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="yyyy-MM-dd" runat="server" TargetControlID="Txt_Received_Date2" />
                                        </td>
                                        <td style="width: 98px">
                                            <asp:Label runat="server" Text="تاريخ الاستلام"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Mail_Type" runat="server" Width="53%" AutoPostBack="True" DataTextField="Description" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="نوع البريد"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                ControlToValidate="Txt_Mails_Count" runat="server"
                                                ErrorMessage="Only Numbers allowed"
                                                ValidationExpression="((\d+)((\.\d{1,2})?))$">
                                            </asp:RegularExpressionValidator>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Mails_Count"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="العدد"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_Notes"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="ملاحظات"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_ID" ReadOnly="True" BackColor="#CCCCCC"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="مرجع رقم"></asp:Label>
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

                                    <tr>
                                        <td>

                                            <asp:Button ID="Btn_Update_Submail" runat="server" Text="تعديل" Height="26px" OnClick="Btn_Update_Submail_Click" />
                                        </td>

                                        <td>
                                            <asp:Button ID="Btn_Save_Submail" runat="server" Text="حفظ" OnClick="Btn_Save_Submail_Click" />
                                        </td>
                                    </tr>

                                </table>
                            </div>
                        </div>
                        <div class="COLR">
                            <div class="table-responsive">
                                <table class="table-responsive">

                                    <asp:GridView ID="GridView_SubMails" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView_SubMails_SelectedIndexChanged" OnPageIndexChanging="GridView_SubMails_PageIndexChanging" PageSize="3" PagerSettings-PageButtonCount="4"></asp:GridView>

                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </section>--%>

    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>





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
            $("#<%=DDL_Sent_To.ClientID%>").select2();
            $("#<%=DDL_Mail_Type.ClientID%>").select2();
            $("#<%=DDL_Company.ClientID%>").select2();
            $("#<%=DDL_Company_Search.ClientID%>").select2();

        }

    </script>
    <script>
        $(function () {
            $("#<%=DDL_Sent_To.ClientID%>").select2();
            $("#<%=DDL_Mail_Type.ClientID%>").select2();
            $("#<%=DDL_Company.ClientID%>").select2();
            $("#<%=DDL_Company_Search.ClientID%>").select2();

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
    <%--rami لتغيير التاريخ من لوحة المفاتيح--%>
</asp:Content>
