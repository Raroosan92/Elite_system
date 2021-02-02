using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Payment_Of_Claims : System.Web.UI.Page
    {
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));



                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies3();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
        }
        protected void DDL_Medical_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Payment_Of_Claims";

                cmd.Parameters.AddWithValue("@Medical_Name", DDL_Medical_Name.SelectedValue);
                cmd.Parameters.AddWithValue("@Main_Company", DDL_Main_Company.SelectedValue);

                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView.DataSource = dt;
                GridView.DataBind();
                GridView.Visible = true;

                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
                MSG(x);
                Cls_Connection.close_connection();


            }



        }

        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Payment_Of_Claims";

                cmd.Parameters.AddWithValue("@Medical_Name", DDL_Medical_Name.SelectedValue);
                cmd.Parameters.AddWithValue("@Main_Company", DDL_Main_Company.SelectedValue);

                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView.DataSource = dt;
                GridView.DataBind();
                GridView.Visible = true;

                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();

                Cls_Connection.close_connection();


            }



        }
        string Sub_ClaimsID;
        string Main_Claims_ID;
        string PatientName;
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sub_ClaimsID = GridView.SelectedRow.Cells[1].Text;
                Main_Claims_ID = GridView.SelectedRow.Cells[2].Text;
                PatientName = GridView.SelectedRow.Cells[7].Text;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (Sub_ClaimsID!= "" && Main_Claims_ID !="" && PatientName !="")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "update Sub_Claims set PatientRatio = '"+Txt_PayAmmount.Text+"' WHERE Main_Claims_ID= '"+ Main_Claims_ID + "' AND ID= '"+ Sub_ClaimsID+ "' AND patient_name = '"+PatientName+"'";
                Cls_Connection.open_connection();
                cmd.ExecuteNonQuery();
                Cls_Connection.close_connection();
             
            }
            else
            {
                MSG("يجب اختيار مريض اولاً");
            }
        }
    }
}



update Main_Check set BarCode_Image = null; شادي هاي خليها بدي اشاورك فيها
-----------------------------------------------------------------------------------------------------------------------------------

ALTER proc[dbo].[Get_V_Claims_Report3]
@From date,
@To date,
@Medical_Name numeric(18,0)=null,
@Main_Company numeric(18,0)=null,
@Sub_Company numeric(18,0)=null,
@InOut int=null
as
begin
ffgfgddfdg

if @InOut=0

BEGIN
if (@Main_Company = 0)
select* from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and([Received_Date] between @From and @To)
else if (@Sub_Company=0)
select* from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and[Main_Company] = @Main_Company and[Received_Date] between @From and @To
else
select* from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and[Main_Company] = @Main_Company and[Sub_Company]=@Sub_Company and[Received_Date] between @From and @To

end

else if @InOut=1
BEGIN

if (@Sub_Company=0)
select* from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and[Main_Company] = @Main_Company and[Received_Date] between @From and @To and Procedure1 is not null and Procedure1 !=0
else
select* from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and[Main_Company] = @Main_Company and[Sub_Company]=@Sub_Company and[Received_Date] between @From and @To and Procedure1 is not null and Procedure1 !=0


end

else

BEGIN

if (@Sub_Company=0)
select* from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and[Main_Company] = @Main_Company and[Received_Date] between @From and @To and(Procedure1 is null or Procedure1 = 0)
else
select* from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and[Main_Company] = @Main_Company and[Sub_Company]=@Sub_Company and[Received_Date] between @From and @To and(Procedure1 is null or Procedure1 = 0)


end

end
-----------------------------------------------------------------------------------------------------------------------------------
create proc[dbo].[Get_V_Payment_Of_Claims]

@Medical_Name numeric(18,0)=null,
@Main_Company numeric(18,0)=null
as
begin

if @Main_Company=0
select id, Main_Claims_ID 'التسلسل' ,Medical_TypeName as 'اسم الجهة الطبية' ,cast(Entry_Date as nvarchar) as 'تاريخ الادخال', Main_CompanyDesc as 'اسم الشركة', Claims_Count as 'عدد المطالبات', [Value] as 'قيمة المطالبة', patient_name 'اسم المريض',Sub_CompanyDesc 'عن شركة' , PatientRatio 'نسبة تحمل المريض' , Tax 'الضريبة' from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name AND patient_name<>''
--select id, Medical_TypeName, cast( Entry_Date as nvarchar) , Main_CompanyDesc, Claims_Count, [Value], patient_name, Sub_CompanyDesc, PatientRatio, Tax from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name
else
select id, Main_Claims_ID 'التسلسل' ,Medical_TypeName as 'اسم الجهة الطبية' ,cast(Entry_Date as nvarchar) as 'تاريخ الادخال', Main_CompanyDesc as 'اسم الشركة', Claims_Count as 'عدد المطالبات', [Value] as 'قيمة المطالبة', patient_name 'اسم المريض',Sub_CompanyDesc 'عن شركة' , PatientRatio 'نسبة تحمل المريض' , Tax 'الضريبة'  from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and Main_Company=@Main_Company AND patient_name<>''
--select id, Medical_TypeName, cast( Entry_Date as nvarchar) , Main_CompanyDesc, Claims_Count, [Value], patient_name, Sub_CompanyDesc, PatientRatio, Tax  from[dbo].[V_ClaimsRpt2] where[Medical_Name]=@Medical_Name and Main_Company=@Main_Company
end
-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------