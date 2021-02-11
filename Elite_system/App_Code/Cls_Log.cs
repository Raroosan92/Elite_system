using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Elite_system
{
    public class Cls_Log
    {

        #region Fields

        private long ID;
        private string Log_UserName;
        private string Log_Event;
        private DateTime Log_Date;

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

        public string _Log_UserName
        {
            get
            {
                return Log_UserName;
            }
            set
            {
                Log_UserName = value;
            }
        }

        public string _Log_Event
        {
            get
            {
                return Log_Event;
            }
            set
            {
                Log_Event = value;
            }
        }

        public DateTime _Log_Date
        {
            get
            {
                return Log_Date;
            }
            set
            {
                Log_Date = value;
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
                cmd.CommandText = "SP_Log";
                string UserName = HttpContext.Current.Request.Cookies["UserName"].Value.ToString();
                cmd.Parameters.AddWithValue("@Log_UserName", UserName);
                cmd.Parameters.AddWithValue("@Log_Event", Log_Event);
                cmd.Parameters.AddWithValue("@Log_Date", DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd"));

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


        #endregion
    }
}