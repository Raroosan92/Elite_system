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
    public partial class Receipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //--rami لتغيير التاريخ من لوحة المفاتيح--
            Txt_Receipt_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 
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
                //Get_Main_Receipt_ForUpdate();
                //Get_SubReceipt_ForGridView();

                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));
                Txt_Receipt_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");

                DDL_Medical_Name_Search.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name_Search.DataBind();
                DDL_Medical_Name_Search.Items.Insert(0, new ListItem("--اختر--", "0"));

                string MonthYear;
                int Month = int.Parse(DateTime.UtcNow.AddHours(2).Month.ToString());
                int Year = int.Parse(DateTime.UtcNow.AddHours(2).Year.ToString());
                if (Month > 1)
                {
                    MonthYear = (Month - 1).ToString() + "/" + Year.ToString();
                }
                else
                {
                    Year = Year - 1;
                    MonthYear = "12/" + (Year).ToString();
                }
                Txt_Statement.Text = "بدل نقل مطالبات + طوابع " + MonthYear;

                //Txt_SubID.Focus();
                RB_Sent_To.Focus();
            }
        }
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        public void Get_Main_Receipt_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_Main_Receipt_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_receipt.SelectedRow.Cells[4].Text));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Txt_MainID.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();
                    Txt_Acounting_No.Text = dr.GetValue(dr.GetOrdinal("Acounting_No")).ToString();
                    RB_Sent_To.SelectedValue = dr.GetValue(dr.GetOrdinal("Sent_To")).ToString();
                    Txt_Receipt_Date.Text = DateTime.Parse(dr.GetValue(dr.GetOrdinal("Bond_Date")).ToString()).ToString("yyyy-MM-dd");

                    Txt_Statement.Text = dr.GetValue(dr.GetOrdinal("Description")).ToString();
                    Txt_SubID.Text = dr.GetValue(dr.GetOrdinal("Claim_ID")).ToString();
                    Txt_Value.Text = dr.GetValue(dr.GetOrdinal("Creditor")).ToString();
                    DDL_Medical_Name.SelectedValue = dr.GetValue(dr.GetOrdinal("Medical_Type")).ToString();
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
            if (Txt_SubID.Text == "" || Txt_Receipt_Date.Text == "" || Txt_Value.Text == "" || Txt_Acounting_No.Text == "" || Txt_Statement.Text == "" || DDL_Medical_Name.SelectedValue == "0")
            {
                LblErrors.Text = " * يرجى إدخال الحقول المطلوبة التي بجانبها";
                return;
            }


            string Result = "";

            Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

            if (DDL_Medical_Name.SelectedValue != "")
            {
                Main_Listing_Bonds._Company = long.Parse(DDL_Medical_Name.SelectedValue);
            }
            Main_Listing_Bonds._Type = 297;

            try
            {
                if (Txt_Receipt_Date.Text != "")
                {
                    Main_Listing_Bonds._Bond_Date = DateTime.Parse(Txt_Receipt_Date.Text);
                }
            }
            catch (Exception)
            {

                MSG("خطأ في تاريخ السند");
                return;
            }


            //if (Acounting_NO == null || Acounting_NO == "")
            //{
            //    Acounting_NO = "0";
            //}
            Main_Listing_Bonds._Acounting_NO = Txt_Acounting_No.Text;
            Main_Listing_Bonds._Debtor = 0;
            Main_Listing_Bonds._Description = Txt_Statement.Text;
            Main_Listing_Bonds._Creditor = decimal.Parse(Txt_Value.Text);
            Main_Listing_Bonds._Sent_To = RB_Sent_To.SelectedValue.ToString();
            Main_Listing_Bonds._Claim_ID = long.Parse(Txt_SubID.Text);
            Result = Main_Listing_Bonds.Insert_Main_Listing_Bonds();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " إدخال سند قبض للجهة الطبية : " + DDL_Medical_Name.SelectedItem.Text + " بقيمة : " + Txt_Value.Text + " ورقم السند : " + Txt_SubID.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////


            MSG(Result);
            GridView_receipt.DataBind();
            string D = Txt_Receipt_Date.Text;
            string ST = Txt_Statement.Text;
            ClearFields(Form.Controls);
            Txt_Receipt_Date.Text = D;
            Txt_Statement.Text = ST;
            Txt_SubID.Focus();
            LblErrors.Text = "";
            //Cls_Main_Receipt Main_Receipt = new Cls_Main_Receipt();
            //Main_Receipt._Acounting_No = Txt_Acounting_No.Text;
            //Main_Receipt._Name = long.Parse(DDL_Medical_Name.SelectedValue);
            //Main_Receipt._Sent_To = RB_Sent_To.SelectedValue.ToString();
            //Main_Receipt._Receipt_Date = DateTime.Parse(Txt_Receipt_Date.Text);
            //Main_Receipt._Statement = Txt_Statement.Text;
            //Main_Receipt._SubID = long.Parse(Txt_SubID.Text);
            //Main_Receipt._Value = double.Parse(Txt_Value.Text);
            //string Result = Main_Receipt.Insert_Main_Receipt();

            //GridView_receipt.DataBind();


            //Rami Roosan

            // To Get Contracting_Value 
            // -------------------------------------



            //SqlConnection con = new SqlConnection();

            //con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            //con = Cls_Connection._con;


            //SqlCommand cmd1 = new SqlCommand();
            //cmd1.Connection = con;
            //string sql = "SELECT [Contracting_Value],[Acounting_NO] FROM [Elite_DB].[dbo].[Medical_Types_And_Companies] where id= '" + DDL_Medical_Name.SelectedValue + "'";
            //SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            //DataTable table = new DataTable();
            //Cls_Connection.open_connection();
            //adapter.Fill(table);

            //string ContractingValue = table.Rows[0]["Contracting_Value"].ToString();
            //string Acounting_NO = table.Rows[0]["Acounting_NO"].ToString();
            //Cls_Connection.close_connection();

            // ----------------------------------------



        }

        protected void Btn_UpdateReceipt_Click(object sender, EventArgs e)
        {
            if (Txt_SubID.Text == "" || Txt_Receipt_Date.Text == "" || Txt_Value.Text == "" || Txt_Acounting_No.Text == "" || Txt_Statement.Text == "" || DDL_Medical_Name.SelectedValue == "0")
            {
                LblErrors.Text = " * يرجى إدخال الحقول المطلوبة التي بجانبها";
                return;
            }

            if (Txt_MainID.Text == "" || Txt_MainID.Text == null)
            {
                MSG("يجب اختيار السند الرئيسي");
                return;
            }

            string Result = "";
            Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

            if (DDL_Medical_Name.SelectedValue != "")
            {
                Main_Listing_Bonds._Company = long.Parse(DDL_Medical_Name.SelectedValue);
            }
            Main_Listing_Bonds._Type = 297;

            try
            {
                if (Txt_Receipt_Date.Text != "")
                {
                    Main_Listing_Bonds._Bond_Date = DateTime.Parse(Txt_Receipt_Date.Text);
                }
            }
            catch (Exception)
            {

                MSG("خطأ في تاريخ السند");
                return;
            }


            Main_Listing_Bonds._Acounting_NO = Txt_Acounting_No.Text;
            Main_Listing_Bonds._Debtor = 0;
            Main_Listing_Bonds._Description = Txt_Statement.Text;
            Main_Listing_Bonds._Creditor = decimal.Parse(Txt_Value.Text);
            Main_Listing_Bonds._Sent_To = RB_Sent_To.SelectedValue.ToString();
            Main_Listing_Bonds._Claim_ID = long.Parse(Txt_SubID.Text);
            Main_Listing_Bonds._ID = long.Parse(Txt_MainID.Text);
            Result = Main_Listing_Bonds.Update_Main_Listing_Bonds();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " تعديل سند قبض للجهة الطبية : " + DDL_Medical_Name.SelectedItem.Text + " بقيمة : " + Txt_Value.Text + " ورقم السند : " + Txt_SubID.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            MSG(Result);


            GridView_receipt.DataBind();
            string D = Txt_Receipt_Date.Text;
            string ST = Txt_Statement.Text;
            ClearFields(Form.Controls);
            Txt_Receipt_Date.Text = D;
            Txt_Statement.Text = ST;
            Txt_SubID.Focus();
            LblErrors.Text = "";
            //Cls_Main_Receipt Main_Receipt = new Cls_Main_Receipt();
            //Main_Receipt._MainID = long.Parse(Txt_MainID.Text);
            //Main_Receipt._Acounting_No = Txt_Acounting_No.Text;
            //Main_Receipt._Name = long.Parse(DDL_Medical_Name.SelectedValue.ToString());
            //Main_Receipt._Sent_To = RB_Sent_To.SelectedValue.ToString();
            //Main_Receipt._Receipt_Date = DateTime.Parse(Txt_Receipt_Date.Text);
            //Main_Receipt._Statement = Txt_Statement.Text;
            //Main_Receipt._SubID = long.Parse(Txt_SubID.Text);
            //Main_Receipt._Value = double.Parse(Txt_Value.Text);

            //string Result = Main_Receipt.Update_Main_Receipt();
            //GridView_receipt.DataBind();
            //MSG(Result);
        }

        protected void GridView_receipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (GridView_receipt.SelectedRow.Cells[7].Text == "قبض")
            //{
            Get_Main_Receipt_ForUpdate();
            //}
            //else
            //{
            //    MSG("لا يمكن تعديل إلا قيود القبض يرجى اختيار قيد قبض");
            //}
            //Get_SubReceiptForMainReceipt();
        }

        protected void DDL_Medical_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Txt_Acounting_No.Text = Cls_Medical_Types_And_Companies.Get_Acounting_NO(long.Parse(DDL_Medical_Name.SelectedValue.ToString()));
            Txt_Acounting_No.Text = DDL_Medical_Name.SelectedValue;
            Txt_Acounting_No.Focus();
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (DDL_Medical_Name_Search.SelectedItem.Text == "--اختر--")
                {
                    GridView_receipt.DataSource = SqlDataSource_Receipt;
                    GridView_receipt.DataBind();
                }
                else
                {


                    cmd.CommandText = "SELECT[ID],[Medical_TypeName],[TypeDescription],[Bond_Date],[Debtor],[Creditor],[Description],[Claim_ID] FROM[dbo].[V_Listing_Bonds] WHERE TypeDescription=N'قبض' AND Medical_TypeName = N'" + DDL_Medical_Name_Search.SelectedItem.Text + "' ORDER BY [ID] DESC";
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
            if (Txt_SubID.Text == "" || Txt_Receipt_Date.Text == "" || Txt_Value.Text == "" || Txt_Acounting_No.Text == "" || Txt_Statement.Text == "" || DDL_Medical_Name.SelectedValue == "0")
            {
                LblErrors.Text = " * يرجى إدخال الحقول المطلوبة التي بجانبها";
                return;
            }

            if (Txt_MainID.Text == "" || Txt_MainID.Text == null)
            {
                MSG("يجب اختيار السند الرئيسي");
                return;
            }

            string Result = "";
            Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

            Main_Listing_Bonds._ID = long.Parse(Txt_MainID.Text);
            Result = Main_Listing_Bonds.Delete_Main_Listing_Bonds();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " حذف سند قبض للجهة الطبية : " + DDL_Medical_Name.SelectedItem.Text + " بقيمة : " + Txt_Value.Text + " ورقم السند : " + Txt_SubID.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            MSG(Result);

            GridView_receipt.DataBind();
            string D = Txt_Receipt_Date.Text;
            string ST = Txt_Statement.Text;
            ClearFields(Form.Controls);
            Txt_Receipt_Date.Text = D;
            Txt_Statement.Text = ST;
            Txt_SubID.Focus();
            LblErrors.Text = "";
        }

        //protected void GridView_SubReceipt_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Get_Sub_Receipt_ForUpdate();
        //}


        //public void Get_Sub_Receipt_ForUpdate()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_Sub_Receipt_ForUpdate";
        //        cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_SubReceipt.SelectedRow.Cells[1].Text));
        //        Cls_Connection.open_connection();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        bool Result;
        //        string Receipt_Date;
        //        DateTime Receipt_Date2;
        //        while (dr.Read())
        //        {

        //            Txt_ID2.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();

        //            Receipt_Date = dr.GetValue(dr.GetOrdinal("Receipt_Date")).ToString();
        //            Result = DateTime.TryParse(Receipt_Date, out Receipt_Date2);
        //            if (Result)
        //            {
        //                Txt_Receipt_Date.Text = Receipt_Date2.ToShortDateString();
        //            }


        //            Txt_Statement.Text = dr.GetValue(dr.GetOrdinal("Statement")).ToString();
        //            Txt_Value.Text = dr.GetValue(dr.GetOrdinal("Value")).ToString();
        //            Txt_Acounting_No.Text = dr.GetValue(dr.GetOrdinal("Acounting_No")).ToString();
        //        }

        //        Cls_Connection.close_connection();


        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}

        //public void Get_SubReceipt_ForGridView()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_Sub_Receipt_ForGridView";
        //        Cls_Connection.open_connection();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        GridView_SubReceipt.DataSource = dt;
        //        GridView_SubReceipt.DataBind();
        //        Cls_Connection.close_connection();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}


        //public void Get_SubReceiptForMainReceipt()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_Sub_Receipt_ForMainReceipt";
        //        cmd.Parameters.AddWithValue("@Main_Receipt_ID", Int64.Parse(Txt_ID.Text));
        //        Cls_Connection.open_connection();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        GridView_SubReceipt.DataSource = dt;
        //        GridView_SubReceipt.DataBind();
        //        Cls_Connection.close_connection();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}

        //protected void Btn_Save_SubReceipt_Click(object sender, EventArgs e)
        //{
        //    Cls_Sub_Recipt Sub_Recipt = new Cls_Sub_Recipt();
        //    if (Txt_ID.Text == "" || Txt_ID.Text == null)
        //    {
        //        MSG("يجب اختيار السند الرئيسي");
        //        return;
        //    }
        //    Sub_Recipt._ID = long.Parse(Txt_ID2.Text);
        //    Sub_Recipt._Acounting_No = Txt_Acounting_No.Text;
        //    Sub_Recipt._Main_Receipt_ID = long.Parse(Txt_ID.Text);
        //    if (Txt_Receipt_Date.Text != "")
        //    {
        //        Sub_Recipt._Receipt_Date = DateTime.Parse(Txt_Receipt_Date.Text);
        //    }

        //    Sub_Recipt._Statement = Txt_Statement.Text;
        //    Sub_Recipt._Value = double.Parse(Txt_Value.Text);
        //    string Result = Sub_Recipt.Insert_Sub_Recipt();
        //    Get_SubReceiptForMainReceipt();
        //    if (Result == "تمت الإضافة بنجاح")
        //    {
        //        MSG(Result);
        //    }
        //    else
        //    {
        //        MSG("يجب ان لا يتكرر رقم السند الفرعي المدخل");
        //    }

        //}

        //protected void Btn_Update_SubReceipt_Click(object sender, EventArgs e)
        //{
        //    Cls_Sub_Recipt Sub_Recipt = new Cls_Sub_Recipt();
        //    if (Txt_ID.Text == "" || Txt_ID.Text == null)
        //    {
        //        MSG("يجب اختيار السند الرئيسي");
        //        return;
        //    }
        //    Sub_Recipt._ID = long.Parse(Txt_ID2.Text);
        //    Sub_Recipt._Acounting_No = Txt_Acounting_No.Text;
        //    Sub_Recipt._Main_Receipt_ID = long.Parse(Txt_ID.Text);
        //    if (Txt_Receipt_Date.Text != "")
        //    {
        //        Sub_Recipt._Receipt_Date = DateTime.Parse(Txt_Receipt_Date.Text);
        //    }

        //    Sub_Recipt._Statement = Txt_Statement.Text;
        //    Sub_Recipt._Value = double.Parse(Txt_Value.Text);
        //    string Result = Sub_Recipt.Update_Sub_Recipt();
        //    GridView_SubReceipt.DataBind();
        //    MSG(Result);
        //}
    }
}