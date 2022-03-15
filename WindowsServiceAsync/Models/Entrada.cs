using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceAsync.Models
{
    internal class Entrada
    {
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }

        public virtual List<EntradaLines> DocumentLines { get; set; }
    }
}
