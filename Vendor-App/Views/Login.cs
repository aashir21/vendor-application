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

namespace Vendor_App.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        //Show register page
        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        //Used to login a user
        private void button1_Click(object sender, EventArgs e)
        {
            LoginController.LoginUser(textBox1.Text,textBox2.Text);
        }
    }
}
