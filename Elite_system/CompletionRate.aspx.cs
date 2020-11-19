using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;


namespace Elite_system
{
    public partial class CompletionRate : System.Web.UI.Page
    {
        DataTable dt_Result = new DataTable();
        int AssignCheckCount = 0;
        int DeliveredChecks = 0;
        int UnDeliveredChecks = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //--rami لتغيير التاريخ من لوحة المفاتيح--
            Txt_FromDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "')");
            Txt_ToDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 

            if (!Page.IsPostBack)
            {
                Txt_FromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Txt_ToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                DDL_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Employee.DataBind();
                DDL_Employee.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            Result_DT();
        }

        public void Result_DT()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_CompletionRate";
                DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null);
                
                cmd.Parameters.AddWithValue("@From", dt1);
                cmd.Parameters.AddWithValue("@To", dt2);
                cmd.Parameters.AddWithValue("@EmployeeName",DDL_Employee.SelectedItem.Text);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();

                adp.Fill(dt_Result);
                AssignCheckCount = dt_Result.Rows.Count;                               
                cmd.CommandText = "Get_DeliveredChecks";               
                DeliveredChecks =int.Parse( cmd.ExecuteScalar().ToString());
                UnDeliveredChecks = AssignCheckCount - DeliveredChecks;

                Cls_Connection.close_connection();

                ReportParameter rp1 = new ReportParameter("AssignCheckCount", AssignCheckCount.ToString());
                ReportParameter rp2 = new ReportParameter("DeliveredChecks", DeliveredChecks.ToString());
                ReportParameter rp3 = new ReportParameter("UnDeliveredChecks", UnDeliveredChecks.ToString());

                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("RptCompletionRate.rdlc");

                ReportViewer1.LocalReport.SetParameters(rp1);
                ReportViewer1.LocalReport.SetParameters(rp2);
                ReportViewer1.LocalReport.SetParameters(rp3);

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Checks", dt_Result));
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }
    }
}