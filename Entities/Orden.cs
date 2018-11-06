using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrdenCarrito
    {
        public string custid { get; set; }
        public object ordid { get; set; }
        public float price { get; set; }
        public string status { get; set; }
        public string comments { get; set; }
        public List<ElementosOrden> elementosOrden { get; set; }
        public OrdenCarrito()
        {
            this.status = "En Validacion";
            elementosOrden = new List<ElementosOrden>();
        }
    }

    public class ElementosOrden
    {
        public string category { get; set; }
        public string clienteid { get; set; }
        public string itemid { get; set; }
        public string ordid { get; set; }
        public string partnum { get; set; }
        public float price { get; set; }
        public int prodid { get; set; }
        public string productname { get; set; }
        public int quantity { get; set; }
        public DateTime saledate { get; set; }
        public string image { get; set; }
        public ElementosOrden()
        {

        }
        public ElementosOrden(Producto producto, int quantity)
        {
            this.quantity = quantity;
            this.prodid = producto.id;
            this.productname = producto.name;
            this.price = producto.totalPrice;
            this.category = producto.category;
            this.image = producto.imageCollection[0].url;

        }
    }

    public class Orden
    {
        public string comments { get; set; }
        public string custid { get; set; }
        public DateTime orderdate { get; set; }
        public string ordid { get; set; }
        public float price { get; set; }
        public string status { get; set; }
    }
}
