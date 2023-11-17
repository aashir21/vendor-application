using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendor_App.Models;
using Vendor_App.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vendor_App.Controllers
{
    internal class ProductController
    {
        Models.Product product = new Models.Product();

        public static void CreateProduct(int CompanyID, string SoftwareName, string TypeOfSoftware, string Description)
        {
            
            try
            {
              
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musta\\Source\\Repos\\vendor-application\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();

                SqlCommand cmd = new SqlCommand("Insert into [Product] values (@CompanyID, @SoftwareName, @TypeOfSoftware, @Description)", conn);

                cmd.Parameters.AddWithValue("CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("SoftwareName", SoftwareName);
                cmd.Parameters.AddWithValue("TypeOfSoftware", TypeOfSoftware);
                cmd.Parameters.AddWithValue("Description", Description);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Product Added.");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public static void UpdateProduct(int ProductID, int CompanyID, string SoftwareName, string TypeOfSoftware, string Description)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musta\\Source\\Repos\\vendor-application\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();

                SqlCommand cmd = new SqlCommand("Update [Product] set CompanyID=@CompanyID, SoftwareName=@SoftwareName, TypeOfSoftware=@TypeOfSoftware, Description=@Description where ProductID=@ProductID", conn);

                cmd.Parameters.AddWithValue("ProductID", ProductID);
                cmd.Parameters.AddWithValue("CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("SoftwareName", SoftwareName);
                cmd.Parameters.AddWithValue("TypeOfSoftware", TypeOfSoftware);
                cmd.Parameters.AddWithValue("Description", Description);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Product Information Updated.");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteProduct(int ProductID)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musta\\Source\\Repos\\vendor-application\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();

                SqlCommand cmd = new SqlCommand("Delete Product WHERE ProductID=@ProductID", conn);

                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Product Deleted.");
            }

            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void SearchByID(int ProductID)
        {
            
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musta\\Source\\Repos\\vendor-application\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ProductID=@ProductID", conn);

                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    reader.Read();
                    string ProductIdentification = reader["ProductID"].ToString();
                    string CompanyIdentification = reader["CompanyID"].ToString();
                    string NameOfSoftware = reader["SoftwareName"].ToString() ;
                    string SoftwareType = reader["TypeOfSoftware"].ToString();
                    string SoftwareDescription = reader["Description"].ToString();

                    MessageBox.Show($"Product ID: {ProductIdentification}\n\nCompany ID: {CompanyIdentification}\n\nSoftware Name: {NameOfSoftware}\n\nType of Software: {SoftwareType}\n\nDescription: {SoftwareDescription}");

                }

                else
                {
                    MessageBox.Show("Product not found.");
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Please check if you have entered the correct product ID");
            }
        }

        public static void SearchByName(string SoftwareName)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\musta\\Source\\Repos\\vendor-application\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE SoftwareName=@SoftwareName", conn);

                cmd.Parameters.AddWithValue("@SoftwareName", SoftwareName);

                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string ProductIdentification = reader["ProductID"].ToString();
                    string CompanyIdentification = reader["CompanyID"].ToString();
                    string NameOfSoftware = reader["SoftwareName"].ToString();
                    string SoftwareType = reader["TypeOfSoftware"].ToString();
                    string SoftwareDescription = reader["Description"].ToString();

                    MessageBox.Show($"Product ID: {ProductIdentification}\n\nCompany ID: {CompanyIdentification}\n\nSoftware Name: {NameOfSoftware}\n\nType of Software: {SoftwareType}\n\nDescription: {SoftwareDescription}");

                }

                else
                {
                    MessageBox.Show("Product not found.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please check if you have entered the correct software name");
            }
        }



    }
}
