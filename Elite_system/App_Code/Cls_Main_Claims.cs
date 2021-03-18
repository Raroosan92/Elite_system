using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

// المطالبات الرئيسية
public class Cls_Main_Claims
{

    #region Fields

    private Int64 ID;
    private Int64 Medical_Name;
    private Int64 Total_Claims;
    private string Month_Year;
    private DateTime Received_Date;
    private int Receiver_Employee;
    private DateTime Entry_Date;
    private int Batch_No;
    private Int64 Main_Company;
    private Int64 Sub_Company;
    private int Claims_Count;
    private double Value;
    private decimal Stamps;
    private Boolean Delivered;
    private Int64 Claim_ID;
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
    public Int64 _Medical_Name
    {
        get
        {
            return Medical_Name;
        }
        set
        {
            Medical_Name = value;
        }
    }

    public Int64 _Total_Claims
    {
        get
        {
            return Total_Claims;
        }
        set
        {
            Total_Claims = value;
        }
    }
    public string _Month_Year
    {
        get
        {
            return Month_Year;
        }
        set
        {
            Month_Year = value;
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
    public int _Receiver_Employee
    {
        get
        {
            return Receiver_Employee;
        }
        set
        {
            Receiver_Employee = value;
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
    public int _Batch_No
    {
        get
        {
            return Batch_No;
        }
        set
        {
            Batch_No = value;
        }
    }


    public Int64 _Main_Company
    {
        get
        {
            return Main_Company;
        }
        set
        {
            Main_Company = value;
        }
    }
    public Int64 _Sub_Company
    {
        get
        {
            return Sub_Company;
        }
        set
        {
            Sub_Company = value;
        }
    }
    public int _Claims_Count
    {
        get
        {
            return Claims_Count;
        }
        set
        {
            Claims_Count = value;
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
    public decimal _Stamps
    {
        get
        {
            return Stamps;
        }
        set
        {
            Stamps = value;
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
    public Cls_Main_Claims()
    {

    }

    public string Insert_Main_Claims()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Claims";

            if (Medical_Name != 0)
            {
                cmd.Parameters.AddWithValue("@Medical_Name", Medical_Name);
            }

            if (Claim_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Claim_ID", Claim_ID);
            }

            cmd.Parameters.AddWithValue("@Month_Year", Month_Year);
            if (Received_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Received_Date", Received_Date);
            }

            if (Receiver_Employee != 0)
            {
                cmd.Parameters.AddWithValue("@Receiver_Employee", Receiver_Employee);
            }

            if (Entry_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Entry_Date", Entry_Date);
            }

            if (Batch_No != 0)
            {
                cmd.Parameters.AddWithValue("@Batch_No", Batch_No);
            }

            if (Total_Claims != 0)
            {
                cmd.Parameters.AddWithValue("@Total_Claims", Total_Claims);
            }
            //if (Main_Company != 0)
            //{
            //    cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
            //}

            //if (Sub_Company != 0)
            //{
            //    cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);
            //}

            //if (Claims_Count != 0)
            //{
            //    cmd.Parameters.AddWithValue("@Claims_Count", Claims_Count);
            //}

            //cmd.Parameters.AddWithValue("@Value", Value);
            //cmd.Parameters.AddWithValue("@Stamps", Stamps);
            //cmd.Parameters.AddWithValue("@Delivered", Delivered);


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

    public string Update_Main_Claims()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Claims";
            if (Medical_Name != 0)
            {
                cmd.Parameters.AddWithValue("@Medical_Name", Medical_Name);
            }

            cmd.Parameters.AddWithValue("@Month_Year", Month_Year);
            if (Received_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Received_Date", Received_Date);
            }

            if (Receiver_Employee != 0)
            {
                cmd.Parameters.AddWithValue("@Receiver_Employee", Receiver_Employee);
            }

            if (Entry_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Entry_Date", Entry_Date);
            }

            if (Batch_No != 0)
            {
                cmd.Parameters.AddWithValue("@Batch_No", Batch_No);
            }

            if (Main_Company != 0)
            {
                cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
            }

            if (Sub_Company != 0)
            {
                cmd.Parameters.AddWithValue("@Sub_Company", Sub_Company);
            }

            if (Claims_Count != 0)
            {
                cmd.Parameters.AddWithValue("@Claims_Count", Claims_Count);
            }

            cmd.Parameters.AddWithValue("@Value", Value);
            cmd.Parameters.AddWithValue("@Stamps", Stamps);
            cmd.Parameters.AddWithValue("@Delivered", Delivered);

            cmd.Parameters.AddWithValue("@ID", ID);

            if (Claim_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Claim_ID", Claim_ID);
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

    public string Delete_Main_Claims()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Main_Claims";
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


    public static string Get_Max_Main_Claims()
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
            cmd.CommandText = "Get_Max_Main_Claims";

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

    static public DataTable Get_Medical_Types()
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
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                cmd.Parameters.AddWithValue("@UName", HttpContext.Current.User.Identity.Name);
                cmd.CommandText = "Get_Medical_TypesForClaimsByName";
            }
            else
            {
                cmd.CommandText = "Get_Medical_Types2";
            }

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



    // جلب الجهات الطبية المتعاقدة فقط
    static public DataTable Get_Medical_Types3()
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
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                cmd.Parameters.AddWithValue("@UName", HttpContext.Current.User.Identity.Name.Replace(' ','%'));
                cmd.CommandText = "Get_Medical_TypesForClaimsByName";
            }
            else
            {
                cmd.CommandText = "Get_Medical_Types";
            }

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


    // جلب جميع الجهات الطبية
    static public DataTable Get_Medical_Types2()
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
            cmd.CommandText = "Get_Medical_Types2";
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

    static public DataTable Get_Medical_TypesForClaims()
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
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                cmd.Parameters.AddWithValue("@UName", HttpContext.Current.User.Identity.Name);
                cmd.CommandText = "Get_Medical_TypesForClaimsByName";
            }
            else
            {
                cmd.CommandText = "Get_Medical_TypesForClaims";
            }
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            Cls_Connection.open_connection();
            adp.Fill(dt);
            Cls_Connection.close_connection();
            return dt;

        }
        catch (Exception ex)
        {
            Cls_Connection.close_connection();
            return dt;


        }

    }

    static public DataTable Get_Medical_Types_Search(string Search)
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
            cmd.CommandText = "Get_Medical_Types_Search";
            cmd.Parameters.AddWithValue("@Send_To", Search);
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

    static public DataTable Get_Companies()
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
            cmd.CommandText = "Get_Companies";
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

    static public DataTable Get_Companies2()
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
            cmd.CommandText = "Get_Companies2";
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

    static public DataTable Get_Companies3()
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
            cmd.CommandText = "Get_Companies3";
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

    static public DataTable Get_Companies_Search(string Search)
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
            cmd.CommandText = "Get_Companies_Search";
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Company", Search);
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
    public string Get_Claim_Value()
    {
        string Value = "";
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_Claim_Value";
            cmd.Parameters.AddWithValue("@ID", ID);
            Cls_Connection.open_connection();

            Value = cmd.ExecuteScalar().ToString();

            Cls_Connection.close_connection();
            return Value;

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            Cls_Connection.close_connection();
            return Value;


        }

    }


    public int CheckMedicalTypeInClaims()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CheckMedicalTypeInClaims";


            if (Claim_ID != 0)
            {
                cmd.Parameters.AddWithValue("@Medical_ID", Claim_ID);
            }

            Cls_Connection.open_connection();
            int Check = (int)cmd.ExecuteScalar();

            Cls_Connection.close_connection();
            return Check;

        }
        catch (Exception ex)
        {
            result = ex.Message.ToString();
            Cls_Connection.close_connection();
            result = "حدث خطأ في الإضافة";
            return 0;

        }

    }

    #endregion

}