using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class Cls_Users
{

    #region Fields

    private int ID;
    private string UserName;
    private string Password;
    
    #endregion


    #region Properties

    public int _ID
    {
        get { return ID; }
        set { ID = value; }
    }
    
    public string _UserName
    {
        get { return UserName; }
        set { UserName = value; }
    }

    public string _Password
    {
        get { return Password; }
        set { Password = value; }
    }

    

    #endregion


    #region Methods

    public Cls_Connection Cls_Connection = new Cls_Connection();

    public string Create_User()
    {
        string result;
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Users";
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);            
            cmd.Parameters.AddWithValue("@check", "i");
            Cls_Connection.open_connection();
            cmd.ExecuteNonQuery();
            result = "تمت الاضافة بنجاح";
            Cls_Connection.close_connection();
            return result;

        }
        catch (Exception ex)
        {
            result= ex.Message.ToString();
            Cls_Connection.close_connection();
            result = "حدث خطأ في اضافة المستخدم";
            return result;

        }
    }


    public string Delete_User()
    {
        string result;
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Users";
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@password", Password);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@chek", "d");
            Cls_Connection.open_connection();
            cmd.ExecuteNonQuery();
            result = "تم الحذف بنجاح";
            Cls_Connection.close_connection();
            return result;

        }
        catch (Exception)
        {
            Cls_Connection.close_connection();
            result = "حدث خطأ في حذف المستخدم";
            return result;

        }
    }

    public string Change_UserName()
    {
        string result;
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Users";
            cmd.Parameters.AddWithValue("@username", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@chek", "u");
            Cls_Connection.open_connection();
            cmd.ExecuteNonQuery();
            result = "تم تعديل اسم المستخدم بنجاح";
            Cls_Connection.close_connection();
            return result;

        }
        catch (Exception)
        {
            Cls_Connection.close_connection();
            result = "حدث خطأ في تعديل اسم المستخدم";
            return result;

        }
    }

    public string Change_Password()
    {
        string result;
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Users";
            cmd.Parameters.AddWithValue("@username", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Check", "u");
            Cls_Connection.open_connection();
            cmd.ExecuteNonQuery();
            result = "تم تعديل كلمة المرور بنجاح";
            Cls_Connection.close_connection();
            return result;

        }
        catch (Exception ex)
        {
            result = ex.Message.ToString();
            Cls_Connection.close_connection();
            result = "حدث خطأ في تعديل كلمة المرور";
            return result;

        }
    }


    public Boolean Check_User()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Check_User";
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            Cls_Connection.open_connection();

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            Cls_Connection.close_connection();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            { return false; }


        }
        catch (Exception)
        {
            Cls_Connection.close_connection();
            return false;

        }
    }

    public string ReturnIdUser()
    {

        try
        {
            SqlConnection con = new SqlConnection();            
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Check_User";
            cmd.Parameters.AddWithValue("@User_name", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            Cls_Connection.open_connection();

            string result = cmd.ExecuteScalar().ToString();
            Cls_Connection.close_connection();
            if (result != null)
            {
                return result;
            }
            else
            { return null; }


        }
        catch (Exception)
        {
            Cls_Connection.close_connection();
            return "0";

        }


    }

    static public DataTable Get_Users()
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
            cmd.CommandText = "Get_Users";

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


