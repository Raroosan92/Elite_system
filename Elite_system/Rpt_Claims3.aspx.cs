using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Rpt_Claims3 : System.Web.UI.Page
    {
        DataTable dt_Result = new DataTable();
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
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_Types3();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_Types();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));

               
                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies3();                
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

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
                cmd.CommandText = "Get_V_Claims_Report3";
                DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null);

                //DateTime dt1 = startDate;
                //DateTime dt2 = endDate;

                cmd.Parameters.AddWithValue("@From", dt1);
                cmd.Parameters.AddWithValue("@To", dt2);
                cmd.Parameters.AddWithValue("@Medical_Name", long.Parse(DDL_Medical_Name.SelectedValue));
                cmd.Parameters.AddWithValue("@Main_Company", long.Parse(DDL_Main_Company.SelectedValue));
                

                if (DDL_Sub_Company.SelectedValue == "")
                {
                    cmd.Parameters.AddWithValue("@Sub_Company", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Sub_Company", DDL_Sub_Company.SelectedValue);
                }

                if (DDL_InOut.SelectedValue == "0")
                {
                    cmd.Parameters.AddWithValue("@InOut", 0);
                }
                else if (DDL_InOut.SelectedValue == "1")
                {

                    cmd.Parameters.AddWithValue("@InOut", 1);

                }
                else if (DDL_InOut.SelectedValue == "2")
                {

                    cmd.Parameters.AddWithValue("@InOut", 2);
                }


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Result);
                Cls_Connection.close_connection();
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Rpt_Claims3.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Claims3", dt_Result));
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
                //string x = ex.Message.ToString();
            }
        }

        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCompany();

        }

        public void GetSubCompany()
        {
            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            Sub_Companies._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            DDL_Sub_Company.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Sub_Company.DataBind();
            DDL_Sub_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
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