using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceAsync.ServiceReferenceVentas;

namespace WindowsServiceAsync.Data
{
    interface IItemData
    {
        bool ExistItem(string itemCode);

        string Login();
        DocumentRpta CreateItem(string token, string document);

        DocumentRpta CreateEntrada(string token, string document);

        bool UpdateItem(string token, string document, string id);

    }
}
