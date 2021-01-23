using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BackupDatabase()
        {
            try
            {
                string _ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();

                string _DatabaseName = "DB_A5D8AE_EliteSystem";
                //string _BackupName = _DatabaseName + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".bak";
                string _BackupName = _DatabaseName + ".bak";
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = _ConnectionString;
                sqlConnection.Open();
                string sqlQuery = "BACKUP DATABASE " + _DatabaseName + " TO DISK = 'C:\\SQLServerBackups\\" + _BackupName + "' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = '" + _BackupName + "';";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                int iRows = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                lblMessage.Text = "The " + _DatabaseName + " database Backup with the name " + _BackupName + " successfully...";
                ReadBackupFiles();
            }
            catch (SqlException sqlException)
            {
                lblMessage.Text = sqlException.Message.ToString();
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.ToString();
            }
        }
        public void ReadBackupFiles()
        {
            try
            {
                if (!Directory.Exists(@"c:\SQLServerBackups\"))
                {
                    Directory.CreateDirectory(@"c:\SQLServerBackups\");
                }

                string[] files = Directory.GetFiles(@"c:\SQLServerBackups\", "*.bak");
                lstBackupfiles.DataSource = files;
                lstBackupfiles.DataBind();
                lstBackupfiles.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.ToString();
            }
        }

        protected void Btn_Backup_Click(object sender, EventArgs e)
        {
            BackupDatabase();
        }
    }
}