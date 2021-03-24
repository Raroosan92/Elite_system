using Elite_system.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Claims : System.Web.UI.Page
    {

        double Stamp;
        double Value;
        int Attch_Id;
        DataTable dt_Claims_GV2 = new DataTable();
        DataTable dt_Claims_GV1 = new DataTable();

        static decimal TransactionValue1;
        static decimal TransactionValue2;
        static decimal TransactionValue3;
        static decimal TransactionValue4;
        static decimal TransactionValue5;
        static decimal Sum;

        static int DoctorSpecializatio;
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //--rami لتغيير التاريخ من لوحة المفاتيح--
            Txt_FreezFrom.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender4.ClientID + "')");
            Txt_FreezTo.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender5.ClientID + "')");
            Txt_Received_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "');return (event.keyCode!=13);");
            Txt_Entry_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender3.ClientID + "');return (event.keyCode!=13);");
            TxtDate_SubClaim.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "');return (event.keyCode!=13);");
            Txt_Month_Year.Attributes.Add("onkeydown", "DateField_KeyDown(this,'return (event.keyCode!=13);");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 


            if (!Page.IsPostBack)
            {
                int year = DateTimeOffset.UtcNow.AddHours(2).Year;
                int month = DateTimeOffset.UtcNow.AddHours(2).Month;
                DateTime dt1 = new DateTime(year, month, System.DateTime.DaysInMonth(System.DateTime.Now.Year, month));

                Txt_FreezFrom.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                Txt_FreezTo.Text = dt1.ToString("yyyy-MM-dd");

                //rami
                slider.Visible = false;
                Approval_number.Visible = false;
                patient_name.Visible = false;
                Date.Visible = false;
                procedures.Visible = false;
                //BTN_RAMI.Visible = false;
                Specializatio.Visible = false;
                ProcedureDesc1.Visible = false;
                ProcedureDesc2.Visible = false;
                ProcedureDesc3.Visible = false;
                ProcedureDesc4.Visible = false;
                ProcedureDesc5.Visible = false;
                Calculate.Visible = false;
                PatientRatio.Visible = false;
                Tax.Visible = false;
                Module_No.Visible = false;
                Card_No.Visible = false;


                Btn_Update.Visible = HttpContext.Current.User.IsInRole("Update");
                Btn_Delete.Visible = HttpContext.Current.User.IsInRole("Delete");
                Btn_Save.Visible = HttpContext.Current.User.IsInRole("Add");

                Btn_Update_SubClaims.Visible = HttpContext.Current.User.IsInRole("Update");
                Btn_Save_SubClaims.Visible = HttpContext.Current.User.IsInRole("Add");
                Btn_Delete_SubClaims.Visible = HttpContext.Current.User.IsInRole("Delete");
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Btn_Save.Visible = true;
                    Btn_Update.Visible = true;
                    Btn_Delete.Visible = true;
                    //BTN_RAMI.Visible = true;
                    Btn_Save_SubClaims.Visible = true;
                    Btn_Update_SubClaims.Visible = true;
                    Btn_Delete_SubClaims.Visible = true;


                    Txt_Value.ReadOnly = false;
                    Txt_Value.BackColor = System.Drawing.Color.White;

                    Txt_Stamps.ReadOnly = false;
                    Txt_Stamps.BackColor = System.Drawing.Color.White;
                    //Btn_ListingBonds.Visible = true;
                }



                if (HttpContext.Current.User.IsInRole("Doctor"))
                {
                    //Approval_number.Visible = true;
                    //patient_name.Visible = true;
                    //Date.Visible = true;
                    //procedures.Visible = true;


                    //ProcedureDesc1.Visible = true;
                    //ProcedureDesc2.Visible = true;
                    //ProcedureDesc3.Visible = true;
                    //ProcedureDesc4.Visible = true;
                    //ProcedureDesc5.Visible = true;
                    //Calculate.Visible = true;
                    //PatientRatio.Visible = true;
                    //Tax.Visible = true;

                    //Txt_Value.ReadOnly = true;
                    //Txt_Value.BackColor = System.Drawing.Color.Silver;

                    DoctorSpecializatio = Get_DoctorSpecialization();

                    DataTable dt = new DataTable();
                    dt = Cls_Procedures.Get_Procedures(DoctorSpecializatio);
                    DDL_ProcedureDesc1.DataSource = dt;
                    DDL_ProcedureDesc1.DataBind();
                    DDL_ProcedureDesc1.Items.Insert(0, new ListItem("--اختر--", "0"));

                    DDL_ProcedureDesc2.DataSource = dt;
                    DDL_ProcedureDesc2.DataBind();
                    DDL_ProcedureDesc2.Items.Insert(0, new ListItem("--اختر--", "0"));

                    DDL_ProcedureDesc3.DataSource = dt;
                    DDL_ProcedureDesc3.DataBind();
                    DDL_ProcedureDesc3.Items.Insert(0, new ListItem("--اختر--", "0"));

                    DDL_ProcedureDesc4.DataSource = dt;
                    DDL_ProcedureDesc4.DataBind();
                    DDL_ProcedureDesc4.Items.Insert(0, new ListItem("--اختر--", "0"));

                    DDL_ProcedureDesc5.DataSource = dt;
                    DDL_ProcedureDesc5.DataBind();
                    DDL_ProcedureDesc5.Items.Insert(0, new ListItem("--اختر--", "0"));
                }

                //rami 
                // ------------- Get MonthYear ----------------------
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
                Txt_Month_Year.Text = MonthYear;
                // ------------------------------------------------

                //rami
                if (HttpContext.Current.User.IsInRole("Doctor"))
                {
                    Btn_Search.Visible = false;
                    DDL_Medical_Name_Search.Visible = false;
                    Label3.Visible = false;
                    Get_MainClaims_ForGridView(HttpContext.Current.User.Identity.Name);
                }
                else
                {
                    Get_MainClaims_ForGridView();
                }
                //rami
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Medical_Name_Search.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name_Search.DataBind();
                DDL_Medical_Name_Search.Items.Insert(0, new ListItem("--اختر--", "0"));


                int year1 = DateTime.UtcNow.AddHours(2).Year;
                for (int i = year1 - 5; i <= year1 + 5; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    DDL_Year.Items.Add(li);
                }
                //DDL_Year.Items.FindByText(year.ToString()).Selected = true;
                DDL_Year.Items.Insert(0, new ListItem("--اختر--", "0"));
                DDL_Month.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Receiver_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Receiver_Employee.DataBind();
                DDL_Receiver_Employee.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies3();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Main_Company2.DataSource = Cls_Main_Claims.Get_Companies3();
                DDL_Main_Company2.DataBind();
                DDL_Main_Company2.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Specialization.DataSource = Cls_Codes.Fill_DDL(2);
                DDL_Specialization.DataBind();
                DDL_Specialization.Items.Insert(0, new ListItem("--اختر--", "0"));



                Txt_Entry_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                Txt_Received_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");

                GetClaimsCount();

                DDL_Medical_Name.Focus();
                //////Fill_Claims_GV2();
                //Get_MainClaims_ForUpdate();



                //Recipt
                Statement.Visible = false;
                SubID.Visible = false;
                Acounting_No.Visible = false;
                Receipt_Date.Visible = false;
                Ammount.Visible = false;
                Txt_Receipt_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                Sent_To.Visible = false;
                Btn_SaveReceipt.Visible = false;
                Fill_Statment();
                //Recipt

            }

        }
        public void ListingBonds3()
        {
            string Result3 = "";
            Int64 Check2 = 0;
            //  -------------- Insert into Listin Bond --------------------



            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;

            // --------------- Check Listing Bonds ------------------------

            /////////////////////////////////////////////////////////////
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "select ID from Main_Listing_Bonds ";
            Cls_Connection.open_connection();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Medical_Name from Main_Claims";
            SqlDataReader reader4 = cmd.ExecuteReader();

            List<string> ID_Medical_Name = new List<string>();
            while (reader4.Read())
            {
                if (!reader4.IsDBNull(0))
                {
                    ID_Medical_Name.Add(reader4[0].ToString());

                }
            }
            reader4.Close();

            Cls_Connection.close_connection();



            //////////////////////////////////////////////////////////////////////////////
            Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();


            for (int i = 0; i < ID_Medical_Name.Count; i++)
            {
                var x = ID_Medical_Name[i].ToString();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckStampsInListingBonds";
                cmd.Parameters.AddWithValue("@Description", " أتعاب مطالبات" + " " + Txt_Month_Year.Text);
                var Claim_ID = long.Parse(Cls_Medical_Types_And_Companies.Get_Claim_ID(long.Parse(ID_Medical_Name[i].ToString()), Txt_Month_Year.Text));
                cmd.Parameters.AddWithValue("@Claim_ID", Int64.Parse(Claim_ID.ToString()));
                string s = "0";
                try
                {
                    Cls_Connection.open_connection();
                    s = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {

                }

                Check2 = Int64.Parse(s);


                Main_Listing_Bonds._Company = long.Parse(ID_Medical_Name[i]);
                Main_Listing_Bonds._Type = 296;
                Main_Listing_Bonds._Bond_Date = DateTime.UtcNow.AddHours(2).Date;
                string Contracting_Value = Cls_Medical_Types_And_Companies.Get_Contracting_Value(long.Parse(ID_Medical_Name[i]));
                Main_Listing_Bonds._Debtor = decimal.Parse(Contracting_Value);
                Main_Listing_Bonds._Description = " أتعاب مطالبات " + Txt_Month_Year.Text;
                Main_Listing_Bonds._Creditor = 0;
                Main_Listing_Bonds._Claim_ID = long.Parse(Cls_Medical_Types_And_Companies.Get_Claim_ID(long.Parse(ID_Medical_Name[i].ToString()), Txt_Month_Year.Text));
                Main_Listing_Bonds._Acounting_NO = Cls_Medical_Types_And_Companies.Get_Acounting_NO(long.Parse(ID_Medical_Name[i].ToString()));
                Cls_Connection.close_connection();


                if (Check2 == 0)
                {
                    Result3 = Main_Listing_Bonds.Insert_Main_Listing_Bonds();

                    //////////////////////////////////       Log        /////////////////////////////////////////////
                    //Cls_Log log = new Cls_Log();
                    //log._Log_Event = " أتعاب مطالبات شهر" + Txt_Month_Year.Text + " لمطالبة رقم " + Txt_ID.Text + " للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " دفعة رقم " + Txt_Batch_No.Text;
                    //log.Insert_Log();
                    //////////////////////////////////   End Of Log        /////////////////////////////////////////////
                }
                else
                {
                    Main_Listing_Bonds._ID = Check2;
                    Result3 = Main_Listing_Bonds.Update_Main_Listing_Bonds();

                    //////////////////////////////////       Log        /////////////////////////////////////////////
                    //Cls_Log log = new Cls_Log();
                    //log._Log_Event = " تعديل أتعاب مطالبات شهر " + Txt_Month_Year.Text + " لمطالبة رقم " + Txt_ID.Text + " للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " دفعة رقم " + Txt_Batch_No.Text;
                    //log.Insert_Log();
                    //////////////////////////////////   End Of Log        /////////////////////////////////////////////
                }
            }
            if (con.State == ConnectionState.Open)
            {
                Cls_Connection.close_connection();
            }

            MSG("تم التعديل على حسابات الجهات الطبية وتم اضافة الاشتراكات");





            ////----------------------------------------------------------- 



            //  -------------- Insert into Listin Bond --------------------
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (DDL_Receiver_Employee.SelectedIndex != 0 && Txt_Received_Date.Text != "")
            {
                string Result;


                int Month = int.Parse(DateTime.UtcNow.AddHours(2).Month.ToString());
                int Year = int.Parse(DateTime.UtcNow.AddHours(2).Year.ToString());
                if (Month > 1)
                {
                    Month = Month - 1;
                }
                else
                {
                    Year = Year - 1;

                }

                //string Month = Txt_Month_Year.Text.Substring(0, 1);
                //string Year = Txt_Month_Year.Text.Substring(2, 4);
                string Medical_ID = int.Parse(DDL_Medical_Name.SelectedValue).ToString();

                string Batch_No = Txt_Batch_No.Text;
                Int64 Claim_ID;
                try
                {
                    Claim_ID = Int64.Parse(Year + Month + Medical_ID + Batch_No);
                }
                catch (Exception)
                {

                    MSG("حدث خطأ في رقم الدفعة");
                    return;
                }



                //----------------- insert Into Main Claim ---------------------

                Cls_Main_Claims Main_Claims = new Cls_Main_Claims();
                Main_Claims._Claim_ID = Claim_ID;
                Main_Claims._Month_Year = Month + "/" + Year;
                if (Main_Claims.CheckMedicalTypeInClaims() == 0)
                {

                    try
                    {
                        Main_Claims._Batch_No = int.Parse(Txt_Batch_No.Text);
                    }
                    catch (Exception)
                    {

                        MSG("حدث خطأ في رقم الدفعة");
                        return;
                    }


                    try
                    {
                        Main_Claims._Entry_Date = DateTime.Parse(Txt_Entry_Date.Text);
                    }
                    catch (Exception)
                    {
                        MSG("حدث خطأ في صيغة تاريخ الإدخال");
                        return;
                    }



                    if (DDL_Medical_Name.SelectedValue != "")
                    {
                        Main_Claims._Medical_Name = int.Parse(DDL_Medical_Name.SelectedValue);
                    }

                    Main_Claims._Month_Year = Txt_Month_Year.Text;

                    try
                    {
                        if (Txt_Received_Date.Text != "")
                        {
                            Main_Claims._Received_Date = DateTime.Parse(Txt_Received_Date.Text);
                        }
                    }
                    catch (Exception)
                    {

                        MSG("حدث خطأ في صيغة تاريخ الإستلام");
                        return;
                    }


                    if (DDL_Receiver_Employee.SelectedValue != "")
                    {
                        Main_Claims._Receiver_Employee = int.Parse(DDL_Receiver_Employee.SelectedValue);
                    }
                    var Max = GetMax_TotalClaim();
                    if (Max > 0)
                    {
                        Main_Claims._Total_Claims = Max;
                    }

                    Result = Main_Claims.Insert_Main_Claims();


                    // --------------------------- insert Into Main Claimd ---------------------

                    ////////////////////////////////       Log        /////////////////////////////////////////////
                    Cls_Log log = new Cls_Log();
                    log._Log_Event = "إضافة مطالبة رئيسية للجهة الطبية: " + DDL_Medical_Name.SelectedItem.Text + " لشهر " + Txt_Month_Year.Text + " دفعة رقم " + Txt_Batch_No.Text;
                    log.Insert_Log();
                    ////////////////////////////////   End Of Log        /////////////////////////////////////////////


                    // --------------- Chech if Medical Typ Pay the Contracting Value ---------------------

                    DateTime month = DateTime.ParseExact(Txt_Entry_Date.Text, "yyyy-MM-dd", null);
                    var startDate = new DateTime(month.Year, month.Month, 1);
                    var endDate = startDate.AddMonths(1).AddDays(-1);
                    DateTime dt1 = startDate;
                    DateTime dt2 = endDate;


                    SqlConnection con = new SqlConnection();

                    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con = Cls_Connection._con;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CheckMedicalTypeInListingBonds";

                    cmd.Parameters.AddWithValue("@From", dt1);
                    cmd.Parameters.AddWithValue("@To", dt2);
                    cmd.Parameters.AddWithValue("@Medical_ID", long.Parse(DDL_Medical_Name.SelectedValue));

                    Cls_Connection.open_connection();

                    int Check = (int)cmd.ExecuteScalar();
                    Cls_Connection.close_connection();
                    if (Check == 0)
                    {
                        //Rami Roosan

                        // To Get Contracting_Value&Freez 

                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = con;
                        string sql = "SELECT [Freez],[Contracting_Value],[Acounting_NO] FROM [dbo].[Medical_Types_And_Companies] where id= '" + DDL_Medical_Name.SelectedValue + "'";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        DataTable table = new DataTable();
                        Cls_Connection.open_connection();
                        adapter.Fill(table);
                        string ContractingValue;
                        string Acounting_NO;
                        bool Freez = true;
                        try
                        {
                            ContractingValue = table.Rows[0]["Contracting_Value"].ToString();
                            Acounting_NO = table.Rows[0]["Acounting_NO"].ToString();
                            Freez = Ch_Freez2.Checked;
                        }
                        catch (Exception)
                        {
                            ContractingValue = "0";
                            Acounting_NO = "0";
                            Freez = false;
                        }

                        Cls_Connection.close_connection();



                        Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

                        if (DDL_Medical_Name.SelectedValue != "")
                        {
                            Main_Listing_Bonds._Company = long.Parse(DDL_Medical_Name.SelectedValue);
                        }
                        Main_Listing_Bonds._Type = 296;

                        if (Txt_Entry_Date.Text != "")
                        {
                            Main_Listing_Bonds._Bond_Date = DateTime.Parse(Txt_Entry_Date.Text);
                        }
                        if (ContractingValue == null || ContractingValue == "")
                        {
                            ContractingValue = "0";
                        }
                        if (Acounting_NO == null || Acounting_NO == "")
                        {
                            Acounting_NO = "0";
                        }
                        Main_Listing_Bonds._Acounting_NO = Acounting_NO;
                        Main_Listing_Bonds._Claim_ID = Claim_ID;

                        if (Freez == true)
                        {
                            Main_Listing_Bonds._Debtor = 0;
                            Main_Listing_Bonds._Description = " أتعاب مطالبات *ملاحظة* تجميد اشتراك" + Txt_Month_Year.Text;
                        }
                        else
                        {
                            Main_Listing_Bonds._Debtor = decimal.Parse(ContractingValue);
                            Main_Listing_Bonds._Description = " أتعاب مطالبات " + Txt_Month_Year.Text;
                        }

                        Main_Listing_Bonds._Creditor = 0;
                        Main_Listing_Bonds.Insert_Main_Listing_Bonds();

                        ////////////////////////////////       Log        /////////////////////////////////////////////

                        log._Log_Event = " إضافة سند قيد لقيمة  أتعاب مطالبات شهر " + Txt_Month_Year.Text + " لمطالبة رقم " + Txt_ID.Text + " للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text;
                        log.Insert_Log();
                        ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                        //Rami Roosan
                    }


                    GridView2.DataBind();
                    //Get_MainClaims_ForUpdate();


                    MSG(Result);
                    Txt_ID.Text = "";
                    Txt_Batch_No.Text = "";
                    DDL_Medical_Name.SelectedValue = "0";
                    Txt_Received_Date.Text = "";
                    DDL_Receiver_Employee.SelectedValue = "0";
                    Ch_Freez2.Checked = false;

                    int year = DateTimeOffset.UtcNow.AddHours(2).Year;
                    int month1 = DateTimeOffset.UtcNow.AddHours(2).Month;
                    DateTime dt3 = new DateTime(year, month1, System.DateTime.DaysInMonth(System.DateTime.Now.Year, month1));
                    Txt_FreezFrom.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                    Txt_FreezTo.Text = dt3.ToString("yyyy-MM-dd");

                    GridView_SubClaims.DataSource = null;
                    GridView_SubClaims.DataBind();

                    GetClaimsCount();
                    Txt_Batch_No.Focus();
                }
                else
                {
                    MSG("هذه المطالبة مدخلة مسبقا يرجى إدخال مطالبات فرعية عليها أو تغيير رقم الدفعة");
                }


                //rami
                if (HttpContext.Current.User.IsInRole("Doctor"))
                {
                    Label3.Visible = false;
                    Get_MainClaims_ForGridView(HttpContext.Current.User.Identity.Name);
                }
                else
                {
                    Get_MainClaims_ForGridView();
                }





                Cls_Medical_Types_And_Companies Medical_Type = new Cls_Medical_Types_And_Companies();


                Medical_Type._Freez = Ch_Freez2.Checked;

                if (Ch_Freez2.Checked)
                {
                    if (Txt_FreezFrom.Text != "")
                    {
                        Medical_Type._FreezFrom = DateTime.Parse(Txt_FreezFrom.Text);
                    }
                    else
                    {
                        Medical_Type._FreezFrom = DateTime.Parse(DBNull.Value.ToString());
                    }
                    if (Txt_FreezTo.Text != "")
                    {
                        Medical_Type._FreezTo = DateTime.Parse(Txt_FreezTo.Text);
                    }
                    else
                    {
                        Medical_Type._FreezTo = DateTime.Parse(DBNull.Value.ToString());
                    }
                    //Medical_Type._ID = Int64.Parse(DDL_Medical_Name.SelectedValue.ToString());
                    Medical_Type._ID = long.Parse(Medical_ID);
                    Medical_Type.Update_Medical_TypesFreezing();
                }




                //rami
                //foreach (Control c in Page.Controls)
                //{
                //    foreach (Control ctrl in c.Controls)
                //    {
                //        if (ctrl is TextBox)
                //        {
                //            ((TextBox)ctrl).Text = string.Empty;
                //        }
                //        if (ctrl is DropDownList)
                //        {
                //            ((DropDownList)c).SelectedIndex = -1;
                //        }
                //    }
                //}
            }
            else
            {
                MSG("لم تتم عملية الاضافة يوجد حقول فارغة");
            }
        }

        private int GetMax_TotalClaim()
        {
            var Month = DateTimeOffset.UtcNow.AddHours(2).Month;
            var Year = DateTimeOffset.UtcNow.AddHours(2).Year;
            if (Month > 1)
            {
                Month = Month - 1;
            }

            else
            {
                Year = Year - 1;
            }

            if (Month == 1)
            {
                Month = 12;
            }

            string MonthYear = Month.ToString() + "/" + Year.ToString();
            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select ISNULL(max(Total_Claims),0) from Main_Claims where Month_Year like N'%" + MonthYear + "%'";
            Cls_Connection.open_connection();
            int Total = (int)cmd.ExecuteScalar();
            Cls_Connection.close_connection();
            return Total + 1;
        }
        protected void Btn_Save_SubClaims_Click(object sender, EventArgs e)
        {
            string Result2;
            Cls_Sub_Claims Sub_Claims = new Cls_Sub_Claims();
            if (DDL_Medical_Name.SelectedIndex != 0)
            {
                if (Txt_ID.Text == "" || Txt_ID.Text == null)
                {
                    MSG("يجب اختيار السند الرئيسي");
                    return;
                }
                Sub_Claims._Main_Claims_ID = Int64.Parse(Txt_ID.Text);



                if (DDL_Main_Company.SelectedValue != "")
                {
                    Sub_Claims._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
                }

                //------------- Calculate Stamps ----------------------------------------
                //Value = double.Parse(Txt_Value.Text);
                //Count = double.Parse(Txt_Claims_Count.Text);
                //Stamp = ((Value * 0.006) + 0.5) * Count;
                //Txt_Stamps.Text = Math.Round(Stamp).ToString();
                //------------------------------------------------------------------------

                if (Txt_Stamps.Text == "0")
                {
                    Sub_Claims._Stamps = 0;
                }
                else
                {
                    try
                    {

                        Sub_Claims._Stamps = decimal.Parse(Txt_Stamps.Text);
                    }
                    catch (Exception)
                    {

                        MSG("خطا في قيمة الطوابع");
                        return;
                    }
                }
                if (DDL_Sub_Company.SelectedValue != "")
                {
                    Sub_Claims._Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
                }
                try
                {
                    Sub_Claims._Claims_Count = int.Parse(Txt_Claims_Count.Text);
                }
                catch (Exception)
                {
                    MSG("خطأ في عدد المطالبات");
                    return;
                }

                try
                {
                    Sub_Claims._Value = double.Parse(Txt_Value.Text);
                }
                catch (Exception)
                {

                    MSG("خطأ في قيمة المطالبة");
                    return;
                }

                if (Txt_patient_name.Text != "")
                {
                    Sub_Claims._patient_name = Txt_patient_name.Text;
                }
                else
                {
                    Sub_Claims._patient_name = "";
                }
                try
                {
                    if (TxtDate_SubClaim.Text != "")
                    {
                        Sub_Claims._Date_Subclaim = DateTime.Parse(TxtDate_SubClaim.Text);
                    }
                }
                catch (Exception)
                {

                    MSG("خطأ في تاريخ الدخول");
                    return;
                }
                if (Txt_Approval_number.Text != "")
                {
                    Sub_Claims._Approval_number = Txt_Approval_number.Text;
                }
                else
                {
                    Sub_Claims._Approval_number = "";
                }
                if (Txt_procedures.Text != "")
                {
                    Sub_Claims._procedures_Subclaim = Txt_procedures.Text;
                }
                else
                {
                    Sub_Claims._procedures_Subclaim = "";
                }
                if (Txt_Card_Num.Text != "")
                {
                    Sub_Claims._Card_Num = Txt_Card_Num.Text;
                }
                else
                {
                    Sub_Claims._Card_Num = "";
                }
                if (Txt_Sample_Num.Text != "")
                {
                    Sub_Claims._Sample_Num = Txt_Sample_Num.Text;
                }
                else
                {
                    Sub_Claims._Sample_Num = "";
                }
                //if (RB_Delivered.SelectedValue == "1")
                //{
                //    Sub_Claims._Delivered = true;
                //}
                //else
                //{
                //    Sub_Claims._Delivered = false;
                //}
                try
                {
                    Sub_Claims._Procedure1 = int.Parse(DDL_ProcedureDesc1.SelectedValue);
                    Sub_Claims._Procedure2 = int.Parse(DDL_ProcedureDesc2.SelectedValue);
                    Sub_Claims._Procedure3 = int.Parse(DDL_ProcedureDesc3.SelectedValue);
                    Sub_Claims._Procedure4 = int.Parse(DDL_ProcedureDesc4.SelectedValue);
                    Sub_Claims._Procedure5 = int.Parse(DDL_ProcedureDesc5.SelectedValue);


                }
                catch (Exception)
                {

                }


                if (Txt_PatientRatio.Text != "")
                {
                    try
                    {
                        Sub_Claims._PatientRatio = (decimal.Parse(Txt_PatientRatio.Text) / 100);
                    }
                    catch (Exception)
                    {

                        MSG("يرجى ادخال نسبة تحمل المريض بشكل صحيح");
                        return;
                    }
                }

                if (Txt_Tax.Text != "")
                {
                    try
                    {
                        Sub_Claims._Tax = (decimal.Parse(Txt_Tax.Text) / 100);
                    }
                    catch (Exception)
                    {

                        MSG("يرجى ادخال ضريبة الدخل بشكل صحيح");
                        return;
                    }
                }


                Result2 = Sub_Claims.Insert_Sub_Claims();




                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " إضافة على المطالبات الفرعية للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " لشهر " + Txt_Month_Year.Text + " دفعة رقم " + Txt_Batch_No.Text + " للشركة " + DDL_Main_Company.SelectedItem.Text + " بقيمة " + Txt_Value.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////


                //rami
                int attach_type = 300;
                string attach_place_store;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                conn.Open();
                cmd.Connection = conn;
                //cmd.CommandText = "Select IDENT_CURRENT('Main_claims')";
                cmd.CommandText = "Select IDENT_CURRENT('Sub_Claims')";
                int strImageName = int.Parse(cmd.ExecuteScalar().ToString());

                DateTime datevalue = (DateTime.UtcNow.AddHours(2));
                string dd = datevalue.Day.ToString();
                string mm = datevalue.Month.ToString();
                string yy = datevalue.Year.ToString();

                try
                {
                    HttpFileCollection flImages = Request.Files;

                    for (int i = 0; i < flImages.Count; i++)
                    {
                        HttpPostedFile userPostedFile = flImages[i];

                        cmd.Parameters.Clear();
                        cmd.CommandText = "Select IDENT_CURRENT('Attachments')";
                        Attch_Id = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
                        cmd.Parameters.Clear();

                        try
                        {
                            if (userPostedFile.ContentLength > 0)

                            {
                                if (System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".png" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".bmp" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".pdf" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".docx" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".xlsx")
                                {
                                    string strConnString = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;

                                    using (SqlConnection con = new SqlConnection(strConnString))
                                    {
                                        //////////////////////////////////////////////////
                                        string path = System.IO.Path.GetExtension(userPostedFile.FileName);

                                        attach_place_store = "\\\\Claims" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + path;
                                        using (SqlCommand cmd1 = new SqlCommand())
                                        {
                                            cmd1.CommandType = CommandType.StoredProcedure;
                                            cmd1.CommandText = "SP_Attachments";
                                            cmd1.Parameters.AddWithValue("@attach_type", attach_type);
                                            cmd1.Parameters.AddWithValue("@attach_Path", attach_place_store);
                                            cmd1.Parameters.AddWithValue("@attach_doc_id", strImageName);
                                            cmd1.Parameters.AddWithValue("@check", "i");
                                            cmd1.Connection = con;
                                            con.Open();
                                            cmd1.ExecuteNonQuery();
                                            con.Close();
                                        }
                                    }

                                    System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Claims\\" + yy + "\\" + mm + "\\" + dd + "\\"));
                                    userPostedFile.SaveAs(Server.MapPath("\\UploadedImages\\" + attach_place_store));
                                }
                                else
                                {
                                    MSG("الملف الذي قمت بإدخاله غير صالح");
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MSG("يوجد خطأ يرجى مراجعة مسؤول النظام");
                            MSG(ex.Message);
                        }

                    }
                }
                catch (Exception ex)
                {

                    MSG("يرجى مراجعة مسؤول النظام" + ex.Message);
                }

                MSG(Result2);
                DDL_Main_Company.SelectedValue = "0";
                DDL_Sub_Company.SelectedIndex = -1;
                Txt_Claims_Count.Text = "";
                Txt_Value.Text = "";
                Txt_Stamps.Text = "";
                Txt_Approval_number.Text = "";
                Txt_patient_name.Text = "";
                Txt_procedures.Text = "";
                TxtDate_SubClaim.Text = "";
                Txt_Card_Num.Text = "";
                Txt_Sample_Num.Text = "";
                DDL_Main_Company.Focus();
                //RB_Delivered.SelectedIndex = -1;


            }
            else
            {
                MSG("يرجى ادخال تفاصيل المعاملة");
            }

            GetSubClaimsCount();
            //rami
            Get_SubClaims_ForMainClaim();

            DDL_Main_Company.SelectedIndex = 0;
            DDL_Sub_Company.DataSource = null;
            DDL_Sub_Company.DataBind();
            Txt_Claims_Count.Text = "";
            Txt_Value.Text = "";
            DDL_ProcedureDesc1.SelectedValue = "0";
            DDL_ProcedureDesc2.SelectedValue = "0";
            DDL_ProcedureDesc3.SelectedValue = "0";
            DDL_ProcedureDesc4.SelectedValue = "0";
            DDL_ProcedureDesc5.SelectedValue = "0";

            Txt_PatientRatio.Text = "";
            Txt_Tax.Text = "";

            GetTotalStamps();
            ListingBonds();
            //ListingBonds2();
            //MSG(Result2);
        }
        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            if (Txt_ID.Text != "")
            {

                string Result;
                Cls_Main_Claims Main_Claims = new Cls_Main_Claims();
                try
                {
                    Main_Claims._Batch_No = int.Parse(Txt_Batch_No.Text);
                }
                catch (Exception)
                {

                    MSG("خطأ في رقم الدفعة");
                    return;
                }

                try
                {
                    if (Txt_Entry_Date.Text != "")
                    {
                        Main_Claims._Entry_Date = DateTime.Parse(Txt_Entry_Date.Text);
                    }
                }
                catch (Exception)
                {

                    MSG("خطأفي تاريخ الإدخال");
                    return;
                }

                if (DDL_Medical_Name.SelectedValue != "")
                {
                    Main_Claims._Medical_Name = int.Parse(DDL_Medical_Name.SelectedValue);
                }

                Main_Claims._Month_Year = Txt_Month_Year.Text;

                try
                {
                    if (Txt_Received_Date.Text != "")
                    {
                        Main_Claims._Received_Date = DateTime.Parse(Txt_Received_Date.Text);
                    }
                }
                catch (Exception)
                {

                    MSG("خطأ في تاريخ الإستلام");
                    return;
                }


                if (DDL_Receiver_Employee.SelectedValue != "")
                {
                    Main_Claims._Receiver_Employee = int.Parse(DDL_Receiver_Employee.SelectedValue);
                }



                Main_Claims._Claim_ID = long.Parse(Txt_ID.Text);
                Main_Claims._ID = Convert.ToInt64(GridView2.SelectedRow.Cells[1].Text);
                Result = Main_Claims.Update_Main_Claims();


                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = "تعديل على المطالبة الرئيسية للجهة الطبية: " + DDL_Medical_Name.SelectedItem.Text + " لشهر " + Txt_Month_Year.Text + " دفعة رقم " + Txt_Batch_No.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////


                Txt_ID.Text = "";
                Txt_Batch_No.Text = "";
                DDL_Medical_Name.SelectedValue = "0";
                Txt_Received_Date.Text = "";
                DDL_Receiver_Employee.SelectedValue = "0";

                GridView_SubClaims.DataSource = null;
                GridView_SubClaims.DataBind();


                MSG(Result);


                Txt_Batch_No.Text = "";
                DDL_Medical_Name.SelectedValue = "0";
                Txt_Received_Date.Text = "";
                DDL_Receiver_Employee.SelectedValue = "0";

                GridView_SubClaims.DataSource = null;
                GridView_SubClaims.DataBind();
                Txt_Batch_No.Focus();
                //rami
                if (HttpContext.Current.User.IsInRole("Doctor"))
                {
                    Label3.Visible = false;
                    Get_MainClaims_ForGridView(HttpContext.Current.User.Identity.Name);
                }
                else
                {
                    Get_MainClaims_ForGridView();
                }
                //rami
            }
            else
            {
                MSG("يجب اختيار مطالبة اولاً");
            }
            //rami
        }
        protected void Btn_Update_SubClaims_Click(object sender, EventArgs e)
        {
            string Result2;
            Cls_Sub_Claims Sub_Claims = new Cls_Sub_Claims();
            if (Txt_ID.Text == "")
            {
                MSG("يجب اختيار مطالبة رئيسية");
                return;
            }
            else
            {
                Sub_Claims._Main_Claims_ID = Convert.ToInt64(Txt_ID.Text);

            }

            Sub_Claims._ID = Convert.ToInt64(GridView_SubClaims.SelectedRow.Cells[1].Text);
            if (DDL_Main_Company.SelectedValue != "")
            {
                Sub_Claims._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            }


            if (Txt_Stamps.Text == "0")
            {
                Sub_Claims._Stamps = 0;
            }
            else
            {
                try
                {

                    Sub_Claims._Stamps = decimal.Parse(Txt_Stamps.Text);
                }
                catch (Exception)
                {

                    MSG("خطأ في قيمة الطوابع");
                    return;
                }
            }


            if (DDL_Sub_Company.SelectedValue != "")
            {
                Sub_Claims._Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
            }
            try
            {
                Sub_Claims._Claims_Count = int.Parse(Txt_Claims_Count.Text);
            }
            catch (Exception)
            {
                MSG("خطأ في عدد المطالبات");
                return;
            }

            try
            {
                Sub_Claims._Value = double.Parse(Txt_Value.Text);
            }
            catch (Exception)
            {

                MSG("خطأ في قيمة المطالبة");
                return;
            }

            if (Txt_patient_name.Text != "")
            {
                Sub_Claims._patient_name = Txt_patient_name.Text;
            }
            else
            {
                Sub_Claims._patient_name = "";
            }
            try
            {
                if (TxtDate_SubClaim.Text != "")
                {
                    Sub_Claims._Date_Subclaim = DateTime.Parse(TxtDate_SubClaim.Text);
                }
            }
            catch (Exception)
            {

                MSG("خطأ في تاريخ الدخول");
                return;
            }
            if (Txt_Approval_number.Text != "")
            {
                Sub_Claims._Approval_number = Txt_Approval_number.Text;
            }
            else
            {
                Sub_Claims._Approval_number = "";
            }
            if (Txt_procedures.Text != "")
            {
                Sub_Claims._procedures_Subclaim = Txt_procedures.Text;
            }
            else
            {
                Sub_Claims._procedures_Subclaim = "";
            }
            if (Txt_Card_Num.Text != "")
            {
                Sub_Claims._Card_Num = Txt_Card_Num.Text;
            }
            else
            {
                Sub_Claims._Card_Num = "";
            }
            if (Txt_Sample_Num.Text != "")
            {
                Sub_Claims._Sample_Num = Txt_Sample_Num.Text;
            }
            else
            {
                Sub_Claims._Sample_Num = "";
            }
            //if (RB_Delivered.SelectedValue == "1")
            //{
            //    Sub_Claims._Delivered = true;
            //}
            //else
            //{
            //    Sub_Claims._Delivered = false;
            //}


            //rami
            int attach_type = 300;
            string attach_place_store;
            int strImageName = int.Parse(GridView_SubClaims.SelectedRow.Cells[1].Text);

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
            cmd.Connection = conn;
            conn.Open();
            DateTime datevalue = (DateTime.UtcNow.AddHours(2));
            string dd = datevalue.Day.ToString();
            string mm = datevalue.Month.ToString();
            string yy = datevalue.Year.ToString();

            try
            {
                HttpFileCollection flImages = Request.Files;

                for (int i = 0; i < flImages.Count; i++)
                {

                    cmd.CommandText = "Select IDENT_CURRENT('Attachments')";
                    Attch_Id = int.Parse(cmd.ExecuteScalar().ToString()) + 1;

                    HttpPostedFile userPostedFile = flImages[i];
                    if (userPostedFile.ContentLength > 0)
                    {
                        if (System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".png" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".bmp" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".pdf" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".docx" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".xlsx")

                        {
                            string strConnString = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;

                            using (SqlConnection con = new SqlConnection(strConnString))
                            {
                                string path = System.IO.Path.GetExtension(userPostedFile.FileName);
                                attach_place_store = "\\\\Claims" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + path;
                                using (SqlCommand cmd1 = new SqlCommand())
                                {
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.CommandText = "SP_Attachments";
                                    cmd1.Parameters.AddWithValue("@attach_type", attach_type);
                                    cmd1.Parameters.AddWithValue("@attach_Path", attach_place_store);
                                    cmd1.Parameters.AddWithValue("@attach_doc_id", strImageName);
                                    cmd1.Parameters.AddWithValue("@check", "i");
                                    cmd1.Connection = con;
                                    con.Open();
                                    cmd1.ExecuteNonQuery();
                                    con.Close();

                                    System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Claims\\" + yy + "\\" + mm + "\\" + dd + "\\"));
                                    userPostedFile.SaveAs(Server.MapPath("\\UploadedImages\\" + attach_place_store));

                                }
                            }


                        }
                        else
                        {
                            MSG("الملف الذي قمت بإدخاله غير صالح");
                        }
                    }

                }
                conn.Close();
            }

            catch (Exception)
            {

                MSG("يرجى مراجعة مسؤول النظام");
            }

            //rami
            try
            {
                Sub_Claims._Procedure1 = int.Parse(DDL_ProcedureDesc1.SelectedValue);
                Sub_Claims._Procedure2 = int.Parse(DDL_ProcedureDesc2.SelectedValue);
                Sub_Claims._Procedure3 = int.Parse(DDL_ProcedureDesc3.SelectedValue);
                Sub_Claims._Procedure4 = int.Parse(DDL_ProcedureDesc4.SelectedValue);
                Sub_Claims._Procedure5 = int.Parse(DDL_ProcedureDesc5.SelectedValue);



            }
            catch (Exception)
            {


            }
            if (Txt_PatientRatio.Text != "")
            {
                try
                {
                    Sub_Claims._PatientRatio = (decimal.Parse(Txt_PatientRatio.Text) / 100);
                }
                catch (Exception)
                {

                    MSG("يرجى ادخال نسبة تحمل المريض بشكل صحيح");
                    return;
                }
            }

            if (Txt_Tax.Text != "")
            {
                try
                {
                    Sub_Claims._Tax = (decimal.Parse(Txt_Tax.Text) / 100);
                }
                catch (Exception)
                {

                    MSG("يرجى ادخال ضريبة الدخل بشكل صحيح");
                    return;
                }
            }

            Result2 = Sub_Claims.Update_Sub_Check();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " تعديل على المطالبة الفرعية للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " لشهر " + Txt_Month_Year.Text + " دفعة رقم " + Txt_Batch_No.Text + " للشركة " + DDL_Main_Company.SelectedItem.Text + " بقيمة " + Txt_Value.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            GetTotalStamps();
            ListingBonds();
            Get_SubClaims_ForMainClaim();
            MSG(Result2);

            DDL_Main_Company.SelectedValue = "0";
            DDL_Sub_Company.SelectedIndex = -1;
            Txt_Claims_Count.Text = "";
            Txt_Value.Text = "";
            Txt_Stamps.Text = "";
            Txt_Approval_number.Text = "";
            Txt_patient_name.Text = "";
            Txt_procedures.Text = "";
            TxtDate_SubClaim.Text = "";
            Txt_Card_Num.Text = "";
            Txt_Sample_Num.Text = "";

            DDL_ProcedureDesc1.SelectedValue = "0";
            DDL_ProcedureDesc2.SelectedValue = "0";
            DDL_ProcedureDesc3.SelectedValue = "0";
            DDL_ProcedureDesc4.SelectedValue = "0";
            DDL_ProcedureDesc5.SelectedValue = "0";

            Txt_PatientRatio.Text = "";
            Txt_Tax.Text = "";

            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            Sub_Companies._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            DDL_Sub_Company.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Sub_Company.DataBind();
            DDL_Sub_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
            DDL_Main_Company.Focus();

            //RB_Delivered.SelectedIndex = -1;
        }
        protected void Btn_Delete_Click1(object sender, EventArgs e)
        {
            if (Txt_ID.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // To Check if there a sub claim from main claim;
                cmd.CommandText = "select count(*) from sub_claims where Main_Claims_ID = " + Int64.Parse(Txt_ID.Text) + "";
                //cmd.Parameters.AddWithValue("@Main_Claims_ID", Int64.Parse(Txt_ID.Text));
                Cls_Connection.open_connection();
                int ID = (int)cmd.ExecuteScalar();
                Cls_Connection.close_connection();


                if (ID <= 0)
                {
                    string Result;
                    Cls_Main_Claims Main_Claims = new Cls_Main_Claims();
                    Cls_Main_Listing_Bonds Listing_Bonds = new Cls_Main_Listing_Bonds();
                    if (HttpContext.Current.User.IsInRole("Admin"))
                    {

                        Main_Claims._ID = Int64.Parse(Txt_ID.Text);
                        Listing_Bonds._ID = Int64.Parse(Txt_ID.Text); ;

                        //rami
                        SqlConnection con1 = new SqlConnection();
                        con1.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                        con1 = Cls_Connection._con;
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select attach_Path from Attachments where  attach_doc_id = " + Int64.Parse(Txt_ID.Text) + "";
                        cmd1.Connection = con1;
                        con1.Open();
                        //if (!reader.IsDBNull(reader.GetOrdinal("attach_Path")))
                        //if (reader["attach_Path"] != null && reader["attach_Path"] != DBNull.Value)
                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string fileName = (string)reader["attach_Path"];
                                string dd = "\\UploadedImages" + fileName.Replace("\\\\", "\\");
                                string sss = Server.MapPath(dd);
                                if (File.Exists(sss))
                                {
                                    File.Delete(sss);
                                }
                            }
                            reader.Close();
                            cmd1.Parameters.Clear();

                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.CommandText = "SP_Attachments";
                            cmd1.Parameters.AddWithValue("@attach_doc_id", Int64.Parse(Txt_ID.Text));
                            cmd1.Parameters.AddWithValue("@check", "A");
                            cmd1.ExecuteNonQuery();
                            con1.Close();


                            Listing_Bonds.Delete_Main_Listing_BondsFromClaims();
                            Result = Main_Claims.Delete_Main_Claims();
                            MSG(Result);



                            ////////////////////////////////       Log        /////////////////////////////////////////////
                            Cls_Log log = new Cls_Log();
                            log._Log_Event = " حذف المطالبة الرئيسية للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " لشهر " + Txt_Month_Year.Text + " دفعة رقم " + Txt_Batch_No.Text;
                            log.Insert_Log();
                            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                            Txt_Batch_No.Text = "";
                            DDL_Medical_Name.SelectedValue = "0";
                            Txt_Received_Date.Text = "";
                            DDL_Receiver_Employee.SelectedValue = "0";

                            GridView_SubClaims.DataSource = null;
                            GridView_SubClaims.DataBind();
                            GetClaimsCount();



                            //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                            //try
                            //{
                            //    // To Get ID For Claim Recored
                            //    conn2.Close();
                            //    conn2.Open();
                            //    SqlCommand cmd2 = new SqlCommand();
                            //    cmd2.Connection = conn2;
                            //    string sql = "select ID from Main_Listing_Bonds where Claim_ID = '" + GridView2.SelectedRow.Cells[1].Text + "'";
                            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn2);
                            //    DataTable table = new DataTable();
                            //    adapter.Fill(table);
                            //    string ClaimID = table.Rows[0]["ID"].ToString();
                            //    Listing_Bonds._ID = int.Parse(ClaimID);
                            //    Listing_Bonds.Delete_Main_Listing_Bonds();
                            //    // To Check if there a sub claim from main claim;

                            //    ////////////////////////////////       Log        /////////////////////////////////////////////
                            //    log._Log_Event = "حذف من حركات المطالبات: " + DDL_Medical_Name.SelectedItem.Text;
                            //    log.Insert_Log();
                            //    ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                            //    ///

                            //}
                            //catch (Exception ex)
                            //{
                            //    conn2.Close();
                            //}



                            //Get_MainClaims_ForUpdate();
                            //Get_SubClaims_ForMainClaim();

                            //Fill_Claims_GV2();
                            //Fill_Claims_GV1(DDL_Medical_Name.SelectedItem.Text, Txt_Month_Year.Text);
                        }
                    }
                    else
                    {
                        MSG("انت لست مخول للحذف  يرجى مراجعة مسؤول النظام");
                    }
                }
                else
                {
                    MSG("هذه الجهة لها مطالبات فرعية يجب حذف المطالبات الفرعية اولاً");
                }
            }
            else
            {
                MSG("يجب اختيار مطالبة اولاً");
            }

            GridView2.DataBind();
            Txt_ID.Text = "";
            Txt_Batch_No.Text = "";
            DDL_Medical_Name.SelectedValue = "0";
            Txt_Received_Date.Text = "";
            DDL_Receiver_Employee.SelectedValue = "0";

            GridView_SubClaims.DataSource = null;
            GridView_SubClaims.DataBind();
            //rami
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                Label3.Visible = false;
                Get_MainClaims_ForGridView(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                Get_MainClaims_ForGridView();
            }
            //rami
            //rami


        }
        protected void Btn_Delete_SubClaims_Click(object sender, EventArgs e)
        {
            if (GridView_SubClaims.SelectedValue != null)
            {


                string Result;
                Cls_Sub_Claims Sub_Claims = new Cls_Sub_Claims();
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Sub_Claims._ID = Convert.ToInt64(GridView_SubClaims.SelectedRow.Cells[1].Text);
                    //rami
                    SqlConnection con1 = new SqlConnection();
                    con1.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con1 = Cls_Connection._con;
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "select attach_Path from Attachments where  attach_doc_id = " + GridView_SubClaims.SelectedValue + "";
                    cmd1.Connection = con1;
                    con1.Close();
                    con1.Open();
                    //if (!reader.IsDBNull(reader.GetOrdinal("attach_Path")))
                    //if (reader["attach_Path"] != null && reader["attach_Path"] != DBNull.Value)
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string fileName = (string)reader["attach_Path"];
                            string dd = "\\UploadedImages" + fileName.Replace("\\\\", "\\");
                            string sss = Server.MapPath(dd);
                            if (File.Exists(sss))
                            {
                                File.Delete(sss);
                            }
                        }
                        reader.Close();
                        cmd1.Parameters.Clear();

                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandText = "SP_Attachments";
                        cmd1.Parameters.AddWithValue("@attach_doc_id", GridView_SubClaims.SelectedValue);
                        cmd1.Parameters.AddWithValue("@check", "A");
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                        Result = Sub_Claims.Delete_Sub_Claims();
                        MSG(Result);

                        ////////////////////////////////       Log        /////////////////////////////////////////////
                        Cls_Log log = new Cls_Log();
                        log._Log_Event = " حذف المطالبة الفرعية للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " لشهر " + Txt_Month_Year.Text + " دفعة رقم " + Txt_Batch_No.Text + " للشركة " + DDL_Main_Company.SelectedItem.Text + " بقيمة " + Txt_Value.Text;
                        log.Insert_Log();
                        ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                        GetTotalStamps();
                        ListingBonds();
                        Get_SubClaims_ForMainClaim();

                        DDL_Main_Company.SelectedValue = "0";
                        DDL_Sub_Company.SelectedIndex = -1;
                        Txt_Claims_Count.Text = "";
                        Txt_Value.Text = "";
                        Txt_Stamps.Text = "";
                        Txt_Approval_number.Text = "";
                        Txt_patient_name.Text = "";
                        Txt_procedures.Text = "";
                        TxtDate_SubClaim.Text = "";

                        GetSubClaimsCount();
                        //RB_Delivered.SelectedIndex = -1;

                        //Fill_Claims_GV2();
                        //Fill_Claims_GV1(DDL_Medical_Name.SelectedItem.Text, Txt_Month_Year.Text);
                    }
                }
                else
                {
                    MSG("انت لست مخول للحذف  يرجى مراجعة مسؤول النظام");
                }
            }
            else
            {
                MSG("يجب اختيار مطالبة اولاً");
            }


            //rami
        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
            {

                LinkButton btn = (LinkButton)sender;
                int attch_id = Convert.ToInt16(btn.CommandArgument);
                SqlConnection con = new SqlConnection();
                try
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con = Cls_Connection._con;
                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "select attach_Path from Attachments where  Attach_Id = " + DDl_Images.SelectedValue + "";
                    cmd.CommandText = "select attach_Path from Attachments where  Attach_Id = " + attch_id + "";
                    cmd.Connection = con;
                    con.Close();
                    con.Open();
                    string fileName = cmd.ExecuteScalar().ToString();
                    cmd.Parameters.Clear();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Attachments";
                    cmd.Parameters.AddWithValue("@Attach_Id", attch_id);
                    cmd.Parameters.AddWithValue("@check", "d");

                    cmd.ExecuteNonQuery();


                    con.Close();

                    //string dd = "C:\\Users\\Rami\\Desktop\\Rami&Shadi 13-1-2020\\Elite_system\\Elite_system\\UploadedImages" + fileName.Replace("\\\\","\\");
                    string dd = "\\UploadedImages" + fileName.Replace("\\\\", "\\");
                    string sss = Server.MapPath(dd);
                    if (File.Exists(sss))
                    {
                        File.Delete(sss);
                    }

                    //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));
                    //Get_MainClaims_ForUpdate2();
                    Get_SubClaims_ForUpdate();
                    MSG("تم حذف الصورة بنجاح");
                }
                catch
                {
                    con.Close();
                    MSG("يوجد خطأ في حذف الصورة");
                }
            }
            else
            {
                MSG("انت لست مخول لحذف الصورة يرجى مراجعة مسؤول النظام");
            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (DDL_Medical_Name_Search.SelectedItem.Text == "--اختر--" && DDL_Month.SelectedItem.Text == "--اختر--" && DDL_Year.SelectedItem.Text == "--اختر--")
            {

                //Get_SubClaims_ForMainClaim();
                //Fill_Claims_GV2();

                //Search2_Claims_GV2();
                //GridView2.DataSource = SqlDataSource_Claims;
                //GridView2.DataBind();
                //rami
                if (HttpContext.Current.User.IsInRole("Doctor"))
                {
                    Label3.Visible = false;
                    Get_MainClaims_ForGridView(HttpContext.Current.User.Identity.Name);
                }
                else
                {
                    Get_MainClaims_ForGridView();

                }
                //rami
                GridView_SubClaims.DataSource = null;
                GridView_SubClaims.DataBind();
            }
            else
            {
                string Month_Year;
                if (DDL_Month.SelectedItem.Text == "--اختر--")
                {
                    Month_Year = null;
                }
                else
                {
                    Month_Year = DDL_Month.SelectedItem.Text;
                }
                string Medical_Name;
                if (DDL_Medical_Name_Search.SelectedItem.Text == "--اختر--")
                {
                    Medical_Name = null;
                }
                else
                {
                    Medical_Name = DDL_Medical_Name_Search.SelectedValue;
                }
                string Year;
                if (DDL_Year.SelectedItem.Text == "--اختر--")
                {
                    Year = null;
                }
                else
                {
                    Year = DDL_Year.SelectedItem.Text;
                }
                Search_Claims_GV2(Medical_Name, Month_Year, Year);
                GridView_SubClaims.DataSource = null;
                GridView_SubClaims.DataBind();
            }

        }

        object result;
        public void Get_SubClaims_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                //Rami

                cmd.CommandText = "select Checked from Sub_Claims where ID = " + Convert.ToInt64(GridView_SubClaims.SelectedRow.Cells[1].Text) + "";


                Cls_Connection.open_connection();
                result = cmd.ExecuteScalar();
                Cls_Connection.close_connection();
                if (!HttpContext.Current.User.IsInRole("Admin"))
                {
                    if (bool.Parse(result.ToString()) == true)
                    {
                        Btn_Update_SubClaims.Visible = false;
                        Btn_Delete_SubClaims.Visible = false;
                    }
                    else
                    {
                        Btn_Update_SubClaims.Visible = true;
                        Btn_Delete_SubClaims.Visible = true;
                    }

                }
                cmd.Parameters.Clear();
                //Rami


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_SubClaims_ForUpdate";

                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_SubClaims.SelectedRow.Cells[1].Text));


                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                string Sub_Company = "";
                string Date_Subclaim;
                DateTime Date_Subclaim2;
                bool Result;

                while (dr.Read())
                {

                    Txt_Claims_Count.Text = dr.GetValue(dr.GetOrdinal("Claims_Count")).ToString();
                    Txt_Value.Text = dr.GetValue(dr.GetOrdinal("Value")).ToString();
                    Txt_Stamps.Text = dr.GetValue(dr.GetOrdinal("Stamps")).ToString();
                    //Txt_Stamps.Text = Math.Round(double.Parse(Txt_Stamps.Text)).ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("Main_Company")))
                    {
                        DDL_Main_Company.SelectedValue = dr.GetValue(dr.GetOrdinal("Main_Company")).ToString();
                    }
                    //RB_Delivered.SelectedValue = dr.GetValue(dr.GetOrdinal("Delivered")).ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("Sub_Company")))
                    {
                        Sub_Company = dr.GetValue(dr.GetOrdinal("Sub_Company")).ToString();
                    }
                    Txt_patient_name.Text = dr.GetValue(dr.GetOrdinal("patient_name")).ToString();
                    Txt_Card_Num.Text = dr.GetValue(dr.GetOrdinal("Card_Num")).ToString();
                    Txt_Sample_Num.Text = dr.GetValue(dr.GetOrdinal("Sample_Num")).ToString();

                    Date_Subclaim = dr.GetValue(dr.GetOrdinal("Date_Subclaim")).ToString();
                    Result = DateTime.TryParse(Date_Subclaim, out Date_Subclaim2);
                    if (Result)
                    {
                        TxtDate_SubClaim.Text = Date_Subclaim2.ToString("yyyy-MM-dd");

                    }

                    //TxtDate_SubClaim.Text = dr.GetValue(dr.GetOrdinal("Date_Subclaim")).ToString();
                    Txt_Approval_number.Text = dr.GetValue(dr.GetOrdinal("Approval_number")).ToString();
                    Txt_procedures.Text = dr.GetValue(dr.GetOrdinal("procedures_Subclaim")).ToString();

                    if (!dr.IsDBNull(dr.GetOrdinal("Procedure1")))
                    {
                        DDL_ProcedureDesc1.SelectedValue = dr.GetValue(dr.GetOrdinal("Procedure1")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Procedure2")))
                    {
                        DDL_ProcedureDesc2.SelectedValue = dr.GetValue(dr.GetOrdinal("Procedure2")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Procedure3")))
                    {
                        DDL_ProcedureDesc3.SelectedValue = dr.GetValue(dr.GetOrdinal("Procedure3")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Procedure4")))
                    {
                        DDL_ProcedureDesc4.SelectedValue = dr.GetValue(dr.GetOrdinal("Procedure4")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Procedure5")))
                    {
                        DDL_ProcedureDesc5.SelectedValue = dr.GetValue(dr.GetOrdinal("Procedure5")).ToString();
                    }
                    double PatientRatio = double.Parse(dr.GetValue(dr.GetOrdinal("PatientRatio")).ToString());

                    Txt_PatientRatio.Text = (PatientRatio * 100).ToString();

                    double tax = double.Parse(dr.GetValue(dr.GetOrdinal("Tax")).ToString());

                    Txt_Tax.Text = (tax * 100).ToString();

                }

                Cls_Connection.close_connection();

                if (Sub_Company != "")
                {
                    Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
                    Sub_Companies._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
                    DDL_Sub_Company.DataSource = Sub_Companies.Get_Sub_Companies();
                    DDL_Sub_Company.DataBind();

                    DDL_Sub_Company.SelectedValue = Sub_Company;

                }
                else
                {
                    DDL_Sub_Company.Items.Clear();
                    DDL_Sub_Company.DataBind();
                }


                //rami
                SqlDataAdapter da2 = new SqlDataAdapter();
                DataSet ds2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand();

                cmd2.Connection = con;
                cmd2.CommandText = "select attach_Path,Attach_Id from Attachments where attach_doc_id=" + Convert.ToInt64(GridView_SubClaims.SelectedRow.Cells[1].Text) + "";
                Cls_Connection.open_connection();
                cmd2.ExecuteNonQuery();
                da2.SelectCommand = cmd2;
                da2.Fill(ds2, "Attachments");

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    var str = ds2.Tables[0].Rows[0]["attach_Path"].ToString();
                    var str2 = str.Substring(str.LastIndexOf('.') + 1).ToLower().ToString();



                    if (str2 == "pdf" || str2 == "doc" || str2 == "docx" || str2 == "xls" || str2 == "xlsx")
                    {
                        Rpt_Download.Visible = true;
                        Rpt_Download.DataSource = ds2;
                        Rpt_Download.DataMember = "Attachments";
                        Rpt_Download.DataBind();
                    }

                    if (str2 == "jpeg" || str2 == "jpg" || str2 == "png" || str2 == "bmp")
                    {
                        slider.Visible = true;
                        RP_ImagesLi.DataSource = ds2;
                        RP_ImagesLi.DataMember = "Attachments";
                        RP_ImagesLi.DataBind();

                        RP_Image.DataSource = ds2;
                        RP_Image.DataMember = "Attachments";
                        RP_Image.DataBind();
                    }
                    //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));

                }
                else
                {
                    slider.Visible = false;
                    RP_ImagesLi.DataSource = ds2;
                    RP_ImagesLi.DataMember = "Attachments";
                    RP_ImagesLi.DataBind();

                    RP_Image.DataSource = ds2;
                    RP_Image.DataMember = "Attachments";
                    RP_Image.DataBind();
                }
                //rami



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }


        }
        public void Get_SubClaims_ForMainClaim()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_subClaims_ForMainClaim";

                cmd.Parameters.AddWithValue("@Main_Claims_ID", Int64.Parse(Txt_ID.Text));


                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView_SubClaims.DataSource = dt;
                GridView_SubClaims.DataBind();
                GridView_SubClaims.Visible = true;



                SqlCommand cmd1 = new SqlCommand("select sum(Stamps) Total from Sub_Claims where Main_Claims_ID ='" + Int64.Parse(Txt_ID.Text) + "'", con);

                string Total = cmd1.ExecuteScalar().ToString();

                if (Total == "")
                {
                    Txt_Stamps_Total.Text = 0.ToString();
                }
                else

                {
                    Txt_Stamps_Total.Text = Total;
                }


                Cls_Connection.close_connection();

                GetSubClaimsCount();

                //rami

                if (GridView_SubClaims.SelectedValue != null)
                {
                    SqlDataAdapter da2 = new SqlDataAdapter();
                    DataSet ds2 = new DataSet();
                    SqlCommand cmd2 = new SqlCommand();

                    cmd2.Connection = con;

                    cmd2.CommandText = "select attach_Path,Attach_Id from Attachments where attach_doc_id=" + Convert.ToInt64(GridView_SubClaims.SelectedRow.Cells[1].Text) + "";


                    Cls_Connection.open_connection();
                    cmd2.ExecuteNonQuery();
                    da2.SelectCommand = cmd2;
                    da2.Fill(ds2, "Attachments");

                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        var str = ds2.Tables[0].Rows[0]["attach_Path"].ToString();
                        var str2 = str.Substring(str.LastIndexOf('.') + 1).ToLower().ToString();



                        if (str2 == "pdf" || str2 == "doc" || str2 == "docx" || str2 == "xls" || str2 == "xlsx")
                        {
                            Rpt_Download.Visible = true;
                            Rpt_Download.DataSource = ds2;
                            Rpt_Download.DataMember = "Attachments";
                            Rpt_Download.DataBind();
                        }

                        if (str2 == "jpeg" || str2 == "jpg" || str2 == "png" || str2 == "bmp")
                        {
                            slider.Visible = true;
                            RP_ImagesLi.DataSource = ds2;
                            RP_ImagesLi.DataMember = "Attachments";
                            RP_ImagesLi.DataBind();

                            RP_Image.DataSource = ds2;
                            RP_Image.DataMember = "Attachments";
                            RP_Image.DataBind();
                        }
                        //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));

                    }
                    else
                    {
                        slider.Visible = false;
                        RP_ImagesLi.DataSource = ds2;
                        RP_ImagesLi.DataMember = "Attachments";
                        RP_ImagesLi.DataBind();

                        RP_Image.DataSource = ds2;
                        RP_Image.DataMember = "Attachments";
                        RP_Image.DataBind();
                    }
                }
                //GridView_SubClaims.Columns[1].Visible = false;
                //rami
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        public void Get_SubClaims_ForMainClaim_Search()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_subClaims_ForMainClaim_Search";

                cmd.Parameters.AddWithValue("@Main_Claims_ID", Int64.Parse(Txt_ID.Text));
                cmd.Parameters.AddWithValue("@Main_Company", Int64.Parse(DDL_Main_Company2.SelectedValue));

                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView_SubClaims.DataSource = dt;
                GridView_SubClaims.DataBind();
                GridView_SubClaims.Visible = true;
                Cls_Connection.close_connection();


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
            }

        }
        public void Get_SubClaims_ForGridView()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_subClaims_ForGridView";
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView_SubClaims.DataSource = dt;
                GridView_SubClaims.DataBind();
                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }
        //rami
        public void Get_MainClaims_ForGridView()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainClaims_ForGridView";
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView2.DataSource = dt;

                GridView2.DataBind();
                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }
        public void Get_MainClaims_ForGridView(string UName)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainClaims_ForGridViewByUName";
                cmd.Parameters.AddWithValue("@UName", UName);
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                GridView2.DataSource = dt;
                GridView2.DataBind();

                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCompany();

            DDL_ProcedureDesc1.SelectedValue = "0";
            DDL_ProcedureDesc2.SelectedValue = "0";
            DDL_ProcedureDesc3.SelectedValue = "0";
            DDL_ProcedureDesc4.SelectedValue = "0";
            DDL_ProcedureDesc5.SelectedValue = "0";

            TransactionValue1 = 0;
            TransactionValue2 = 0;
            TransactionValue3 = 0;
            TransactionValue4 = 0;
            TransactionValue5 = 0;
            Txt_Value.Text = "";
            Txt_Stamps.Text = "";

            DDL_Sub_Company.Focus();

        }

        protected void DDL_Sub_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_ProcedureDesc1.SelectedValue = "0";
            DDL_ProcedureDesc2.SelectedValue = "0";
            DDL_ProcedureDesc3.SelectedValue = "0";
            DDL_ProcedureDesc4.SelectedValue = "0";
            DDL_ProcedureDesc5.SelectedValue = "0";

            TransactionValue1 = 0;
            TransactionValue2 = 0;
            TransactionValue3 = 0;
            TransactionValue4 = 0;
            TransactionValue5 = 0;

            Txt_Value.Text = "";
            Txt_Stamps.Text = "";
            Txt_Value.Focus();

        }
        public void GetSubCompany()
        {
            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            Sub_Companies._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            DDL_Sub_Company.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Sub_Company.DataBind();
            DDL_Sub_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            slider.Visible = false;
            RP_Image.DataSource = null;
            RP_Image.DataMember = null;
            RP_Image.DataBind();
            Get_MainClaims_ForUpdate();
            Get_SubClaims_ForMainClaim();
            Txt_Value.Text = "";

            string Contracting_Value = Cls_Medical_Types_And_Companies.Get_Contracting_Value(long.Parse(DDL_Medical_Name.SelectedValue.ToString()));
            Label5.Text = " قيمة الإشتراك : " + Contracting_Value.ToString();
            Label10.Text = " قيمة الإشتراك : " + Contracting_Value.ToString();


            //Fill_Claims_GV1(GridView2.SelectedRow.Cells[1].Text, GridView2.SelectedRow.Cells[3].Text);
        }

        public void Search_Claims_GV2(string Medical_Name, string Month_Year, string year)
        {
            try
            {


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Search_Claims_GV2";

                cmd.Parameters.AddWithValue("@Medical_Name", Medical_Name);
                cmd.Parameters.AddWithValue("@Month_Year", Month_Year);
                cmd.Parameters.AddWithValue("@year", year);
                //cmd.Parameters.AddWithValue("@To", dt2);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Claims_GV2);
                Cls_Connection.close_connection();
                GridView2.DataSourceID = null;
                GridView2.DataSource = dt_Claims_GV2;
                GridView2.DataBind();

            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }

        public void Search2_Claims_GV2()
        {
            try
            {


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Search2_Claims_GV2";



                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Claims_GV2);
                Cls_Connection.close_connection();
                GridView2.DataSourceID = null;
                GridView2.DataSource = dt_Claims_GV2;
                GridView2.DataBind();

            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }
        protected void Txt_Value_TextChanged(object sender, EventArgs e)
        {
            if (Txt_ID.Text == "" || Txt_ID.Text == null)
            {
                MSG("يجب اختيار السند الرئيسي");
                return;
            }

            if (DDL_Medical_Name.SelectedValue == "0")
            {
                Txt_Value.Text = "";
                MSG("يجب اختيار الجهة الطبية");
                return;

            }
            if (DDL_Main_Company.SelectedValue == "0")
            {
                Txt_Value.Text = "";
                MSG("يجب اختيار الشركة");
                return;

            }
            int StampStatus1;
            int StampStatus2;
            try
            {


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select Stamps from Medical_Types_And_Companies where ID=" + DDL_Medical_Name.SelectedValue + " ";

                Cls_Connection.open_connection();
                StampStatus1 = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.CommandText = "Select Stamps from Medical_Types_And_Companies where ID=" + DDL_Main_Company.SelectedValue + " ";
                StampStatus2 = int.Parse(cmd.ExecuteScalar().ToString());
                Cls_Connection.close_connection();

                if (StampStatus1 == 306 && StampStatus2 == 306)
                {

                    Txt_Stamps.Enabled = true;
                    Value = double.Parse(Txt_Value.Text);
                    double StampFloat;
                    if (Value >= 50)
                    {
                        //Count = double.Parse(Txt_Claims_Count.Text);
                        Stamp = ((Value * 0.006) + 0.5);
                        StampFloat = (Math.Ceiling(Stamp * 10) / 10);
                        if (StampFloat < 1)
                        {
                            Txt_Stamps.Text = "1";

                        }
                        else
                        {
                            Txt_Stamps.Text = StampFloat.ToString();
                        }
                    }
                    else
                    {
                        Txt_Stamps.Text = "0";
                    }


                }
                else
                {
                    //Txt_Value.Text = "";
                    //Txt_Claims_Count.Text = "";
                    Txt_Stamps.Text = "0";
                    Txt_Stamps.Enabled = false;
                    //MSG("الجهة الطبية لا تضع طوابع");
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
            //Txt_Stamps.Focus();
            Txt_Claims_Count.Focus();
        }

        public void Get_MainClaims_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainClaims_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView2.SelectedRow.Cells[1].Text));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                bool Result;

                string Entry_Date;
                DateTime Entry_Date2;
                string Received_Date;
                DateTime Received_Date2;


                while (dr.Read())
                {

                    Txt_Batch_No.Text = dr.GetValue(dr.GetOrdinal("Batch_No")).ToString();
                    Txt_ID.Text = dr.GetValue(dr.GetOrdinal("Claim_ID")).ToString();
                    Txt_Month_Year.Text = dr.GetValue(dr.GetOrdinal("Month_Year")).ToString();

                    if (!dr.IsDBNull(dr.GetOrdinal("Medical_Name")))
                    {
                        DDL_Medical_Name.SelectedValue = dr.GetValue(dr.GetOrdinal("Medical_Name")).ToString();
                    }


                    Entry_Date = dr.GetValue(dr.GetOrdinal("Entry_Date")).ToString();
                    Result = DateTime.TryParse(Entry_Date, out Entry_Date2);
                    if (Result)
                    {
                        Txt_Entry_Date.Text = Entry_Date2.ToString("yyyy-MM-dd");

                    }

                    Received_Date = dr.GetValue(dr.GetOrdinal("Received_Date")).ToString();
                    Result = DateTime.TryParse(Received_Date, out Received_Date2);
                    if (Result)
                    {
                        Txt_Received_Date.Text = Received_Date2.ToString("yyyy-MM-dd");
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Receiver_Employee")))
                    {
                        DDL_Receiver_Employee.SelectedValue = dr.GetValue(dr.GetOrdinal("Receiver_Employee")).ToString();
                    }


                }

                Cls_Connection.close_connection();
                dr.Close();






                /////////////To Get Freezing ////////////////////////
                try
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con = Cls_Connection._con;
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandText = "Get_Medical_Types_ForUpdate";
                    cmd2.Parameters.AddWithValue("@ID", Int64.Parse(DDL_Medical_Name.SelectedValue.ToString()));
                    Cls_Connection.open_connection();
                    SqlDataReader dr2 = cmd2.ExecuteReader();

                    string FreezFrom;
                    DateTime FreezFrom2;
                    string FreezTo;
                    DateTime FreezTo2;

                    while (dr2.Read())
                    {

                        Ch_Freez2.Checked = bool.Parse(dr2.GetValue(dr2.GetOrdinal("Freez")).ToString());
                        FreezFrom = dr2.GetValue(dr2.GetOrdinal("FreezFrom")).ToString();
                        Result = DateTime.TryParse(FreezFrom, out FreezFrom2);
                        if (Result)
                        {
                            Txt_FreezFrom.Text = FreezFrom2.ToString("yyyy-MM-dd");
                        }
                        FreezTo = dr2.GetValue(dr2.GetOrdinal("FreezTo")).ToString();
                        Result = DateTime.TryParse(FreezTo, out FreezTo2);
                        if (Result)
                        {
                            Txt_FreezTo.Text = FreezTo2.ToString("yyyy-MM-dd");
                        }
                    }
                    dr2.Close();


                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    Cls_Connection.close_connection();
                }




            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }
            finally
            {

                Cls_Connection.close_connection();
            }

        }
        protected void DDL_Medical_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

            Txt_Acounting_No.Text = DDL_Medical_Name.SelectedValue.ToString() ;

            string Contracting_Value = Cls_Medical_Types_And_Companies.Get_Contracting_Value(long.Parse(DDL_Medical_Name.SelectedValue.ToString()));

            Label5.Text = " قيمة الإشتراك : " + Contracting_Value.ToString();

            DoctorSpecializatio = Get_DoctorSpecializationByID();
            DDL_Specialization.SelectedValue = DoctorSpecializatio.ToString();
            
            //if (HttpContext.Current.User.IsInRole("Doctor"))
            //{

            //}
            //else
            //{

            //}

            //Fill_DDL();

            Txt_Received_Date.Focus();
          
        }


        protected void GridView_SubClaims_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Get_SubClaims_ForUpdate();
            GetSubCompany();
        }

        protected void GridView_SubClaims_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Get_SubClaims_ForMainClaim();
            GridView_SubClaims.PageIndex = e.NewPageIndex;
            GridView_SubClaims.DataBind();
        }

        protected void Btn_ListingBonds_Click(object sender, EventArgs e)
        {


            //  -------------- Insert into Listin Bond --------------------

            ListingBonds();
            //ListingBonds2();

            //  -------------- Insert into Listin Bond --------------------
        }

        public void ListingBonds()
        {


            //  -------------- Insert into Listin Bond --------------------

            if (Txt_Stamps_Total.Text == "0.000" || Txt_ID.Text == "")
            {
                //MSG("رصيد الطوابع 0 يرجى اختيار مطالبة رئيسية");
            }
            else
            {

                string Month = DateTime.UtcNow.AddHours(2).Month.ToString();
                string Year = DateTime.UtcNow.AddHours(2).Year.ToString();
                string Medical_ID = int.Parse(DDL_Medical_Name.SelectedValue).ToString();
                string Batch_No = Txt_Batch_No.Text;
                Int64 Claim_ID;
                try
                {
                    Claim_ID = Int64.Parse(Year + Month + Medical_ID + Batch_No);
                }
                catch (Exception)
                {
                    MSG("خطأ في رقم الدفعة");
                    return;
                }


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;

                // --------------- Check Listing Bonds ------------------------
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckStampsInListingBonds";
                cmd.Parameters.AddWithValue("@Description", " طوابع مطالبات شهر " + Txt_Month_Year.Text + " مطالبة رقم " + Txt_ID.Text);
                cmd.Parameters.AddWithValue("@Claim_ID", Int64.Parse(Txt_ID.Text));

                string s = "0";
                Cls_Connection.open_connection();
                try
                {
                    s = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {

                }

                Int64 Check = Int64.Parse(s);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [Acounting_NO] FROM [dbo].[Medical_Types_And_Companies] where id= '" + DDL_Medical_Name.SelectedValue + "'";

                string Acounting_NO = cmd.ExecuteScalar().ToString();
                Cls_Connection.close_connection();

                Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

                if (DDL_Medical_Name.SelectedValue != "")
                {
                    Main_Listing_Bonds._Company = long.Parse(DDL_Medical_Name.SelectedValue);
                }
                Main_Listing_Bonds._Type = 296;

                try
                {
                    if (Txt_Entry_Date.Text != "")
                    {
                        Main_Listing_Bonds._Bond_Date = DateTime.Parse(Txt_Entry_Date.Text);
                    }
                }
                catch (Exception)
                {

                    MSG("خطأ في تاريخ الادخال");
                    return;
                }


                Main_Listing_Bonds._Debtor = decimal.Parse(Txt_Stamps_Total.Text);
                Main_Listing_Bonds._Description = " طوابع مطالبات شهر " + Txt_Month_Year.Text + " مطالبة رقم " + Txt_ID.Text;
                Main_Listing_Bonds._Creditor = 0;
                Main_Listing_Bonds._Claim_ID = long.Parse(Txt_ID.Text);
                Main_Listing_Bonds._Acounting_NO = Acounting_NO;

                string Result3 = "";
                if (Check == 0)
                {
                    Result3 = Main_Listing_Bonds.Insert_Main_Listing_Bonds();

                    ////////////////////////////////       Log        /////////////////////////////////////////////
                    Cls_Log log = new Cls_Log();
                    log._Log_Event = " إضافة سند قيد لقيمة  طوابع مطالبات شهر " + Txt_Month_Year.Text + " لمطالبة رقم " + Txt_ID.Text + " للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " دفعة رقم " + Txt_Batch_No.Text;
                    log.Insert_Log();
                    ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                }
                else
                {
                    Main_Listing_Bonds._ID = Check;
                    Result3 = Main_Listing_Bonds.Update_Main_Listing_Bonds();

                    ////////////////////////////////       Log        /////////////////////////////////////////////
                    Cls_Log log = new Cls_Log();
                    log._Log_Event = " تعديل سند قيد لقيمة  طوابع مطالبات شهر " + Txt_Month_Year.Text + " لمطالبة رقم " + Txt_ID.Text + " للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " دفعة رقم " + Txt_Batch_No.Text;
                    log.Insert_Log();
                    ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                }
                //----------------------------------------------------------- 
                MSG(Result3);

                DDL_Medical_Name.Focus();


            }
            //  -------------- Insert into Listin Bond --------------------
        }
        public void ListingBonds2()
        {


            //  -------------- Insert into Listin Bond --------------------

            if (Label5.Text == "")
            {
                MSG("يرجى اختيار مطالبة رئيسية");
            }
            else
            {

                string Month = DateTime.UtcNow.AddHours(2).Month.ToString();
                string Year = DateTime.UtcNow.AddHours(2).Year.ToString();
                string Medical_ID = int.Parse(DDL_Medical_Name.SelectedValue).ToString();
                string Batch_No = Txt_Batch_No.Text;
                Int64 Claim_ID;
                try
                {
                    Claim_ID = Int64.Parse(Year + Month + Medical_ID + Batch_No);
                }
                catch (Exception)
                {
                    MSG("خطأ في رقم الدفعة");
                    return;
                }


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;

                // --------------- Check Listing Bonds ------------------------

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckStampsInListingBonds";
                cmd.Parameters.AddWithValue("@Description", " أتعاب مطالبات" + " " + Txt_Month_Year.Text);
                cmd.Parameters.AddWithValue("@Claim_ID", Int64.Parse(Txt_ID.Text));

                string s = "0";
                Cls_Connection.open_connection();
                try
                {
                    s = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {

                }

                Int64 Check = Int64.Parse(s);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [Acounting_NO] FROM [dbo].[Medical_Types_And_Companies] where id= '" + DDL_Medical_Name.SelectedValue + "'";
                string Acounting_NO = cmd.ExecuteScalar().ToString();
                Cls_Connection.close_connection();

                Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

                if (DDL_Medical_Name.SelectedValue != "")
                {
                    Main_Listing_Bonds._Company = long.Parse(DDL_Medical_Name.SelectedValue);
                }
                Main_Listing_Bonds._Type = 296;

                try
                {
                    if (Txt_Entry_Date.Text != "")
                    {
                        Main_Listing_Bonds._Bond_Date = DateTime.Parse(Txt_Entry_Date.Text);
                    }
                }
                catch (Exception)
                {

                    MSG("خطأ في تاريخ الادخال");
                    return;
                }

                string Contracting_Value = Cls_Medical_Types_And_Companies.Get_Contracting_Value(long.Parse(DDL_Medical_Name.SelectedValue.ToString()));
                Main_Listing_Bonds._Debtor = decimal.Parse(Contracting_Value);
                Main_Listing_Bonds._Description = " أتعاب مطالبات " + Txt_Month_Year.Text;
                Main_Listing_Bonds._Creditor = 0;
                Main_Listing_Bonds._Claim_ID = long.Parse(Txt_ID.Text);
                Main_Listing_Bonds._Acounting_NO = Acounting_NO;

                string Result3 = "";
                if (Check == 0)
                {
                    Result3 = Main_Listing_Bonds.Insert_Main_Listing_Bonds();

                    ////////////////////////////////       Log        /////////////////////////////////////////////
                    Cls_Log log = new Cls_Log();
                    log._Log_Event = " أتعاب مطالبات شهر" + Txt_Month_Year.Text + " لمطالبة رقم " + Txt_ID.Text + " للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " دفعة رقم " + Txt_Batch_No.Text;
                    log.Insert_Log();
                    ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                }
                else
                {
                    Main_Listing_Bonds._ID = Check;
                    Result3 = Main_Listing_Bonds.Update_Main_Listing_Bonds();

                    ////////////////////////////////       Log        /////////////////////////////////////////////
                    Cls_Log log = new Cls_Log();
                    log._Log_Event = " تعديل أتعاب مطالبات شهر " + Txt_Month_Year.Text + " لمطالبة رقم " + Txt_ID.Text + " للجهة الطبية " + DDL_Medical_Name.SelectedItem.Text + " دفعة رقم " + Txt_Batch_No.Text;
                    log.Insert_Log();
                    ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                }
                //----------------------------------------------------------- 


                MSG(Result3);

                //DDL_Main_Company.SelectedValue = "0";
                //DDL_Sub_Company.SelectedIndex = -1;
                //Txt_Claims_Count.Text = "";
                //Txt_Value.Text = "";
                //Txt_Stamps.Text = "";
                ////RB_Delivered.SelectedIndex = -1;

                //Txt_ID.Text = "";
                //Txt_Batch_No.Text = "";
                //DDL_Medical_Name.SelectedValue = "0";
                //Txt_Received_Date.Text = "";
                //DDL_Receiver_Employee.SelectedValue = "0";

                //GridView_SubClaims.DataSource = null;
                //GridView_SubClaims.DataBind();
                DDL_Medical_Name.Focus();


            }
            //  -------------- Insert into Listin Bond --------------------
        }
        public void GetClaimsCount()
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select count(*) from Claims_GridView where Month_Year='" + Txt_Month_Year.Text + "'";
            Cls_Connection.open_connection();
            Label3.Text = " العدد " + cmd.ExecuteScalar().ToString();
            Cls_Connection.close_connection();

        }

        public void GetSubClaimsCount()
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from Sub_Claims where Main_Claims_ID ='" + Int64.Parse(Txt_ID.Text) + "'";
            Cls_Connection.open_connection();
            Label4.Text = " العدد " + cmd.ExecuteScalar().ToString();
            Cls_Connection.close_connection();

        }

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (!IsPostBack)
            //{
            //e.Row.Cells[1].Visible = false;
            //e.Row.Cells[4].Visible = false;
            //e.Row.Cells[6].Visible = false;
            //}
            //else
            //{
            if (GridView2.Rows.Count >= 0)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[6].Visible = false;

            }
            //}
        }

        protected void GridView_SubClaims_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[1].Visible = false;
        }

        protected void GridView_SubClaims_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //for the Edit button:
            //    LinkButton lb = (LinkButton)e.Row.Cells[0].Controls[0];
            //    if (lb != null)
            //    {
            //        lb.Enabled = false;
            //    }
        }

        protected void Btn_InsertAll_Click(object sender, EventArgs e)
        {
            string StrQuery;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                for (int i = 0; i < GridView_SubClaims.Rows.Count; i++)
                {
                    StrQuery = @"UPDATE [dbo].[Sub_Claims] SET [Checked] = 1 WHERE ID="
                        + GridView_SubClaims.Rows[i].Cells[1].Text + "";
                    cmd.CommandText = StrQuery;
                    cmd.ExecuteNonQuery();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                MSG("تم حفظ جميع المدخلات");

                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        protected void DDL_Specialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_DDL();
            Txt_patient_name.Focus();
        }

        protected void DDL_ProcedureDesc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            long MedicalType_ID = long.Parse(DDL_Medical_Name.SelectedValue);
            int ProcedureDesc = int.Parse(DDL_ProcedureDesc1.SelectedValue);
            long Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            long Sub_Company;
            try
            {
                Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
            }
            catch (Exception)
            {
                Sub_Company = 0;
            }
            decimal TransactionPrice = Get_Medical_Types_Check(MedicalType_ID, ProcedureDesc, Main_Company, Sub_Company);
            decimal Points = Get_ProcedurePoints(ProcedureDesc);
            TransactionValue1 = TransactionPrice * Points;

            //Lbl_ProcedureDesc1.Text= "تسعيرة الإجراء= " + TransactionPrice.ToString() + ", عدد النقاط= " + Points.ToString();
            //Lbl_ProcedureDesc11.Text = " قيمة الإجراء :" + TransactionValue1.ToString();

            DDL_ProcedureDesc2.Focus();
        }

        protected void DDL_ProcedureDesc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            long MedicalType_ID = long.Parse(DDL_Medical_Name.SelectedValue);
            int ProcedureDesc = int.Parse(DDL_ProcedureDesc2.SelectedValue);
            long Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            long Sub_Company;
            try
            {
                Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
            }
            catch (Exception)
            {
                Sub_Company = 0;
            }
            decimal TransactionPrice = Get_Medical_Types_Check(MedicalType_ID, ProcedureDesc, Main_Company, Sub_Company);
            decimal Points = Get_ProcedurePoints(ProcedureDesc);
            TransactionValue2 = TransactionPrice * Points;

            //Lbl_ProcedureDesc2.Text = "تسعيرة الإجراء= " + TransactionPrice.ToString() + ", عدد النقاط= " + Points.ToString();
            //Lbl_ProcedureDesc22.Text = " قيمة الإجراء :" + TransactionValue2.ToString();
            DDL_ProcedureDesc3.Focus();

        }

        protected void DDL_ProcedureDesc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            long MedicalType_ID = long.Parse(DDL_Medical_Name.SelectedValue);
            int ProcedureDesc = int.Parse(DDL_ProcedureDesc3.SelectedValue);
            long Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            long Sub_Company;
            try
            {
                Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
            }
            catch (Exception)
            {
                Sub_Company = 0;
            }

            decimal TransactionPrice = Get_Medical_Types_Check(MedicalType_ID, ProcedureDesc, Main_Company, Sub_Company);
            decimal Points = Get_ProcedurePoints(ProcedureDesc);
            TransactionValue3 = TransactionPrice * Points;

            //Lbl_ProcedureDesc3.Text = "تسعيرة الإجراء= " + TransactionPrice.ToString() + ", عدد النقاط= " + Points.ToString();
            //Lbl_ProcedureDesc33.Text = " قيمة الإجراء :" + TransactionValue3.ToString();
            DDL_ProcedureDesc4.Focus();

        }

        protected void DDL_ProcedureDesc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            long MedicalType_ID = long.Parse(DDL_Medical_Name.SelectedValue);
            int ProcedureDesc = int.Parse(DDL_ProcedureDesc4.SelectedValue);
            long Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            long Sub_Company;
            try
            {
                Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
            }
            catch (Exception)
            {
                Sub_Company = 0;
            }
            decimal TransactionPrice = Get_Medical_Types_Check(MedicalType_ID, ProcedureDesc, Main_Company, Sub_Company);
            decimal Points = Get_ProcedurePoints(ProcedureDesc);
            TransactionValue4 = TransactionPrice * Points;

            //Lbl_ProcedureDesc4.Text = "تسعيرة الإجراء= " + TransactionPrice.ToString() + ", عدد النقاط= " + Points.ToString();
            //Lbl_ProcedureDesc44.Text = " قيمة الإجراء :" + TransactionValue4.ToString();
            DDL_ProcedureDesc5.Focus();
        }

        protected void DDL_ProcedureDesc5_SelectedIndexChanged(object sender, EventArgs e)
        {
            long MedicalType_ID = long.Parse(DDL_Medical_Name.SelectedValue);
            int ProcedureDesc = int.Parse(DDL_ProcedureDesc5.SelectedValue);
            long Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            long Sub_Company;
            try
            {
                Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
            }
            catch (Exception)
            {
                Sub_Company = 0;
            }
            decimal TransactionPrice = Get_Medical_Types_Check(MedicalType_ID, ProcedureDesc, Main_Company, Sub_Company);
            decimal Points = Get_ProcedurePoints(ProcedureDesc);
            TransactionValue5 = TransactionPrice * Points;

            //Lbl_ProcedureDesc5.Text = "تسعيرة الإجراء= " + TransactionPrice.ToString() + ", عدد النقاط= " + Points.ToString();
            //Lbl_ProcedureDesc55.Text = " قيمة الإجراء :" + TransactionValue5.ToString
            Txt_PatientRatio.Focus();
        }


        public decimal Get_Medical_Types_Check(long MedicalType_ID, int ProcedureDesc, long Main_Company, long Sub_Company)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_Medical_Types_Check";
                cmd.Parameters.AddWithValue("@MedicalType_ID", MedicalType_ID);
                cmd.Parameters.AddWithValue("@ProcedureDesc", ProcedureDesc);
                cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
                cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);




                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                decimal Result = 0;
                while (dr.Read())
                {
                    Result = decimal.Parse(dr.GetValue(dr.GetOrdinal("TransactionPrice")).ToString());
                    //Result = " تسعيرة الإجراء: " + dr.GetValue(dr.GetOrdinal("TransactionPrice")).ToString() + " , ";
                    //Result +=" تسعيرة الكشفية: "+ dr.GetValue(dr.GetOrdinal("CheckPrice")).ToString() + " , ";
                    //Result+= " نسبة الخصم التعاقدي: " +  dr.GetValue(dr.GetOrdinal("DiscountRatio")).ToString();

                }

                Cls_Connection.close_connection();

                return Result;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();

                return 0;
            }

        }



        public decimal Get_ProcedurePoints(int ProcedureDesc)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_ProcedurePoints";

                cmd.Parameters.AddWithValue("@ID", ProcedureDesc);
                Cls_Connection.open_connection();

                decimal Result = decimal.Parse(cmd.ExecuteScalar().ToString());

                Cls_Connection.close_connection();

                return Result;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();

                return 0;
            }

        }


        public decimal GetMax(decimal N1, decimal N2, decimal N3, decimal N4, decimal N5)
        {
            decimal Max = Math.Max(Math.Max(Math.Max(Math.Max(N1, N2), N3), N4), N5);
            return Max;

        }

        protected void Btn_Calculat_Click(object sender, EventArgs e)
        {
            decimal Max = GetMax(TransactionValue1, TransactionValue2, TransactionValue3, TransactionValue4, TransactionValue5);
            Sum = 0;
            if (TransactionValue1 == Max)
            {
                Sum += TransactionValue1;
            }
            else
            {
                Sum += decimal.Parse("0.5") * TransactionValue1;
            }


            if (TransactionValue2 == Max)
            {
                Sum += TransactionValue2;
            }
            else
            {
                Sum += decimal.Parse("0.5") * TransactionValue2;
            }


            if (TransactionValue3 == Max)
            {
                Sum += TransactionValue3;
            }
            else
            {
                Sum += decimal.Parse("0.5") * TransactionValue3;
            }


            if (TransactionValue4 == Max)
            {
                Sum += TransactionValue4;
            }
            else
            {
                Sum += decimal.Parse("0.5") * TransactionValue4;
            }

            if (TransactionValue5 == Max)
            {
                Sum += TransactionValue5;
            }
            else
            {
                Sum += decimal.Parse("0.5") * TransactionValue5;
            }
            Txt_Value.Text = Sum.ToString();

            // Calculate Stamps

            if (Txt_ID.Text == "" || Txt_ID.Text == null)
            {
                MSG("يجب اختيار السند الرئيسي");
                return;
            }

            if (DDL_Medical_Name.SelectedValue == "0")
            {
                Txt_Value.Text = "";
                MSG("يجب اختيار الجهة الطبية");
                return;

            }
            if (DDL_Main_Company.SelectedValue == "0")
            {
                Txt_Value.Text = "";
                MSG("يجب اختيار الشركة");
                return;

            }
            int StampStatus1;
            int StampStatus2;
            try
            {


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select Stamps from Medical_Types_And_Companies where ID=" + DDL_Medical_Name.SelectedValue + " ";

                Cls_Connection.open_connection();
                StampStatus1 = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.CommandText = "Select Stamps from Medical_Types_And_Companies where ID=" + DDL_Main_Company.SelectedValue + " ";
                StampStatus2 = int.Parse(cmd.ExecuteScalar().ToString());
                Cls_Connection.close_connection();

                if (StampStatus1 == 306 && StampStatus2 == 306)
                {

                    Txt_Stamps.Enabled = true;
                    Value = double.Parse(Txt_Value.Text);
                    double StampFloat;
                    if (Value >= 50)
                    {
                        //Count = double.Parse(Txt_Claims_Count.Text);
                        Stamp = ((Value * 0.006) + 0.5);
                        StampFloat = (Math.Ceiling(Stamp * 10) / 10);
                        if (StampFloat < 1)
                        {
                            Txt_Stamps.Text = "1";

                        }
                        else
                        {
                            Txt_Stamps.Text = StampFloat.ToString();
                        }
                    }
                    else
                    {
                        Txt_Stamps.Text = "0";
                    }


                }
                else
                {
                    //Txt_Value.Text = "";
                    //Txt_Claims_Count.Text = "";
                    Txt_Stamps.Text = "0";
                    Txt_Stamps.Enabled = false;
                    //MSG("الجهة الطبية لا تضع طوابع");
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
            Txt_Stamps.Focus();

            //MSG("Max: " + Max.ToString() + " Sum: "+ Sum.ToString());
        }


        public int Get_DoctorSpecialization()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_DoctorSpecialization";

                cmd.Parameters.AddWithValue("@UName", HttpContext.Current.User.Identity.Name);
                Cls_Connection.open_connection();

                int Result = int.Parse(cmd.ExecuteScalar().ToString());

                Cls_Connection.close_connection();

                return Result;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();

                return 0;
            }

        }

        public int Get_DoctorSpecializationByID()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_DoctorSpecializationByID";

                cmd.Parameters.AddWithValue("@UName", long.Parse(DDL_Medical_Name.SelectedValue));
                Cls_Connection.open_connection();

                int Result = int.Parse(cmd.ExecuteScalar().ToString());

                Cls_Connection.close_connection();

                return Result;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();

                return 0;
            }

        }


        public void Fill_DDL()
        {
            DataTable dt = new DataTable();

            dt = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization.SelectedValue));
            //dt = Cls_Procedures.Get_Procedures(DoctorSpecializatio);

            int x = dt.Rows.Count;
            DDL_ProcedureDesc1.DataSource = dt;
            DDL_ProcedureDesc1.DataBind();
            DDL_ProcedureDesc1.Items.Insert(0, new ListItem("--اختر--", "0"));

            DDL_ProcedureDesc2.DataSource = dt;
            DDL_ProcedureDesc2.DataBind();
            DDL_ProcedureDesc2.Items.Insert(0, new ListItem("--اختر--", "0"));

            DDL_ProcedureDesc3.DataSource = dt;
            DDL_ProcedureDesc3.DataBind();
            DDL_ProcedureDesc3.Items.Insert(0, new ListItem("--اختر--", "0"));

            DDL_ProcedureDesc4.DataSource = dt;
            DDL_ProcedureDesc4.DataBind();
            DDL_ProcedureDesc4.Items.Insert(0, new ListItem("--اختر--", "0"));

            DDL_ProcedureDesc5.DataSource = dt;
            DDL_ProcedureDesc5.DataBind();
            DDL_ProcedureDesc5.Items.Insert(0, new ListItem("--اختر--", "0"));

        }

        protected void BTN_RAMI_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(48540);
            //var watch = System.Diagnostics.Stopwatch.StartNew();


            ListingBonds3();
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //Txt_procedures.Text = elapsedMs.ToString();
        }

        public double GetTotalStamps()
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;

            SqlCommand cmd1 = new SqlCommand("select sum(Stamps) Total from Sub_Claims where Main_Claims_ID ='" + Int64.Parse(Txt_ID.Text) + "'", con);
            Cls_Connection.open_connection();

            string Total = cmd1.ExecuteScalar().ToString();
            Cls_Connection.close_connection();
            double TStamps = 0;
            if (Total == "")
            {
                Txt_Stamps_Total.Text = 0.ToString();
            }
            else

            {
                Txt_Stamps_Total.Text = Total;
                TStamps = double.Parse(Total);
            }
            return TStamps;
        }

        protected void Btn_IN_Click(object sender, EventArgs e)
        {
            Approval_number.Visible = true;
            patient_name.Visible = true;
            Date.Visible = true;
            procedures.Visible = true;
            Specializatio.Visible = true;
            ProcedureDesc1.Visible = true;
            ProcedureDesc2.Visible = true;
            ProcedureDesc3.Visible = true;
            ProcedureDesc4.Visible = true;
            ProcedureDesc5.Visible = true;
            Calculate.Visible = true;
            PatientRatio.Visible = true;
            Tax.Visible = true;
            Card_No.Visible = true;
            Module_No.Visible = true;
            DDL_Recipt.Visible = true;
        }

        protected void Btn_Out_Click(object sender, EventArgs e)
        {
            Approval_number.Visible = false;
            patient_name.Visible = false;
            Date.Visible = false;
            procedures.Visible = false;
            Specializatio.Visible = false;
            ProcedureDesc1.Visible = false;
            ProcedureDesc2.Visible = false;
            ProcedureDesc3.Visible = false;
            ProcedureDesc4.Visible = false;
            ProcedureDesc5.Visible = false;
            Calculate.Visible = false;
            PatientRatio.Visible = false;
            Tax.Visible = false;
            Card_No.Visible = false;
            Module_No.Visible = false;
            DDL_Recipt.Visible = false; 
        }

        protected void Btn_Search2_Click(object sender, EventArgs e)
        {
            if (DDL_Main_Company2.SelectedItem.Text == "--اختر--")
            {
                Get_SubClaims_ForMainClaim();
            }
            else
            {
                Get_SubClaims_ForMainClaim_Search();
            }


        }


        //Receipt
        public void Fill_Statment()
        {
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
            Txt_Statement.Text = "اتعاب مطالبات وطوابع" + MonthYear;
        }

        protected void DDL_Recipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_Recipt.SelectedIndex ==1)
            {
                Statement.Visible = true;
                SubID.Visible = true;
                Acounting_No.Visible = true;
                Txt_Acounting_No.Text = DDL_Medical_Name.SelectedValue.ToString();
                Receipt_Date.Visible = true;
                Ammount.Visible = true;
                Sent_To.Visible = true;
                Btn_SaveReceipt.Visible = true;
            }
            else
            {
                Statement.Visible = false;
                SubID.Visible = false;
                Acounting_No.Visible = false;
                Receipt_Date.Visible = false;
                Ammount.Visible = false;
                Sent_To.Visible = false;
                Btn_SaveReceipt.Visible = false;
            }
        }

        protected void Btn_SaveReceipt_Click(object sender, EventArgs e)
        {
            decimal Contracting_Value = decimal.Parse(Cls_Medical_Types_And_Companies.Get_Contracting_Value(long.Parse(DDL_Medical_Name.SelectedValue.ToString())));
            decimal Stamps = decimal.Parse(Txt_Stamps_Total.Text);

            if (Txt_SubID.Text == "" || Txt_Receipt_Date.Text == "" || Txt_ReceiptAmmount.Text == "" || Txt_Acounting_No.Text == "" || Txt_Statement.Text == "" || DDL_Medical_Name.SelectedValue == "0")
            {
                MSG(" * يرجى إدخال الحقول المطلوبة * ");
                return;
            }
            Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

            if (DDL_Medical_Name.SelectedIndex != 0)
            {
                Main_Listing_Bonds._Company = long.Parse(DDL_Medical_Name.SelectedValue);
            }
            else
            {
                MSG("يرجى اختيار الجهة الطبية");
                return;
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

            if (Txt_Acounting_No.Text != "")
            {
                Main_Listing_Bonds._Acounting_NO = Txt_Acounting_No.Text;
            }
            else
            {
                MSG("يرجى اختيار جهة طبية مرة اخرى لجلب رقم الحساب");
                return;
            }
            
            Main_Listing_Bonds._Debtor = 0;
            Main_Listing_Bonds._Description = Txt_Statement.Text;
            if (Contracting_Value+ Stamps> decimal.Parse(Txt_ReceiptAmmount.Text))
            {
                MSG("القيمة المدخلة اقل من قيمة السند");
                return;
            }
            else if (Contracting_Value + Stamps < decimal.Parse(Txt_ReceiptAmmount.Text))
            {
                MSG("القيمة المدخلة اكبر من قيمة السند");
                return;
            }
            else if (Contracting_Value + Stamps == decimal.Parse(Txt_ReceiptAmmount.Text))
            {
                Main_Listing_Bonds._Creditor = decimal.Parse(Txt_ReceiptAmmount.Text);
            }
            Main_Listing_Bonds._Sent_To = RB_Sent_To.SelectedValue.ToString();
            Main_Listing_Bonds._Claim_ID = long.Parse(Txt_SubID.Text);
            
            string Result =  Main_Listing_Bonds.Insert_Main_Listing_Bonds();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " إدخال سند قبض للجهة الطبية : " + DDL_Medical_Name.SelectedItem.Text + " بقيمة : " + Txt_ReceiptAmmount.Text + " ورقم السند : " + Txt_SubID.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            string D = Txt_Receipt_Date.Text;
            string ST = Txt_Statement.Text;
            Txt_Receipt_Date.Text = D;
            Txt_Statement.Text = ST;
            Txt_SubID.Text = "";
            Txt_ReceiptAmmount.Text = "";
            Statement.Visible = false;
            SubID.Visible = false;
            Acounting_No.Visible = false;
            Receipt_Date.Visible = false;
            Ammount.Visible = false;
            Sent_To.Visible = false;
            Btn_SaveReceipt.Visible = false;
            DDL_Recipt.SelectedIndex = 0;
            MSG(Result);
        }

        //Receipt
    }
}
