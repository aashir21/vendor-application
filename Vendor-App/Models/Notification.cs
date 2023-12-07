using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor_App.Models
{
    internal class Notification
    {

        public int NotificationID { get; set; }
        public string Text { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

    }
}
