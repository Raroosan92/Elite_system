<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Controls_Header" %>


<%--<script>
    window.onload = function exampleFunction() {

        var x = document.cookie;
        readCookie(x);
    }


    function readCookie(name) {
        var Username;
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        var c = ca[0].substring(9, 9999999);
        document.getElementById("UName").innerHTML = "مرحبا :  " + c + "  !  ";
    }
</script>--%>
<style>
    .hello{
        display:grid !important;
        visibility:visible;
    }
     @media only screen and (max-width: 676px) {
             .hello{
       display: inline !important;
    visibility: visible;
    margin-right: 18px;
    }
        }
</style>

<!--header start-->
<%--<header class="header black-bg" style="position: fixed; margin-top: -4%;">
   
    <!--logo start-->
    <a href="#" class="logo"><b>النخبة<span> Elite</span></b></a>
    <!--logo end-->

    <div classm="top-menu">
        <ul class="nav pull-right top-menu">
            <div style="margin-right: 43px; margin-top: 12px;">
                <ul class="logout">
                    <li>
                        <a id="UName"></a>
                    </li>
                    <li class="logout1">

                        <asp:Button CssClass="logout1" ID="Logout" runat="server" Text="Logout" OnClick="Unnamed_LoggingOut" />
                    </li>
                </ul>



            </div>
        </ul>
    </div>

    <%--<div class="nav notify-row" id="top_menu">
        <!--  notification start -->
        <ul class="nav top-menu">
            <!-- settings start -->
            <li class="dropdown">
                <a data-toggle="dropdown" class="dropdown-toggle" href="index.html#">
                    <i class="fa fa-tasks"></i>
                    <span class="badge bg-theme">4</span>
                </a>
                <ul class="dropdown-menu extended tasks-bar">
                    <div class="notify-arrow notify-arrow-green"></div>
                    <li>
                        <p class="green">You have 4 pending tasks</p>
                    </li>
                    <li>
                        <a href="index.html#">
                            <div class="task-info">
                                <div class="desc">Dashio Admin Panel</div>
                                <div class="percent">40%</div>
                            </div>
                            <div class="progress progress-striped">
                                <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%">
                                    <span class="sr-only">40% Complete (success)</span>
                                </div>
                            </div>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <div class="task-info">
                                <div class="desc">Database Update</div>
                                <div class="percent">60%</div>
                            </div>
                            <div class="progress progress-striped">
                                <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%">
                                    <span class="sr-only">60% Complete (warning)</span>
                                </div>
                            </div>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <div class="task-info">
                                <div class="desc">Product Development</div>
                                <div class="percent">80%</div>
                            </div>
                            <div class="progress progress-striped">
                                <div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                                    <span class="sr-only">80% Complete</span>
                                </div>
                            </div>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <div class="task-info">
                                <div class="desc">Payments Sent</div>
                                <div class="percent">70%</div>
                            </div>
                            <div class="progress progress-striped">
                                <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width: 70%">
                                    <span class="sr-only">70% Complete (Important)</span>
                                </div>
                            </div>
                        </a>
                    </li>
                    <li class="external">
                        <a href="#">See All Tasks</a>
                    </li>
                </ul>
            </li>
            <!-- settings end -->
            <!-- inbox dropdown start-->
            <li id="header_inbox_bar" class="dropdown">
                <a data-toggle="dropdown" class="dropdown-toggle" href="index.html#">
                    <i class="fa fa-envelope-o"></i>
                    <span class="badge bg-theme">5</span>
                </a>
                <ul class="dropdown-menu extended inbox">
                    <div class="notify-arrow notify-arrow-green"></div>
                    <li>
                        <p class="green">You have 5 new messages</p>
                    </li>
                    <li>
                        <a href="index.html#">
                            <span class="photo">
                                <img alt="avatar" src="img/ui-zac.jpg"></span>
                            <span class="subject">
                                <span class="from">Zac Snider</span>
                                <span class="time">Just now</span>
                            </span>
                            <span class="message">Hi mate, how is everything?
                            </span>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <span class="photo">
                                <img alt="avatar" src="img/ui-divya.jpg"></span>
                            <span class="subject">
                                <span class="from">Divya Manian</span>
                                <span class="time">40 mins.</span>
                            </span>
                            <span class="message">Hi, I need your help with this.
                            </span>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <span class="photo">
                                <img alt="avatar" src="img/ui-danro.jpg"></span>
                            <span class="subject">
                                <span class="from">Dan Rogers</span>
                                <span class="time">2 hrs.</span>
                            </span>
                            <span class="message">Love your new Dashboard.
                            </span>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <span class="photo">
                                <img alt="avatar" src="img/ui-sherman.jpg"></span>
                            <span class="subject">
                                <span class="from">Dj Sherman</span>
                                <span class="time">4 hrs.</span>
                            </span>
                            <span class="message">Please, answer asap.
                            </span>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">See all messages</a>
                    </li>
                </ul>
            </li>
            <!-- inbox dropdown end -->
            <!-- notification dropdown start-->
            <li id="header_notification_bar" class="dropdown">
                <a data-toggle="dropdown" class="dropdown-toggle" href="index.html#">
                    <i class="fa fa-bell-o"></i>
                    <span class="badge bg-warning">7</span>
                </a>
                <ul class="dropdown-menu extended notification">
                    <div class="notify-arrow notify-arrow-yellow"></div>
                    <li>
                        <p class="yellow">You have 7 new notifications</p>
                    </li>
                    <li>
                        <a href="index.html#">
                            <span class="label label-danger"><i class="fa fa-bolt"></i></span>
                            Server Overloaded.
                  <span class="small italic">4 mins.</span>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <span class="label label-warning"><i class="fa fa-bell"></i></span>
                            Memory #2 Not Responding.
                  <span class="small italic">30 mins.</span>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <span class="label label-danger"><i class="fa fa-bolt"></i></span>
                            Disk Space Reached 85%.
                  <span class="small italic">2 hrs.</span>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">
                            <span class="label label-success"><i class="fa fa-plus"></i></span>
                            New User Registered.
                  <span class="small italic">3 hrs.</span>
                        </a>
                    </li>
                    <li>
                        <a href="index.html#">See all notifications</a>
                    </li>
                </ul>
            </li>
            <!-- notification dropdown end -->
        </ul>
        <!--  notification end -->
    </div>--%>
<%--</header>--%>





<div class="navbar navbar-inverse navbar-fixed-top" style="height:9%;display:flex">
      <!--logo start-->
    <a href="#" class="logo"><b>النخبة<span> Elite</span></b></a>
    <!--logo end-->

            <div class="container">
                    <%--<div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" runat="server" href="#">ادارة مستخدمي النظام</a>
                    </div>--%>
                <div class="navbar-collapse collapse">
                  <%--  <ul class="nav navbar-nav" style="float:right">
                        
                        
                        <li><a runat="server" href="Admin/UserToRole">ربط المستخد بالصلاحية</a></li>
                        <li><a runat="server" href="Admin/AddRole">اضافة صلاحية</a></li>
                        <li><a runat="server" href="Admin/RegisterUser">اضافة مستخدم</a></li>
                        
                    </ul>--%>
                   
                    <asp:LoginView runat="server" ViewStateMode="Enabled" >
                        <AnonymousTemplate>
                            <ul class="nav navbar-nav navbar-right" style="float:left !important;">
                                <%--<li><a runat="server" href="~/Account/Register">Register</a></li>--%>
                                <li><a runat="server" href="Login">تسجيل دخول</a></li>
                                
                            </ul>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <ul class="nav navbar-nav navbar-right" style="float:left !important; direction: ltr;margin-top:-2px;margin-right:-34px" >
                                <li><a runat="server" class="hello" href="#" title="Manage your account">!مرحبا , <%: Context.User.Identity.GetUserName()  %> </a></li>
                                <li>
                                    <asp:LoginStatus class="hello" runat="server" LogoutAction="Redirect" LogoutText="تسجيل الخروج" LogoutPageUrl="Login" OnLoggingOut="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </LoggedInTemplate>
                    </asp:LoginView>
                </div>
            </div>
        </div>
