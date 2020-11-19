using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// المطالبات الفرعية
public class Cls_Sub_Claims
{
    #region Fields

    private Int64 ID;
    private Int64 Main_Company;
    private Int64 Sub_Company;
    private int Claims_Count;
    private double Value;
    private decimal Stamps;
    private Int64 Main_Claims_ID;
    private Boolean Delivered;
    private string patient_name;
    private DateTime Date_Subclaim;
    private string Approval_number;
    private string procedures_Subclaim;
    private int Procedure1;
    private int Procedure2;
    private int Procedure3;
    private int Procedure4;
    private int Procedure5;
    private decimal PatientRatio;
    private decimal Tax;
    private string Card_Num;
    private string Sample_Num;
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
    public Int64 _Main_Claims_ID
    {
        get
        {
            return Main_Claims_ID;
        }
        set
        {
            Main_Claims_ID = value;
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

    public string _patient_name
    {
        get
        {
            return patient_name;
        }
        set
        {
            patient_name = value;
        }
    }
    public string _Card_Num
    {
        get
        {
            return Card_Num;
        }
        set
        {
            Card_Num = value;
        }
    }
    public string _Sample_Num
    {
        get
        {
            return Sample_Num;
        }
        set
        {
            Sample_Num = value;
        }
    }

    public DateTime _Date_Subclaim
    {
        get
        {
            return Date_Subclaim;
        }
        set
        {
            Date_Subclaim = value;
        }
    }

    public string _Approval_number
    {
        get
        {
            return Approval_number;
        }
        set
        {
            Approval_number = value;
        }
    }

    public string _procedures_Subclaim
    {
        get
        {
            return procedures_Subclaim;
        }
        set
        {
            procedures_Subclaim = value;
        }
    }

    public int _Procedure1
    {
        get
        {
            return Procedure1;
        }
        set
        {
            Procedure1 = value;
        }
    }

    public int _Procedure2
    {
        get
        {
            return Procedure2;
        }
        set
        {
            Procedure2 = value;
        }
    }

    public int _Procedure3
    {
        get
        {
            return Procedure3;
        }
        set
        {
            Procedure3 = value;
        }
    }

    public int _Procedure4
    {
        get
        {
            return Procedure4;
        }
        set
        {
            Procedure4 = value;
        }
    }

    public int _Procedure5
    {
        get
        {
            return Procedure5;
        }
        set
        {
            Procedure5 = value;
        }
    }

    public decimal _PatientRatio
    {
        get
        {
            return PatientRatio;
        }
        set
        {
            PatientRatio = value;
        }
    }

    public decimal _Tax
    {
        get
        {
            return Tax;
        }
        set
        {
            Tax = value;
        }
    }
    #endregion

    #region Methods

    SqlConnection con = new SqlConnection();
    string result;
    public Cls_Sub_Claims()
    {

    }

    public string Insert_Sub_Claims()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Claims";
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
            cmd.Parameters.AddWithValue("@Main_Claims_ID", Main_Claims_ID);
            cmd.Parameters.AddWithValue("@Delivered", Delivered);
            cmd.Parameters.AddWithValue("@patient_name", patient_name);
            cmd.Parameters.AddWithValue("@Card_Num", Card_Num);
            cmd.Parameters.AddWithValue("@Sample_Num", Sample_Num);

            if (Date_Subclaim == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Date_Subclaim", Date_Subclaim);
            }

            
            cmd.Parameters.AddWithValue("@Approval_number", Approval_number);
            cmd.Parameters.AddWithValue("@procedures_Subclaim", procedures_Subclaim);

            cmd.Parameters.AddWithValue("@Procedure1", Procedure1);
            cmd.Parameters.AddWithValue("@Procedure2", Procedure2);
            cmd.Parameters.AddWithValue("@Procedure3", Procedure3);
            cmd.Parameters.AddWithValue("@Procedure4", Procedure4);
            cmd.Parameters.AddWithValue("@Procedure5", Procedure5);
            cmd.Parameters.AddWithValue("@PatientRatio", PatientRatio);
            cmd.Parameters.AddWithValue("@Tax", Tax);

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

    public string Update_Sub_Check()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Claims";
            cmd.Parameters.AddWithValue("@ID", ID);
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
            cmd.Parameters.AddWithValue("@Main_Claims_ID", Main_Claims_ID);
            cmd.Parameters.AddWithValue("@Delivered", Delivered);
            cmd.Parameters.AddWithValue("@patient_name", patient_name);
            if (Date_Subclaim == DateTime.MinValue)
            {
                //DateTime is null
            }
            else
            {
                cmd.Parameters.AddWithValue("@Date_Subclaim", Date_Subclaim);
            }
            
            cmd.Parameters.AddWithValue("@Approval_number", Approval_number);
            cmd.Parameters.AddWithValue("@procedures_Subclaim", procedures_Subclaim);

            cmd.Parameters.AddWithValue("@Procedure1", Procedure1);
            cmd.Parameters.AddWithValue("@Procedure2", Procedure2);
            cmd.Parameters.AddWithValue("@Procedure3", Procedure3);
            cmd.Parameters.AddWithValue("@Procedure4", Procedure4);
            cmd.Parameters.AddWithValue("@Procedure5", Procedure5);
            cmd.Parameters.AddWithValue("@PatientRatio", PatientRatio);
            cmd.Parameters.AddWithValue("@Card_Num", Card_Num);
            cmd.Parameters.AddWithValue("@Sample_Num", Sample_Num);

            cmd.Parameters.AddWithValue("@Tax", Tax);


            cmd.Parameters.AddWithValue("@check", "u");
            Cls_Connection.close_connection();
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

    public string Delete_Sub_Claims()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Sub_Claims";
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