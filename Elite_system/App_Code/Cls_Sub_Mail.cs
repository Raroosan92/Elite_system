using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// البريد الفرعي

public class Cls_Sub_Mail
{
    #region Fields

    private Int64 ID;
    private Int64  Sent_To;
    private DateTime Received_Date;
    private int Mail_Type;
    private int Mails_Count;
    private string Notes;
    private Int64 Main_Mail_ID;
    private Boolean Delivered;
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
    public Int64 _Sent_To
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
    public DateTime _Received_Date
    {
        get
        {
            return Received_Date;
        }
        set
        {
            Received_Date = value;
        }
    }
    public int _Mail_Type
    {
        get
        {
            return Mail_Type;
        }
        set
        {
            Mail_Type = value;
        }
    }
    public int _Mails_Count
    {
        get
        {
            return Mails_Count;
        }
        set
        {
            Mails_Count = value;
        }
    }
    public string _Notes
    {
        get
        {
            return Notes;
        }
        set
        {
            Notes = value;
        }
    }
    public Int64 _Main_Mail_ID
    {
        get
        {
            return Main_Mail_ID;
        }
        set
        {
            Main_Mail_ID = value;
        }
    }

    public Boolean _Delivered
    {
        get
        {
            return Delivered;
        }
        set
        {
            Delivered = value;
        }
    }

    #endregion

    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Sub_Mail()
    {

    }

    public string Insert_Sub_Mail()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Mail";
            if (Sent_To != 0)
            {
                cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            }

            if (Received_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Received_Date", Received_Date);
            }

            
            if (Mail_Type != 0)
            {
                cmd.Parameters.AddWithValue("@Mail_Type", Mail_Type);
            }
            
            cmd.Parameters.AddWithValue("@Mails_Count", Mails_Count);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@Main_Mail_ID", Main_Mail_ID);
            cmd.Parameters.AddWithValue("@Delivered", Delivered);
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

    public string Update_Sub_Mail()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Mail";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            cmd.Parameters.AddWithValue("@Received_Date", Received_Date);
            cmd.Parameters.AddWithValue("@Mail_Type", Mail_Type);
            cmd.Parameters.AddWithValue("@Mails_Count", Mails_Count);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@Main_Mail_ID", Main_Mail_ID);
            cmd.Parameters.AddWithValue("@Delivered", Delivered);
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

    public string Delete_Sub_Mail()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Mail";
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

    #endregion
}