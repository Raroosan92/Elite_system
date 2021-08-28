using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Elite_system.App_Code
{
    public class Cls_Spendings
    {
        #region Fields

        private Int64 ID;
        private string Description;
        private DateTime Voucher_Date;
        private DateTime Created_Datetime;
        private decimal Voucher_Value;
        private Int64 Voucher_No;
        private Int64 Invoice_No;
        private string Sent_To;
        private string Company;

        #endregion


        #region Properties

        public Int64 _ID
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
        public string _Description
        {
            get
            {
                return Description;
            }
            set
            {
                Description = value;
            }
        }
        public DateTime _Voucher_Date
        {
            get
            {
                return Voucher_Date;
            }
            set
            {
                Voucher_Date = value;
            }
        }
        public DateTime _Created_Datetime
        {
            get
            {
                return Created_Datetime;
            }
            set
            {
                Created_Datetime = value;
            }
        }
        public decimal _Voucher_Value
        {
            get
            {
                return Voucher_Value;
            }
            set
            {
                Voucher_Value = value;
            }
        }
        public Int64 _Voucher_No
        {
            get
            {
                return Voucher_No;
            }
            set
            {
                Voucher_No = value;
            }
        }
        public Int64 _Invoice_No
        {
            get
            {
                return Invoice_No;
            }
            set
            {
                Invoice_No = value;
            }
        }
        public string _Sent_To
        {
            get
            {
                return Sent_To;
            }
            set
            {
                Sent_To = value;
            }
        }
        public string _Company
        {
            get
            {
                return Company;
            }
            set
            {
                Company = value;
            }
        }
        #endregion


        #region Methods

        SqlConnection con = new SqlConnection();
        string result;


        public string Insert_Spendings()
        {
            try
            {

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Spendings";
                cmd.Parameters.AddWithValue("@Voucher_Value", Voucher_Value);
                cmd.Parameters.AddWithValue("@Voucher_No", Voucher_No);
                cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Type", 315);
                if (Company != "")
                {
                    cmd.Parameters.AddWithValue("@Company", Company);
                }
                if (Voucher_Date == DateTime.MinValue)
                {
                    //DateTime is null
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Voucher_Date", Voucher_Date);
                }
                cmd.Parameters.AddWithValue("@Created_Datetime", DateTime.Now);
                if (Sent_To != "")
                {
                    cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
                }
                cmd.Parameters.AddWithValue("@check", "i");

                Cls_Connection.open_connection();
                cmd.ExecuteNonQuery();
                result = "تمت الإضافة بنجاح";
                Cls_Connection.close_connection();
                return result;

            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
                Cls_Connection.close_connection();
                result = "يوجد خطأ في الادخال او ان رقم السند مدخل مسبقا";
                return result;

            }

        }

        public string Update_Spendings()
        {
            try
            {

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Spendings";
                cmd.Parameters.AddWithValue("@Voucher_Value", Voucher_Value);
                cmd.Parameters.AddWithValue("@Voucher_No", Voucher_No);
                cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No);
                cmd.Parameters.AddWithValue("@Description", Description);
                if (Company != "")
                {
                    cmd.Parameters.AddWithValue("@Company", Company);
                }
                if (Voucher_Date == DateTime.MinValue)
                {
                    //DateTime is null
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Voucher_Date", Voucher_Date);
                }
                cmd.Parameters.AddWithValue("@Created_Datetime", DateTime.Now);
                if (Sent_To != "")
                {
                    cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
                }
                cmd.Parameters.AddWithValue("@ID", ID);
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
                result = "حدث خطأ في التعديل او ان رقم السند مدخل مسبقا";
                return result;

            }

        }

        public string Delete_Spendings()
        {
            try
            {

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Spendings";
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@check", "D");

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
        
        public string Check_Spendings()
        {
            
            try
            {

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Spendings";
                cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No);
                cmd.Parameters.AddWithValue("@Voucher_No", Voucher_No);
                cmd.Parameters.AddWithValue("@check", "C");

                Cls_Connection.open_connection();
                result = cmd.ExecuteScalar().ToString();
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

        #endregion
    }


}