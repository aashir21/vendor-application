﻿

using System;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Vendor_App.Controllers
{
    public class VendorController
    {
        public void CreateVendor(string name, string establishedAt,string website)
        {

            try
            {

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();

                SqlCommand searchCommand = new SqlCommand("SELECT Count(*) FROM dbo.[Vendor] Where Name = @Name", conn);
                searchCommand.Parameters.AddWithValue("@Name", name);

                int vendorExists = (int)searchCommand.ExecuteScalar();

                if (vendorExists > 0)  //checking if vendor already exists in db or not
                {
                    MessageBox.Show("Vendor already exists.");
                    return;
                }

                SqlCommand insertCommand = new SqlCommand("INSERT INTO dbo.[Vendor] (Name, EstablishedAt, CompanyWebsite) VALUES (@Name, @EstablishedAt, @CompanyWebsite)", conn);

                if (name.Length < 3)  //validating that vendor name should be atleast 3 chars
                {
                    MessageBox.Show("Vendor name should be atleast 3 characters");
                    return;
                }

                if(establishedAt.Length < 3 || website.Length < 3) {

                    MessageBox.Show("Established At & Website are a required field");
                    return;

                }



                Models.Vendor vendor = new Models.Vendor(); //creating model object to make full use of MVC model

                vendor.Name = name;
                vendor.EstablishedAt = establishedAt;
                vendor.CompanyWebsite = website;

                //choosing only name, establishedat, website as cumpolsory choice, 
                // as a vendor may not have all the required fields at time of creation
                //Vendors can be edited later at any point, through EditVendor form 

                insertCommand.Parameters.AddWithValue("@Name", vendor.Name);
                insertCommand.Parameters.AddWithValue("@EstablishedAt", vendor.EstablishedAt);
                insertCommand.Parameters.AddWithValue("@CompanyWebsite", vendor.CompanyWebsite);


                insertCommand.ExecuteNonQuery();

                conn.Close();

                //Calling notification controller method once new vendor is added
                NotificationController.CreateNotification($"{vendor.Name} was added as a vendor", DateTime.Now);
                MessageBox.Show("Vendor Added!");
                

            }
            catch (Exception ex) { 

                MessageBox.Show("Something went wrong");
            }

        }

        public void GetVendorById(int VendorID)
        {
            try
            {

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();

                //query to check if user is present in table
                SqlCommand searchQuery = new SqlCommand("SELECT * FROM dbo.[Vendor] WHERE VendorID = @VendorID", conn);
                searchQuery.Parameters.AddWithValue("@VendorID", VendorID);

                using(SqlDataReader reader = searchQuery.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string[] Vendor = new string[11];  //creating a vendor array to store columns fields.

                        for(int i=0; i<reader.FieldCount; i++)
                        {
                            Vendor[i] = reader[i].ToString(); //populating array with fields
                        }


                        //displaying vendor details
                        MessageBox.Show($"Vendor Details for: {Vendor[1]} \n\n" +
                            $"Vendor ID : {Vendor[0]} \n" +
                            $"Name: {Vendor[1]} \n" +
                            $"Established At: {Vendor[2]} \n" +
                            $"Address: {Vendor[3]} \n" +
                            $"Country: {Vendor[4]} \n" +
                            $"City: {Vendor[5]}  \n" +
                            $"Number Of Employees: {Vendor[6]}  \n" +
                            $"Is International: {Vendor[7]}  \n" +
                            $"Last Demo: {Vendor[8]}  \n" +
                            $"Last Reviewed: {Vendor[9]}  \n" +
                            $"Company Website: {Vendor[10]} \n");
                    }
                    else
                    {
                        //if vendor not found
                        MessageBox.Show("Vendor not found");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        internal static void UpdateVendor(int VendorID,string Name, string EstablishedAt, string Address, string Country, string City, int NoOfEmployees, string IsInternational, string LastDemo, string LastReviewed, string CompanyWebsite)
        {
            try
            {

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                conn.Open();

                SqlCommand searchQuery = new SqlCommand("Update Vendor set Name=@Name, EstablishedAt=@EstablishedAt, Address=@Address, Country=@Country, City=@City, NoOfEmployees=@NoOfEmployees, IsInternational=@IsInternational, LastDemo=@LastDemo, LastReviewed=@LastReviewed, CompanyWebsite=@CompanyWebsite WHERE VendorID=@VendorID", conn);

                //Inserting data to update vendor
                searchQuery.Parameters.AddWithValue("VendorID", VendorID);
                searchQuery.Parameters.AddWithValue("Name", Name);
                searchQuery.Parameters.AddWithValue("EstablishedAt", EstablishedAt);
                searchQuery.Parameters.AddWithValue("Address", Address);
                searchQuery.Parameters.AddWithValue("Country", Country);
                searchQuery.Parameters.AddWithValue("City", City);
                searchQuery.Parameters.AddWithValue("NoOfEmployees", NoOfEmployees);
                searchQuery.Parameters.AddWithValue("IsInternational", IsInternational);
                searchQuery.Parameters.AddWithValue("LastDemo", LastDemo);
                searchQuery.Parameters.AddWithValue("LastReviewed", LastReviewed);
                searchQuery.Parameters.AddWithValue("CompanyWebsite", CompanyWebsite);


                searchQuery.ExecuteNonQuery();


                MessageBox.Show("Vendor Updated!");

                //Calling notification controller method once new vendor is updated
                NotificationController.CreateNotification($"{Name.Trim()} vendor was updated", DateTime.Now);

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        public void DeleteVendorById(int vendorID)
        {
            try
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                    con.Open();

                    SqlCommand searchQuery = new SqlCommand("SELECT * FROM dbo.[Vendor] WHERE VendorID = @VendorID", con);
                    searchQuery.Parameters.AddWithValue("@VendorID", vendorID);

                    using (SqlDataReader reader = searchQuery.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SqlCommand deleteQuery = new SqlCommand("DELETE dbo.[Vendor] WHERE VendorID=@VendorID", con); //checking vendor exists or not

                            deleteQuery.Parameters.AddWithValue("VendorID", vendorID);

                            reader.Close();
                            deleteQuery.ExecuteNonQuery();


                            MessageBox.Show("Vendor deleted from system");
                        }
                        else
                        {
                            MessageBox.Show("Vendor not found");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong"); //exception handling
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }

        }

    }
}
