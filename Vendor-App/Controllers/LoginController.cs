
//Login Controller is used to handle login operations
//LoginUser() -- Checks the credential of a user, does validations whether a user exists or not
// if successfully logged in, vault class object is initialised to store user data, 

using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Vendor_App.Utility;


namespace Vendor_App.Controllers
{
    internal class LoginController
    {


        public static void LoginUser(string username, string password)
        {

            try
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                connection.Open();

                SqlCommand searchCommand = new SqlCommand("SELECT Count(*) FROM dbo.[User] Where Username = @Username", connection);

                searchCommand.Parameters.AddWithValue("@Username", username);
                int userExists = (int)searchCommand.ExecuteScalar();

                if (userExists <= 0)  //checking if user already exists in db or not
                {
                    MessageBox.Show("User not found, please register");
                    return;
                }
                else
                {
                    SqlCommand SqlPass = new SqlCommand("SELECT Count(*) FROM dbo.[User] Where Username = @Username AND Password = @Password", connection);
                    SqlPass.Parameters.AddWithValue("@Username", username);
                    SqlPass.Parameters.AddWithValue("@Password", password);

                    int correctPass = (int)SqlPass.ExecuteScalar();

                    if(correctPass == 1)
                    {
                        

                        SqlCommand SqlRole = new SqlCommand("SELECT Role FROM [User] Where Username = @Username", connection);
                        SqlRole.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = SqlRole.ExecuteReader())
                        {
                            if (reader.Read()) // If there is a row to read
                            {
                                string role = reader["Role"].ToString(); // Read the role from the 'Role' column

                                Vault.CurrentUser = new UserInfo { Username = username, Role = role };  //initialise the vault class and intialise user info

                                Form1 form1 = new Form1();
                                form1.Show();

                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  //exception handling
            }
        }


    }
}
