using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendor_App.Models;
using Vendor_App.Views;

namespace Vendor_App.Controllers
{
    internal class UserController
    {

        

        public static void CreateUser(string firstName, string lastName, string username, string password, string email)
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand searchCommand = new SqlCommand("SELECT Count(*) FROM dbo.[User] Where Username = @Username OR Email = @Email", con);

                searchCommand.Parameters.AddWithValue("@Username", username);
                searchCommand.Parameters.AddWithValue("@Email", email);
                int userExists = (int)searchCommand.ExecuteScalar();

                if (userExists > 0)  //checking if user already exists in db or not
                {
                    MessageBox.Show("User already exists, please Log In.");
                    return;
                }


                //registering a new user
                SqlCommand insertCommand = new SqlCommand("INSERT INTO dbo.[User] (FirstName, LastName,Username, Password, Email) VALUES (@FirstName,@LastName,@Username,@Password,@Email)", con);

                if (firstName.Length < 3 || lastName.Length < 3)
                {
                    MessageBox.Show("First & Last name should be greater than 3 characters");
                    return;
                }
                
                string[] splitStr = email.Split('@');

                if (splitStr[splitStr.Length - 1] != "citisoft.com")
                {
                    MessageBox.Show("You need a Citisoft email to register");
                    return;
                }


                Models.User user = new Models.User(firstName,lastName,username,password,email,"USER");



                insertCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", user.LastName);
                insertCommand.Parameters.AddWithValue("@Username", user.Username);
                insertCommand.Parameters.AddWithValue("@Password", user.Password);
                insertCommand.Parameters.AddWithValue("@Email", user.Email);
                insertCommand.Parameters.AddWithValue("@Role", user.Role);

                insertCommand.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Account Registered!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: \n" + ex.Message);
            }

        }

        public static void ChangeAccessRights(int UserID)
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand searchCommand = new SqlCommand("SELECT Role from dbo.[User] WHERE UserID = @UserID", con);
                searchCommand.Parameters.AddWithValue("UserID", UserID);

                using (SqlDataReader reader = searchCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string role = reader["Role"].ToString();

                        if (role.Trim() == "ADMIN")
                        {
                            MessageBox.Show("User is already an admin");
                        }
                        else
                        {
                            SqlCommand insertCommand = new SqlCommand("Update [User] SET Role=@Role WHERE UserID=@UserID", con);
                            insertCommand.Parameters.AddWithValue("Role", "ADMIN");
                            insertCommand.Parameters.AddWithValue("UserID", UserID);
                            reader.Close();
                            insertCommand.ExecuteNonQuery();

                            MessageBox.Show("User Rights Changed");

                        }

                    }
                    else
                    {
                        MessageBox.Show($"Employee does not exist with ID: {UserID}");
                    }

                    con.Close();
                }
            }catch(Exception e)
            {
                MessageBox.Show("Something went wrong");
            }
        }


        public static void DeleteUser(int UserID)
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand searchQuery = new SqlCommand("SELECT * FROM dbo.[User] WHERE UserID = @UserID", con);
                searchQuery.Parameters.AddWithValue("@UserID", UserID);

                using (SqlDataReader reader = searchQuery.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        SqlCommand deleteQuery = new SqlCommand("DELETE dbo.[User] WHERE UserID=@UserID", con);

                        deleteQuery.Parameters.AddWithValue("UserID", UserID);

                        reader.Close();
                        deleteQuery.ExecuteNonQuery();
                        

                        MessageBox.Show("User deleted from system");
                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong");
            }


        }

        public static void SearchUser(int UserID)
        {
         

            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand searchQuery = new SqlCommand("SELECT * FROM dbo.[User] WHERE UserID = @UserID", con);
                searchQuery.Parameters.AddWithValue("@UserID", UserID);

                using (SqlDataReader reader = searchQuery.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string[] User = new string[7];

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            User[i] = reader[i].ToString();
                        } 

                        MessageBox.Show($"Vendor Details for: {User[1]} \n\n" +
                            $"User ID : {User[0]} \n" +
                            $"First Name: {User[1]} \n" +
                            $"Last Name: {User[2]} \n" +
                            $"Username: {User[3]} \n" +
                            $"Email: {User[5]}  \n" +
                            $"Role: {User[6]}  \n");
                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong");
            }


        }

    }
}
