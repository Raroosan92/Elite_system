<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Payment_Of_Claims.aspx.cs" Inherits="Elite_system.Payment_Of_Claims" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" UpdateMode="Conditional">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <section class="text-center" style="padding-top: 1%; direction: ltr;">

                <div class="container">
                    <div class="row">
                        <div class="COLR" style="float: right">
                            <div class="table-responsive">
                                <table id="SubClaimTable" runat="server" class="table table-striped">
                                    <tr style="background-color: #2f323a;">
                                        <td class="auto-style1"></td>
                                        <td style="width: 98px">
                                            <asp:Label ID="Label4" runat="server" Text="الدفع" ForeColor="#f2f2f2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </td>
                                    </tr>
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

                                            <asp:DropDownList ID="DDL_Main_Company" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" Width="300px" OnSelectedIndexChanged="DDL_Main_Company_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الشركة الرئيسية"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDL_Status" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="ID" Width="300px" OnSelectedIndexChanged="DDL_Status_SelectedIndexChanged">
                                                <asp:ListItem>--أختر--</asp:ListItem>
                                                <asp:ListItem>IN</asp:ListItem>
                                                <asp:ListItem>OUT</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="الحالة"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <%--  <asp:DropDownList ID="DDL_Sub_Company" runat="server" AutoPostBack="True" Width="300px" DataTextField="Sub_Company" DataValueField="ID">
                                            </asp:DropDownList>--%>
                                            <asp:TextBox AutoCompleteType="Disabled" runat="server" ID="Txt_PayAmmount" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="المبلغ المدفوع"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td class="nav-justified" style="direction: rtl;white-space: normal;">
                                            <asp:FileUpload ID="fileImages" Multiple="Multiple" runat="server" Width="236px" />
                                            <asp:Repeater ID="Rpt_Download" Visible="false" runat="server">
                                                <ItemTemplate>
                                                    <a href="Download.ashx?file=\\UploadedImages<%# DataBinder.Eval(Container, "DataItem.attach_Path") %>" style="font-size: large; color: blue;" target="_blank">تنزيل</a>


                                                    <%--<input type="button" title="X" value="X" style="color: red; background: none; border: none;"
                                                        onclick="ConfirmDelete()">
                                                    <asp:LinkButton ID="btnDeletePic2" runat="server" Style="font-size: large; color: red; visibility: hidden" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.Attach_Id") %>' OnClick="btnDeletePic_Click">
                                            X
                                                    </asp:LinkButton>--%>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>

                                        <td style="height: 26px; width: 98px;">
                                            <asp:Label runat="server" Text="الملفات المرفقة"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Button ID="Btn_Save" runat="server" Text="دفع" OnClick="Btn_Save_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Btn_Upload" runat="server" Text="تحميل المرفق" OnClick="Btn_Upload_Click" />
                                        </td>
                                    </tr>

                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="main_ClaimID" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LL" runat="server" Text="رقم المطالبة"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="Sub_ClaimID" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="رقم المطالبة الفرعية"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="Patient_Name" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="اسم المريض"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="direction: rtl;">
                                        <td>
                                            <asp:Label ID="lbl_count" runat="server" Text=" " Font-Size="26px" ForeColor="red"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="العدد الكلي"></asp:Label>
                                        </td>
                                    </tr>
                                </table>


                            </div>
                        </div>
                        <div class="COLR" style="float: right">

                            <div id="slider" runat="server" style="padding: 100px 0; background: #333; width: 100%; height: 12px;">
                                <div id="thumbnail-slider" style="display: none;">
                                    <div class="inner">
                                        <ul>
                                            <asp:Repeater ID="RP_ImagesLi" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <a class="thumb" href='UploadedImages<%# DataBinder.Eval(Container, "DataItem.attach_Path") %>'></a>

                                                          <%-- <input type="button" title="X" value="X" style="color: red; background: none; border: none;"
                                                               onclick="ConfirmDelete()">
                                                        <asp:LinkButton ID="btnDeletePic" runat="server" Style="font-size: large; visibility:hidden" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.Attach_Id") %>' OnClick="btnDeletePic_Click">
                                            حذف
                                                        </asp:LinkButton>--%>
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
                                                <img style="margin-top: -39px; height: 87%;" src="UploadedImages\<%# DataBinder.Eval(Container, "DataItem.attach_Path") %>" title="<%# DataBinder.Eval(Container, "DataItem.Attach_Id") %>" />
                                                <%--<a id="Btn_Delete_Image"  style="font-size: large;" onclick="Delete_Image(<%# DataBinder.Eval(Container, "DataItem.Attach_Id") %>)">حذف</a>--%>
                                                  <%-- <input type="button" title="X" value="X" style="color: red; background: none; border: none;"
                                                       onclick="ConfirmDelete2()">
                                                <asp:LinkButton ID="btnDeletePic" tagname="btnDeletePic" runat="server" Style="font-size: large; visibility:hidden" CommandArgument='<%#DataBinder.Eval(Container, "DataItem.Attach_Id") %>' OnClick="btnDeletePic_Click">
                                            حذف
                                                </asp:LinkButton>--%>

                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>

                                <div style="clear: both;"></div>

                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="text-center my-5" style="direction: ltr; margin-right: 10%">
                <div class="container">
                    <div class="row">
                    </div>
                    <div id="Main_GV" style="overflow-y: scroll; height: 572px;">
                        <asp:GridView ID="GridView" runat="server" CssClass="Grid" AllowPaging="false" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="اختر" ControlStyle-ForeColor="Black" />
                                <%--<asp:BoundField DataField="id" HeaderText="التسلسل" ReadOnly="True" HeaderStyle-CssClass="ColumnGV" ItemStyle-CssClass="ColumnGV" SortExpression="ID" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Btn_Upload" />

        </Triggers>
    </asp:UpdatePanel>
    <script src="scripts/jquery-1.7.min.js"></script>
    <script src="scripts/select2.min.js"></script>


    <script src="js/thumbnail-slider.js"></script>

    <script>
        function ConfirmDelete() {
            var x = confirm("هلا انت متأكد من الحذف");
            if (x)
                document.getElementById("ContentPlaceHolder1_Rpt_Download_btnDeletePic2_0").click();
            else
                return false;
        }


        function ConfirmDelete2() {
            var x = confirm("هلا انت متأكد من الحذف");
            if (x)
                document.getElementsByTagName("btnDeletePic").click();
            else
                return false;
        }
    </script>


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

