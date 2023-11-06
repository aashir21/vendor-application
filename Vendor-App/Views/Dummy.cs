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
    public partial class Dummy : Form
    {
        public Dummy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\vendor-application-main\\vendor-application-main\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into Dummy values (@dummy_id,@dummy_name,@dummy_email)", connection);
            cmd.Parameters.AddWithValue("@dummy_id",1);
            cmd.Parameters.AddWithValue("@dummy_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@dummy_email", textBox2.Text);
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("successfully added");
        }

        private void Dummy_Load(object sender, EventArgs e)
        {

        }
    }
}
