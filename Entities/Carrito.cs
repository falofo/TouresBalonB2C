using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class CarritoItem
    {
        private int cantidad;
        private Producto producto;

        public CarritoItem() { }

        public CarritoItem(Producto producto, int cantidad) {
            this.producto = producto;
            this.cantidad = cantidad;
        }

        public Producto Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}