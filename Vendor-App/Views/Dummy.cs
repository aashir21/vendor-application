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
    public partial class Dummy : Form
    {
        public Dummy()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DummyController.CreateDummy(4, textBox1.Text, textBox2.Text);

        }

        private void Dummy_Load(object sender, EventArgs e)
        {

        }
    }
}
