using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//البريد الرئيسي 
public class Cls_Main_Mail
{

    #region Fields

    private Int64 ID;
    private Int64 Company;
    private DateTime Entry_Date;
    private DateTime Received_Date;
    private DateTime Delivery_Date;
    private Int64 Sent_To;
    private int Mail_Type;
    private int Mails_Count;
    private string Notes;
    private Boolean Delivered;
    private string BarCode;
    private Boolean Refunded;
    private DateTime modified;


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
    public Int64 _Company
    {
        get
        {
            return Company;
        }
        set
        {
            Company = value;
        }
    }
    public DateTime _Entry_Date
    {
        get
        {
            return Entry_Date;
        }
        set
        {
            Entry_Date = value;
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
    public DateTime _Delivery_Date
    {
        get
        {
            return Delivery_Date;
        }
        set
        {
            Delivery_Date = value;
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

    public string _Barcode
    {
        get
        {
            return BarCode;
        }
        set
        {
            BarCode = value;
        }
    }

    public Boolean _Refunded
    {
        get
        {
            return Refunded;
        }
        set
        {
            Refunded = value;
        }
    }



    public DateTime _modified
    {
        get
        {
            return modified;
        }
        set
        {
            modified = value;
        }
    }


    #endregion


    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Main_Mail()
    {

    }

    public string Insert_Main_Mail()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Mail";
            if (Company != 0)
            {
                cmd.Parameters.AddWithValue("@Company", Company);
            }

            if (Entry_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Entry_Date", Entry_Date);
            }

            if (Received_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Received_Date", Received_Date);
            }

            if (Delivery_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Delivery_Date", Delivery_Date);
            }

            if (Sent_To != 0)
            {
                cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            }



            if (Mail_Type != 0)
            {
                cmd.Parameters.AddWithValue("@Mail_Type", Mail_Type);
            }

            cmd.Parameters.AddWithValue("@Mails_Count", Mails_Count);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@Delivered", Delivered);

            cmd.Parameters.AddWithValue("@Refunded", Refunded);
            cmd.Parameters.AddWithValue("@BarCode", BarCode);



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

    public string Update_Main_Mail()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Mail";
            cmd.Parameters.AddWithValue("@Company", Company);
            cmd.Parameters.AddWithValue("@Entry_Date", Entry_Date);
            cmd.Parameters.AddWithValue("@Received_Date", Received_Date);
            cmd.Parameters.AddWithValue("@Delivery_Date", Delivery_Date);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            cmd.Parameters.AddWithValue("@Mail_Type", Mail_Type);
            cmd.Parameters.AddWithValue("@Mails_Count", Mails_Count);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@Delivered", Delivered);
            cmd.Parameters.AddWithValue("@Refunded", Refunded);
            cmd.Parameters.AddWithValue("@BarCode", BarCode);
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

    public string Delete_Main_Mail()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Mail";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@check", "d");

            Cls_Connection.open_connection();
            cmd.ExecuteNonQuery();
            result = "تم الحذف بنجاح";
            Cls_Connection.close_connection();
            return result;

        }
        catch (Exception ex)
        {
            Cls_Connection.close_connection();
            result = ex.Message.ToString();
            result = "حدث خطأ في الحذف";
            return result;

        }

    }


    public static string Get_Max_Main_Mail()
    {
        string max = "";
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Max_Main_Mail";

            Cls_Connection.open_connection();

            max = cmd.ExecuteScalar().ToString();

            Cls_Connection.close_connection();
            return max;

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            Cls_Connection.close_connection();
            return max;


        }

    }

    #endregion

}