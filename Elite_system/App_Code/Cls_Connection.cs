using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;




public class Cls_Connection
{
    #region Filed

    static private SqlConnection con = new SqlConnection();

    #endregion


    #region Propties

    static public SqlConnection _con
    {
        get { return con; }
        set { con = value; }
    }

    #endregion


    #region Methods


    static public void open_connection()
    {
        try
        {

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

        }
        catch (Exception ex)
        {
            string x = ex.Message.ToString();
           
        }


    }

    static public void close_connection()
    {
        try
        {

            //con.ConnectionString = ConfigurationManager.ConnectionStrings["CON"].ToString();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }
        catch (Exception)
        {

            throw;
        }


    }

    #endregion

}

////////////////////



