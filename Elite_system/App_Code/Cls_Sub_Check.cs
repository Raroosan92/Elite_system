using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// الشيكات الفرعية
public class Cls_Sub_Check
{
    #region Fields

    private Int64 ID;
    private Int64 Sent_To;
    private double Value;
    private string Check_No;
    private DateTime Check_Date;
    private string Months;
    private string Notes;
    private Int64 Main_Check_ID;
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
    public string _Check_No
    {
        get
        {
            return Check_No;
        }
        set
        {
            Check_No = value;
        }
    }
    public DateTime _Check_Date
    {
        get
        {
            return Check_Date;
        }
        set
        {
            Check_Date = value;
        }
    }
    public string _Months
    {
        get
        {
            return Months;
        }
        set
        {
            Months = value;
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
    public Int64 _Main_Check_ID
    {
        get
        {
            return Main_Check_ID;
        }
        set
        {
            Main_Check_ID = value;
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
    public Cls_Sub_Check()
    {

    }

    public string Insert_Sub_Check()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Check";
            if (Sent_To != 0)
            {
                cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            }

            if (Value != 0)
            {
                cmd.Parameters.AddWithValue("@Value", Value);
            }

            if (Check_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Check_Date", Check_Date);
            }

            cmd.Parameters.AddWithValue("@Check_No", Check_No);
            cmd.Parameters.AddWithValue("@Months", Months);
            cmd.Parameters.AddWithValue("@Notes", Notes);

            if (Main_Check_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Main_Check_ID", Main_Check_ID);
            }

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

    public string Update_Sub_Check()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Check";
            if (Sent_To != 0)
            {
                cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            }

            if (Value != 0)
            {
                cmd.Parameters.AddWithValue("@Value", Value);
            }

            if (Check_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Check_Date", Check_Date);
            }

            cmd.Parameters.AddWithValue("@Check_No", Check_No);
            cmd.Parameters.AddWithValue("@Months", Months);
            cmd.Parameters.AddWithValue("@Notes", Notes);

            if (Main_Check_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Main_Check_ID", Main_Check_ID);
            }

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@check", "u");
            cmd.Parameters.AddWithValue("@Delivered", Delivered);

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

    public string Delete_Sub_Check()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Check";
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