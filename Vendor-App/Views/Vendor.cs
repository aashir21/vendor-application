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
using Vendor_App.Utility;

namespace Vendor_App.Views
{
    public partial class Vendor : Form
    {
        public Vendor()
        {
            InitializeComponent();
        }

        VendorController VendorController = new VendorController();

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();

            home.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            

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

        private void button5_Click(object sender, EventArgs e)
        {
            VendorController.GetVendorById(int.Parse(textBox4.Text));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            VendorController.DeleteVendorById(int.Parse(textBox4.Text));
        }

        private void Vendor_Load(object sender, EventArgs e)
        {
            if (Vault.CurrentUser != null)
            {

                var role = Vault.CurrentUser.Role.ToString();

                if (role.Trim() == "ADMIN")
                {

                    //only users with the role "ADMIN" will have access to edit or delete a vendor

                    button4.Enabled = true;
                    button2.Enabled = true;
                    this.Refresh();
                }
                else
                {
                    button4.Enabled = false;
                    button2.Enabled = false;
                    this.Refresh();
                }

            }
        }
    }
}
