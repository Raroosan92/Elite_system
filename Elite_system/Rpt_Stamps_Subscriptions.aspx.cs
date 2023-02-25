using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;


namespace Elite_system
{
    public partial class Rpt_Stamps_Subscriptions : System.Web.UI.Page
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
                DDL_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Employee.DataBind();
                DDL_Employee.Items.Insert(0, new ListItem("--اختر--", "0"));


                Txt_FromDate.Text = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");
                Txt_ToDate.Text = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");
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




                DateTime dt1 = DateTime.ParseExact(Txt_FromDate.Text, "yyyy-MM-dd", null);
                DateTime dt2 = DateTime.ParseExact(Txt_ToDate.Text, "yyyy-MM-dd", null);
                ReportParameter rp1 = new ReportParameter("From", Txt_FromDate.Text);
                ReportParameter rp2 = new ReportParameter("To", Txt_ToDate.Text);
                if (DDL_Medical_Name.SelectedIndex == 0 && DDL_Employee.SelectedIndex != 0)
                {
                    cmd.CommandText = "SELECT Medical_Type, Medical_TypeName,Employee,type," +
                                    " IIF(substring([Description], 1, 7) like N'%طوابع%', sum(Debtor),0 ) as Stamps," +
                                    " IIF(substring([Description], 1, 7) like N'%أتعاب%', sum(Debtor),0 )as Subscription" +
                                    " FROM v_net1" +
                                    " where(" +
                                    " [Bond_Date] between '" + Txt_FromDate.Text + "' and '" + Txt_ToDate.Text + "'" +
                                    " and [Employee] = N'" + DDL_Employee.SelectedItem.Text + "'" +
                                    " and (substring([Description], 1, 7) like N'%طوابع%' or" +
                                    " substring([Description], 1, 7) like N'%أتعاب%'))" +
                                    " group by Medical_Type,Medical_TypeName,Employee,substring([Description],1,7),type" +
                                    " order by Employee desc";
                }
                else if (DDL_Employee.SelectedIndex == 0 && DDL_Medical_Name.SelectedIndex != 0)
                {
                    cmd.CommandText = "SELECT Medical_Type, Medical_TypeName,Employee,type," +
                                " IIF(substring([Description], 1, 7) like N'%طوابع%', sum(Debtor),0 ) as Stamps," +
                                " IIF(substring([Description], 1, 7) like N'%أتعاب%', sum(Debtor),0 )as Subscription" +
                                " FROM v_net1" +
                                " where(Medical_Type = " + long.Parse(DDL_Medical_Name.SelectedValue) + "" +
                                " and [Bond_Date] between '" + Txt_FromDate.Text + "' and '" + Txt_ToDate.Text + "'" +
                                " and (substring([Description], 1, 7) like N'%طوابع%' or" +
                                " substring([Description], 1, 7) like N'%أتعاب%'))" +
                                " group by Medical_Type,Medical_TypeName,Employee,substring([Description],1,7),type" +
                                " order by Employee desc";
                }
                else if (DDL_Employee.SelectedIndex != 0 && DDL_Medical_Name.SelectedIndex != 0)

                {
                    cmd.CommandText = "SELECT Medical_Type, Medical_TypeName,Employee,type," +
                                   " IIF(substring([Description], 1, 7) like N'%طوابع%', sum(Debtor),0 ) as Stamps," +
                                   " IIF(substring([Description], 1, 7) like N'%أتعاب%', sum(Debtor),0 )as Subscription" +
                                   " FROM v_net1" +
                                   " where(Medical_Type = " + long.Parse(DDL_Medical_Name.SelectedValue) + "" +
                                   " and [Bond_Date] between '" + Txt_FromDate.Text + "' and '" + Txt_ToDate.Text + "'" +
                                   " and [Employee] = N'" + DDL_Employee.SelectedItem.Text + "'" +
                                   " and(substring([Description], 1, 7) like N'%طوابع%' or" +
                                   " substring([Description], 1, 7) like N'%أتعاب%'))" +
                                   " group by Medical_Type,Medical_TypeName,Employee,substring([Description],1,7),type" +
                                   " order by Employee desc";
                }

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Result);
                Cls_Connection.close_connection();
                ////لجلب رصيد بداية المدة
                //cmd.Parameters.Clear();

                //Cls_Connection.open_connection();
                //cmd.Connection = con;
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "Get_V_Listing_Bonds_Start";

                //cmd.Parameters.AddWithValue("@From", dt1);
                //cmd.Parameters.AddWithValue("@To", dt2);
                //cmd.Parameters.AddWithValue("@Medical_Type", long.Parse(DDL_Medical_Name.SelectedValue));

                //SqlDataReader dr = cmd.ExecuteReader();

                //ReportParameter rp3 = new ReportParameter();
                //ReportParameter rp4 = new ReportParameter();
                //ReportParameter rp5 = new ReportParameter();
                //if (dr.HasRows)
                //{
                //    if (dr.Read())
                //    {
                //        string StartDesc = dr.GetValue(dr.GetOrdinal("Description")).ToString();
                //        decimal StartCreditor = decimal.Parse(dr["Creditor"].ToString());
                //        decimal StartDebtor = decimal.Parse(dr["Debtor"].ToString());


                //        rp3 = new ReportParameter("StartDesc", StartDesc);
                //        rp4 = new ReportParameter("StartDebtor", StartDebtor.ToString());
                //        rp5 = new ReportParameter("StartCreditor", StartCreditor.ToString());
                //    }
                //}

                //Cls_Connection.close_connection();
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Rpt_Stamps_Subscriptions.rdlc");
                ReportViewer1.LocalReport.SetParameters(rp1);
                ReportViewer1.LocalReport.SetParameters(rp2);

                //ReportViewer1.LocalReport.SetParameters(rp3);
                //ReportViewer1.LocalReport.SetParameters(rp4);
                //ReportViewer1.LocalReport.SetParameters(rp5);

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DS_Stamps_Subscriptions22", dt_Result));
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


                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Ticket_GetTicket", SqlDataSource1));


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