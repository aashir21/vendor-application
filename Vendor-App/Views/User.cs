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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Vendor_App.Views
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        //Creating new user btn
        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            UserController.CreateUser(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
        }


        //Show login page if user already regsitered in db
        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            login.Show();
            this.Hide();
        }
    }
}
