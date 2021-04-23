using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
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
            GetClaims();
        }

        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetClaims();
        }


        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sub_ClaimID.Text = GridView.SelectedRow.Cells[1].Text;
                main_ClaimID.Text = GridView.SelectedRow.Cells[2].Text;
                Patient_Name.Text = GridView.SelectedRow.Cells[8].Text;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
            }
        }
        int Attch_Id;
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sub_ClaimID.Text != "" && main_ClaimID.Text != null && Patient_Name.Text != null)
                {
                    if (Txt_PayAmmount.Text != "")
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                        con = Cls_Connection._con;
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "update Sub_Claims set PayValue = '" + Txt_PayAmmount.Text + "' WHERE Main_Claims_ID= '" + main_ClaimID.Text + "' AND ID= '" + Sub_ClaimID.Text + "' AND patient_name = N'" + Patient_Name.Text + "'";
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Cls_Connection.close_connection();
                        Sub_ClaimID.Text = null;
                        main_ClaimID.Text = null;
                        Patient_Name.Text = null;
                        Txt_PayAmmount.Text = "";
                        GetClaims();
                        MSG("تم دفع المبلغ");
                    }
                    else
                    {
                        MSG("حدد المبلغ المدفوع");
                    }
                }
                else
                {
                    MSG("يجب اختيار مريض اولاً");
                }
            }
            catch (Exception ex)
            {

                Cls_Connection.close_connection();
            }

        }

        protected void GetClaims()
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
                lbl_count.Text = dt.Rows.Count.ToString();
                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
            }
        }

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {
            HttpFileCollection flImages = Request.Files;
            try
            {
                if (Sub_ClaimID.Text != "" && main_ClaimID.Text != null && Patient_Name.Text != null)
                {

                    //rami
                        int attach_type = 300;
                    string attach_place_store;
                    int strImageName = int.Parse(Sub_ClaimID.Text);
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd2 = new SqlCommand();
                    DataSet ds = new DataSet();
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                    cmd2.Connection = conn;
                    conn.Open();
                    DateTime datevalue = (DateTime.UtcNow.AddHours(3));
                    string dd = datevalue.Day.ToString();
                    string mm = datevalue.Month.ToString();
                    string yy = datevalue.Year.ToString();

                    try
                    {
                        HttpFileCollection flImages2 = Context.Request.Files;

                        for (int i = 0; i < flImages2.Count; i++)
                        {

                            cmd2.CommandText = "Select IDENT_CURRENT('Attachments')";
                            Attch_Id = int.Parse(cmd2.ExecuteScalar().ToString()) + 1;

                            HttpPostedFile userPostedFile = flImages[i];
                            if (userPostedFile.ContentLength > 0)
                            {
                                if (System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".png" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".bmp" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".pdf" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".docx" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".xlsx")

                                {
                                    string strConnString = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;

                                    using (SqlConnection con2 = new SqlConnection(strConnString))
                                    {
                                        string path = System.IO.Path.GetExtension(userPostedFile.FileName);
                                        attach_place_store = "\\\\Claims" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + path;
                                        using (SqlCommand cmd1 = new SqlCommand())
                                        {
                                            cmd1.CommandType = CommandType.StoredProcedure;
                                            cmd1.CommandText = "SP_Attachments";
                                            cmd1.Parameters.AddWithValue("@attach_type", attach_type);
                                            cmd1.Parameters.AddWithValue("@attach_Path", attach_place_store);
                                            cmd1.Parameters.AddWithValue("@attach_doc_id", strImageName);
                                            cmd1.Parameters.AddWithValue("@check", "i");
                                            cmd1.Connection = con2;
                                            con2.Open();
                                            cmd1.ExecuteNonQuery();
                                            con2.Close();

                                            System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Claims\\" + yy + "\\" + mm + "\\" + dd + "\\"));
                                            userPostedFile.SaveAs(Server.MapPath("\\UploadedImages\\" + attach_place_store));
                                            MSG("تم تحميل المرفق ");
                                        }
                                    }


                                }
                                else
                                {
                                    MSG("الملف الذي قمت بإدخاله غير صالح");
                                }
                            }

                        }
                        conn.Close();
                    }

                    catch (Exception)
                    {

                        MSG("يرجى مراجعة مسؤول النظام");
                    }

                    //rami




                    Sub_ClaimID.Text = null;
                    main_ClaimID.Text = null;
                    Patient_Name.Text = null;
                    Txt_PayAmmount.Text = "";
                    GetClaims();
                   
                }


                else
                {
                    MSG("يجب اختيار مريض اولاً");
                }
            }


            catch (Exception ex)
            {

                Cls_Connection.close_connection();
            }
        }
    }
}