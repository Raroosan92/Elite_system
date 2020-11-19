using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// سندات القبض الرئيسية
public class Cls_Main_Receipt 
{

    #region Fields

    private Int64 MainID;
    private string Sent_To;
    private Int64 Name;
    private string Acounting_No;
    private Int64 SubID;
    private DateTime Receipt_Date;
    private double Value;
    private string Statement;
    #endregion


    #region Properties

    public Int64 _MainID
    {
        get
        {
            return MainID;
        }
        set
        {
            MainID = value;
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
    public Int64 _Name
    {
        get
        {
            return Name;
        }
        set
        {
            Name = value;
        }
    }
    public string _Acounting_No
    {
        get
        {
            return Acounting_No;
        }
        set
        {
            Acounting_No = value;
        }
    }
    public Int64 _SubID
    {
        get
        {
            return SubID;
        }
        set
        {
            SubID = value;
        }
    }
    public DateTime _Receipt_Date
    {
        get
        {
            return Receipt_Date;
        }
        set
        {
            Receipt_Date = value;
        }
    }
    public double _Value
    {
        get
        {
            return Value;
        }
        set
        {
            Value = value;
        }
    }
    public string _Statement
    {
        get
        {
            return Statement;
        }
        set
        {
            Statement = value;
        }
    }
    #endregion


    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Main_Receipt()
    {

    }

    public string Insert_Main_Receipt()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Receipt";
                                        
            cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Acounting_No", Acounting_No);
            cmd.Parameters.AddWithValue("@SubID", SubID);
            cmd.Parameters.AddWithValue("@Receipt_Date", Receipt_Date);
            cmd.Parameters.AddWithValue("@Value", Value);
            cmd.Parameters.AddWithValue("@Statement", Statement);

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
            result = "حدث خطأ في الإضافة";
            return result;

        }

    }

    public string Update_Main_Receipt()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Receipt";

            cmd.Parameters.AddWithValue("@MainID", MainID);
            cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Acounting_No", Acounting_No);
            cmd.Parameters.AddWithValue("@SubID", SubID);
            cmd.Parameters.AddWithValue("@Receipt_Date", Receipt_Date);
            cmd.Parameters.AddWithValue("@Value", Value);
            cmd.Parameters.AddWithValue("@Statement", Statement);
            cmd.Parameters.AddWithValue("@check", "u");

            Cls_Connection.open_connection();
            cmd.ExecuteNonQuery();
            result = "تم التعديل بنجاح";
            Cls_Connection.close_connection();
            return result;

        }
        catch (Exception ex)
        {
            result = ex.Message.ToString();
            Cls_Connection.close_connection();
            result = "حدث خطأ في التعديل";
            return result;

        }

    }

    public string Delete_Main_Receipt()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Receipt";
            cmd.Parameters.AddWithValue("@MainID", MainID);
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