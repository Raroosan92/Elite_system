using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Elite_system
{
    public class Cls_Codes
    {
        #region Fields

        private int ID;
        private string Description;
        private int Parent;

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

        public int _Parent
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value;
            }
        }


        #endregion

        #region Methods

        public Cls_Connection Cls_Connection = new Cls_Connection();
        string result;
        public string Insert_Codes()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Codes";
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Parent", Parent);
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

        public string Update_Codes()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Codes";
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Parent", Parent);
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
                result = "حدث خطأ في التعديل";
                return result;

            }

        }

        public string Delete_Codes()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Codes";
                cmd.Parameters.AddWithValue("@ID", ID);
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


        public static DataTable Fill_DDL(int Parent)
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
                cmd.CommandText = "SP_Select_Codes";
                cmd.Parameters.AddWithValue("@Parent", Parent);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt);
                Cls_Connection.close_connection();
                return dt;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                return dt;


            }

        }


        public static DataTable Fill_Specialization(long id)
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
                cmd.CommandText = "SP_Select_Specialization";
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt);
                Cls_Connection.close_connection();
                return dt;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                return dt;


            }

        }


        static public DataTable Get_Codes()
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
                cmd.CommandText = "Get_Codes";

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt);
                Cls_Connection.close_connection();
                return dt;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                return dt;


            }

        }

        static public DataTable Get_SubCodes(int Parent)
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
                cmd.CommandText = "Get_SubCodes";
                cmd.Parameters.AddWithValue("@Parent", Parent);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt);
                Cls_Connection.close_connection();
                return dt;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                return dt;


            }

        }

        #endregion

    }
}