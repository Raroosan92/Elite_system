using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Elite_system
{
    public partial class Accounting_Tree_Details : System.Web.UI.Page
    {
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Btn_Update.Visible = HttpContext.Current.User.IsInRole("Update");
            Btn_Save.Visible = HttpContext.Current.User.IsInRole("Add");
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                Btn_Update.Visible = true;
                Btn_Save.Visible = true;
            }
            if (!Page.IsPostBack)
            {
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_Types();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));


                DataTable dt = new DataTable();
                dt = Cls_Accounting_Tree.Get_MainAccount();

                DDL_Parent.DataSource = dt;
                DDL_Parent.DataBind();
             

                int Parent = int.Parse(DDL_Parent.SelectedValue.ToString());
                DDL_Parent_Level.DataSource = Cls_Accounting_Tree.Get_AccountLevels(Parent);
                DDL_Parent_Level.DataBind();

                Parent = int.Parse(DDL_Parent_Level.SelectedValue.ToString());
                DDL_Account.DataSource = Cls_Accounting_Tree.Get_AccountLevels(Parent);
                DDL_Account.DataBind();

                Fill_Accounting_GV();

            }
        }

        protected void DDL_Parent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Parent = int.Parse(DDL_Parent.SelectedValue.ToString());
            DDL_Parent_Level.DataSource = Cls_Accounting_Tree.Get_AccountLevels(Parent);
            DDL_Parent_Level.DataBind();         

            Parent = int.Parse(DDL_Parent_Level.SelectedValue.ToString());
            DDL_Account.DataSource = Cls_Accounting_Tree.Get_AccountLevels(Parent);
            DDL_Account.DataBind();


        }

        protected void DDL_Parent_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Parent = int.Parse(DDL_Parent_Level.SelectedValue.ToString());
            DDL_Account.DataSource = Cls_Accounting_Tree.Get_AccountLevels(Parent);
            DDL_Account.DataBind();

            
            
        }

        protected void DDL_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Cls_Accounting_Tree_Details Details = new Cls_Accounting_Tree_Details();
            Details._Account_Level = DDL_Parent_Level.SelectedItem.Text;
            Details._Main_Account = DDL_Parent.SelectedItem.Text;
            Details._Sub_Account = DDL_Account.SelectedItem.Text;
            Details._Account_ID = int.Parse(DDL_Account.SelectedValue.ToString());
            Details._Medical_Types_ID = Int64.Parse(DDL_Medical_Name.SelectedValue.ToString());
            Details._Medical_Types = DDL_Medical_Name.SelectedItem.Text;
            string Result = Details.Insert_Accounting_Tree_Details();
            //Lbl_Result1.Text = Result;
            
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " ربط الجهة الطبية  : " + DDL_Medical_Name.SelectedItem.Text + " مع حساب  " + DDL_Account.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            MSG(Result);
            Fill_Accounting_GV();

        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Cls_Accounting_Tree_Details Details = new Cls_Accounting_Tree_Details();
            Details._Account_Level = DDL_Parent_Level.SelectedItem.Text;
            Details._Main_Account = DDL_Parent.SelectedItem.Text;
            Details._Sub_Account = DDL_Account.SelectedItem.Text;
            Details._Account_ID = int.Parse(DDL_Account.SelectedValue.ToString());
            Details._Medical_Types_ID = Int64.Parse(DDL_Medical_Name.SelectedValue.ToString());
            Details._Medical_Types = DDL_Medical_Name.SelectedItem.Text;
            string Result = Details.Update_Accounting_Tree_Details();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " تعديل ربط الجهة الطبية : " + DDL_Medical_Name.SelectedItem.Text + " مع حساب  " + DDL_Account.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            //Lbl_Result1.Text = Result;
            MSG(Result);

            Fill_Accounting_GV();
        }

        public void Fill_Accounting_GV()
        {
            try
            {
                DataTable dt_Accounting_GV = new DataTable();

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Fill_Accounting_GV";          
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Accounting_GV);
                Cls_Connection.close_connection();
                int c = dt_Accounting_GV.Rows.Count;
                GV.DataSourceID = null;
                GV.DataSource = dt_Accounting_GV;
                GV.DataBind();

            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }


        protected void GV_SelectedIndexChanged(object sender, EventArgs e)
        {           
            DDL_Medical_Name.SelectedValue= GV.SelectedRow.Cells[1].Text;
        }

    }
}