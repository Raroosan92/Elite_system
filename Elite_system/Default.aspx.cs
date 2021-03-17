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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServerTime.Text = DateTimeOffset.UtcNow.AddHours(2).ToString();
            if (!IsPostBack)
            {
                ResetFreez();
            }
        }


        public void ResetFreez()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            Cls_Connection.open_connection();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select id , FreezTo from [dbo].[Medical_Types_And_Companies] where Freez = 1";
            SqlDataReader reader4 = cmd.ExecuteReader();
            try
            {
               
                while (reader4.Read())
                {
                   
                    if (!reader4.IsDBNull(0))
                    {
                        var x = reader4[1].ToString().Substring(0, 10);
                        var y = DateTime.UtcNow.AddHours(2).ToString().Substring(0,10);
                        if ( x == y)
                        {
                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                       
                            cmd.CommandText = "update [dbo].[Medical_Types_And_Companies] set FreezTo = Null , FreezFrom = Null , Freez = 0 where id = '" + reader4[0].ToString() + "'  ";
                            reader4.Close();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                reader4.Close();
                Cls_Connection.open_connection();
            }

            finally
            {
                reader4.Close();
                Cls_Connection.close_connection();
            }

        }
    }
}