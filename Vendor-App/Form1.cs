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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            

        }

        private void button6_Click_1(object sender, EventArgs e)  //uploading a file btn
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file to upload";
            openFileDialog.Filter = "All files (*.*)|*.*"; // You can filter for specific file types

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                string filePath = openFileDialog.FileName;

                // Read the contents of the file into a stream
                byte[] fileData;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        fileData = br.ReadBytes((int)fs.Length);
                    }
                }

               SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30"); 
               conn.Open();

                string sql = "INSERT INTO dbo.[File](FileName, FileData, VendorID) VALUES (@FileName, @FileData, @VendorID)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FileName", Path.GetFileName(filePath));
                    cmd.Parameters.AddWithValue("@FileData", fileData);
                    cmd.Parameters.AddWithValue("@VendorID", int.Parse(textBox1.Text));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("File uploaded successfully!");

                conn.Close();

            }
        }
    }
}
