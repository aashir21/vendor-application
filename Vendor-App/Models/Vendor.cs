using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor_App.Models
{
    internal class Vendor
    {
        public int VendorID { get; set; }
        public string Name { get; set; }
        public String EstablishedAt { get; set; }
        public String Address { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public int NoOfEmployees { get; set; }
        public bool IsInternational { get; set; }
        public String LastDemo { get; set; }
        public String LastReviewed { get; set; }
        public String CompanyWebsite { get;set; }

    }
}
