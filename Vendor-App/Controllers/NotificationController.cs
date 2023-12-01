using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vendor_App.Controllers
{
    internal class NotificationController
    {
        internal static DataTable ViewAllNotifications()
        {

            DataTable dataTable = new DataTable();

            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\My Documents\\Development\\Vendor-App\\Vendor.mdf\";Integrated Security=True;Connect Timeout=30");
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Notification]", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);


            return dataTable;
        }

        public void CreateNotification(string Text, DateTime Date)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\My Documents\\Development\\Vendor-App\\Vendor.mdf\";Integrated Security=True;Connect Timeout=30");

            sqlConnection.Open();

            SqlCommand insertCommand = new SqlCommand("Insert into [Notification] values (Text = @Text, Date = @Date)", sqlConnection);
            insertCommand.Parameters.AddWithValue("@Text", Text);
            insertCommand.Parameters.AddWithValue("@Date", Date);

            insertCommand.ExecuteNonQuery();
        }

        

    }
}
