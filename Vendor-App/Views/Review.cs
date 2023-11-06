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
            ReviewController.AddNewReview(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), textBox4.Text, int.Parse(textBox5.Text));
        }

        private void button2_Click(object sender, EventArgs e)  //get all reviews from review table
        {
            ReviewController.GetAllReviews();

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
    }
}
