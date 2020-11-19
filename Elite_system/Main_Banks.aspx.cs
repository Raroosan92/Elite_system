using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Main_Banks : System.Web.UI.Page
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
                DDL_Bank_Name.DataSource = Cls_Main_Banks.Get_Main_Banks();
                DDL_Bank_Name.DataBind();
                DDL_Bank_Name.SelectedValue = "24";
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Cls_Main_Banks Bank = new Cls_Main_Banks();
            string Result;
            Bank._Bank_Name = Txt_Bank_Name.Text;
            Result = Bank.Insert_Main_Banks();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "إضافة بنك جديد  : " + Txt_Bank_Name.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result.Text = Result;
            DDL_Bank_Name.DataSource = Cls_Main_Banks.Get_Main_Banks();
            DDL_Bank_Name.DataBind();
            DDL_Bank_Name.SelectedValue = "24";

        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Cls_Main_Banks Bank = new Cls_Main_Banks();
            string Result;
            Bank._Bank_Name = Txt_Bank_Name2.Text;
            Bank._ID = int.Parse(DDL_Bank_Name.SelectedValue.ToString());
            Result = Bank.Update_Main_Banks();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على بنك   : " + DDL_Bank_Name.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;
            DDL_Bank_Name.DataSource = Cls_Main_Banks.Get_Main_Banks();
            DDL_Bank_Name.DataBind();
            DDL_Bank_Name.SelectedValue = "24";
        }

        protected void DDL_Bank_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Bank_Name2.Text = DDL_Bank_Name.SelectedItem.Text;
        }
    }
}