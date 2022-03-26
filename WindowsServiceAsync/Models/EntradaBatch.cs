using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceAsync.Models
{
    internal class EntradaBatch
    {
        public string ItemCode { get; set; }
        public string BatchNumber { get; set; }
        public string Quantity { get; set; }
    }
}
