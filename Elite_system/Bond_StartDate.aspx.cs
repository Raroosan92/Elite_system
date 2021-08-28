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
    public partial class Bond_StartDate : System.Web.UI.Page
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
                Txt_Receipt_Date.Text = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");

                DDL_Medical_Name_Search.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name_Search.DataBind();
                DDL_Medical_Name_Search.Items.Insert(0, new ListItem("--اختر--", "0"));

                string MonthYear;
                int Month = int.Parse(DateTime.UtcNow.AddHours(3).Month.ToString());
                int Year = int.Parse(DateTime.UtcNow.AddHours(3).Year.ToString());
                if (Month > 1)
                {
                    MonthYear = (Month - 1).ToString() + "/" + Year.ToString();
                }
                else
                {
                    Year = Year - 1;
                    MonthYear = "12/" + (Year).ToString();
                }
                Txt_Statement.Text = "رصيد بداية المدة";

                //Txt_SubID.Focus();
                
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
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_receipt.SelectedRow.Cells[1].Text));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Txt_MainID.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();
                    Txt_Acounting_No.Text = dr.GetValue(dr.GetOrdinal("Acounting_No")).ToString();
                    
                    Txt_Receipt_Date.Text = DateTime.Parse(dr.GetValue(dr.GetOrdinal("Bond_Date")).ToString()).ToString("yyyy-MM-dd");

                    Txt_Statement.Text = dr.GetValue(dr.GetOrdinal("Description")).ToString();
                    
                    Txt_creditor.Text = dr.GetValue(dr.GetOrdinal("Creditor")).ToString();
                    Txt_Debtor.Text = dr.GetValue(dr.GetOrdinal("Debtor")).ToString();
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
            if (Txt_Receipt_Date.Text == "" || (Txt_Debtor.Text == "" && Txt_creditor.Text == "") || Txt_Acounting_No.Text == "" || Txt_Statement.Text == "" || DDL_Medical_Name.SelectedValue == "0")
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
            Main_Listing_Bonds._Type = 332;

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
            if (Txt_Debtor.Text=="")
            {
                Main_Listing_Bonds._Debtor = 0;
            }
            else
            {
                Main_Listing_Bonds._Debtor = decimal.Parse(Txt_Debtor.Text);
            }
            
            if (Txt_creditor.Text == "")
            {
                Main_Listing_Bonds._Creditor  = 0;
            }
            else
            {
                Main_Listing_Bonds._Creditor = decimal.Parse(Txt_creditor.Text);
            }
            Main_Listing_Bonds._Description = Txt_Statement.Text;
            //Main_Listing_Bonds._Claim_ID = long.Parse(Txt_SubID.Text);


            if (Main_Listing_Bonds.Check_Start_Listing_Bonds()=="0")
            {
                Result = Main_Listing_Bonds.Insert_Main_Listing_Bonds();
            }
            else
            {
                MSG("الجهة الطبية تم اضافة رصيدها مسبقاً يرجى التعديل عليها");
                goto S;
            }

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " إدخال سند رصيد بداية المدة للجهة الطبية : " + DDL_Medical_Name.SelectedItem.Text + " المدين : " + Txt_Debtor.Text + " الدائن : " + Txt_creditor.Text  ;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////


            MSG(Result);
            S:
            string D = Txt_Receipt_Date.Text;
            string ST = Txt_Statement.Text;
            ClearFields(Form.Controls);
            Txt_Receipt_Date.Text = D;
            Txt_Statement.Text = ST;
            DDL_Medical_Name.Focus();
            LblErrors.Text = "";
            GridView_receipt.DataBind();
        }

        protected void Btn_UpdateReceipt_Click(object sender, EventArgs e)
        {
            if (Txt_Receipt_Date.Text == "" || (Txt_Debtor.Text == "" && Txt_creditor.Text == "") || Txt_Acounting_No.Text == "" || Txt_Statement.Text == "" || DDL_Medical_Name.SelectedValue == "0")
            {
                LblErrors.Text = " * يرجى إدخال الحقول المطلوبة التي بجانبها";
                return;
            }

            if (Txt_MainID.Text == "" || Txt_MainID.Text == null)
            {
                MSG("يجب اختيار الجهة الطبية");
                return;
            }

            string Result = "";
            Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

            if (DDL_Medical_Name.SelectedValue != "")
            {
                Main_Listing_Bonds._Company = long.Parse(DDL_Medical_Name.SelectedValue);
            }
            Main_Listing_Bonds._Type = 332;

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
            if (Txt_Debtor.Text == "")
            {
                Main_Listing_Bonds._Debtor = 0;
            }
            else
            {
                Main_Listing_Bonds._Debtor = decimal.Parse(Txt_Debtor.Text);
            }

            if (Txt_creditor.Text == "")
            {
                Main_Listing_Bonds._Creditor = 0;
            }
            else
            {
                Main_Listing_Bonds._Creditor = decimal.Parse(Txt_creditor.Text);
            }
            Main_Listing_Bonds._Description = Txt_Statement.Text;
            //Main_Listing_Bonds._Sent_To = RB_Sent_To.SelectedValue.ToString();
            //Main_Listing_Bonds._Claim_ID = long.Parse(Txt_SubID.Text);
            Main_Listing_Bonds._ID = long.Parse(Txt_MainID.Text);
            Result = Main_Listing_Bonds.Update_Main_Listing_Bonds();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " تعديل سند رصيد بداية المدة للجهة الطبية : " + DDL_Medical_Name.SelectedItem.Text + " المدين : " + Txt_Debtor.Text + " الدائن : " + Txt_creditor.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            MSG(Result);


            
            string D = Txt_Receipt_Date.Text;
            string ST = Txt_Statement.Text;
            ClearFields(Form.Controls);
            Txt_Receipt_Date.Text = D;
            Txt_Statement.Text = ST;
            DDL_Medical_Name.Focus();
            LblErrors.Text = "";
            GridView_receipt.DataBind();

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
            Txt_Debtor.Focus();
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


                    cmd.CommandText = "Select ID, Medical_TypeName, TypeDescription, Bond_Date, Debtor, Creditor, Description, Claim_ID FROM V_Listing_Bonds WHERE (Type = 332) AND Medical_TypeName = N'" + DDL_Medical_Name_Search.SelectedItem.Text + "' ORDER BY [ID] DESC";
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
            if (Txt_Receipt_Date.Text == "" || (Txt_Debtor.Text == "" && Txt_creditor.Text == "") || Txt_Acounting_No.Text == "" || Txt_Statement.Text == "" || DDL_Medical_Name.SelectedValue == "0")
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
            log._Log_Event = " حذف سند رصيد بداية المدة للجهة الطبية : " + DDL_Medical_Name.SelectedItem.Text + " المدين : " + Txt_Debtor.Text + " الدائن : " + Txt_creditor.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            MSG(Result);

            GridView_receipt.DataBind();
            string D = Txt_Receipt_Date.Text;
            string ST = Txt_Statement.Text;
            ClearFields(Form.Controls);
            Txt_Receipt_Date.Text = D;
            Txt_Statement.Text = ST;
            DDL_Medical_Name.Focus();
            LblErrors.Text = "";
        }

        protected void Txt_Debtor_TextChanged(object sender, EventArgs e)
        {
            if (Txt_Debtor.Text.Length>0)
            {
                Txt_creditor.Enabled = false;
                Txt_Receipt_Date.Focus();
            }
            else
            {
                Txt_creditor.Enabled = true;
            }
        }

        protected void Txt_creditor_TextChanged(object sender, EventArgs e)
        {
            if (Txt_creditor.Text.Length > 0)
            {
                Txt_Debtor.Enabled = false;
                Txt_Receipt_Date.Focus();
            }
            else
            {
                Txt_Debtor.Enabled = true;
            }
        }
    }
}