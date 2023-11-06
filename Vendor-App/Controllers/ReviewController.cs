﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendor_App.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vendor_App.Controllers
{
    internal class ReviewController
    {
        Review review = new Review();
        public static void AddNewReview(int reviewid,int userid, int productid, string reviewtext, int rating)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\vendor-application-main\\vendor-application-main\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Review values (@ReviewID,@UserID,@ProductID,@ReviewText,@Rating)", conn);
                cmd.Parameters.AddWithValue("ReviewID", reviewid);
                cmd.Parameters.AddWithValue("UserID", userid);
                cmd.Parameters.AddWithValue("ProductID", productid);
                cmd.Parameters.AddWithValue("ReviewText", reviewtext);
                cmd.Parameters.AddWithValue("Rating", rating);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void DeleteReview(int reviewId) 
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\vendor-application-main\\vendor-application-main\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete Review where ReviewID=@ReviewID", conn);
                cmd.Parameters.AddWithValue("@ReviewID", reviewId);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("successfully deleted");
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void UpdateReview(int reviewid,int userid, int productid, string reviewtext, int rating)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\vendor-application-main\\vendor-application-main\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Review set UserID=@UserID, ProductID=@ProductID, ReviewText=@ReviewText, Rating=@Rating where ReviewID=@ReviewID", conn);
                cmd.Parameters.AddWithValue("ReviewID", reviewid);
                cmd.Parameters.AddWithValue("UserID", userid);
                cmd.Parameters.AddWithValue("ProductID", productid);
                cmd.Parameters.AddWithValue("ReviewText", reviewtext);
                cmd.Parameters.AddWithValue("Rating", rating);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Updated");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public int GetReviewById(int id)
        {
            return review.ReviewID;
        }

        public static SqlDataAdapter GetAllReviews()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Downloads\\vendor-application-main\\vendor-application-main\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Review", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return adapter;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
