using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;

namespace Elite_system
{
    public partial class Rpt_Checks3 : System.Web.UI.Page
    {
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        DataTable dt_Result = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //--rami لتغيير التاريخ من لوحة المفاتيح--
            //  Txt_FromDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "')");
            //  Txt_ToDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 
            if (!Page.IsPostBack)
            {
                Txt_FromDate.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                Txt_ToDate.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_Types();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DDL_Medical_Name.SelectedIndex!=0)
            {
                Result_DT();
            }
            else
            {
                MSG("يجب ادخال الجهة الطبية");
            }
           
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

                DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                dt1 = dt1.Date;
                DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null);
                dt2 = dt2.Date;
                //if (DDL_CheckStatus.SelectedValue=="0")
                //{
                //    cmd.CommandText = "Get_V_Checks_Report3";
                //    cmd.Parameters.AddWithValue("@Check", 0);

                //}
                //else if (DDL_CheckStatus.SelectedValue == "1")
                //{
                //    cmd.CommandText = "Get_V_Checks_Report3";
                //    cmd.Parameters.AddWithValue("@Delivered", 1);

                //}
                //else if (DDL_CheckStatus.SelectedValue == "2")
                //{
                //    cmd.CommandText = "Get_V_Checks_Report3";
                //    cmd.Parameters.AddWithValue("@Delivered", 0);
                //}

                //else if (DDL_CheckStatus.SelectedValue == "3")
                //{
                //    cmd.CommandText = "Get_V_Checks2_Report3";
                //    cmd.Parameters.AddWithValue("@Refunded", 1);
                //}



                cmd.CommandText = "Get_V_Checks";
                cmd.Parameters.AddWithValue("@From", dt1);
                cmd.Parameters.AddWithValue("@To", dt2);

                if (DDL_CheckStatus.SelectedValue == "0")
                {

                }
                else if (DDL_CheckStatus.SelectedValue == "1")
                {

                    cmd.Parameters.AddWithValue("@Delivered", true);

                }
                else if (DDL_CheckStatus.SelectedValue == "2")
                {

                    cmd.Parameters.AddWithValue("@Delivered", false);
                }

                else if (DDL_CheckStatus.SelectedValue == "3")
                {

                    cmd.Parameters.AddWithValue("@Refunded", true);
                }

                if (DDL_Main_Company.SelectedValue == "0")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@Company", DDL_Main_Company.SelectedItem.Text);
                }

                if (DDL_Medical_Name.SelectedValue == "0")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@Sent_To", long.Parse(DDL_Medical_Name.SelectedValue));

                }
                //DateTime dt1 = startDate;
                //DateTime dt2 = endDate;


                ////cmd.Parameters.AddWithValue("@Sent_To", long.Parse(DDL_Medical_Name.SelectedValue));

                //rami
                ReportParameterCollection Rpt = new ReportParameterCollection();
                Rpt.Add(new ReportParameter("Uname", HttpContext.Current.User.Identity.Name));

                //rami

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Result);
                Cls_Connection.close_connection();
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Rpt_Checks6.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Checks", dt_Result));
                //rami
                this.ReportViewer1.LocalReport.SetParameters(Rpt);
                //rami
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