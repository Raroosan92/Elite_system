
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Elite_system
{
    public class Cls_ChecksLog
    {
        #region Fields
        private string Log_Event;
        private DateTime Log_Date;
        private long ID;
        private string Check_Number;
        private int Check_Type;
        private string Check_EmpName;
        private string Check_MedicalName;
        private string Check_Company;
        private string Check_Barcode;
        private DateTime Check_CurrentDate;
        private DateTime Check_Date;

        #endregion

        #region Properties

        public long _ID
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
        public string _Check_Number
        {
            get
            {
                return Check_Number;
            }
            set
            {
                Check_Number = value;
            }
        }
        public int _Check_Type
        {
            get
            {
                return Check_Type;
            }
            set
            {
                Check_Type = value;
            }
        }
        public string _Check_EmpName
        {
            get
            {
                return Check_EmpName;
            }
            set
            {
                Check_EmpName = value;
            }
        }
        public string _Check_MedicalName
        {
            get
            {
                return Check_MedicalName;
            }
            set
            {
                Check_MedicalName = value;
            }
        }
        public string _Check_Company
        {
            get
            {
                return Check_Company;
            }
            set
            {
                Check_Company = value;
            }
        }
        public string _Check_Barcode
        {
            get
            {
                return Check_Barcode;
            }
            set
            {
                Check_Barcode = value;
            }
        }
        public DateTime _Check_CurrentDate
        {
            get
            {
                return Check_CurrentDate;
            }
            set
            {
                Check_CurrentDate = value;
            }
        }
        public DateTime _Check_Date
        {
            get
            {
                return Check_Date;
            }
            set
            {
                Check_Date = value;
            }
        }


        #endregion

        #region Methods

        public Cls_Connection Cls_Connection = new Cls_Connection();
        string result;
        public string Insert_Log()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Check_Logs";
                string UserName = HttpContext.Current.Request.Cookies["UserName"].Value.ToString();
                cmd.Parameters.AddWithValue("@Check_Number", Check_Number);
                cmd.Parameters.AddWithValue("@Check_Uname", UserName);
                cmd.Parameters.AddWithValue("@Check_Type", Check_Type);
                cmd.Parameters.AddWithValue("@Check_EmpName", Check_EmpName);
                cmd.Parameters.AddWithValue("@Check_MedicalName", Check_MedicalName);
                cmd.Parameters.AddWithValue("@Check_Company", Check_Company);
                cmd.Parameters.AddWithValue("@Check_Barcode", Check_Barcode);
                cmd.Parameters.AddWithValue("@Check_CurrentDate", DateTime.UtcNow.AddHours(3).ToString("yyyy-MM-dd  h:mm tt"));
                cmd.Parameters.AddWithValue("@Check_Date", Check_Date);
                cmd.Parameters.AddWithValue("@Check", 'I');


                Cls_Connection.open_connection();
                cmd.ExecuteNonQuery();
                result = "تمت الإضافة بنجاح";
               // Cls_Connection.close_connection();
                return result;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                result = "حدث خطأ في الإضافة";
                return result;

            }

        }


        #endregion
    }
}