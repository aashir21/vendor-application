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
using Vendor_App.Controllers;

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

        //Add Review Method
        private void button2_Click(object sender, EventArgs e)
        {
            ReviewController.AddNewReview(int.Parse(textBox2.Text), int.Parse(textBox3.Text), textBox4.Text, int.Parse(textBox5.Text));
        }


        //Get All Reviews Method
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Review", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }catch(Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        //Update Method

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ReviewController.UpdateReview(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), textBox4.Text, int.Parse(textBox5.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }


        // Delete Review Method
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ReviewController.DeleteReview(int.Parse(textBox1.Text));
            }catch(Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }


        //Get Review for a product method

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Review Where ProductID=@ProductID", conn);
                cmd.Parameters.AddWithValue("ProductID", int.Parse(textBox3.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
