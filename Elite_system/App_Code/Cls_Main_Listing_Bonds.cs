using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


// سندات القيد الرئيسية
public class Cls_Main_Listing_Bonds // سندات القيد الرئيسية
{

    #region Fields

    private Int64 ID;
    private Int64 Company;
    private int Type;
    private DateTime Bond_Date;

    //rami roosan
    private decimal Debtor;
    private Int64 Claim_ID;
    private decimal Creditor;
    private string Description;
    private string Acounting_NO;
    //rami roosan

    private string Sent_To;

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
    public int _Type
    {
        get
        {
            return Type;
        }
        set
        {
            Type = value;
        }
    }
    public DateTime _Bond_Date
    {
        get
        {
            return Bond_Date;
        }
        set
        {
            Bond_Date = value;
        }
    }

    //rami roosan
    public decimal _Debtor
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
    public Int64 _Claim_ID
    {
        get
        {
            return Claim_ID;
        }
        set
        {
            Claim_ID = value;
        }
    }
    public decimal _Creditor
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
    public string _Description
    {
        get
        {
            return Description;
        }
        set
        {
            Description = value;
        }
    }
    public string _Acounting_NO
    {
        get
        {
            return Acounting_NO;
        }
        set
        {
            Acounting_NO = value;
        }
    }
    //rami roosan

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
    #endregion


    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Main_Listing_Bonds()
    {

    }

    public string Insert_Main_Listing_Bonds()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Listing_Bonds";

            //rami roosan

            cmd.Parameters.AddWithValue("@Debtor", Debtor);
            cmd.Parameters.AddWithValue("@Creditor", Creditor);
            cmd.Parameters.AddWithValue("@Claim_ID", Claim_ID);
            cmd.Parameters.AddWithValue("@Acounting_NO", Acounting_NO);


            if (Description != "")
            {
                cmd.Parameters.AddWithValue("@Description", Description);
            }
            //rami roosan
            if (Company != 0)
            {
                cmd.Parameters.AddWithValue("@Company", Company);
            }

            if (Type != 0)
            {
                cmd.Parameters.AddWithValue("@Type", Type);
            }

            if (Bond_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Bond_Date", Bond_Date);
            }

            if (Sent_To != "")
            {
                cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
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
            result = "يوجد خطأ في الادخال او ان رقم السند مدخل مسبقا";
            return result;

        }

    }

    public string Update_Main_Listing_Bonds()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Listing_Bonds";
            cmd.Parameters.AddWithValue("@Company", Company);
            //rami roosan
            cmd.Parameters.AddWithValue("@Debtor", Debtor);
            cmd.Parameters.AddWithValue("@Creditor", Creditor);
            cmd.Parameters.AddWithValue("@Description", Description);
            //rami roosan
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Bond_Date", Bond_Date);

            cmd.Parameters.AddWithValue("@Claim_ID", Claim_ID);
            cmd.Parameters.AddWithValue("@Acounting_NO", Acounting_NO);
            if (Sent_To != "")
            {
                cmd.Parameters.AddWithValue("@Sent_To", Sent_To);
            }
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
            result = "حدث خطأ في التعديل او ان رقم السند مدخل مسبقا";
            return result;

        }

    }

    public string Delete_Main_Listing_Bonds()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Listing_Bonds";
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

    public string Delete_Main_Listing_BondsFromClaims()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Listing_Bonds";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@check", "R");

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


    public string Check_Start_Listing_Bonds()
    {
        try
        {

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Main_Listing_Bonds";
                cmd.Parameters.AddWithValue("@Company", Company);
                cmd.Parameters.AddWithValue("@check", "C");

                Cls_Connection.open_connection();
                
                result = cmd.ExecuteScalar().ToString();
            Cls_Connection.close_connection();
                return result;

            }
        catch (Exception ex)
        {
            Cls_Connection.close_connection();
            return "1";
        }

    }

    #endregion

}