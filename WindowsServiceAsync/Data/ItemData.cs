using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceAsync.ServiceReferenceVentas;

namespace WindowsServiceAsync.Data
{
    internal class ItemData : IItemData
    {
        ServiceReferenceVentas.ServiceVentasClient objClient = new ServiceReferenceVentas.ServiceVentasClient();
        public DocumentRpta CreateEntrada(string token, string document)
        {
            return objClient.createEntrada(token, document);
        }

        public DocumentRpta CreateItem(string token, string document)
        {
            return objClient.createItem(token, document);
        }

        public bool ExistItem(string itemCode)
        {
            return objClient.ExistItem(itemCode);
        }

        public string Login()
        {
            return objClient.Login();
        }

        public bool UpdateItem(string token, string document, string id)
        {
            return objClient.updateItem(token, document, id);
        }
    }
}
