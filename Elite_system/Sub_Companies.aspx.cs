using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Sub_Companies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
           
            Btn_Save.Visible = HttpContext.Current.User.IsInRole("Add");
            Btn_Update.Visible = HttpContext.Current.User.IsInRole("Update");

            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                Btn_Update.Visible = true;
                Btn_Save.Visible = true;
              
            }
            if (!Page.IsPostBack)
            {

                

                DDL_Main_Company_ID.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Main_Company_ID.DataBind();
                DDL_Main_Company_ID.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Main_Company_ID2.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Main_Company_ID2.DataBind();
                DDL_Main_Company_ID2.Items.Insert(0, new ListItem("--اختر--", "0"));

                
            }
           
        }


        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            string Result;
            Sub_Companies._Main_Company = Convert.ToInt32(DDL_Main_Company_ID.SelectedValue);
            Sub_Companies._Sub_Company = Txt_Sub_Company_Name.Text;
            Result = Sub_Companies.Insert_Sub_Companies();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " إضافة شركة فرعية جديدة : " + Txt_Sub_Company_Name.Text + ": لشركة : " + DDL_Main_Company_ID.SelectedItem.Text;
            log.Insert_Log();
            ///////////////////////////////   End Of Log        /////////////////////////////////////////////

            Lbl_Result.Text = Result;

            DDL_Main_Company_ID.DataSource = Cls_Main_Claims.Get_Companies();
            DDL_Main_Company_ID.DataBind();


            DDL_Main_Company_ID2.DataSource = Cls_Main_Claims.Get_Companies();
            DDL_Main_Company_ID2.DataBind();
        }

        protected void DDL_Main_Company_ID2_SelectedIndexChanged(object sender, EventArgs e)
        {
             Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            Sub_Companies._Main_Company =long.Parse( DDL_Main_Company_ID2.SelectedValue.ToString());
            DDL_Company_Branch.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Company_Branch.DataBind();
            try
            {
                Txt_Sub_Company_Name2.Text = DDL_Company_Branch.SelectedItem.Text;
            }
            catch (Exception)
            {

                Txt_Sub_Company_Name2.Text = "";
            }

        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {

            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            string Result;
            Sub_Companies._Main_Company = Convert.ToInt32(DDL_Main_Company_ID.SelectedValue);
            Sub_Companies._Sub_Company = Txt_Sub_Company_Name2.Text;
            Sub_Companies._ID= int.Parse(DDL_Company_Branch.SelectedValue.ToString());
            Result = Sub_Companies.Update_Sub_Companies();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " تعديل على الشركة الفرعية : " + DDL_Company_Branch.SelectedItem.Text + ": لشركة : " + DDL_Main_Company_ID2.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            Lbl_Result2.Text = Result;

            DDL_Main_Company_ID.DataSource = Cls_Main_Claims.Get_Companies();
            DDL_Main_Company_ID.DataBind();


            DDL_Company_Branch.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Company_Branch.DataBind();

            DDL_Main_Company_ID2.DataSource = Cls_Main_Claims.Get_Companies();
            DDL_Main_Company_ID2.DataBind();


        }

        protected void DDL_Company_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Sub_Company_Name2.Text = DDL_Company_Branch.SelectedItem.Text;
        }

        protected void BTN_Delete_Click(object sender, EventArgs e)
        {
            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            string Result;
            Sub_Companies._ID = int.Parse(DDL_Company_Branch.SelectedValue);
            Result = Sub_Companies.Delete_Sub_Companies();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " حذف الشركة الفرعية : " + DDL_Company_Branch.SelectedItem.Text + ": لشركة : " + DDL_Main_Company_ID2.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            Lbl_Result2.Text = Result;

            DDL_Main_Company_ID.DataSource = Cls_Main_Claims.Get_Companies();
            DDL_Main_Company_ID.DataBind();


            DDL_Company_Branch.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Company_Branch.DataBind();

            DDL_Main_Company_ID2.DataSource = Cls_Main_Claims.Get_Companies();
            DDL_Main_Company_ID2.DataBind();

            Txt_Sub_Company_Name2.Text = "";

        }
    }
}