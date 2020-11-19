using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system.Admin
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
                lblWorning.Text = "تنبيه انت على وشك اضافة مستخدم عادي";
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
        }
          
        
        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser newUser = Membership.CreateUser(txtUserName.Text, txtPassword.Text);
                if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
                {
                    //FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
                    Msg.Text = "تم تسجيل اسم المستخدم بنجاح"+"       "  + txtUserName.Text;
                    ddlUser.Items.Clear();
                    BindList();
                }
                else
                {
                    Msg.Text = "يوجد خطأ";
                }
                //للتعديل على جدول الجهات الطبية ووضع اسم المستخدم للجهة الطبية في حال انشاء مستخدم له
                if (CheckBox1.Checked==true)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                        con = Cls_Connection._con;
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "UPDATE [dbo].[Medical_Types_And_Companies] SET [UName] = '"+txtUserName.Text+"'  WHERE ID = "+DDL_Medical_Name.SelectedValue+"";
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Cls_Connection.close_connection();
                        Msg.Text = "تم تسجيل اسم المستخدم بنجاح" + "       " + txtUserName.Text;
                    }
                    catch (Exception ex)
                    {
                        Cls_Connection.close_connection();
                        Msg.Text = "يوجد خطأ في التعديل على الجهات الطبية يرجى مراجعة مسؤول النظام للضرورة";
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.Text = "كلمة المرور ضعيفة يرجى استخدام احرف كبيرة وصغيرة ورموز وارقام";
            }
        }
        private void BindList()
        {
            foreach (MembershipUser user in Membership.GetAllUsers())
            {
                ddlUser.Items.Add(new ListItem(user.UserName, user.UserName));
            }
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
           Membership.DeleteUser(ddlUser.SelectedItem.Text, true);
            ddlUser.Items.Clear();
            BindList();
            Msg.Text = "تم حذف المستخدم بنجاح";
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBox1.Checked== true)
            {
                DDL_Medical_Name.Enabled = true;
                lblWorning.Text = "تنبيه انت على وشك اضافة مستخدم (جهة طبية) جديد للإلغاء انقر المربع بجانب الجهات الطبية";
            }
            else
            {
                DDL_Medical_Name.Enabled = false;
                lblWorning.Text = "تنبيه انت على وشك اضافة مستخدم عادي";
            }
            
        }


        protected void DDL_Medical_Name_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserName.Text = DDL_Medical_Name.SelectedItem.Text;
        }
    }
}