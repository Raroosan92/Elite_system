using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Rpt_Claims4 : System.Web.UI.Page
    {

        DataTable dt_Result = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            //--rami لتغيير التاريخ من لوحة المفاتيح--
            // Txt_FromDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "')");
            // Txt_ToDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 
            if (!Page.IsPostBack)
            {
                Txt_FromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Txt_ToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Type.DataSource = Cls_Codes.Fill_DDL(1);
                DDL_Type.DataBind();
                DDL_Type.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Result_DT();
        }

        public void Result_DT()
        {
            try
            {
                //DateTime month = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                //var startDate = new DateTime(month.Year, month.Month, 1);
                //var endDate = startDate.AddMonths(1).AddDays(-1);

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Claims_Report";
                DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null);
                //DateTime dt1 = startDate;
                //DateTime dt2 = endDate;
                cmd.Parameters.AddWithValue("@From", dt1);
                cmd.Parameters.AddWithValue("@To", dt2);
                cmd.Parameters.AddWithValue("@Main_Company", long.Parse(DDL_Main_Company.SelectedValue));
                cmd.Parameters.AddWithValue("@Type", int.Parse(DDL_Type.SelectedValue));
                string batch = "";
                ReportParameter rp1;
                if (Txt_Batch_No.Text == "")
                {
                    cmd.Parameters.AddWithValue("@Batch_No", 0);
                    batch = "جميع الدفعات";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Batch_No", int.Parse(Txt_Batch_No.Text));
                    batch = " دفعة رقم " + Txt_Batch_No.Text;
                }

                cmd.Parameters.AddWithValue("@Medical_Name", long.Parse(DDL_Medical_Name.SelectedValue));

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt_Result);
                //Cls_Connection.open_connection();

                //Cls_Connection.close_connection();

                rp1 = new ReportParameter("Batch_No", batch);

                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Rpt_Claims.rdlc");
                ReportViewer1.LocalReport.SetParameters(rp1);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Claims", dt_Result));
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }

        private void PrintPDF()
        {
            try
            {
                Warning[] warnings = null;
                string[] streamids = null;
                string mimeType = null;
                string encoding = null;
                string extension = null;
                byte[] bytes;


                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Ticket_GetTicket", ObjectDataSource1));


                bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);


                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                Response.ContentType = "Application/pdf";
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
            catch
            {

            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            PrintPDF();
        }
    }
}