using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Elite_system.App_Code
{
    public class Cls_Procedures
    {

        #region Fields

        private int ID;
        private int Specialization;
        private string ProcedureDesc;
        private decimal Points;
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

        public string _ProcedureDesc
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

        public decimal _Points
        {
            get
            {
                return Points;
            }
            set
            {
                Points = value;
            }
        }


        #endregion

        #region Methods

        public Cls_Connection Cls_Connection = new Cls_Connection();
        string result;
        public string Insert_Procedure()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Procedures";
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
                cmd.Parameters.AddWithValue("@ProcedureDesc", ProcedureDesc);
                cmd.Parameters.AddWithValue("@Points", Points);
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

        public string Update_Procedure()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Procedures";
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
                cmd.Parameters.AddWithValue("@ProcedureDesc", ProcedureDesc);
                cmd.Parameters.AddWithValue("@Points", Points);
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

        public string Delete_Procedure()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Procedures";
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

        static public DataTable Get_Procedures(int Specialization)
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
                cmd.CommandText = "Get_Procedures";
                cmd.Parameters.AddWithValue("@Specialization", Specialization);

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