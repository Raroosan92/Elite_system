using Elite_system;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Controls_Header : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

    }
  
    protected void Unnamed_LoggingOut(object sender, EventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        Response.Cookies["UserName"].Expires = DateTime.Now.AddSeconds(-1);
        FormsAuthentication.SignOut();
        Response.Redirect("~/Login.aspx");
    }
}