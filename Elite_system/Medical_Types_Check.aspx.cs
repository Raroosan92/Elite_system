using Elite_system.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Elite_system
{
    public partial class Medical_Types_Check : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies3();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Specialization.DataSource = Cls_Codes.Fill_DDL(2);
                DDL_Specialization.DataBind();
                DDL_Specialization.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Medical_Name2.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name2.DataBind();
                DDL_Medical_Name2.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Main_Company2.DataSource = Cls_Main_Claims.Get_Companies3();
                DDL_Main_Company2.DataBind();
                DDL_Main_Company2.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Specialization2.DataSource = Cls_Codes.Fill_DDL(2);
                DDL_Specialization2.DataBind();
                DDL_Specialization2.Items.Insert(0, new ListItem("--اختر--", "0"));


            }


        }

        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCompany();
            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name.SelectedValue), int.Parse(DDL_Specialization.SelectedValue), long.Parse(DDL_Main_Company.SelectedValue), long.Parse(DDL_Sub_Company.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization.SelectedItem.Text;
            }
            catch (Exception)
            {


            }

        }

        protected void DDL_Medical_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_Specialization.SelectedValue = Get_DoctorSpecializationByID().ToString();

            DDL_ProcedureDesc.DataSource = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization.SelectedValue));
            DDL_ProcedureDesc.DataBind();
            DDL_ProcedureDesc.Items.Insert(0, new ListItem("--اختر--", "0"));
        }

        protected void DDL_Medical_Name2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_Specialization2.SelectedValue = Get_DoctorSpecializationByID2().ToString();

            DDL_ProcedureDesc2.DataSource = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization2.SelectedValue));
            DDL_ProcedureDesc2.DataBind();
            DDL_ProcedureDesc2.Items.Insert(0, new ListItem("--اختر--", "0"));
        }

        protected void DDL_Main_Company2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCompany2();

            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name2.SelectedValue), int.Parse(DDL_Specialization2.SelectedValue), long.Parse(DDL_Main_Company2.SelectedValue), long.Parse(DDL_Sub_Company2.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name2.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company2.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company2.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization2.SelectedItem.Text;
            }
            catch (Exception)
            {


            }
        }

        protected void DDL_Sub_Company2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name2.SelectedValue), int.Parse(DDL_Specialization2.SelectedValue), long.Parse(DDL_Main_Company2.SelectedValue), long.Parse(DDL_Sub_Company2.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name2.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company2.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company2.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization2.SelectedItem.Text;
            }
            catch (Exception)
            {


            }
        }

        protected void DDL_Sub_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name.SelectedValue), int.Parse(DDL_Specialization.SelectedValue), long.Parse(DDL_Main_Company.SelectedValue), long.Parse(DDL_Sub_Company.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization.SelectedItem.Text;
            }
            catch (Exception)
            {


            }
        }
        public void GetSubCompany()
        {
            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            Sub_Companies._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            DDL_Sub_Company.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Sub_Company.DataBind();
            DDL_Sub_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
        }

        public void GetSubCompany2()
        {
            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            Sub_Companies._Main_Company = long.Parse(DDL_Main_Company2.SelectedValue);
            DDL_Sub_Company2.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Sub_Company2.DataBind();
            DDL_Sub_Company2.Items.Insert(0, new ListItem("--اختر--", "0"));
        }

        protected void DDL_Specialization2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_ProcedureDesc2.DataSource = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization2.SelectedValue));
            DDL_ProcedureDesc2.DataBind();
            DDL_ProcedureDesc2.Items.Insert(0, new ListItem("--اختر--", "0"));

            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name2.SelectedValue), int.Parse(DDL_Specialization2.SelectedValue), long.Parse(DDL_Main_Company2.SelectedValue), long.Parse(DDL_Sub_Company2.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name2.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company2.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company2.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization2.SelectedItem.Text;
            }
            catch (Exception)
            {


            }
        }

        protected void DDL_Specialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDL_ProcedureDesc.DataSource = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization.SelectedValue));
            DDL_ProcedureDesc.DataBind();
            DDL_ProcedureDesc.Items.Insert(0, new ListItem("--اختر--", "0"));

            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name.SelectedValue), int.Parse(DDL_Specialization.SelectedValue), long.Parse(DDL_Main_Company.SelectedValue), long.Parse(DDL_Sub_Company.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization.SelectedItem.Text;
            }
            catch (Exception)
            {

               
            }
           

        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {


            if (DDL_Medical_Name.SelectedValue == "0")
            {
                Lbl_Result1.Text = "يرجى إختيار الجهة الطبية";
                return;
            }

            if (DDL_Main_Company.SelectedValue == "0")
            {
                Lbl_Result1.Text = "يرجى إختيار الشركة الرئيسية";
                return;
            }
            if (DDL_Specialization.SelectedValue == "0")
            {
                Lbl_Result1.Text = "يرجى إختيار التخصص";
                return;
            }

            //if (DDL_ProcedureDesc.SelectedValue == "0")
            //{
            //    Lbl_Result1.Text = "يرجى إختيار الإجراء";
            //    return;
            //}

            if (Txt_TransactionPrice.Text == "")
            {
                Lbl_Result1.Text = "يرجى ادخال تسعيرة الإجراء";
                return;

            }
            if (Txt_CheckPrice.Text == "")
            {
                Lbl_Result1.Text = "يرجى ادخال تسعيرة الكشفية";
                return;

            }

            if (Txt_DiscountRatio.Text == "")
            {
                Lbl_Result1.Text = "يرجى ادخال نسبة الخصم التعاقدي للإجراء";
                return;

            }

            if (Txt_DiscountRatio22.Text == "")
            {
                Lbl_Result1.Text = " يرجى ادخال نسبة الخصم التعاقدي للكشفية";
                return;

            }

            Cls_Medical_Types_Check Medical_Types_Check = new Cls_Medical_Types_Check();

            try
            {

                Medical_Types_Check._TransactionPrice = decimal.Parse(Txt_TransactionPrice.Text);

            }
            catch (Exception)
            {
                Lbl_Result1.Text = "يرجى ادخال تسعيرة الإجراء بشكل صحيح";
                return;
            }

            try
            {

                Medical_Types_Check._CheckPrice = decimal.Parse(Txt_CheckPrice.Text);

            }
            catch (Exception)
            {
                Lbl_Result1.Text = "يرجى ادخال تسعيرة الكشفية بشكل صحيح";
                return;
            }

            try
            {

                Medical_Types_Check._DiscountRatio = decimal.Parse(Txt_DiscountRatio.Text);

            }
            catch (Exception)
            {
                Lbl_Result1.Text = "يرجى ادخال نسبة الخصم التعاقدي  للإجراء بشكل صحيح";
                return;
            }

            try
            {

                Medical_Types_Check._DiscountRatio2 = decimal.Parse(Txt_DiscountRatio22.Text);

            }
            catch (Exception)
            {
                Lbl_Result1.Text = "يرجى ادخال نسبة الخصم التعاقدي  للكشفية بشكل صحيح";
                return;
            }

            string Result;

            
            Medical_Types_Check._MedicalType_ID = long.Parse(DDL_Medical_Name.SelectedValue);
            Medical_Types_Check._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            Medical_Types_Check._Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
            Medical_Types_Check._Specialization = int.Parse(DDL_Specialization.SelectedValue);
            Medical_Types_Check._ProcedureDesc = int.Parse(DDL_ProcedureDesc.SelectedValue);


            Result = Medical_Types_Check.Insert_Medical_Types_Check();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "إضافة على إعدادات الجهة الطبية للتدقيق : " + DDL_Medical_Name.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result1.Text = Result;


            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name.SelectedValue), int.Parse(DDL_Specialization.SelectedValue), long.Parse(DDL_Main_Company.SelectedValue), long.Parse(DDL_Sub_Company.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization.SelectedItem.Text;
            }
            catch (Exception)
            {


            }

            DDL_ProcedureDesc.SelectedValue = "0";
            Txt_CheckPrice.Text = "";
            Txt_DiscountRatio.Text = "";
            Txt_TransactionPrice.Text = "";
            Txt_DiscountRatio22.Text = "";
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {


            if (DDL_Medical_Name2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار الجهة الطبية";
                return;
            }

            if (DDL_Main_Company2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار الشركة الرئيسية";
                return;
            }
            if (DDL_Specialization2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار التخصص";
                return;
            }

            if (DDL_ProcedureDesc2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار الإجراء";
                return;
            }

            if (Txt_TransactionPrice2.Text == "")
            {
                Lbl_Result2.Text = "يرجى ادخال تسعيرة الإجراء";
                return;

            }
            if (Txt_CheckPrice2.Text == "")
            {
                Lbl_Result2.Text = "يرجى ادخال تسعيرة الكشفية";
                return;

            }

            if (Txt_DiscountRatio2.Text == "")
            {
                Lbl_Result1.Text = "يرجى ادخال نسبة الخصم التعاقدي للإجراء";
                return;

            }

            if (Txt_DiscountRatio3.Text == "")
            {
                Lbl_Result1.Text = " يرجى ادخال نسبة الخصم التعاقدي للكشفية";
                return;

            }



            Cls_Medical_Types_Check Medical_Types_Check = new Cls_Medical_Types_Check();

            try
            {

                Medical_Types_Check._TransactionPrice = decimal.Parse(Txt_TransactionPrice2.Text);

            }
            catch (Exception)
            {
                Lbl_Result2.Text = "يرجى ادخال تسعيرة الإجراء بشكل صحيح";
                return;
            }

            try
            {

                Medical_Types_Check._CheckPrice = decimal.Parse(Txt_CheckPrice2.Text);

            }
            catch (Exception)
            {
                Lbl_Result2.Text = "يرجى ادخال تسعيرة الكشفية بشكل صحيح";
                return;
            }

            try
            {

                Medical_Types_Check._DiscountRatio = decimal.Parse(Txt_DiscountRatio2.Text);

            }
            catch (Exception)
            {
                Lbl_Result1.Text = "يرجى ادخال نسبة الخصم التعاقدي  للإجراء بشكل صحيح";
                return;
            }

            try
            {

                Medical_Types_Check._DiscountRatio2 = decimal.Parse(Txt_DiscountRatio3.Text);

            }
            catch (Exception)
            {
                Lbl_Result1.Text = "يرجى ادخال نسبة الخصم التعاقدي  للكشفية بشكل صحيح";
                return;
            }

            string Result;


            Medical_Types_Check._MedicalType_ID = long.Parse(DDL_Medical_Name2.SelectedValue);
            Medical_Types_Check._Main_Company = long.Parse(DDL_Main_Company2.SelectedValue);
            Medical_Types_Check._Sub_Company = long.Parse(DDL_Sub_Company2.SelectedValue);
            Medical_Types_Check._Specialization = int.Parse(DDL_Specialization2.SelectedValue);
            Medical_Types_Check._ProcedureDesc = int.Parse(DDL_ProcedureDesc2.SelectedValue);


            Result = Medical_Types_Check.Update_Medical_Types_Check();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على إعدادات الجهة الطبية للتدقيق : " + DDL_Medical_Name.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;

            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name2.SelectedValue), int.Parse(DDL_Specialization2.SelectedValue), long.Parse(DDL_Main_Company2.SelectedValue), long.Parse(DDL_Sub_Company2.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name2.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company2.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company2.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization2.SelectedItem.Text;
            }
            catch (Exception)
            {


            }

            DDL_ProcedureDesc2.SelectedValue = "0";
            Txt_DiscountRatio2.Text = "";
            Txt_TransactionPrice2.Text = "";
            Txt_DiscountRatio3.Text = "";
            Txt_CheckPrice2.Text = "";
        }

         protected void Btn_Delete_Click(object sender, EventArgs e)
        {


            if (DDL_Medical_Name2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار الجهة الطبية";
                return;
            }

            if (DDL_Main_Company2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار الشركة الرئيسية";
                return;
            }
            if (DDL_Specialization2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار التخصص";
                return;
            }

            if (DDL_ProcedureDesc2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار الإجراء";
                return;
            }

          

            Cls_Medical_Types_Check Medical_Types_Check = new Cls_Medical_Types_Check();

            

            string Result;


            Medical_Types_Check._MedicalType_ID = long.Parse(DDL_Medical_Name2.SelectedValue);
            Medical_Types_Check._Main_Company = long.Parse(DDL_Main_Company2.SelectedValue);
            Medical_Types_Check._Sub_Company = long.Parse(DDL_Sub_Company2.SelectedValue);
            Medical_Types_Check._ProcedureDesc = int.Parse(DDL_ProcedureDesc2.SelectedValue);


            Result = Medical_Types_Check.Delete_Medical_Types_Check();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "حذف إعدادات الجهة الطبية للتدقيق : " + DDL_Medical_Name.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;


            try
            {
                GV.DataSource = Cls_Medical_Types_Check.Get_Procedures(long.Parse(DDL_Medical_Name2.SelectedValue), int.Parse(DDL_Specialization2.SelectedValue), long.Parse(DDL_Main_Company2.SelectedValue), long.Parse(DDL_Sub_Company2.SelectedValue));
                GV.DataBind();
                Lbl_Medical_Name.Text = DDL_Medical_Name2.SelectedItem.Text;
                Lbl_Main_Company.Text = DDL_Main_Company2.SelectedItem.Text;
                Lbl_Sub_Company.Text = DDL_Sub_Company2.SelectedItem.Text;
                Lbl_Specialization.Text = DDL_Specialization2.SelectedItem.Text;
            }
            catch (Exception)
            {


            }

            DDL_ProcedureDesc2.SelectedValue = "0";
            Txt_CheckPrice2.Text = "";
            Txt_DiscountRatio2.Text = "";
            Txt_DiscountRatio3.Text = "";
            Txt_TransactionPrice2.Text = "";
        }


        public void Get_Medical_Types_Check()
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
                cmd.Parameters.AddWithValue("@MedicalType_ID", long.Parse(DDL_Medical_Name2.SelectedValue));
                cmd.Parameters.AddWithValue("@ProcedureDesc", int.Parse(DDL_ProcedureDesc2.SelectedValue));
                cmd.Parameters.AddWithValue("@Main_Company", long.Parse(DDL_Main_Company2.SelectedValue));
                try
                {
                    cmd.Parameters.AddWithValue("@Sub_Company", long.Parse(DDL_Sub_Company2.SelectedValue));
                }
                catch (Exception)
                {
                    cmd.Parameters.AddWithValue("@Sub_Company", 0);
                }
                


                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
               
                while (dr.Read())
                {

                    Txt_CheckPrice2.Text = dr.GetValue(dr.GetOrdinal("CheckPrice")).ToString();
                    Txt_DiscountRatio2.Text = dr.GetValue(dr.GetOrdinal("DiscountRatio")).ToString();
                    Txt_DiscountRatio3.Text = dr.GetValue(dr.GetOrdinal("DiscountRatio2")).ToString();
                    Txt_TransactionPrice2.Text = dr.GetValue(dr.GetOrdinal("TransactionPrice")).ToString();                    

                }

                Cls_Connection.close_connection();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        protected void DDL_ProcedureDesc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Medical_Types_Check();
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


        public int Get_DoctorSpecializationByID2()
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

                cmd.Parameters.AddWithValue("@UName", long.Parse(DDL_Medical_Name2.SelectedValue));
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


    }


}