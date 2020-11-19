using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system.Account
{

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }




        protected void LogIn(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(UserName.Text, Password.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked);
                HttpCookie UserNameCookie = new HttpCookie("UserName");
                UserNameCookie.Value = UserName.Text;
                HttpContext.Current.Response.Cookies.Add(UserNameCookie);
                //Roles.GetRolesForUser(UserName.Text);

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                Failer.InnerText = "يرجى التأكد من كلمة المرور واسم المستخدم";
            }
        }
    }
}