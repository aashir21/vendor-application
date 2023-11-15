using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor_App.Models
{
    internal class Product
    {

        public int ProductID { get; set; }
        public int CompanyID { get; set; }
        public string SoftwareName { get; set; }

        public string TypeOfString {  get; set; }
        public string Description { get; set; }

    }
}
