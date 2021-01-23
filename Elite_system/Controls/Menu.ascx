<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Controls_Menu" %>

<!DOCTYPE html>
<html style="direction: rtl">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">

  
    <link href="../css/SideBar/style2.css" rel="stylesheet" />
    <script src="../js/SideBar/bootstrap.min.js"></script>

    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>

</head>
<body>

    <!--================ Start Header Menu Area =================-->

    <div class="menu-trigger">
        <span></span>
        <span></span>
        <span></span>
    </div>


    <header id="HeaderSideBar" class="fixed-menu" style="direction: ltr;">
        <span class="menu-close">
            <img src="../imgSideBar/Close.png" style="width: 17%;" /></span>
        <div class="menu-header" style="height: 106px">
            <div class="logo d-flex justify-content-center" style="text-align: -webkit-center;">
                <img class="img-circle" src="img/Elite.jpg" width="32%" alt="">
            </div>
        </div>
        <div class="nav-wraper">
            <div class="navbar">
                <ul class="nav nav-pills nav-stacked">
                    <li class="active"><a href="../Default.aspx">الرئيسية<img src="../imgSideBar/header/nav-icon1.png" /></a></li>

                    <li class=""><a href="../Claims.aspx">المطالبات<img src="../imgSideBar/header/nav-icon2.png" /></a></li>

                    <li class=""><a href="../Medical_Types.aspx">الجهات الطبية<img src="../imgSideBar/header/nav-icon6.png" /></a></li>

                     <li class=""><a href="../Companies.aspx">الشركات<img src="../imgSideBar/header/nav-icon5.png" /></a></li>

                    <li class="">
                    <li class=""><a href="../Mail.aspx">البريد<img src="../imgSideBar/header/nav-icon3.png" /></a></li>

                         <li class=""><a href="../Employees.aspx">الموظفين<img src="../imgSideBar/header/nav-icon6.png" /></a></li>

                    <li class=""><a href="../Receipt.aspx">سندات القبض<img src="../imgSideBar/header/nav-icon4.png" /></a></li>                                

                   <%-- <li class=""><a href="../Listing_Bonds.aspx">سندات القيد<img src="../imgSideBar/header/nav-icon6.png" /></a></li>--%>


                   <li class=""><a href="../Admin/RegisterUser.aspx">ادراة المستخدمين<img src="../imgSideBar/header/nav-icon6.png" /></a></li>
                    <li class="">
                    
                     <li class="">
                        <div class="dropup">
                            <a class="" style="margin-left: 50%;" data-toggle="dropdown">الشيكات<img src="../imgSideBar/header/nav-icon6.png" /><span class="caret"></span></a>
                            <ul class="dropdown-menu nav-stacked" style="direction: rtl;">
                                <li class=""><a href="../Checks">ادخال شيكات<img src="../imgSideBar/header/nav-icon6.png" /></a></li>
                                <li class=""><a href="../AssignCheck">احالة شيكات<img src="../imgSideBar/header/nav-icon8.png" /></a></li>
                                <li class=""><a href="../DeliveredChecks">تسليم الشيكات<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                <li class=""><a href="../RefundedCheckes">إرجاع الشيكات<img src="../imgSideBar/header/nav-icon7.png" /></a></li>

                            </ul>
                        </div>
                          </li>

                     <li class="">
                        <div class="dropup">
                            <a class="" style="margin-left: 50%;" data-toggle="dropdown">المحاسبة<img src="../imgSideBar/header/nav-icon6.png" /><span class="caret"></span></a>
                            <ul class="dropdown-menu nav-stacked" style="direction: rtl;">
                               
                                <li class=""><a href="../Accounting_Tree.aspx"> الشجرة المحاسبية <img src="../imgSideBar/header/nav-icon8.png" /></a></li>
                                <li class=""><a href="../Accounting_Tree_Details.aspx"> ربط الشجرة المحاسبية<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                
                            </ul>
                        </div>
                    </li>

                    <li class="">
                        <div class="dropup">
                            <a class="" style="margin-left: 50%;" data-toggle="dropdown">اعدادات<img src="../imgSideBar/header/nav-icon6.png" /><span class="caret"></span></a>
                            <ul class="dropdown-menu nav-stacked" style="direction: rtl;">
                                <li class=""><a href="../Main_Banks.aspx">البنوك الرئيسية<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                <li class=""><a href="../Sub_Banks.aspx">البنوك الفرعية<img src="../imgSideBar/header/nav-icon8.png" /></a></li>
                                <li class=""><a href="../Sub_Companies.aspx">الشركات الفرعية<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                <li class=""><a href="../Codes">الرموز<img src="../imgSideBar/header/nav-icon7.png" /></a></li>

                                 <li class=""><a href="../Procedures.aspx">الإجراءات<img src="../imgSideBar/header/nav-icon7.png" /></a></li>

                                 <li class=""><a href="../Medical_Types_Check">التسعيرات<img src="../imgSideBar/header/nav-icon7.png" /></a></li>

                            </ul>
                        </div>
                    </li>
                   <li class="">
                        <div class="dropup">
                            <a class="" style="margin-left: 50%;" data-toggle="dropdown">الكشوفات<img src="../imgSideBar/header/nav-icon6.png" /><span class="caret"></span></a>
                            <ul class="dropdown-menu nav-stacked" style="direction: rtl;">
                               
                                <li class=""><a href="../Rpt_Checks2.aspx">الجهات الطبية المتعاقدة<img src="../imgSideBar/header/nav-icon8.png" /></a></li>
                                <li class=""><a href="../Rpt_Claims2.aspx">مطالبات الجهة الطبية<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                <li class=""><a href="../Rpt_Claims.aspx">المطالبات حسب الشركة<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                 <li class=""><a href="../Rpt_Claims4.aspx">المطالبات حسب الشركة2<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                 <li class=""><a href="../Rpt_Claims3.aspx">تدقيق المطالبات<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                
                                <li class=""><a href="../Rpt_Checks.aspx">شيكات الجهة الطبية<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                <li class=""><a href="../Rpt_Checks3.aspx"> جميع الشيكات <img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                <li class=""><a href="../Rpt_Mails.aspx">كشف البريد <img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                <li class=""><a href="../Rpt_Account.aspx">كشف حساب <img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                 <li class=""><a href="../Rpt_Listing1.aspx">كشف السندات <img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                 <li class=""><a href="../Rpt_GetContractingValue.aspx">كشف االإشتراك الشهري <img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                 <li class=""><a href="../Rpt_Stamps.aspx">كشف الطوابع <img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                 <li class=""><a href="../Rpt_MedicalTypesWithNoClaims.aspx">كشف ليس لها مطالبات <img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                                
                                
                                 <li class=""><a href="../Rep_Log.aspx">حركات النظام<img src="../imgSideBar/header/nav-icon7.png" /></a></li>
                            </ul>
                        </div>
                    </li>

                    


                </ul>
            </div>
        </div>
    </header>
    <!--================ End Header Menu Area =================-->


    <script>

        $(".nav a").on("click", function () {
            $(".nav").find(".active").removeClass("active");
            $(this).parent().addClass("active");
        });


    </script>
    <script src="../js/SideBar/theme.js"></script>
</body>
</html>














