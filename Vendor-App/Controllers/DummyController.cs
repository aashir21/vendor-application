using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vendor_App.Controllers
{
    internal class DummyController
    {
        public static void CreateDummy(int id, string name, string email)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\project\\vendor-application\\Vendor-App\\Vendor.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand cmd = new SqlCommand("insert into Dummy values (@DummyID, @DummyName, @DummyEmail)", con);


                cmd.Parameters.AddWithValue("@DummyID", id);
                cmd.Parameters.AddWithValue("@DummyName", name);
                cmd.Parameters.AddWithValue("@DummyEmail", email);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Successfully Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
                throw (ex);
            }
        }
    }
}
