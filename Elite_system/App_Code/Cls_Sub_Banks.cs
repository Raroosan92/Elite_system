using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// البنوك الفرعية
public class Cls_Sub_Banks
{

    #region Fields

    private int ID;
    private string Sub_Bank_Name;
    private int Main_Bank_ID;

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
    public string _Sub_Bank_Name
    {
        get
        {
            return Sub_Bank_Name;
        }
        set
        {
            Sub_Bank_Name = value;
        }
    }
    public int _Main_Bank_ID
    {
        get
        {
            return Main_Bank_ID;
        }
        set
        {
            Main_Bank_ID = value;
        }
    }

    #endregion

    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Sub_Banks()
    {

    }

    public string Insert_Sub_Banks()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Banks";
            cmd.Parameters.AddWithValue("@Sub_Bank_Name", Sub_Bank_Name);
            cmd.Parameters.AddWithValue("@Main_Bank_ID", Main_Bank_ID);            

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

    public string Update_Sub_Banks()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Banks";
            cmd.Parameters.AddWithValue("@Sub_Bank_Name", Sub_Bank_Name);
            cmd.Parameters.AddWithValue("@Main_Bank_ID", Main_Bank_ID);
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

    public string Delete_Sub_Banks()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Banks";
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

    public DataTable Get_Sub_Banks(int Main_Bank_ID)
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
            cmd.CommandText = "Get_Sub_Banks";
            cmd.Parameters.AddWithValue("@Main_Bank_ID", Main_Bank_ID);
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