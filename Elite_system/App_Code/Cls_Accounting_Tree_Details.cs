using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Elite_system
{
    public class Cls_Accounting_Tree_Details
    {
        #region Fields

        private int ID;
        private Int64 Medical_Types_ID;
        private string Medical_Types;
        private string Main_Account;
        private string Account_Level;
        private string Sub_Account;
        private int Account_ID;

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

        public Int64 _Medical_Types_ID
        {
            get
            {
                return Medical_Types_ID;
            }
            set
            {
                Medical_Types_ID = value;
            }
        }

        public string _Medical_Types
        {
            get
            {
                return Medical_Types;
            }
            set
            {
                Medical_Types = value;
            }
        }
        public string _Main_Account
        {
            get
            {
                return Main_Account;
            }
            set
            {
                Main_Account = value;
            }
        }

        public string _Account_Level
        {
            get
            {
                return Account_Level;
            }
            set
            {
                Account_Level = value;
            }
        }

        public string _Sub_Account
        {
            get
            {
                return Sub_Account;
            }
            set
            {
                Sub_Account = value;
            }
        }
        public int _Account_ID
        {
            get
            {
                return Account_ID;
            }
            set
            {
                Account_ID = value;
            }
        }


        #endregion

        #region Methods

        public Cls_Connection Cls_Connection = new Cls_Connection();
        string result;
        public string Insert_Accounting_Tree_Details()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Account_Tree_Details";
                cmd.Parameters.AddWithValue("@Medical_Types_ID", Medical_Types_ID);
                cmd.Parameters.AddWithValue("@Medical_Types", Medical_Types);
                cmd.Parameters.AddWithValue("@Main_Account", Main_Account);
                cmd.Parameters.AddWithValue("@Account_Level", Account_Level);
                cmd.Parameters.AddWithValue("@Sub_Account", Sub_Account);
                cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
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

        public string Update_Accounting_Tree_Details()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Account_Tree_Details";
                cmd.Parameters.AddWithValue("@Medical_Types_ID", Medical_Types_ID);
                cmd.Parameters.AddWithValue("@Medical_Types", Medical_Types);
                cmd.Parameters.AddWithValue("@Main_Account", Main_Account);
                cmd.Parameters.AddWithValue("@Account_Level", Account_Level);
                cmd.Parameters.AddWithValue("@Sub_Account", Sub_Account);
                cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
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

        public string Delete_Accounting_Tree_Details()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Account_Tree_Details";
                cmd.Parameters.AddWithValue("@Medical_Types_ID", Medical_Types_ID);
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


      


        #endregion

    }
}