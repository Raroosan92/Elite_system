using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Rpt_MedicalTypesWithNoClaims : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //--rami لتغيير التاريخ من لوحة المفاتيح--
            //Txt_FromDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "')");
            //Txt_ToDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 
            if (!Page.IsPostBack)
            {
                Txt_FromDate.Text = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");
                Txt_ToDate.Text = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");
                DDL_Region.DataSource = Cls_Codes.Fill_DDL(3);
                DDL_Region.DataBind();
                DDL_Region.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
        }
        DataTable dt_Result = new DataTable();
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
                cmd.CommandText = "Get_MedicalTypesWithNoClaims";
                DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null);

                //DateTime dt1 = startDate;
                //DateTime dt2 = endDate;

                cmd.Parameters.AddWithValue("@From", dt1);
                cmd.Parameters.AddWithValue("@To", dt2);
                cmd.Parameters.AddWithValue("@Region", DDL_Region.SelectedItem.Text);


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                ReportParameter rp1 = new ReportParameter("From", Txt_FromDate.Text);
                ReportParameter rp2 = new ReportParameter("To", Txt_ToDate.Text);
                ReportParameter rp3 = new ReportParameter("Region",  DDL_Region.SelectedItem.Text);

                Cls_Connection.open_connection();
                adp.Fill(dt_Result);
                Cls_Connection.close_connection();
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Rpt_MedicalTypesWithNoClaims.rdlc");
                ReportViewer1.LocalReport.SetParameters(rp1);
                ReportViewer1.LocalReport.SetParameters(rp2);
                ReportViewer1.LocalReport.SetParameters(rp3);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Rpt_MedicalTypesWithNoClaims", dt_Result));
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