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

            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT NotificationText, NotificationDate FROM [Notification]", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);


            return dataTable;
        }

        public static void CreateNotification(string NotificationText, DateTime NotificationDate)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

            sqlConnection.Open();

            SqlCommand insertCommand = new SqlCommand("Insert INTO [Notification] (NotificationText, NotificationDate) values (@NotificationText, @NotificationDate)", sqlConnection);
            insertCommand.Parameters.AddWithValue("@NotificationText", NotificationText);
            insertCommand.Parameters.AddWithValue("@NotificationDate", NotificationDate);

            insertCommand.ExecuteNonQuery();
        }



    }
}
