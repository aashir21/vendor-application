using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vendor_App.Models
{
    public class User
    {
        

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }


        public User(string firstName, string lastName, string username, string password, string email, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }

        public User()
        {
        }


    }

    



}
