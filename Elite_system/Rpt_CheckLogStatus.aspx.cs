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
    public partial class CheckLogStatus : System.Web.UI.Page
    {
        DataTable dt_Result = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    Txt_FromDate.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
            //    Txt_ToDate.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
            DDL_Medical_Name.DataSource = Cls_Employees.Get_Employee();
            DDL_Medical_Name.DataBind();
           //DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));


            //    DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies();
            //    DDL_Main_Company.DataBind();
            //    DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Result_DT();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PrintPDF();
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

                //DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                //dt1 = dt1.Date;
                //DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null);
                //dt2 = dt2.Date;


                cmd.CommandText = "Rpt_CheckLogStatus";
                //cmd.Parameters.AddWithValue("@From", dt1);
                //cmd.Parameters.AddWithValue("@To", dt2);


                cmd.Parameters.AddWithValue("@Medical_Name", DDL_Medical_Name.SelectedItem.Text.Replace(' ','%'));
                


                //ReportParameter rp1 = new ReportParameter("From", Txt_FromDate.Text);
                //ReportParameter rp2 = new ReportParameter("To", Txt_ToDate.Text);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Result);
                Cls_Connection.close_connection();
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_ChecksLogStatus", dt_Result));
              
             
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Rpt_CheckLogStatus.rdlc");
               
                //ReportViewer1.LocalReport.SetParameters(rp1);
                //ReportViewer1.LocalReport.SetParameters(rp2);




                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }
    }
}