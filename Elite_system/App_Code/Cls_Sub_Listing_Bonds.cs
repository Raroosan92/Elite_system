using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// سندات القيد الفرعية
public class Cls_Sub_Listing_Bonds // سندات القيد الفرعية
{
    #region Fields

    private Int64 ID;
    private string Trans;
    private string Debtor; // مدين
    private string Creditor; //دائن
    private string Acounting_No;
    private string Accounting_Name;
    private string Statement;
    private Int64 Main_Listing_Bond_id;


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
    public string _Trans
    {
        get
        {
            return Trans;
        }
        set
        {
            Trans = value;
        }
    }
    public string _Debtor
    {
        get
        {
            return Debtor;
        }
        set
        {
            Debtor = value;
        }
    }
    public string _Creditor
    {
        get
        {
            return Creditor;
        }
        set
        {
            Creditor = value;
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
    public string _Accounting_Name
    {
        get
        {
            return Accounting_Name;
        }
        set
        {
            Accounting_Name = value;
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

    public Int64 _Main_Listing_Bond_id
    {
        get
        {
            return Main_Listing_Bond_id;
        }
        set
        {
            Main_Listing_Bond_id = value;
        }
    }


    #endregion

    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Sub_Listing_Bonds()
    {

    }

    public string Insert_Sub_Listing_Bonds()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Listing_Bonds";
            cmd.Parameters.AddWithValue("@Trans", Trans);
            cmd.Parameters.AddWithValue("@Debtor", Debtor);
            cmd.Parameters.AddWithValue("@Creditor", Creditor);
            cmd.Parameters.AddWithValue("@Acounting_No", Acounting_No);
            cmd.Parameters.AddWithValue("@Accounting_Name", Accounting_Name);
            cmd.Parameters.AddWithValue("@Statement", Statement);
            cmd.Parameters.AddWithValue("@Main_Listing_Bond_id", Main_Listing_Bond_id);
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
            result = "حدث خطأ في الإضافة او ان رقم السند مدخل مسبقا";
            return result;

        }

    }

    public string Update_Sub_Listing_Bonds()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Listing_Bonds";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Trans", Trans);
            cmd.Parameters.AddWithValue("@Debtor", Debtor);
            cmd.Parameters.AddWithValue("@Creditor", Creditor);
            cmd.Parameters.AddWithValue("@Acounting_No", Acounting_No);
            cmd.Parameters.AddWithValue("@Accounting_Name", Accounting_Name);
            cmd.Parameters.AddWithValue("@Statement", Statement);
            cmd.Parameters.AddWithValue("@Main_Listing_Bond_id", Main_Listing_Bond_id);
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
            result = "حدث خطأ في التعديل او ان رقم السند مدخل مسبقا";
            return result;

        }

    }

    public string Delete_Sub_Listing_Bonds()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Listing_Bonds";
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