using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Codes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Btn_Update.Visible = HttpContext.Current.User.IsInRole("Admin");
            if (!Page.IsPostBack)
            {               

                DataTable dt = new DataTable();
                dt = Cls_Codes.Get_Codes2();
                //dt = Cls_Codes.Get_Codes();

                DDL_Parent.DataSource = dt;
                DDL_Parent.DataBind();

                DDL_Parent2.DataSource = dt;
                DDL_Parent2.DataBind();


                int Parent = int.Parse(DDL_Parent2.SelectedValue.ToString());
                DDL_Sub.DataSource = Cls_Codes.Get_SubCodes(Parent);
                DDL_Sub.DataBind();
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Cls_Codes Code = new Cls_Codes();
            string Result;
            Code._Description = Txt_Description.Text;
            Code._Parent = int.Parse(DDL_Parent.SelectedValue);
            Result = Code.Insert_Codes();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "إضافة على : " + DDL_Parent.SelectedItem.Text + " : " + Txt_Description.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result1.Text = Result;
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Cls_Codes Code = new Cls_Codes();
            Code._ID = int.Parse(DDL_Sub.SelectedValue.ToString());
            Code._Description = Txt_Description2.Text;
            Code._Parent = int.Parse(DDL_Parent2.SelectedValue.ToString());
            string Result = Code.Update_Codes();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على : " + DDL_Sub.SelectedItem.Text + " إلى " + Txt_Description2.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;
        }

        protected void DDL_Parent2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Parent = int.Parse(DDL_Parent2.SelectedValue.ToString());
            DDL_Sub.DataSource = Cls_Codes.Get_SubCodes(Parent);
            DDL_Sub.DataBind();

        }

        protected void DDL_Sub_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Description2.Text = DDL_Sub.SelectedItem.Text;
        }
    }
}