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
    public class ProductoService : ServiceUtil
    {
        public static Producto buscarProductoId(int id)
        {
            try
            {
                ServiceResponse srProduct = consumirServicio("GET", Constants.URL_PRODUCTOS+"products/Complete/byID/" + id, null);

                if (srProduct.code.Equals(HttpStatusCode.OK))
                {
                    JObject jProduct = JObject.Parse(srProduct.content);
                    Producto producto;
                    producto = jProduct.ToObject<Producto>();

                    return producto;
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

        public static List<Producto> buscarProductoDesc(String desc)
        {
            try
            {
                ServiceResponse srProduct = consumirServicio("GET", Constants.URL_PRODUCTOS + "products/Complete/byDESCRIPTION/" + desc, null);
                if (srProduct.code.Equals(HttpStatusCode.OK))
                {
                    JObject jProduct = JObject.Parse(srProduct.content);
                    IList<JToken> results = jProduct["collectionProducts"].Children().ToList();

                    List<Producto> productos = new List<Producto>();
                    foreach (JToken result in results)
                    {
                        Producto searchResult = result.ToObject<Producto>();
                        productos.Add(searchResult);
                    }
                    return productos;
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

        public static List<Producto> buscarProductoNombre(String desc)
        {
            try
            {
                ServiceResponse srProduct = consumirServicio("GET", Constants.URL_PRODUCTOS + "products/Complete/byNAME/" + desc, null);
                if (srProduct.code.Equals(HttpStatusCode.OK))
                {
                    JObject jProduct = JObject.Parse(srProduct.content);
                    IList<JToken> results = jProduct["collectionProducts"].Children().ToList();

                    List<Producto> productos = new List<Producto>();
                    foreach (JToken result in results)
                    {
                        Producto searchResult = result.ToObject<Producto>();
                        productos.Add(searchResult);
                    }
                    return productos;
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
    }
}
