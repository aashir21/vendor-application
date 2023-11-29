using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendor_App.Utility;
using Vendor_App.Views;


namespace Vendor_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e) //product btn
        {
            Product product = new Product();
            product.Show(this);
            this.Hide();
        }


        private void button3_Click(object sender, EventArgs e)  //client btn
        {
            Client client = new Client();
            client.Show(this);
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e) //review btn
        {
            Review review = new Review();
            review.Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)  //exit btn
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show(this);
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
            if(Vault.CurrentUser != null)
            {

                label1.Text = $"Hello, {Vault.CurrentUser.Username}";

                var role = Vault.CurrentUser.Role.ToString();
                
                if(role.Trim() == "ADMIN")
                {
                    button4.Enabled = true;
                    this.Refresh();
                }
                else
                {
                    button4.Enabled=false;
                    this.Refresh();
                }

            }
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vendor vendor = new Vendor();
            vendor.Show();
            this.Hide();
        }
    }
}
