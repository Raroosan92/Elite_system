using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// سندات القبض الفرعية
public class Cls_Sub_Recipt
{
    #region Fields

    private Int64 ID;
    private DateTime Receipt_Date;
    private double Value;
    private string Acounting_No;
    private string Statement;
    private Int64 Main_Receipt_ID;


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
    public Int64 _Main_Receipt_ID
    {
        get
        {
            return Main_Receipt_ID;
        }
        set
        {
            Main_Receipt_ID = value;
        }
    }



    #endregion

    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Sub_Recipt()
    {

    }

    public string Insert_Sub_Recipt()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Recipt";
            if (ID != 0)
            {
                cmd.Parameters.AddWithValue("@ID", ID);
            }

            if (Receipt_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Receipt_Date", Receipt_Date);
            }

            
            if (Value != 0)
            {
                cmd.Parameters.AddWithValue("@Value", Value);
            }
            
            cmd.Parameters.AddWithValue("@Acounting_No", Acounting_No);
            cmd.Parameters.AddWithValue("@Statement", Statement);
            if (Main_Receipt_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Main_Receipt_ID", Main_Receipt_ID);
            }
           
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

    public string Update_Sub_Recipt()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Recipt";
            if (ID != 0)
            {
                cmd.Parameters.AddWithValue("@ID", ID);
            }

            if (Receipt_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Receipt_Date", Receipt_Date);
            }


            if (Value != 0)
            {
                cmd.Parameters.AddWithValue("@Value", Value);
            }

            cmd.Parameters.AddWithValue("@Acounting_No", Acounting_No);
            cmd.Parameters.AddWithValue("@Statement", Statement);
            if (Main_Receipt_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Main_Receipt_ID", Main_Receipt_ID);
            }
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

    public string Delete_Sub_Recipt()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Recipt";
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