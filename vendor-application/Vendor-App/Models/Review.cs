using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor_App.Models
{
    internal class Review
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; } // rating is out 5

    }
}
