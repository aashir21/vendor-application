using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor_App.Models
{
    public class File
    {

        public int FileID { get; set; }
        public string FileName { get; set; }
        public int VendorID { get; set; }  
        public File Files { get; set; } 

    }
}
