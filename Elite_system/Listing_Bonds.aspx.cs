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
    public partial class Listing_Bonds : System.Web.UI.Page
    {
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (DDL_Company_Search.SelectedItem.Text == "--اختر--")
                {
                    GridView_Bonds.DataSource = SqlDataSource_Bonds;
                    GridView_Bonds.DataBind();
                }
                else
                {
                    cmd.CommandText = "SELECT TOP (100) PERCENT dbo.Main_Listing_Bonds.ID, dbo.Medical_Types_And_Companies.Name, dbo.Codes.Description, dbo.Main_Listing_Bonds.Bond_Date FROM dbo.Main_Listing_Bonds LEFT OUTER JOIN dbo.Medical_Types_And_Companies ON dbo.Main_Listing_Bonds.Company = dbo.Medical_Types_And_Companies.ID LEFT OUTER JOIN dbo.Codes ON dbo.Main_Listing_Bonds.Type = dbo.Codes.ID WHERE(dbo.Medical_Types_And_Companies.Name = N'" + DDL_Company_Search.SelectedItem.Text + "') ORDER BY dbo.Main_Listing_Bonds.ID DESC";
                    Cls_Connection.open_connection();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    GridView_Bonds.DataSourceID = null;
                    GridView_Bonds.DataSource = dt;
                    GridView_Bonds.DataBind();
                    Cls_Connection.close_connection();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //--rami لتغيير التاريخ من لوحة المفاتيح--
            Txt_Bond_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender3.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 

            Btn_UpdateBonds.Visible = HttpContext.Current.User.IsInRole("Update");
            Btn_SaveBonds.Visible = HttpContext.Current.User.IsInRole("Add");

            Btn_UpdateSubBonds.Visible = HttpContext.Current.User.IsInRole("Update");
            Btn_SaveSubBonds.Visible = HttpContext.Current.User.IsInRole("Add");

            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                Btn_UpdateBonds.Visible = true;
                Btn_SaveBonds.Visible = true;
                Btn_UpdateSubBonds.Visible = true;
                Btn_SaveSubBonds.Visible = true;

            }

            if (!Page.IsPostBack)
            {
                DDL_Company.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Company.DataBind();
                //  DDL_Company.SelectedValue = "6822";
                DDL_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Company_Search.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Company_Search.DataBind();
                //  DDL_Company.SelectedValue = "6822";
                DDL_Company_Search.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Type.DataSource = Cls_Codes.Fill_DDL(7);
                DDL_Type.DataBind();
                //DDL_Type.SelectedValue = "296";
                DDL_Type.Items.Insert(0, new ListItem("--اختر--", "0"));

                Get_MainListing_Bonds_ForUpdate();
                Get_SubBonds_ForGridView();
                //GetSubListing_Bonds_ForUpdate();
            }
        }

        public void Get_MainListing_Bonds_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainListing_Bonds_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_Bonds.SelectedRow.Cells[1].Text));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                bool Result;

                string Bond_Date;
                DateTime Bond_Date2;

                while (dr.Read())
                {


                    Txt_ID.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();


                    if (!dr.IsDBNull(dr.GetOrdinal("Company")))
                    {
                        DDL_Company.SelectedValue = dr.GetValue(dr.GetOrdinal("Company")).ToString();
                    }


                    if (!dr.IsDBNull(dr.GetOrdinal("Type")))
                    {
                        DDL_Type.SelectedValue = dr.GetValue(dr.GetOrdinal("Type")).ToString();
                    }

                    Bond_Date = dr.GetValue(dr.GetOrdinal("Bond_Date")).ToString();
                    Result = DateTime.TryParse(Bond_Date, out Bond_Date2);
                    if (Result)
                    {
                        Txt_Bond_Date.Text = Bond_Date2.ToString("yyyy-MM-dd");
                    }




                }

                Cls_Connection.close_connection();


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        public void Get_SubBonds_ForGridView()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_SubBonds_ForGridView";
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView_SubBonds.DataSource = dt;
                GridView_SubBonds.DataBind();
                Cls_Connection.close_connection();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        public void GetSubListing_Bonds_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_SubListing_Bonds_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_SubBonds.SelectedRow.Cells[1].Text));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Txt_Accounting_Name.Text = dr.GetValue(dr.GetOrdinal("Accounting_Name")).ToString();
                    Txt_Acounting_No.Text = dr.GetValue(dr.GetOrdinal("Acounting_No")).ToString();
                    Txt_Creditor.Text = dr.GetValue(dr.GetOrdinal("Creditor")).ToString();
                    Txt_Debtor.Text = dr.GetValue(dr.GetOrdinal("Debtor")).ToString();
                    Txt_Statement.Text = dr.GetValue(dr.GetOrdinal("Statement")).ToString();
                    Txt_Trans.Text = dr.GetValue(dr.GetOrdinal("Trans")).ToString();
                    Txt_SubID.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();

                }

                Cls_Connection.close_connection();


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        public void Get_SubListing_Bonds_ForMainBond()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_SubBonds_ForMainBonds";
                cmd.Parameters.AddWithValue("@Main_Bonds_ID", Int64.Parse(Txt_ID.Text));
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView_SubBonds.DataSource = dt;
                GridView_SubBonds.DataBind();
                Cls_Connection.close_connection();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        protected void GridView_SubBonds_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubListing_Bonds_ForUpdate();
        }

        protected void GridView_Bonds_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_MainListing_Bonds_ForUpdate();
            Get_SubListing_Bonds_ForMainBond();
        }

        protected void Btn_UpdateBonds_Click(object sender, EventArgs e)
        {
            Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

            if (DDL_Company.SelectedValue != "")
            {
                Main_Listing_Bonds._Company = long.Parse(DDL_Company.SelectedValue);
            }

            if (DDL_Type.SelectedValue != "")
            {
                Main_Listing_Bonds._Type = int.Parse(DDL_Type.SelectedValue);
            }

            Main_Listing_Bonds._ID = long.Parse(Txt_ID.Text);

            if (Txt_Bond_Date.Text != "")
            {
                Main_Listing_Bonds._Bond_Date = DateTime.Parse(Txt_Bond_Date.Text);
            }

            string Result;
            Result = Main_Listing_Bonds.Update_Main_Listing_Bonds();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على سندات القيد الرئيسية على الشركة: " + DDL_Company.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            GridView_Bonds.DataBind();
            MSG(Result);
        }

        protected void Btn_SaveBonds_Click(object sender, EventArgs e)
        {
            Cls_Main_Listing_Bonds Main_Listing_Bonds = new Cls_Main_Listing_Bonds();

            if (DDL_Company.SelectedValue != "")
            {
                Main_Listing_Bonds._Company = long.Parse(DDL_Company.SelectedValue);
            }

            if (DDL_Type.SelectedValue != "")
            {
                Main_Listing_Bonds._Type = int.Parse(DDL_Type.SelectedValue);
            }

            Main_Listing_Bonds._ID = long.Parse(Txt_ID.Text);

            if (Txt_Bond_Date.Text != "")
            {
                Main_Listing_Bonds._Bond_Date = DateTime.Parse(Txt_Bond_Date.Text);
            }


            string Result;
            Result = Main_Listing_Bonds.Insert_Main_Listing_Bonds();
            GridView_Bonds.DataBind();
            MSG(Result);
        }

        protected void Btn_SaveSubBonds_Click(object sender, EventArgs e)
        {
            Cls_Sub_Listing_Bonds Sub_Listing_Bonds = new Cls_Sub_Listing_Bonds();
            if (Txt_ID.Text == "" || Txt_ID.Text == null)
            {
                MSG("يجب اختيار السند الرئيسي");
                return;
            }
            Sub_Listing_Bonds._Accounting_Name = Txt_Accounting_Name.Text;
            Sub_Listing_Bonds._Acounting_No = Txt_Acounting_No.Text;
            Sub_Listing_Bonds._Creditor = Txt_Creditor.Text;
            Sub_Listing_Bonds._Debtor = Txt_Debtor.Text;
            Sub_Listing_Bonds._Main_Listing_Bond_id = long.Parse(Txt_ID.Text);
            Sub_Listing_Bonds._Statement = Txt_Statement.Text;
            Sub_Listing_Bonds._Trans = Txt_Trans.Text;
            string Result = Sub_Listing_Bonds.Insert_Sub_Listing_Bonds();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "إضافة على سندات القيد الفرعية على الشركة: " + DDL_Company.SelectedItem.Text + " على رقم السند " + Txt_ID.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Get_SubBonds_ForGridView();
            MSG(Result);
        }

        protected void Btn_UpdateSubBonds_Click(object sender, EventArgs e)
        {

            Cls_Sub_Listing_Bonds Sub_Listing_Bonds = new Cls_Sub_Listing_Bonds();
            if (Txt_ID.Text == "" || Txt_ID.Text == null)
            {
                MSG("يجب اختيار السند الرئيسي");
                return;
            }
            Sub_Listing_Bonds._Accounting_Name = Txt_Accounting_Name.Text;
            Sub_Listing_Bonds._Acounting_No = Txt_Acounting_No.Text;
            Sub_Listing_Bonds._Creditor = Txt_Creditor.Text;
            Sub_Listing_Bonds._Debtor = Txt_Debtor.Text;
            Sub_Listing_Bonds._Main_Listing_Bond_id = long.Parse(Txt_ID.Text);
            Sub_Listing_Bonds._Statement = Txt_Statement.Text;
            Sub_Listing_Bonds._Trans = Txt_Trans.Text;
            Sub_Listing_Bonds._ID = Int64.Parse(Txt_SubID.Text);
            string Result = Sub_Listing_Bonds.Update_Sub_Listing_Bonds();
            Get_SubBonds_ForGridView();
            MSG(Result);
        }

        protected void GridView_SubBonds_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            Get_SubBonds_ForGridView();
            GridView_SubBonds.PageIndex = e.NewPageIndex;
            GridView_SubBonds.DataBind();
        }
    }
}