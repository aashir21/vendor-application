using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor_App.Models
{
    public class Product
    {

        public int ProductID { get; set; }
        public int CompanyID { get; set; }
        public string SoftwareName { get; set; }

        public string TypeOfSoftware {  get; set; }
        public string Description { get; set; }

        public Product(int productID, int companyID, string softwareName, string typeOfSoftware, string description)
        {
            ProductID = productID;
            CompanyID = companyID;
            SoftwareName = softwareName;
            TypeOfSoftware = typeOfSoftware;
            Description = description;
        }
        public Product()
        {
        }
    }
}
