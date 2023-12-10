//Notification controller works as a real time notification panel.
//It basically fetches every newly made entry from the database and writes that down into the notification table.
//Controller then performs another task to fetch everything from notification table to grid view notification panel based in main dashboard.
//ViewAllNotifications() -- Shows a list of all notifications onto a data grid view.
//CreateNotification() -- Adds a new notification to the Notifications Table

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

        //Populate the Data Grid
        internal static DataTable ViewAllNotifications()
        {
            // Create a new data table
            DataTable dataTable = new DataTable();

            // Opem SQL Connection
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
            sqlConnection.Open();

            // Run the query
            SqlCommand sqlCommand = new SqlCommand("SELECT NotificationText, NotificationDate FROM [Notification]", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            //Populate the table from the query 
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }


        //Create Notification Method
        public static void CreateNotification(string NotificationText, DateTime NotificationDate)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

            //Opening SQL connection
            sqlConnection.Open();

            //Inserting values into table
            SqlCommand insertCommand = new SqlCommand("Insert INTO [Notification] (NotificationText, NotificationDate) values (@NotificationText, @NotificationDate)", sqlConnection);
            insertCommand.Parameters.AddWithValue("@NotificationText", NotificationText);
            insertCommand.Parameters.AddWithValue("@NotificationDate", NotificationDate);

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }



    }
}
