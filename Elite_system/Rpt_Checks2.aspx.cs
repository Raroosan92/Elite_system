using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using System.Web;

namespace Elite_system
{
    public partial class Rpt_Checks2 : System.Web.UI.Page
    {
        DataTable dt_Result = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                Commission.Visible = true;

            }
            else
            {
                Commission.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                DDL_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Employee.DataBind();
                DDL_Employee.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Region1.DataSource = Cls_Codes.Fill_DDL(3);
                DDL_Region1.DataBind();
                DDL_Region1.Items.Insert(0, new ListItem("--اختر--", "0"));
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
                ReportParameter rp1;
                ReportParameter rp2;
                ReportParameter rp3;
                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    cmd.CommandText = "Get_V_Financial_Receivables_Report";
                }
                else
                {
                    cmd.CommandText = "Get_V_Financial_Receivables_Report2";
                }
                cmd.Parameters.AddWithValue("@EmployeeNum", Int64.Parse(DDL_Employee.SelectedValue));
                cmd.Parameters.AddWithValue("@Region", Int64.Parse(DDL_Region1.SelectedValue));
                if (Txt_FromDate.Text=="")
                {
                    cmd.Parameters.AddWithValue("@Date_From", null);
                    rp2 = new ReportParameter("DateFrom", "");

                }
                else
                {
                    DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                    cmd.Parameters.AddWithValue("@Date_From", dt1);
                    rp2 = new ReportParameter("DateFrom", dt1.ToString("yyyy-MM-dd"));


                }
                if (Txt_ToDate.Text == "")
                {
                    cmd.Parameters.AddWithValue("@Date_To", null);
                    rp3 = new ReportParameter("DateTo", "");

                }
                else
                {
                    DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null);
                    cmd.Parameters.AddWithValue("@Date_To", dt2);
                    rp3 = new ReportParameter("DateTo", dt2.ToString("yyyy-MM-dd"));

                }

                
              
                float Commission;
                if (Txt_Commission.Text == "")
                {
                    Commission = 0;
                }
                else
                {
                    Commission = float.Parse(Txt_Commission.Text);

                }
                rp1 = new ReportParameter("commission", Commission.ToString());
              

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Result);
                Cls_Connection.close_connection();
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Rpt_Check2.rdlc");
                ReportViewer1.LocalReport.SetParameters(rp1);
                ReportViewer1.LocalReport.SetParameters(rp2);
                ReportViewer1.LocalReport.SetParameters(rp3);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Financial_Receivables", dt_Result));
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