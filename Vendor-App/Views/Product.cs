using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendor_App.Controllers;
using Vendor_App.Models;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Vendor_App.Views
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        // Go Back Button.
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        // Add button.
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                ProductController.CreateProduct(int.Parse(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text);
            }

            catch(Exception ex)
            {
                MessageBox.Show("Sorry, product could not be added.");
            }
        }

        //Update Button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                ProductController.UpdateProduct(int.Parse(textBox1.Text),int.Parse(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sorry, the product could not be updated. " +
                    "Maybe the details you entered did not match with database in order to update it.");
            }
        }

        // Delete Button.
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ProductController.DeleteProduct(int.Parse(textBox1.Text));
            }
            
            catch(Exception ex)
            {
                MessageBox.Show("Sorry, the product could not be deleted. Please check if the Product ID is correct.");
            }
        }

        // Search by ID button.
        private void button5_Click(object sender, EventArgs e)
        {
            

            ProductController.SearchByID(int.Parse(textBox1.Text));
        }

        // Search by Name button.
        private void button6_Click(object sender, EventArgs e)
        {
            ProductController.SearchByName(textBox3.Text);
        }

        // View All Button
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musta\\Source\\Repos\\vendor-application\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Product", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
