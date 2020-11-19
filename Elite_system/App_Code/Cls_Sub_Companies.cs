using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// الشركات الفرعية
public class Cls_Sub_Companies
{
    #region Fields

    private Int64 ID;
    private string Sub_Company;
    private Int64 Main_Company;


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
    public string _Sub_Company
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


    #endregion

    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Sub_Companies()
    {

    }

    public string Insert_Sub_Companies()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Companies";
            cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);
            cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
          
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

    public string Update_Sub_Companies()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Companies";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);
            cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
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

    public string Delete_Sub_Companies()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Companies";
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


    public DataTable Get_Sub_Companies()
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
            cmd.CommandText = "Get_Sub_Companies";
            cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
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