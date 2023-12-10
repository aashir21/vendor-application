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
using System.Windows.Forms.VisualStyles;
using Vendor_App.Controllers;
using Vendor_App.Utility;

namespace Vendor_App.Views
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Hide();
        }

        
        //Return to home page button
        private void button8_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }


        // Add Button
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ProductController.CreateProduct(int.Parse(textBox7.Text), textBox8.Text, textBox9.Text, textBox10.Text);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Sorry, product could not be added.");
            }
        }   

        //Update Product
        private void button10_Click(object sender, EventArgs e)
        {
            // Try and Catch is used to handle any errors that might occur in the code block below.
            try
            {
                // Update Product method in Product Controller is called here and the method that is in it, to be executed.

                ProductController.UpdateProduct(int.Parse(textBox6.Text), int.Parse(textBox7.Text), textBox8.Text, textBox9.Text, textBox10.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, the product could not be updated. " +
                    "Maybe the details you entered did not match with database in order to update it.");
            }
        }


        //Delete product
        private void button11_Click(object sender, EventArgs e)
        {
            // Try and Catch is used to handle any errors that might occur in the code block below.

            try
            {
                // Calls DeletectProduct method of the ProductController.

                ProductController.DeleteProduct(int.Parse(textBox6.Text));
            }

            catch (Exception ex)
            {
                MessageBox.Show("Sorry, the product could not be deleted. Please check if the Product ID is correct.");
            }
        }

        //Search By Product ID
        private void button12_Click(object sender, EventArgs e)
        {
            ProductController.SearchByID(int.Parse(textBox6.Text));
        }

        //Search by Product Name
        private void button13_Click(object sender, EventArgs e)
        {
            ProductController.SearchByName(textBox8.Text);
        }


        // View All data
        private void button14_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

            conn.Open();

            // To display all product record.

            SqlCommand cmd = new SqlCommand("Select * from Product", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            if (Vault.CurrentUser != null)
            {

                var role = Vault.CurrentUser.Role.ToString();

                if (role.Trim() == "ADMIN")
                {

                    //only users with the role "ADMIN" will have access to edit or delete a vendor

                    button11.Enabled = true;
                    button10.Enabled = true;
                    this.Refresh();
                }
                else
                {
                    button11.Enabled = false;
                    button10.Enabled = false;
                    this.Refresh();
                }

            }
        }
    }
}
