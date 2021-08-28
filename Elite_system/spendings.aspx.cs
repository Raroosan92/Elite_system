using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class spendings : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {

                Btn_SaveReceipt.Visible = HttpContext.Current.User.IsInRole("Add");
                Btn_UpdateReceipt.Visible = HttpContext.Current.User.IsInRole("Update");
                Btn_Delete.Visible = HttpContext.Current.User.IsInRole("Delete");
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Btn_UpdateReceipt.Visible = true;
                    Btn_SaveReceipt.Visible = true;
                    Btn_Delete.Visible = true;
                }

                DDL_Description.DataSource = Cls_Codes.Fill_DDL(315);
                DDL_Description.DataBind();
                DDL_Description.Items.Insert(0, new ListItem("--اختر--", "0"));
                Txt_Voucher_Date.Text = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");

                //DDL_Medical_Name_Search.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                //DDL_Medical_Name_Search.DataBind();
                //DDL_Medical_Name_Search.Items.Insert(0, new ListItem("--اختر--", "0"));



                //Txt_SubID.Focus();
                RB_Sent_To.Focus();
            }
        }
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        public void Get_Voucher_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Spendings";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_receipt.SelectedRow.Cells[1].Text));
                cmd.Parameters.AddWithValue("@check", "S");
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Txt_MainID.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();
                    Txt_Company.Text = dr.GetValue(dr.GetOrdinal("Company")).ToString();
                    //Txt_Description.Text = dr.GetValue(dr.GetOrdinal("Description")).ToString();
                    RB_Sent_To.SelectedValue = dr.GetValue(dr.GetOrdinal("Sent_To")).ToString();
                    Txt_Voucher_Value.Text = dr.GetValue(dr.GetOrdinal("Voucher_Value")).ToString();
                    Txt_VoucherNo.Text = dr.GetValue(dr.GetOrdinal("Voucher_No")).ToString();
                    Txt_Voucher_Date.Text = DateTime.Parse(dr.GetValue(dr.GetOrdinal("Voucher_Date")).ToString()).ToString("yyyy-MM-dd");
                    Txt_Invoice_No.Text = dr.GetValue(dr.GetOrdinal("Invoice_No")).ToString();
                    DDL_Description.SelectedValue = dr.GetValue(dr.GetOrdinal("Description")).ToString();
                }

                Cls_Connection.close_connection();


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        protected void Btn_SaveReceipt_Click(object sender, EventArgs e)
        {
            string Result2 = "";
            App_Code.Cls_Spendings Spendings = new App_Code.Cls_Spendings();

            Spendings._Invoice_No = long.Parse(Txt_Invoice_No.Text);
            Spendings._Voucher_No = long.Parse(Txt_VoucherNo.Text);
            Result2 = Spendings.Check_Spendings();
            if (Result2 == "0")
            {

            
            if (DDL_Description.SelectedIndex == 0 || Txt_Voucher_Value.Text == "" || Txt_VoucherNo.Text == "" || Txt_Invoice_No.Text == "")
            {
                LblErrors.Text = " * يرجى إدخال الحقول المطلوبة التي بجانبها";
                return;
            }


            string Result = "";

            


            Spendings._Description = DDL_Description.SelectedValue;
            //Spendings._Description = Txt_Description.Text;


            try
            {
                if (Txt_Voucher_Date.Text != "")
                {
                    Spendings._Voucher_Date = DateTime.Parse(Txt_Voucher_Date.Text);
                }
            }
            catch (Exception)
            {

                MSG("خطأ في تاريخ السند");
                return;
            }



            Spendings._Company = Txt_Company.Text;
            Spendings._Voucher_Value = decimal.Parse(Txt_Voucher_Value.Text);
            Spendings._Voucher_No = int.Parse(Txt_VoucherNo.Text);
            Spendings._Invoice_No = int.Parse(Txt_Invoice_No.Text);
            Spendings._Sent_To = RB_Sent_To.SelectedValue.ToString();
            Result = Spendings.Insert_Spendings();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " ادخال سند صرف : " + DDL_Description.SelectedItem.Text + " بقيمة : " + Txt_Voucher_Value.Text + " ورقم السند : " + Txt_VoucherNo.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////


            MSG(Result);
            GridView_receipt.DataBind();
            string D = Txt_Voucher_Date.Text;

            ClearFields(Form.Controls);
            Txt_Voucher_Date.Text = D;

            Txt_Voucher_Value.Focus();
            LblErrors.Text = "";
            }
            else
            {
                MSG("هذا السند مضاف مسبقاً");
            }
        }

        protected void Btn_UpdateReceipt_Click(object sender, EventArgs e)
        {
            if (DDL_Description.SelectedIndex == 0 || Txt_Voucher_Value.Text == "" || Txt_VoucherNo.Text == "" || Txt_Invoice_No.Text == "")
            {
                LblErrors.Text = " * يرجى إدخال الحقول المطلوبة التي بجانبها";
                return;
            }

            if (Txt_MainID.Text == "" || Txt_MainID.Text == null)
            {
                MSG("يجب اختيار السند");
                return;
            }

            string Result = "";
            App_Code.Cls_Spendings Spendings = new App_Code.Cls_Spendings();


            Spendings._Description = DDL_Description.SelectedValue;
            //Spendings._Description = Txt_Description.Text;



            try
            {
                if (Txt_Voucher_Date.Text != "")
                {
                    Spendings._Voucher_Date = DateTime.Parse(Txt_Voucher_Date.Text);
                }
            }
            catch (Exception)
            {

                MSG("خطأ في تاريخ السند");
                return;
            }


            Spendings._Company = Txt_Company.Text;
            Spendings._Voucher_Value = decimal.Parse(Txt_VoucherNo.Text);
            Spendings._Voucher_No = int.Parse(Txt_VoucherNo.Text);
            Spendings._Invoice_No = int.Parse(Txt_Invoice_No.Text);
            Spendings._ID = int.Parse(Txt_MainID.Text);
            Spendings._Sent_To = RB_Sent_To.SelectedValue.ToString();
            Result = Spendings.Update_Spendings();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " تعديل سند صرف : " + DDL_Description.SelectedItem.Text + " بقيمة : " + Txt_Voucher_Value.Text + " ورقم السند : " + Txt_VoucherNo.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            MSG(Result);

            GridView_receipt.DataBind();
            string D = Txt_Voucher_Date.Text;

            ClearFields(Form.Controls);
            Txt_Voucher_Date.Text = D;

            Txt_Voucher_Value.Focus();
            LblErrors.Text = "";
        }

        protected void GridView_receipt_SelectedIndexChanged(object sender, EventArgs e)
        {

            Get_Voucher_ForUpdate();

        }




        public static void ClearFields(ControlCollection pageControls)
        {

            foreach (Control contl in pageControls)
            {
                string strCntName = (contl.GetType()).Name;

                switch (strCntName)
                {
                    case "TextBox":
                        TextBox tbSource = (TextBox)contl;
                        tbSource.Text = "";
                        break;
                    //case "RadioButtonList":
                    //    RadioButtonList rblSource = (RadioButtonList)contl;
                    //    rblSource.SelectedIndex = -1;
                    //    break;
                    case "DropDownList":
                        DropDownList ddlSource = (DropDownList)contl;
                        ddlSource.SelectedIndex = -1;
                        break;
                    case "ListBox":
                        ListBox lbsource = (ListBox)contl;
                        lbsource.SelectedIndex = -1;
                        break;
                }
                ClearFields(contl.Controls);
            }


        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {


            if (Txt_MainID.Text == "" || Txt_MainID.Text == null)
            {
                MSG("يجب اختيار السند");
                return;
            }

            string Result = "";
            App_Code.Cls_Spendings Spendings = new App_Code.Cls_Spendings();

            Spendings._ID = long.Parse(Txt_MainID.Text);
            Result = Spendings.Delete_Spendings();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " حذف سند صرف : " + DDL_Description.SelectedItem.Text + " بقيمة : " + Txt_Voucher_Value.Text + " ورقم السند : " + Txt_VoucherNo.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            MSG(Result);


            GridView_receipt.DataBind();
            string D = Txt_Voucher_Date.Text;

            ClearFields(Form.Controls);
            Txt_Voucher_Date.Text = D;

            Txt_Voucher_Value.Focus();
            LblErrors.Text = "";
        }

        protected void Btn_SearchBondNo_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (Txt_SearchBondNo.Text == "")
                {

                    cmd.CommandText = "SELECT [ID],[Company],[Sent_To],[Voucher_Value],[Voucher_No],[Voucher_Date],[Invoice_No],[Description],[Created_Datetime] FROM [dbo].[Spendings] ORDER BY [ID] DESC";
                    Cls_Connection.open_connection();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    GridView_receipt.DataSourceID = null;

                    GridView_receipt.DataSource = dt;
                    GridView_receipt.DataBind();
                    Cls_Connection.close_connection();
                }
                else
                {


                    cmd.CommandText = "SELECT [ID],[Company],[Sent_To],[Voucher_Value],[Voucher_No],[Voucher_Date],[Invoice_No],[Description],[Created_Datetime] FROM [dbo].[Spendings] WHERE [Voucher_No] = " + Txt_SearchBondNo.Text + " OR [Invoice_No] = " + Txt_SearchBondNo.Text + " ORDER BY [ID] DESC";
                    Cls_Connection.open_connection();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    GridView_receipt.DataSourceID = null;

                    GridView_receipt.DataSource = dt;
                    GridView_receipt.DataBind();
                    Cls_Connection.close_connection();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

    }
}