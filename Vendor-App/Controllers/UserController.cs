using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendor_App.Models;

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

                User user = new User(firstName,lastName,username,password,email,"USER");



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


    }
}
