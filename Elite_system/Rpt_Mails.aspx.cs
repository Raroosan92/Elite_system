﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using System.Web;

namespace Elite_system
{
    public partial class Rpt_Mails : System.Web.UI.Page
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
                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies2();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_Types();
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


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Mails";

                DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null); ;
                DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null); ;

                ReportParameter rp1 = new ReportParameter("From", Txt_FromDate.Text);
                ReportParameter rp2 = new ReportParameter("To", Txt_ToDate.Text);

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

                if (DDL_Main_Company.SelectedValue == "0")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@Company", long.Parse(DDL_Main_Company.SelectedValue));
                }

                if (DDL_Medical_Name.SelectedValue == "0")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@Sent_To", long.Parse(DDL_Medical_Name.SelectedValue));

                }
               

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Result);
                Cls_Connection.close_connection();
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Rpt_Mails2.rdlc");
                ReportViewer1.LocalReport.SetParameters(rp1);
                ReportViewer1.LocalReport.SetParameters(rp2);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Mails", dt_Result));
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }

        private void PrintPDF()
        {
            //////////////////////////////////////Export as PDF File////////////////////////////////////////
            //Warning[] warnings;
            //string[] streamIds;
            //string contentType;
            //string encoding;
            //string extension;

            ////Export the RDLC Report to Byte Array.
            //byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);

            ////Download the RDLC Report in Word, Excel, PDF and Image formats.
            //Response.Clear();
            //Response.Buffer = true;
            //Response.Charset = "";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = contentType;
            //Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC." + extension);
            //Response.BinaryWrite(bytes);
            //Response.Flush();
            //Response.End();
            //////////////////////////////////////Export as PDF File////////////////////////////////////////

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