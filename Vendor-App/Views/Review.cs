using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendor_App.Controllers;
using Vendor_App.Models;

namespace Vendor_App.Views
{
    public partial class Review : Form 
    {
        public Review()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReviewController.AddNewReview( int.Parse(textBox2.Text), int.Parse(textBox3.Text), textBox4.Text, int.Parse(textBox5.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ReviewController.UpdateReview(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), textBox4.Text, int.Parse(textBox5.Text));
            }catch(Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReviewController.DeleteReview(int.Parse(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)  //get all reviews from review table
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\vendor-application-main\\vendor-application-main\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Review", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\vendor-application-main\\vendor-application-main\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Review Where ProductID=@ProductID", conn);
            cmd.Parameters.AddWithValue("ProductID", int.Parse(textBox3.Text));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
