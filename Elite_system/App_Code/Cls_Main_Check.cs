using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// الشيكات الرئيسية
public class Cls_Main_Check
{
    #region Fields

    private Int64 ID;
    private Int64 Company;
    private DateTime Check_Date;
    private DateTime Entry_Date;
    private DateTime Received_Date;
    private DateTime Delivery_Date;
    private int Main_Bank;
    private int Sub_Bank;
    private Int64 Sent_To;
    private double Value;
    private string Check_No;
    private string Months;
    private string Notes;
    private Boolean Delivered;
    private string EmployeeName;
    private Boolean Refunded;
    private string BarCode;
    private byte[] BarCode_Image;

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
    public int _Main_Bank
    {
        get
        {
            return Main_Bank;
        }
        set
        {
            Main_Bank = value;
        }
    }
    public int _Sub_Bank
    {
        get
        {
            return Sub_Bank;
        }
        set
        {
            Sub_Bank = value;
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
    public string _EmployeeName
    {
        get
        {
            return EmployeeName;
        }
        set
        {
            EmployeeName = value;
        }
    }
    public string _BarCode
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

    public byte[] _BarCode_Image
    {
        get
        {
            return BarCode_Image;
        }
        set
        {
            BarCode_Image = value;
        }
    }

    #endregion


    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Main_Check()
    {

    }

    public string Insert_Main_Check()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Check";
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

            if (Check_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Check_Date", Check_Date);
            }

            if (Main_Bank != 0)
            {
                cmd.Parameters.AddWithValue("@Main_Bank", Main_Bank);
            }

            if (Sub_Bank != 0)
            {
                cmd.Parameters.AddWithValue("@Sub_Bank", Sub_Bank);
            }

            if (Sent_To != 0)
            {
                cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            }

            if (Value != 0)
            {
                cmd.Parameters.AddWithValue("@Value", Value);
            }

            cmd.Parameters.AddWithValue("@Check_No", Check_No);
            cmd.Parameters.AddWithValue("@Months", Months);
            cmd.Parameters.AddWithValue("@Notes", Notes);

            cmd.Parameters.AddWithValue("@Delivered", Delivered);
            cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmd.Parameters.AddWithValue("@Refunded", Refunded);
            cmd.Parameters.AddWithValue("@BarCode", BarCode);
            cmd.Parameters.AddWithValue("@BarCode_Image", BarCode_Image);
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

    public string Update_Main_Check()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Check";
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

            if (Check_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Check_Date", Check_Date);
            }

            if (Main_Bank != 0)
            {
                cmd.Parameters.AddWithValue("@Main_Bank", Main_Bank);
            }

            if (Sub_Bank != 0)
            {
                cmd.Parameters.AddWithValue("@Sub_Bank", Sub_Bank);
            }
            cmd.Parameters.AddWithValue("@ID", ID);

            if (Sent_To != 0)
            {
                cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            }

            if (Value != 0)
            {
                cmd.Parameters.AddWithValue("@Value", Value);
            }

            cmd.Parameters.AddWithValue("@Check_No", Check_No);
            cmd.Parameters.AddWithValue("@Months", Months);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@BarCode", BarCode);
            cmd.Parameters.AddWithValue("@Delivered", Delivered);
            cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmd.Parameters.AddWithValue("@Refunded", Refunded);
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

    public string Delete_Main_Check()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Check";
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


    public static string Get_Max_Main_Check()
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
            cmd.CommandText = "Get_Max_Main_Check";

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


    public string Check_Main_Checks()
    {
        string num = "";
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Check_Main_Checks";
            cmd.Parameters.AddWithValue("@CheckNum",Check_No);
            cmd.Parameters.AddWithValue("@value",Value);
            Cls_Connection.open_connection();

            num = cmd.ExecuteReader().HasRows.ToString();

            Cls_Connection.close_connection();
            return num;

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            Cls_Connection.close_connection();
            return num;


        }

    }

    #endregion

}