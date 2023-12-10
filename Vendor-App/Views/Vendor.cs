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
using Vendor_App.Utility;

namespace Vendor_App.Views
{
    public partial class Vendor : Form
    {
        public Vendor()
        {
            InitializeComponent();
        }

        //Initialising object of vendor controller
        VendorController VendorController = new VendorController();


        //Showing home page
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();

            home.Show();
            this.Hide();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            VendorController.CreateVendor(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditVendor EditVendor = new EditVendor();
            EditVendor.Show();
            this.Hide();
        }

        //Vendor Info By Id
        private void button5_Click(object sender, EventArgs e)
        {
            VendorController.GetVendorById(int.Parse(textBox4.Text));
        }

        //Deleting a vendor
        private void button4_Click(object sender, EventArgs e)
        {
            VendorController.DeleteVendorById(int.Parse(textBox4.Text));
        }


        //Upon intialisation of form, perform these actions
        private void Vendor_Load(object sender, EventArgs e)
        {
            if (Vault.CurrentUser != null)
            {

                var role = Vault.CurrentUser.Role.ToString();

                if (role.Trim() == "ADMIN") //checking if logged in user has, "ADMIN" access or not
                {

                    //only users with the role "ADMIN" will have access to edit or delete a vendor

                    button4.Enabled = true; //if admin btns enabled
                    button2.Enabled = true;
                    this.Refresh();
                }
                else
                {
                    button4.Enabled = false; //if not admin btns disabled
                    button2.Enabled = false;
                    this.Refresh();
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

            conn.Open();

            // To display all product record.

            SqlCommand cmd = new SqlCommand("Select * from Vendor", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
