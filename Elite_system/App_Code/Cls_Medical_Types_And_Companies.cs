using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// الجهات الطبية والشركات
public class Cls_Medical_Types_And_Companies
{
    #region Fields

    private Int64 ID;
    private string Name;
    private int Type;
    private int Specialization;
    private int Place;
    private int Region;
    private string Address;
    private string Building;
    private string Email;
    private string Phone;
    private string Mobile;
    private string Fax;
    private string P_O_Box;
    private int Medical_Status;
    private string Reason;
    private int Contracting_Status;
    private int Contract_NO;
    private DateTime Contract_Date;
    private DateTime ContractExpiryDate;
    private DateTime Accounting_Date;
    private string Contracting_Value;
    private string Contracting_NO;
    private int Stamps;
    private string Acounting_NO;
    private int Employee;
    private int Bank;
    private int Bank_Branch;
    private string P_O_Box2;
    private string Tax_NO;
    private string Authorization_NO;
    private int Contracting_Type1;
    private int Contracting_Type2;
    private int Contracting_Type3;
    private bool Entry_Type;
    private int User_ID;
    private string Notes;
    private bool Freez;
    private DateTime FreezFrom;
    private DateTime FreezTo;
    //private decimal TransactionPrice;
    //private decimal CheckPrice;
    //private decimal DiscountRatio;

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
    public string _Name
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
    public int _Specialization
    {
        get
        {
            return Specialization;
        }
        set
        {
            Specialization = value;
        }
    }
    public int _Place
    {
        get
        {
            return Place;
        }
        set
        {
            Place = value;
        }
    }
    public int _Region
    {
        get
        {
            return Region;
        }
        set
        {
            Region = value;
        }
    }
    public string _Address
    {
        get
        {
            return Address;
        }
        set
        {
            Address = value;
        }
    }
    public string _Building
    {
        get
        {
            return Building;
        }
        set
        {
            Building = value;
        }
    }
    public string _Email
    {
        get
        {
            return Email;
        }
        set
        {
            Email = value;
        }
    }
    public string _Phone
    {
        get
        {
            return Phone;
        }
        set
        {
            Phone = value;
        }
    }
    public string _Mobile
    {
        get
        {
            return Mobile;
        }
        set
        {
            Mobile = value;
        }
    }
    public string _Fax
    {
        get
        {
            return Fax;
        }
        set
        {
            Fax = value;
        }
    }
    public string _P_O_Box
    {
        get
        {
            return P_O_Box;
        }
        set
        {
            P_O_Box = value;
        }
    }
    public int _Medical_Status
    {
        get
        {
            return Medical_Status;
        }
        set
        {
            Medical_Status = value;
        }
    }
    public string _Reason
    {
        get
        {
            return Reason;
        }
        set
        {
            Reason = value;
        }
    }
    public int _Contracting_Status
    {
        get
        {
            return Contracting_Status;
        }
        set
        {
            Contracting_Status = value;
        }
    }
    public int _Contract_NO
    {
        get
        {
            return Contract_NO;
        }
        set
        {
            Contract_NO = value;
        }
    }
    public DateTime _Contract_Date
    {
        get
        {
            return Contract_Date;
        }
        set
        {
            Contract_Date = value;
        }
    }
    public DateTime _ContractExpiryDate
    {
        get
        {
            return ContractExpiryDate;
        }
        set
        {
            ContractExpiryDate = value;
        }
    }
    public DateTime _Accounting_Date
    {
        get
        {
            return Accounting_Date;
        }
        set
        {
            Accounting_Date = value;
        }
    }
    public string _Contracting_Value
    {
        get
        {
            return Contracting_Value;
        }
        set
        {
            Contracting_Value = value;
        }
    }
    public string _Contracting_NO
    {
        get
        {
            return Contracting_NO;
        }
        set
        {
            Contracting_NO = value;
        }
    }
    public int _Stamps
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
    public int _Employee
    {
        get
        {
            return Employee;
        }
        set
        {
            Employee = value;
        }
    }
    public int _Bank
    {
        get
        {
            return Bank;
        }
        set
        {
            Bank = value;
        }
    }
    public int _Bank_Branch
    {
        get
        {
            return Bank_Branch;
        }
        set
        {
            Bank_Branch = value;
        }
    }
    public string _P_O_Box2
    {
        get
        {
            return P_O_Box2;
        }
        set
        {
            P_O_Box2 = value;
        }
    }
    public string _Tax_NO
    {
        get
        {
            return Tax_NO;
        }
        set
        {
            Tax_NO = value;
        }
    }
    public string _Authorization_NO
    {
        get
        {
            return Authorization_NO;
        }
        set
        {
            Authorization_NO = value;
        }
    }
    public int _Contracting_Type1
    {
        get
        {
            return Contracting_Type1;
        }
        set
        {
            Contracting_Type1 = value;
        }
    }

    public int _Contracting_Type2
    {
        get
        {
            return Contracting_Type2;
        }
        set
        {
            Contracting_Type2 = value;
        }
    }

    public int _Contracting_Type3
    {
        get
        {
            return Contracting_Type3;
        }
        set
        {
            Contracting_Type3 = value;
        }
    }
    public bool _Entry_Type
    {
        get
        {
            return Entry_Type;
        }
        set
        {
            Entry_Type = value;
        }
    }

    public int _User_ID
    {
        get
        {
            return User_ID;
        }
        set
        {
            User_ID = value;
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
    public bool _Freez
    {
        get
        {
            return Freez;
        }
        set
        {
            Freez = value;
        }
    }
    public DateTime _FreezTo
    {
        get
        {
            return FreezTo;
        }
        set
        {
            FreezTo = value;
        }
    }
    public DateTime _FreezFrom
    {
        get
        {
            return FreezFrom;
        }
        set
        {
            FreezFrom = value;
        }
    }
    //public decimal _TransactionPrice
    //{
    //    get
    //    {
    //        return TransactionPrice;
    //    }
    //    set
    //    {
    //        TransactionPrice = value;
    //    }
    //}

    //public decimal _CheckPrice
    //{
    //    get
    //    {
    //        return CheckPrice;
    //    }
    //    set
    //    {
    //        CheckPrice = value;
    //    }
    //}

    //public decimal _DiscountRatio
    //{
    //    get
    //    {
    //        return DiscountRatio;
    //    }
    //    set
    //    {
    //        DiscountRatio = value;
    //    }
    //}
    #endregion

    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Medical_Types_And_Companies()
    {

    }

    public string Insert_Medical_Types()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Medical_Types_And_Companies";
            cmd.Parameters.AddWithValue("@Name", Name);
            if (Type != 0)
            {
                cmd.Parameters.AddWithValue("@Type", Type);
            }

            if (Specialization != 0)
            {
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
            }

            if (Place != 0)
            {
                cmd.Parameters.AddWithValue("@Place", Place);
            }

            if (Region != 0)
            {
                cmd.Parameters.AddWithValue("@Region", Region);
            }

            cmd.Parameters.AddWithValue("@Address", Address);
        
            cmd.Parameters.AddWithValue("@Building", Building);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@P_O_Box", P_O_Box);
            if (Medical_Status != 0)
            {
                cmd.Parameters.AddWithValue("@Medical_Status", Medical_Status);
            }

            cmd.Parameters.AddWithValue("@Reason", Reason);
            if (Contracting_Status != 0)
            {
                cmd.Parameters.AddWithValue("@Contracting_Status", Contracting_Status);
            }

            cmd.Parameters.AddWithValue("@Contract_NO", Contract_NO);
            if (Contract_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Contract_Date", Contract_Date);
            }

            if (ContractExpiryDate == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContractExpiryDate", ContractExpiryDate);
            }

            if (Accounting_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Accounting_Date", Accounting_Date);
            }

            if (Contracting_Value == "")
            {
                cmd.Parameters.AddWithValue("@Contracting_Value", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Contracting_Value", Contracting_Value);
            }

            cmd.Parameters.AddWithValue("@Contracting_NO", Contracting_NO);
            cmd.Parameters.AddWithValue("@Stamps", Stamps);
            cmd.Parameters.AddWithValue("@Acounting_NO", Acounting_NO);
            if (Employee != 0)
            {
                cmd.Parameters.AddWithValue("@Employee", Employee);
            }

            if (Bank != 0)
            {
                cmd.Parameters.AddWithValue("@Bank", Bank);
            }

            if (Bank_Branch != 0)
            {
                cmd.Parameters.AddWithValue("@Bank_Branch", Bank_Branch);
            }


            cmd.Parameters.AddWithValue("@P_O_Box2", P_O_Box2);
            cmd.Parameters.AddWithValue("@Tax_NO", Tax_NO);
            cmd.Parameters.AddWithValue("@Authorization_NO", Authorization_NO);
            cmd.Parameters.AddWithValue("@Entry_Type", 1);
            cmd.Parameters.AddWithValue("@User_ID", 1);
            //cmd.Parameters.AddWithValue("@TransactionPrice", TransactionPrice);
            //cmd.Parameters.AddWithValue("@CheckPrice", CheckPrice);
            //cmd.Parameters.AddWithValue("@DiscountRatio", DiscountRatio);
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

    public string Update_Medical_Types()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Medical_Types_And_Companies";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Freez", Freez);
            cmd.Parameters.AddWithValue("@FreezFrom", FreezFrom);
            cmd.Parameters.AddWithValue("@FreezTo", FreezTo);
            if (Type != 0)
            {
                cmd.Parameters.AddWithValue("@Type", Type);
            }

            if (Specialization != 0)
            {
                cmd.Parameters.AddWithValue("@Specialization", Specialization);
            }

            if (Place != 0)
            {
                cmd.Parameters.AddWithValue("@Place", Place);
            }

            if (Region != 0)
            {
                cmd.Parameters.AddWithValue("@Region", Region);
            }
            
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Building", Building);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@P_O_Box", P_O_Box);
            //if (Medical_Status != 0)
            //{
            //    cmd.Parameters.AddWithValue("@Medical_Status", Medical_Status);
            //}

            cmd.Parameters.AddWithValue("@Reason", Reason);
            if (Contracting_Status != 0)
            {
                cmd.Parameters.AddWithValue("@Contracting_Status", Contracting_Status);
            }

            cmd.Parameters.AddWithValue("@Contract_NO", Contract_NO);
            if (Contract_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Contract_Date", Contract_Date);
            }

            if (ContractExpiryDate == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@ContractExpiryDate", ContractExpiryDate);
            }

            if (Accounting_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Accounting_Date", Accounting_Date);
            }

            cmd.Parameters.AddWithValue("@Contracting_Value", Contracting_Value);
            cmd.Parameters.AddWithValue("@Contracting_NO", Contracting_NO);
            cmd.Parameters.AddWithValue("@Stamps", Stamps);
            cmd.Parameters.AddWithValue("@Acounting_NO", Acounting_NO);
            if (Employee != 0)
            {
                cmd.Parameters.AddWithValue("@Employee", Employee);
            }

            if (Bank != 0)
            {
                cmd.Parameters.AddWithValue("@Bank", Bank);
            }

            if (Bank_Branch != 0)
            {
                cmd.Parameters.AddWithValue("@Bank_Branch", Bank_Branch);
            }


            cmd.Parameters.AddWithValue("@P_O_Box2", P_O_Box2);
            cmd.Parameters.AddWithValue("@Tax_NO", Tax_NO);
            cmd.Parameters.AddWithValue("@Authorization_NO", Authorization_NO);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@Entry_Type", 1);
            cmd.Parameters.AddWithValue("@User_ID", 1);
            //cmd.Parameters.AddWithValue("@TransactionPrice", TransactionPrice);
            //cmd.Parameters.AddWithValue("@CheckPrice", CheckPrice);
            //cmd.Parameters.AddWithValue("@DiscountRatio", DiscountRatio);
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

    public string Delete_Medical_Types()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Medical_Types_And_Companies";
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

    public string Insert_Companies()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Medical_Types_And_Companies";
            cmd.Parameters.AddWithValue("@Name", Name);
            if (Contract_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Contract_Date", Contract_Date);
            }

            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@P_O_Box", P_O_Box);
            cmd.Parameters.AddWithValue("@Stamps", Stamps);
            cmd.Parameters.AddWithValue("@Contracting_Type1", Contracting_Type1);
            cmd.Parameters.AddWithValue("@Contracting_Type2", Contracting_Type2);
            cmd.Parameters.AddWithValue("@Contracting_Type3", Contracting_Type3);
            cmd.Parameters.AddWithValue("@Entry_Type", 2);
            cmd.Parameters.AddWithValue("@User_ID", 1);
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

    public string Update_Companies()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Medical_Types_And_Companies";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);

            if (Contract_Date == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Contract_Date", Contract_Date);
            }

            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@P_O_Box", P_O_Box);
            cmd.Parameters.AddWithValue("@Stamps", Stamps);
            cmd.Parameters.AddWithValue("@Contracting_Type1", Contracting_Type1);
            cmd.Parameters.AddWithValue("@Contracting_Type2", Contracting_Type2);
            cmd.Parameters.AddWithValue("@Contracting_Type3", Contracting_Type3);
            cmd.Parameters.AddWithValue("@Entry_Type", 2);
            cmd.Parameters.AddWithValue("@User_ID", 1);
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

    public string Delete_Companies()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Medical_Types_And_Companies";
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
            result = " حدث خطأ في الحذف ربما يوجد مطالبات لهذه الشركة";
            return result;

        }

    }

    static public string Get_Acounting_NO(long ID)
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
            cmd.CommandText = "Get_Acounting_NO";
            cmd.Parameters.AddWithValue("@ID", ID);

            Cls_Connection.open_connection();
            result = cmd.ExecuteScalar().ToString();
            Cls_Connection.close_connection();
            return result;

        }
        catch (Exception)
        {
            Cls_Connection.close_connection();
            result = "0";
            return result;

        }

    }

    static public string Get_Contracting_Value(long ID)
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
            cmd.CommandText = "Get_Contracting_Value";
            cmd.Parameters.AddWithValue("@ID", ID);

            Cls_Connection.open_connection();
            result = cmd.ExecuteScalar().ToString();
            Cls_Connection.close_connection();
            return result;

        }
        catch (Exception)
        {
            Cls_Connection.close_connection();
            result = "0";
            return result;

        }

    }


    ///////////////////////////RAMI///////////////////////////////////

    static public string Get_Claim_ID(long ID, string month_year)
    {
        string result="0";
        try
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select [Claim_ID] from [dbo].[main_claims] where Medical_Name = " + ID + " and Month_Year = '" + month_year + "'";
            Cls_Connection.open_connection();
            try { 
            result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {

            }
           
            Cls_Connection.close_connection();
             return result;

        }
        catch (Exception)
        {
            Cls_Connection.close_connection();
            result = "0";
            return result;

        }

    }




#endregion

}