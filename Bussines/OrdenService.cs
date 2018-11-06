using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class OrdenService : ServiceUtil
    {
        public static List<Orden> buscarOrdenesCust(String custid)
        {
            try
            {
                ServiceResponse srProduct = consumirServicio("GET", Constants.URL_ORDENES + "orden/buscar/porCliente/" + custid, null);
                if (srProduct.code.Equals(HttpStatusCode.OK))
                {
                    JObject jProduct = JObject.Parse(srProduct.content);
                    IList<JToken> results = jProduct["collectionOrdenes"].Children().ToList();

                    List<Orden> ordenes = new List<Orden>();
                    foreach (JToken result in results)
                    {
                        Orden searchResult = result.ToObject<Orden>();
                        ordenes.Add(searchResult);
                    }
                    return ordenes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                String algo = e.Message;
                return null;
            }
        }

        public static List<ElementosOrden> buscarItemOrden(String orderid)
        {
            try
            {
                ServiceResponse srProduct = consumirServicio("GET", Constants.URL_ORDENES + "items/buscar/porOrden/" + orderid, null);
                if (srProduct.code.Equals(HttpStatusCode.OK))
                {
                    JObject jProduct = JObject.Parse(srProduct.content);
                    IList<JToken> results = jProduct["collectionItems"].Children().ToList();

                    List<ElementosOrden> items = new List<ElementosOrden>();
                    foreach (JToken result in results)
                    {
                        ElementosOrden searchResult = result.ToObject<ElementosOrden>();
                        items.Add(searchResult);
                    }
                    return items;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static Boolean crearOrden(OrdenCarrito order)
        {
            try
            {
                ServiceResponse srOrder = consumirServicio("POST", Constants.URL_ORDENES + "orden/crear", order);
                if (srOrder.code.Equals(HttpStatusCode.OK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
