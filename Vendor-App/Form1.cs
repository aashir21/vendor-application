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
using Vendor_App.Controllers;
using Vendor_App.Models;
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

        private void button1_Click_1(object sender, EventArgs e) //show Product page
        {
            Views.Product product = new Views.Product();
            product.Show(this);
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e) //show Review page
        {
            Views.Review review = new Views.Review();
            review.Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)  //Stop the application -- Logout btn
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)  //Open Admin Settings panel
        {
            Settings settings = new Settings();
            settings.Show(this);
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Upon home page load, perform these actions

            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

            conn.Open();

            
            // Selecting names of vendors
            SqlCommand cmd = new SqlCommand("Select Name from Vendor", conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {

                    comboBox1.Items.Add(reader["Name"].ToString()); //Populating the combo box
                    
                }

                reader.Close();
                
                //Refreshing combo box to display all vendors from db
                comboBox1.Refresh();    
            }


                if (Vault.CurrentUser != null)
                {

                    label1.Text = $"Hello, {Vault.CurrentUser.Username}"; //dynamically setting user name on home page

                    var role = Vault.CurrentUser.Role.ToString();

                    if (role.Trim() == "ADMIN") //checking access rights
                    {
                        button4.Enabled = true; //if "ADMIN" , enable btn 
                        this.Refresh();
                    }
                    else
                    {
                        button4.Enabled = false; //if not ADMIN, disable btn
                        this.Refresh();
                    }

                    conn.Close(); //closing connection

                }

            DataTable notifications = NotificationController.ViewAllNotifications(); //populating data table with notifications


            dataGridView1.DataSource = notifications;
            for(int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 200; //setting width of every column in data table
            }

            dataGridView1.Columns[0].HeaderText = "Notification"; //renaming the column name of the frontend
           

        }


        //Show Vendors Page
        private void button5_Click(object sender, EventArgs e)
        {
            Views.Vendor vendor = new Views.Vendor();
            vendor.Show();
            this.Hide();
        }

        
        //Setting up file upload operations
        private void button6_Click_1(object sender, EventArgs e)  
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); //configuring file properties
            openFileDialog.Title = "Select a file to upload";
            openFileDialog.Filter = "All files (*.*)|*.*"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string filePath = openFileDialog.FileName; //storing file name

                
                byte[] fileData; //initialising array to store file data
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        fileData = br.ReadBytes((int)fs.Length);
                    }
                }

                //Opening connection
               SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30"); 
               conn.Open();

                int vendorId = 0;
                SqlCommand searchVendorQuery = new SqlCommand("Select VendorID FROM dbo.[Vendor] WHERE Name=@Name", conn);

                //Searching db
                searchVendorQuery.Parameters.AddWithValue("@Name", comboBox1.Text);

                object result = searchVendorQuery.ExecuteScalar();
                if (result != null)
                {
                    vendorId = Convert.ToInt32(result); //getting vendor id that was mapped to the name
                }


                //storing the file against the fetched vendor ID as foreign key
                string sql = "INSERT INTO dbo.[File](FileName, FileData, VendorID) VALUES (@FileName, @FileData, @VendorID)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FileName", Path.GetFileName(filePath));
                    cmd.Parameters.AddWithValue("@FileData", fileData);
                    cmd.Parameters.AddWithValue("VendorID", vendorId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("File uploaded successfully!");

                conn.Close(); //closing connection

            }
        }

        
    }
}
