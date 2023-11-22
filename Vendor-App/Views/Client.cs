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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vendor_App.Views
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if the text boxes are empty
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter both Company ID and Client Type.");
                return; 
            }

            
            
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\My Documents\\Development\\Vendor-App\\Vendor.mdf\";Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into [Client] values (@CompanyID,@TypeName)", con);
                cmd.Parameters.AddWithValue("@CompanyID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@TypeName", textBox2.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            UpdateClientForm updateForm = new UpdateClientForm();
            updateForm.Show();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            // Assuming textBoxSearch is the TextBox where the user enters the search term
            string searchTerm = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\My Documents\\Development\\Vendor-App\\Vendor.mdf\";Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();

                try
                {
                    // Use a parameterized query to search for the specified entry
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [Client] WHERE CompanyID LIKE @SearchTerm OR TypeName LIKE @SearchTerm", con);
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%"); // Use '%' for a partial match
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Display the search results in the DataGridView
                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching entries found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteClientForm deleteForm = new DeleteClientForm();
            deleteForm.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
