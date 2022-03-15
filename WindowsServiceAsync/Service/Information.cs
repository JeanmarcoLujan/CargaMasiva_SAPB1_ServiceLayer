using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceAsync.Data;
using WindowsServiceAsync.Models;
using WindowsServiceAsync.ServiceReferenceVentas;

namespace WindowsServiceAsync.Service
{
    class Information
    {
        public static void getData(string token)
        {
           // RegisterItemAndEntrada(token);

          // GetItems(token);

            UpdateItem(token);
        }

        static bool ValidateItem(string code)
        {
            ItemData itemData = new ItemData();
            bool existencSN = itemData.ExistItem(code);
            return existencSN;
        }

        static DocumentRpta createItem(ItemA item,  string token)
        {
            ItemData itemData = new ItemData();
            var doc = JsonConvert.SerializeObject(item);
            return itemData.CreateItem(token, doc);
        }

        static DocumentRpta updateItem(ItemB item, string token, string id)
        {
            ItemData itemData = new ItemData();
            var doc = JsonConvert.SerializeObject(item);
            return itemData.UpdateItem(token, doc, id);
        }

        static void GenerateEntrada(Entrada entrada, string token)
        {

            ItemData itemData = new ItemData();
            var doc = JsonConvert.SerializeObject(entrada);
            DocumentRpta documentRpta =  itemData.CreateEntrada(token, doc);
        }


        public static void WriteToFileA(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Result";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Result\\Resultado_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
        static  void GetItems(string token)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
            using (SqlCommand command = new SqlCommand("GET_ITEM", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Call Read before accessing data.
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Entrada entrada = new Entrada();
                            entrada.DocDate = "20220315";
                            entrada.DocDueDate = "20220315";

                            List<EntradaLines> lista = new List<EntradaLines>();


                            

                            for (int i = 0; i < 10; i++)
                            {
                                if (i == 9)
                                {
                                    EntradaLines entradaLines = new EntradaLines();
                                    entradaLines.ItemCode = "PR" + reader["tBarra"].ToString();
                                    entradaLines.Quantity = "1200";
                                    entradaLines.UnitPrice = 20.00;
                                    entradaLines.WarehouseCode = "001";
                                    entradaLines.AccountCode = "759901";
                                    lista.Add(entradaLines);
                                }
                                else
                                {
                                    EntradaLines entradaLines = new EntradaLines();
                                    entradaLines.ItemCode = "PR" + reader["tBarra"].ToString();
                                    entradaLines.Quantity = "1200";
                                    entradaLines.UnitPrice = 20.00;
                                    entradaLines.WarehouseCode = "0" + (i + 30).ToString();
                                    entradaLines.AccountCode = "759901";
                                    lista.Add(entradaLines);
                                }
                                


                            }



                            entrada.DocumentLines = lista;

                            GenerateEntrada(entrada, token);
                            WriteToFileA(reader["tBarra"].ToString());


                        }
                    }

                }
            }
        }

        static void RegisterItemAndEntrada(string token)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
            {

                using (SqlCommand command = new SqlCommand("SELECT DISTINCT tBarra, tDetallado FROM TPRODUCTO WHERE lCombinacion=0 AND LEN(tBarra)=8  ", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int cont = 1;
                        while (reader.Read())
                        {
                            var sdds1 = reader["tBarra"].ToString();

                            if (!ValidateItem(reader["tBarra"].ToString()))
                            {

                                ItemA item = new ItemA();
                                item.ItemCode = "PR" + reader["tBarra"].ToString();
                                item.ItemName = reader["tDetallado"].ToString();
                                item.ArTaxCode = "IGV";
                                item.PurchaseItem = "Y";
                                item.InventoryItem = "Y";
                                item.SalesItem = "Y";
                                item.ApTaxCode = "IGV";
                                item.ItemsGroupCode = 101;
                                // item.IndirectTax = "Y";
                                item.U_SYP_CATEXIST = "02";
                                item.U_SYP_CODSAPMA = reader["tBarra"].ToString();
                                item.U_SYP_CATEXIST = "1";
                                item.U_SYP_TIPUNMED = "BX";
                                item.U_SYP_TIPEXIST = "02";



                                DocumentRpta itemm = createItem(item, token);


                                WriteToFileA(reader["tBarra"].ToString() + "-" + reader["tDetallado"].ToString() + "-" + itemm.Message);

                                if (itemm.Registered)
                                {
                                    Entrada entrada = new Entrada();
                                    entrada.DocDate = "20220314";
                                    entrada.DocDueDate = "20220314";

                                    List<EntradaLines> lista = new List<EntradaLines>();

                                    EntradaLines entradaLines = new EntradaLines();
                                    entradaLines.ItemCode = "PR" + reader["tBarra"].ToString();
                                    entradaLines.Quantity = "1200";
                                    entradaLines.UnitPrice = 20.00;
                                    entradaLines.WarehouseCode = "034";
                                    entradaLines.AccountCode = "759901";


                                    lista.Add(entradaLines);

                                    entrada.DocumentLines = lista;

                                    GenerateEntrada(entrada, token);
                                }
                            }

                        }
                    }
                }
            }
        }

        static void UpdateItem(string token)
        {
            ItemB item = new ItemB();
            item.SalesItem = "Y";

            string id = "P2100001";

            updateItem(item, token, id);
        }
    }
}
