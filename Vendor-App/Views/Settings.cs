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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserController.ChangeAccessRights(int.Parse(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserController.DeleteUser(int.Parse(textBox1.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserController.SearchUser(int.Parse(textBox1.Text));
        }
    }
}
