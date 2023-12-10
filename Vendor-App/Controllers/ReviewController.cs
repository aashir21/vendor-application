//Review controller is supposed to handle all operations done by Review API and contains
//AddNewReview() -- Adds a new review
//DeleteReview() -- Deletes a review by entering a ReviewID
//UpdateReview() -- Update a review by entering a ReviewID
//GetAllReviews() --  Shows a list of all the Reviews created
//and GetReviewByProductID() -- Get all reviews against a specific product

using System;

using System.Data.SqlClient;

using System.Windows.Forms;
using Vendor_App.Models;


namespace Vendor_App.Controllers
{
    internal class ReviewController
    {
        Review review = new Review();
        public static void AddNewReview(int userid, int productid, string reviewtext, int rating) // add new review in the review table
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into [Review] values (@UserID,@ProductID,@ReviewText,@Rating)", conn);



                cmd.Parameters.AddWithValue("UserID", userid);
                cmd.Parameters.AddWithValue("ProductID", productid);
                cmd.Parameters.AddWithValue("ReviewText", reviewtext);
                cmd.Parameters.AddWithValue("Rating", rating);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Added Review");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  //exception handling
            }
        }
        public static void DeleteReview(int reviewId) // delete review in the review table by passing reviewid 
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete Review where ReviewID=@ReviewID", conn);  //deleting review mapped to an ID
                cmd.Parameters.AddWithValue("@ReviewID", reviewId);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully deleted");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void UpdateReview(int reviewid, int userid, int productid, string reviewtext, int rating) // update review in the review table
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aashi\\OneDrive\\Desktop\\vendor-application-user\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open(); //opening sql connection
                SqlCommand cmd = new SqlCommand("Update Review set UserID=@UserID, ProductID=@ProductID, ReviewText=@ReviewText, Rating=@Rating where ReviewID=@ReviewID", conn);
                cmd.Parameters.AddWithValue("ReviewID", reviewid);
                cmd.Parameters.AddWithValue("UserID", userid);
                cmd.Parameters.AddWithValue("ProductID", productid);
                cmd.Parameters.AddWithValue("ReviewText", reviewtext);
                cmd.Parameters.AddWithValue("Rating", rating);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
    }
}