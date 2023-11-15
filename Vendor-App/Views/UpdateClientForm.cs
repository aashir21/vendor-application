using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vendor_App.Views
{
    public partial class UpdateClientForm : Form
    {
        public UpdateClientForm()
        {
            InitializeComponent();
        }

        private void UpdateClientForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clientID = int.Parse(textBox1.Text);
            int companyID = int.Parse(textBox2.Text);
            string typeName = textBox3.Text;
                                                   

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\My Documents\\Development\\Vendor-App\\Vendor.mdf\";Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Client] SET CompanyID = @CompanyID, TypeName = @TypeName WHERE ClientID = @ClientID", con);
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                cmd.Parameters.AddWithValue("@TypeName", typeName);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
            }
        }
        
    }
}
