using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Elite_system.App_Code
{
    public class Cls_Medical_Types_Check
    {

        #region Fields

        private int ID;
        private Int64 MedicalType_ID;
        private Int64 Main_Company;
        private Int64 Sub_Company;
        private int Specialization;
        private int ProcedureDesc;
        private decimal TransactionPrice;
        private decimal CheckPrice;
        private decimal DiscountRatio;
        private decimal DiscountRatio2;

        #endregion

        #region Properties

        public int _ID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public Int64 _MedicalType_ID
        {
            get
            {
                return MedicalType_ID;
            }
            set
            {
                MedicalType_ID = value;
            }
        }

        public Int64 _Main_Company
        {
            get
            {
                return Main_Company;
            }
            set
            {
                Main_Company = value;
            }
        }

        public Int64 _Sub_Company
        {
            get
            {
                return Sub_Company;
            }
            set
            {
                Sub_Company = value;
            }
        }

        public int _Specialization
        {
            get
            {
                return Specialization;
            }
            set
            {
                Specialization = value;
            }
        }

        public int _ProcedureDesc
        {
            get
            {
                return ProcedureDesc;
            }
            set
            {
                ProcedureDesc = value;
            }
        }

        public decimal _TransactionPrice
        {
            get
            {
                return TransactionPrice;
            }
            set
            {
                TransactionPrice = value;
            }
        }

        public decimal _CheckPrice
        {
            get
            {
                return CheckPrice;
            }
            set
            {
                CheckPrice = value;
            }
        }

        public decimal _DiscountRatio
        {
            get
            {
                return DiscountRatio;
            }
            set
            {
                DiscountRatio = value;
            }
        }

        public decimal _DiscountRatio2
        {
            get
            {
                return DiscountRatio2;
            }
            set
            {
                DiscountRatio2 = value;
            }
        }


        #endregion

        #region Methods

        public Cls_Connection Cls_Connection = new Cls_Connection();
        string result;
        public string Insert_Medical_Types_Check()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                if (ProcedureDesc == 0)
                {
                    cmd.CommandText = "SP_Medical_Types_Check2";
                }
                else
                {
                    cmd.CommandText = "SP_Medical_Types_Check";
                }
               

                cmd.Parameters.AddWithValue("@MedicalType_ID", MedicalType_ID);
                cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
                cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
                cmd.Parameters.AddWithValue("@ProcedureDesc", ProcedureDesc);               
                cmd.Parameters.AddWithValue("@TransactionPrice", TransactionPrice);
                cmd.Parameters.AddWithValue("@CheckPrice", CheckPrice);
                cmd.Parameters.AddWithValue("@DiscountRatio", DiscountRatio);
                cmd.Parameters.AddWithValue("@DiscountRatio2", DiscountRatio2);

                cmd.Parameters.AddWithValue("@check", "i");

                Cls_Connection.open_connection();
                cmd.ExecuteNonQuery();
                result = "تمت الإضافة بنجاح";
                Cls_Connection.close_connection();
                return result;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                result = "حدث خطأ في الإضافة";
                return result;

            }

        }

        public string Update_Medical_Types_Check()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Medical_Types_Check";
                cmd.Parameters.AddWithValue("@MedicalType_ID", MedicalType_ID);
                cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
                cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
                cmd.Parameters.AddWithValue("@ProcedureDesc", ProcedureDesc);
                cmd.Parameters.AddWithValue("@TransactionPrice", TransactionPrice);
                cmd.Parameters.AddWithValue("@CheckPrice", CheckPrice);
                cmd.Parameters.AddWithValue("@DiscountRatio", DiscountRatio);
                cmd.Parameters.AddWithValue("@DiscountRatio2", DiscountRatio2);
                cmd.Parameters.AddWithValue("@check", "u");

                Cls_Connection.open_connection();
                cmd.ExecuteNonQuery();
                result = "تم التعديل بنجاح";
                Cls_Connection.close_connection();
                return result;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                result = "حدث خطأ في التعديل";
                return result;

            }

        }

        public string Delete_Medical_Types_Check()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Medical_Types_Check";

                cmd.Parameters.AddWithValue("@MedicalType_ID", MedicalType_ID);
                cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
                cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);
                cmd.Parameters.AddWithValue("@ProcedureDesc", ProcedureDesc);

                cmd.Parameters.AddWithValue("@check", "d");

                Cls_Connection.open_connection();
                cmd.ExecuteNonQuery();
                result = "تم الحذف بنجاح";
                Cls_Connection.close_connection();
                return result;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                result = "حدث خطأ في الحذف";
                return result;

            }

        }

        public static DataTable Get_Procedures(long MedicalType_ID, int Specialization, long Main_Company, long Sub_Company)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Medical_Types_Check";
                cmd.Parameters.AddWithValue("@MedicalType_ID", MedicalType_ID);
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
                cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
                cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt);
                Cls_Connection.close_connection();
                return dt;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();

                return dt;
            }

        }

        #endregion

    }
}