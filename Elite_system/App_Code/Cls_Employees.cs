using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class Cls_Employees
{

    #region Fields

    private int ID;
    private string Employee_Name;

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

    public string _Employee_Name
    {
        get
        {
            return Employee_Name;
        }
        set
        {
            Employee_Name = value;
        }
    }




    #endregion


    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Employees()
    {

    }

    public string Insert_Employees()
    {
        try
        {
            
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Employees";
            cmd.Parameters.AddWithValue("@Employee_Name", Employee_Name);            
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

    public string Update_Employees()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Employees";
            cmd.Parameters.AddWithValue("@Employee_Name", Employee_Name);
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

    public string Delete_Employees()
    {
        try
        {
            
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Employees";
            cmd.Parameters.AddWithValue("@Employee_Name", Employee_Name);
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


    static public DataTable Get_Employee()
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
            cmd.CommandText = "Get_Employee";
        
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