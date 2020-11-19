using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Sub_Banks : System.Web.UI.Page
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

                DDL_Main_Bank_ID.DataSource = Cls_Main_Banks.Get_Main_Banks();
                DDL_Main_Bank_ID.DataBind();
                //DDL_Main_Bank_ID.SelectedValue = "24";
                DDL_Main_Bank_ID.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Main_Bank_ID2.DataSource = Cls_Main_Banks.Get_Main_Banks();
                DDL_Main_Bank_ID2.DataBind();
                //DDL_Main_Bank_ID2.SelectedValue = "24";
                DDL_Main_Bank_ID2.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            string Result;
            Sub_Bank._Main_Bank_ID = Convert.ToInt32(DDL_Main_Bank_ID.SelectedValue);
            Sub_Bank._Sub_Bank_Name = Txt_Sub_Bank_Name.Text;
            Result = Sub_Bank.Insert_Sub_Banks();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " إضافة فرع بنك جديد : " + Txt_Sub_Bank_Name.Text + " لبنك : " + DDL_Main_Bank_ID.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result.Text = Result;

            DDL_Main_Bank_ID.DataSource = Cls_Main_Banks.Get_Main_Banks();
            DDL_Main_Bank_ID.DataBind();

            DDL_Main_Bank_ID2.DataSource = Cls_Main_Banks.Get_Main_Banks();
            DDL_Main_Bank_ID2.DataBind();
        }

        protected void DDL_Main_Bank_ID2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Main_Bank_ID2.SelectedValue));
            DDL_Bank_Branch.DataBind();
            try
            {
                Txt_Sub_Bank_Name2.Text = DDL_Bank_Branch.SelectedItem.Text;
            }
            catch (Exception)
            {

                Txt_Sub_Bank_Name2.Text = "";
            }

        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            string Result;
            Sub_Bank._Main_Bank_ID = Convert.ToInt32(DDL_Main_Bank_ID2.SelectedValue);
            Sub_Bank._Sub_Bank_Name = Txt_Sub_Bank_Name2.Text;
            Sub_Bank._ID = int.Parse(DDL_Bank_Branch.SelectedValue.ToString());
            Result = Sub_Bank.Update_Sub_Banks();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " تعديل على فرع البنك    : " + DDL_Bank_Branch.SelectedItem.Text + " لبنك : " + DDL_Main_Bank_ID2.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;

            DDL_Main_Bank_ID.DataSource = Cls_Main_Banks.Get_Main_Banks();
            DDL_Main_Bank_ID.DataBind();

            DDL_Main_Bank_ID2.DataSource = Cls_Main_Banks.Get_Main_Banks();
            DDL_Main_Bank_ID2.DataBind();
        }

        protected void DDL_Bank_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Sub_Bank_Name2.Text = DDL_Bank_Branch.SelectedItem.Text;
        }
    }
}