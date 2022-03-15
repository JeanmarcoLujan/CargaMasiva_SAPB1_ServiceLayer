using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceAsync.Models
{
    internal class EntradaLines
    {

        public string ItemCode { get; set; }
        public string Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string WarehouseCode { get; set; }   
        public string AccountCode { get; set; }
    }
}
