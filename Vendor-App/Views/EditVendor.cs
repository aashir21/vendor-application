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
using Vendor_App.Models;


namespace Vendor_App.Views
{
    public partial class EditVendor : Form
    {
        public EditVendor()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditVendor_Load(object sender, EventArgs e)
        {

            
        }

        private void button2_Click(object sender, EventArgs e)  // Button used to fetch existing data from db and populate fields
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

            conn.Open();

            SqlCommand searchQuery = new SqlCommand("SELECT * FROM dbo.[Vendor] WHERE VendorID = @VendorID", conn);
            searchQuery.Parameters.AddWithValue("@VendorID", int.Parse(textBox11.Text));

            using (SqlDataReader reader = searchQuery.ExecuteReader())
            {
                if (reader.Read())
                {
                    string[] Vendor = new string[11];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Vendor[i] = reader[i].ToString();
                    }

                    //populating fields

                    textBox1.Text = Vendor[1];
                    textBox2.Text = Vendor[2];
                    textBox3.Text = Vendor[3];
                    textBox4.Text = Vendor[4];
                    textBox5.Text = Vendor[5];
                    textBox6.Text = Vendor[6];
                    textBox7.Text = Vendor[7];
                    textBox8.Text = Vendor[8];
                    textBox9.Text = Vendor[9];
                    textBox10.Text = Vendor[10];


                }
                else
                {
                    MessageBox.Show("Vendor not found");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //calling update method from VendorController

            VendorController.UpdateVendor(int.Parse(textBox11.Text),textBox1.Text,
                textBox2.Text, textBox3.Text,
                textBox4.Text, textBox5.Text,
                int.Parse(textBox6.Text), textBox7.Text,
                textBox8.Text, textBox9.Text,
                textBox10.Text);

        }

    }
}
