using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

                slider.Visible = false;
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));



                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies3();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
                Btn_Upload.Visible = HttpContext.Current.User.IsInRole("Upload_Attach_Claim");
                Btn_Save.Visible = HttpContext.Current.User.IsInRole("Pay_Claim");
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Btn_Upload.Visible=true;
                    Btn_Save.Visible = true;
                }
                

               
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

                Get_Attachement();
                Get_Attachement2();
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
                        if (DDL_Status.SelectedIndex == 1)
                        {
                            cmd.CommandText = "update Sub_Claims set PayValue = '" + Txt_PayAmmount.Text + "' WHERE Main_Claims_ID= '" + main_ClaimID.Text + "' AND ID= '" + Sub_ClaimID.Text + "' AND patient_name = N'" + Patient_Name.Text + "'";
                        }

                        else
                        {
                            cmd.CommandText = "update Sub_Claims set PayValue = '" + Txt_PayAmmount.Text + "' WHERE Main_Claims_ID= '" + main_ClaimID.Text + "' AND ID= '" + Sub_ClaimID.Text + "' AND patient_name = ''";
                        }
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
                cmd.Parameters.AddWithValue("@Status", DDL_Status.SelectedIndex);

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


        public void Get_Attachement()
        {

            //ForAttachement

            //rami
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlDataAdapter da2 = new SqlDataAdapter();
            DataSet ds2 = new DataSet();
            SqlCommand cmd2 = new SqlCommand();

            cmd2.Connection = con;
            cmd2.CommandText = "select attach_Path,Attach_Id from Attachments where attach_doc_id=" + Convert.ToInt64(Sub_ClaimID.Text) + " and  (RIGHT(LOWER(attach_Path),3)='doc' or RIGHT(LOWER(attach_Path),4)='docx' or RIGHT(LOWER(attach_Path),3)='xls' or RIGHT(LOWER(attach_Path),4)='xlsx' or RIGHT(LOWER(attach_Path),3)='pdf') ";
            Cls_Connection.open_connection();
            cmd2.ExecuteNonQuery();
            da2.SelectCommand = cmd2;
            da2.Fill(ds2, "Attachments");

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    var str = ds2.Tables[0].Rows[i]["attach_Path"].ToString();
                    var str2 = str.Substring(str.LastIndexOf('.') + 1).ToLower().ToString();
                    if (str2.ToLower() == "pdf" || str2.ToLower() == "doc" || str2.ToLower() == "docx" || str2.ToLower() == "xls" || str2.ToLower() == "xlsx")
                    {
                        Rpt_Download.Visible = true;
                        Rpt_Download.DataSource = ds2;
                        Rpt_Download.DataMember = "Attachments";
                        Rpt_Download.DataBind();
                    }
                    //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));
                }
            }
            else
            {
                Rpt_Download.Visible = false;
                //slider.Visible = false;
                //RP_ImagesLi.DataSource = ds2;
                //RP_ImagesLi.DataMember = "Attachments";
                //RP_ImagesLi.DataBind();

                //RP_Image.DataSource = ds2;
                //RP_Image.DataMember = "Attachments";
                //RP_Image.DataBind();
            }
            //rami

            //ForAttachement

        }


        public void Get_Attachement2()
        {

            //ForAttachement

            //rami
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlDataAdapter da2 = new SqlDataAdapter();
            DataSet ds2 = new DataSet();
            SqlCommand cmd2 = new SqlCommand();

            cmd2.Connection = con;
            cmd2.CommandText = "select attach_Path,Attach_Id from Attachments where attach_doc_id=" + Convert.ToInt64(Sub_ClaimID.Text) + " and  " +
                "(RIGHT(LOWER(attach_Path),4)='jpeg' " +
                "or RIGHT(LOWER(attach_Path),3)='jpg' or " +
                "RIGHT(LOWER(attach_Path),3)='png' or" +
                " RIGHT(LOWER(attach_Path),3)='bmp')";
            Cls_Connection.open_connection();
            cmd2.ExecuteNonQuery();
            da2.SelectCommand = cmd2;
            da2.Fill(ds2, "Attachments");

            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    var str = ds2.Tables[0].Rows[i]["attach_Path"].ToString();
                    var str2 = str.Substring(str.LastIndexOf('.') + 1).ToLower().ToString();
                    if (str2.ToLower() == "jpeg" || str2.ToLower() == "jpg" || str2.ToLower() == "png" || str2.ToLower() == "bmp")
                    {
                        slider.Visible = true;
                        RP_ImagesLi.DataSource = ds2;
                        RP_ImagesLi.DataMember = "Attachments";
                        RP_ImagesLi.DataBind();

                        RP_Image.DataSource = ds2;
                        RP_Image.DataMember = "Attachments";
                        RP_Image.DataBind();
                    }
                    //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));
                }
            }
            else
            {
                slider.Visible = false;
                //RP_ImagesLi.DataSource = ds2;
                //RP_ImagesLi.DataMember = "Attachments";
                //RP_ImagesLi.DataBind();

                //RP_Image.DataSource = ds2;
                //RP_Image.DataMember = "Attachments";
                //RP_Image.DataBind();
            }
            //rami

            //ForAttachement

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
                                        attach_place_store = "\\\\Claims" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + userPostedFile.FileName;
                                        using (SqlCommand cmd1 = new SqlCommand())
                                        {
                                            try
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
                                            }
                                            catch
                                            {
                                                MSG("حدث خطأ");
                                            }
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
                        MSG("تم تحميل المرفق ");

                        Get_Attachement();
                        Get_Attachement2();
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

        protected void DDL_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetClaims();
        }

        protected void btnDeleteAttach_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
            {

                LinkButton btn = (LinkButton)sender;
                int attch_id = Convert.ToInt16(btn.CommandArgument);
                SqlConnection con = new SqlConnection();
                try
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con = Cls_Connection._con;
                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "select attach_Path from Attachments where  Attach_Id = " + DDl_Images.SelectedValue + "";
                    cmd.CommandText = "select attach_Path from Attachments where  Attach_Id = " + attch_id + "";
                    cmd.Connection = con;
                    con.Close();
                    con.Open();
                    string fileName = cmd.ExecuteScalar().ToString();
                    cmd.Parameters.Clear();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Attachments";
                    cmd.Parameters.AddWithValue("@Attach_Id", attch_id);
                    cmd.Parameters.AddWithValue("@check", "d");

                    cmd.ExecuteNonQuery();


                    con.Close();

                    //string dd = "C:\\Users\\Rami\\Desktop\\Rami&Shadi 13-1-2020\\Elite_system\\Elite_system\\UploadedImages" + fileName.Replace("\\\\","\\");
                    string dd = "\\UploadedImages" + fileName.Replace("\\\\", "\\");
                    string sss = Server.MapPath(dd);
                    if (File.Exists(sss))
                    {
                        File.Delete(sss);
                    }

                    //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));
                    //Get_MainClaims_ForUpdate2();
                    MSG("تم حذف الصورة بنجاح");
                }
                catch
                {
                    con.Close();
                    MSG("يوجد خطأ في حذف الصورة");
                }
            }
            else
            {
                MSG("انت لست مخول لحذف الصورة يرجى مراجعة مسؤول النظام");
            }
        }

        protected void btnDeletePic_Click(object sender, EventArgs e)
        {

            if (HttpContext.Current.User.IsInRole("Admin"))
            {

                LinkButton btn = (LinkButton)sender;
                int attch_id = Convert.ToInt16(btn.CommandArgument);
                SqlConnection con = new SqlConnection();
                try
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con = Cls_Connection._con;
                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "select attach_Path from Attachments where  Attach_Id = " + DDl_Images.SelectedValue + "";
                    cmd.CommandText = "select attach_Path from Attachments where  Attach_Id = " + attch_id + "";
                    cmd.Connection = con;
                    con.Close();
                    con.Open();
                    string fileName = cmd.ExecuteScalar().ToString();
                    cmd.Parameters.Clear();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Attachments";
                    cmd.Parameters.AddWithValue("@Attach_Id", attch_id);
                    cmd.Parameters.AddWithValue("@check", "d");

                    cmd.ExecuteNonQuery();


                    con.Close();

                    //string dd = "C:\\Users\\Rami\\Desktop\\Rami&Shadi 13-1-2020\\Elite_system\\Elite_system\\UploadedImages" + fileName.Replace("\\\\","\\");
                    string dd = "\\UploadedImages" + fileName.Replace("\\\\", "\\");
                    string sss = Server.MapPath(dd);
                    if (File.Exists(sss))
                    {
                        File.Delete(sss);
                    }

                    //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));
                    //Get_MainClaims_ForUpdate2();
                    MSG("تم حذف المرفق بنجاح");
                    Get_Attachement();
                    Get_Attachement2();
                }
                catch
                {
                    con.Close();
                    MSG("يوجد خطأ في حذف المرفق");
                }
            }
            else
            {
                MSG("انت لست مخول لحذف الصورة يرجى مراجعة مسؤول النظام");
            }
        }
    }
}