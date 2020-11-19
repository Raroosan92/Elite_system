<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Title="النخبة للمطالبات" Inherits="Elite_system.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="google-site-verification" content="YBaCd-YXM8Peoy_oVxTzbW246C9FDpWpJlkIc1_ozGc" />
    <meta name="descriptions" content="Claims" />
    <meta name="keywords" content="Claims,مطالبات,Elite,النخبة" />


    <title>شركة النخبة للمطالبات</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />


    <!-- Favicons -->
    <%--   <link href="img/favicon.png" rel="icon">--%>
    <%--<link href="img/apple-touch-icon.png" rel="apple-touch-icon">--%>

    <!-- Bootstrap core CSS -->
    <link href="../lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!--external css-->
    <link href="../lib/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/style-responsive.css" rel="stylesheet" />
    <link href="../lib/style.css" rel="stylesheet" />
    <link href="../fonts/Fonts.css" rel="stylesheet" />
    <style>
         body {
            font-family: Al-Jazeera-Regular !important;
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
</head>
<body>

    <div id="login-page">
        <div class="container">
            <form class="form-login" onclick="LogIn" runat="server">
                <h2 class="form-login-heading">سجل دخولك</h2>
                <div class="login-wrap">
                    <asp:TextBox  runat="server" ID="UserName" CssClass="form-control" placeholder="اسم المستخدم" autofocus AutoCompleteType="Notes" />
                    <br />
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="كلمة المرور" AutoCompleteType="Notes" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="كلمة المرور فارغة" />
                    <label class="checkbox" style="float:right">
                        <asp:CheckBox runat="server" ID="RememberMe" />
                        تذكرني
                    </label>
                    <%-- <span class="pull-right">
                <a data-toggle="modal" href="login.html#myModal">Forgot Password?</a>
            </span>--%>
                    <asp:Button runat="server" Text="تسجيل الدخول" CssClass="btn btn-send" Width="100%" OnClick="LogIn" />
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <p id="Failer" style="font:bolder; color:orangered" runat="server"></p>
                    <div class="login-social-link centered">
                        <p>قم بزيارة شبكاتنا الاجتماعية</p>
                        <button class="btn btn-facebook" type="submit"><i class="fa fa-facebook"></i>Facebook</button>
                        <button class="btn btn-twitter" type="submit"><i class="fa fa-twitter"></i>Twitter</button>
                    </div>
                    <%--   <div class="registration">
                                Don't have an account yet?<br />
                                <a class="" href="#">Create an account
                                </a>
                            </div>--%>
                </div>
                <!-- Modal -->
                <%--   <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">Forgot Password ?</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>Enter your e-mail address below to reset your password.</p>
                                        <input type="text" name="email" placeholder="Email" autocomplete="off" class="form-control placeholder-no-fix">
                                    </div>
                                    <div class="modal-footer">
                                        <button data-dismiss="modal" class="btn btn-default" type="button">Cancel</button>
                                        <button class="btn btn-theme" type="button">Submit</button>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                <!-- modal -->
            </form>
        </div>
    </div>
    <!-- js placed at the end of the document so the pages load faster -->
    <script src="../lib/jquery/jquery.min.js"></script>
    <script src="../lib/bootstrap/js/bootstrap.min.js"></script>
    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="../lib/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("../img/login-bg.jpg", {
            speed: 500
        });
    </script>

</body>
</html>
