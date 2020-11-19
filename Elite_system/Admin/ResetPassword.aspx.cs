using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system.Admin
{
    public partial class ResetPassword : System.Web.UI.Page
    {

        MembershipUser u;
        
        public void Page_Load(object sender, EventArgs args)
        {


           


            if (!Membership.EnablePasswordReset)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            Msg.Text = "";


            //ddlUser.Items.Insert(0, new ListItem("--اختر--", "0"));

            if (!IsPostBack)
            {
                foreach (MembershipUser user in Membership.GetAllUsers())
                {
                    ddlUser.Items.Add(new ListItem(user.UserName, user.UserName));
                }

                ddlUser.Items.Insert(0, new ListItem("--اختر--", "0"));
                //Msg.Text = "يرجى كتابة اسم المستخدم";
            }
            else
            {
                ResetPasswordButton.Enabled = true;
                //VerifyUsername();
            }
        }

       
        public void VerifyUsername()
        {
            u = Membership.GetUser(ddlUser.SelectedItem.Text);

            if (u == null)
            {
                Msg.Text = "  يرجى اعادة كتابة اسم المستخدم " + Server.HtmlEncode(ddlUser.SelectedItem.Text) + "لم يتم العثور على المستخدم:";

                ResetPasswordButton.Enabled = false;
            }
            else
            {
                ResetPasswordButton.Enabled = true;
            }
        }
        public void ResetPassword_OnClick(object sender, EventArgs args)
        {

            string newPassword;

            u = Membership.GetUser(ddlUser.SelectedItem.Text, false);

            if (u == null)
            {
                Msg.Text = "كلمة المرور " + Server.HtmlEncode(ddlUser.SelectedItem.Text) + " لم يتم العثور عليه يرجى اعادة كتابة اسم المستخدم";
                return;
            }

            try
            {
                string username = u.UserName;
                newPassword = PasswordTextBox.Text;
                MembershipUser mu = Membership.GetUser(username);
                mu.ChangePassword(mu.ResetPassword(), newPassword);
                ddlUser.Items.Clear();
                //foreach (MembershipUser user in Membership.GetAllUsers())
                //{
                //    ddlUser.Items.Add(new ListItem(user.UserName, user.UserName));
                //}
                //ddlUser.Items.Insert(0, new ListItem("--اختر--", "0"));
                //newPassword = PasswordTextBox.Text;
                //oldPassword = u.GetPassword();
                //result = u.ChangePassword(oldPassword, newPassword );
            }
            catch (MembershipPasswordException e)
            {
                Msg.Text = "Invalid password answer. Please re-enter and try again.";
                return;
            }
            catch (Exception e)
            {
                Msg.Text = e.Message;
                return;
            }

            if (newPassword != null)
            {
                Msg.Text = "تم استرجاع كلمة المرور  : " + Server.HtmlEncode(newPassword);
            }
            else
            {
                Msg.Text = "يوجد خطأ يرجى مراجعة مسؤول النظام";
            }
        }

        protected void UnlockUser_Click(object sender, EventArgs e)
        {
            string username = ddlUser.SelectedItem.Text;
            MembershipUser mu = Membership.GetUser(username);
            if (mu.UnlockUser())
            {
                Msg.Text = "تم تفعيل المستخدم بنجاح  الان ادخل كلمة المرور";
                PasswordTextBox.Enabled = true;
            }
            else
            {
                Msg.Text = "يوجد خطأ يرجى مراجعة مسؤول النظام";
            }

           // ddlUser.Items.Clear();
            //foreach (MembershipUser user in Membership.GetAllUsers())
            //{
            //    ddlUser.Items.Add(new ListItem(user.UserName, user.UserName));
            //}
            //ddlUser.Items.Insert(0, new ListItem("--اختر--", "0"));
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = ddlUser.SelectedItem.Text;
            MembershipUser mu = Membership.GetUser(username);
            if (mu.IsLockedOut)
            {
                Msg.Text = "هذا المستخدم غير فعال حاليا يرجى الضغط على تفعيل المستخم";
                PasswordTextBox.Enabled = false;
            }
            else
            { PasswordTextBox.Enabled = true; }
        }
    }
}