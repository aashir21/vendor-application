

using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Vendor_App.Controllers
{
    internal class ProductController
    {
        Models.Product product = new Models.Product();

        /*
         * Method to add product details by its Comapny ID, Software NAme, Type of Software and its description.
         * Parameters are CompanyID, SfotwareName, TypeOfSoftware and Description.
         */
        public static void CreateProduct(int CompanyID, string SoftwareName, string TypeOfSoftware, string Description)
        {

            // Try & Catch used to handle and print any error that might occur when this block runs.

            try
            {
                // Connection string for the datbase.

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                // Open SQL connection

                conn.Open();

                //SQL commands to insert values into the database.

                SqlCommand cmd = new SqlCommand("Insert into [Product] values (@CompanyID, @SoftwareName, @TypeOfSoftware, @Description)", conn);

                cmd.Parameters.AddWithValue("CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("SoftwareName", SoftwareName);
                cmd.Parameters.AddWithValue("TypeOfSoftware", TypeOfSoftware);
                cmd.Parameters.AddWithValue("Description", Description);

                // SQL method used when the query doesn't show any results. Best for the current use.

                cmd.ExecuteNonQuery();

                // Close SQL database connection.

                conn.Close();

                // To show message in a pop-up.

                MessageBox.Show("Product Added.");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /* 
         * Method to update product with parameters ProductID, CompanyID, SoftwareName , TypeOf Software and Description.
         */
        public static void UpdateProduct(int ProductID, int CompanyID, string SoftwareName, string TypeOfSoftware, string Description)
        {
            // Try and catch have been use to handle any errors in the code block when it is executed.

            try
            {
                // Connecting string for the database.

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                // Open SQL Connection with database.

                conn.Open();

                // SQL Command to update products with the parameters above.

                SqlCommand cmd = new SqlCommand("Update [Product] set CompanyID=@CompanyID, SoftwareName=@SoftwareName, TypeOfSoftware=@TypeOfSoftware, Description=@Description where ProductID=@ProductID", conn);

                cmd.Parameters.AddWithValue("ProductID", ProductID);
                cmd.Parameters.AddWithValue("CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("SoftwareName", SoftwareName);
                cmd.Parameters.AddWithValue("TypeOfSoftware", TypeOfSoftware);
                cmd.Parameters.AddWithValue("Description", Description);

                // SQL method used when query doesn't show any results. Best for the UPDATE purpose.

                cmd.ExecuteNonQuery();

                // Close connection.

                conn.Close();

                // Display message in pop-up window.

                MessageBox.Show("Product Information Updated.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         * Method to delete product with ProductID as parameters.
         */
        public static void DeleteProduct(int ProductID)
        {
            // Try and catch have been use to handle any errors in the code block when it is executed.

            try
            {
                // Connecting string for the database.

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                //SQL Command to open connection.

                conn.Open();

                //SQL query to delete product.

                SqlCommand cmd = new SqlCommand("SELECT * FROM [Product] WHERE ProductID=@ProductID", conn);

                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                // SQL method used when query doesn't show any results. Best for the UPDATE purpose.

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        SqlCommand deleteQuery = new SqlCommand("DELETE dbo.[Product] WHERE ProductID=@ProductID", conn);

                        deleteQuery.Parameters.AddWithValue("ProductID", ProductID);

                        reader.Close();
                        deleteQuery.ExecuteNonQuery();

                        // Display message in pop-up window
                        MessageBox.Show("Product deleted from system");
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.");
                    }
                }

                // Close connection.

                conn.Close();

                

                
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /* 
         * Method to search product by its ID.
         */
        public static void SearchByID(int ProductID)
        {
            // Try and Catch to handle errors that might occur in the code-block below.

            try
            {
                // Connection string

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                // SQL Connection open with database.

                conn.Open();

                // SELECT query to fetch product details by ID.

                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ProductID=@ProductID", conn);

                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                cmd.ExecuteNonQuery();

                // Declaration of reader variable. Assings results from Execute.Reader();

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

                // Message pop-ups.

                else
                {
                    MessageBox.Show("Product not found.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please check if you have entered the correct product ID");
            }
        }

        /*
         * Method to searc product by name.
         * */
        public static void SearchByName(string SoftwareName)
        {
            // Try and Catch to handle errors that might occur in the code-block below.

            try
            {
                // Connection string

                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                // SQL Connection open with database.

                conn.Open();

                // SQL SELECT Query.

                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE SoftwareName=@SoftwareName", conn);

                cmd.Parameters.AddWithValue("@SoftwareName", SoftwareName);

                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                // If-else statements to search the product by the name entered.

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

                // Message that will be displayed when the product is not found.
                else
                {
                    MessageBox.Show("Product not found.");
                }
            }

            // Message in pop-up window if the product name entered is incorrect.

            catch (Exception ex)
            {
                MessageBox.Show("Please check if you have entered the correct software name");
            }
        }



    }
}