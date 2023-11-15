using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Vendor_App.Views
{
    public partial class DeleteClientForm : Form
    {
        public DeleteClientForm()
        {
            InitializeComponent();
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            int clientID;
            if (!int.TryParse(textBox2.Text, out clientID))
            {
                MessageBox.Show("Please enter a valid Client ID.");
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\My Documents\\Development\\Vendor-App\\Vendor.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Client] WHERE ClientID = @ClientID", con);
                cmd.Parameters.AddWithValue("@ClientID", clientID);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Client deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Client not found.");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
