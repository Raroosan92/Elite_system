using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace Elite_system
{
    public partial class SiteMaster : MasterPage
    {

        protected new void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{
            //    //LoginStatus1.Visible = false;
            //    if (Roles.IsUserInRole("Administrators") || Roles.IsUserInRole("Administrators"))
            //    {
            //        //login.Visible = false;
            //        //LoginStatus1.Visible = true;
            //    }
            //    if (this.Context.User.Identity.Name != null)
            //    {
            //        //login.Visible = false; LoginStatus1.Visible = true;
            //    }
            //    if (Roles.IsUserInRole("Admin"))
            //    {
            //        Menu1.Items[1].Text = "Admin";
            //    }
            //    else
            //    {
            //        Menu1.Items[1].Text = "";
            //    }
            //}
            //bool cc = Roles.IsUserInRole("Administrators");


            //if (Roles.IsUserInRole(Request.Cookies["UserName"].Value, "Administrators"))
            //{
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else
            //{
            //    //Response.Redirect("/login.aspx",true);
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}