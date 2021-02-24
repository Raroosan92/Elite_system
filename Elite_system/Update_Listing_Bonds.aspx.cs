﻿using System;
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
   
    public partial class Update_Listing_Bonds : System.Web.UI.Page
    {
        public string AcountingNO = "";
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
       
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Medical_Name.Text = GridView.SelectedRow.Cells[1].Text;
                Acounting_NO.Text = GridView.SelectedRow.Cells[6].Text;
                Claim_ID.Text = GridView.SelectedRow.Cells[7].Text;
                
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Medical_Name.Text != "" & Txt_Value.Text!=null)
                {

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con = Cls_Connection._con;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text; 
                    cmd.CommandText = "UPDATE [dbo].[Main_Listing_Bonds] SET [Debtor] = '"+Txt_Value.Text+"'    WHERE   [Acounting_NO] = '"+Txt_Acounting_NO.Text+"'";
                    Cls_Connection.open_connection();
                    cmd.ExecuteNonQuery();
                    Cls_Connection.close_connection();
                    Medical_Name.Text = null;
                    Acounting_NO.Text = null;
                    Claim_ID.Text = null;
                    Txt_Value.Text = null;
                    //Txt_Acounting_NO.Text = null;
                    GetBonds();
                    MSG("تم تعديل الحساب ");


                }
                else
                {
                    MSG("يجب اختيار حساب اولاً");
                }
            }
            catch (Exception ex)
            {

                Cls_Connection.close_connection();
            }

        }

        protected void GetBonds()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Listing_Bonds_Updates";
                 AcountingNO = Txt_Acounting_NO.Text;
              
                cmd.Parameters.AddWithValue("@Acounting_NO", AcountingNO);
               

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

        protected void Txt_Acounting_NO_TextChanged(object sender, EventArgs e)
        {
            GetBonds();
        }
    }
}