using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceAsync.Models
{
    internal class ItemA
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string PurchaseItem { get; set; }
        public string SalesItem { get; set; }
        public string InventoryItem { get; set; }
        public string ArTaxCode { get; set; }
        public string ApTaxCode { get; set; }
        //public string IndirectTax { get; set; }
        public int ItemsGroupCode { get; set; }
        public string U_SYP_TIPEXIST { get; set; }
        public string U_SYP_TIPUNMED { get; set; }
        public string U_SYP_CATEXIST { get; set; }
        public string U_SYP_CODSAPMA { get; set; }
    }
}
