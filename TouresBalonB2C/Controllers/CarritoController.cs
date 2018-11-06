using Bussines;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TouresBalonB2C.Controllers
{
    public class CarritoController : ControllerUtil
    {
        public ActionResult Index()
        {
            return View("Display");
        }

        public ActionResult AgregarCarrito(int id)
        {
           
            if (Session["carrito"] == null)
            {
                OrdenCarrito orden = new OrdenCarrito();
                Producto producto = getProducto(id);
                orden.elementosOrden.Add(new ElementosOrden(producto,1));
                orden.price = producto.totalPrice;
                Session["carrito"] = orden;
            }
            else
            {
                OrdenCarrito orden = (OrdenCarrito)Session["carrito"];
                int index = getIndex(id, orden);
                if (index == -1)
                {
                    Producto producto = getProducto(id);
                    orden.elementosOrden.Add(new ElementosOrden(producto, 1));
                }
                else
                {
                    orden.elementosOrden[index].quantity++;
                }
                orden.price = 0;
                foreach (ElementosOrden elemento in orden.elementosOrden)
                {
                    orden.price += elemento.price * elemento.quantity;
                }
                Session["carrito"] = orden;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            OrdenCarrito orden = (OrdenCarrito)Session["carrito"];
            orden.elementosOrden.RemoveAt(getIndex(id,orden));
            orden.price = 0;
            foreach (ElementosOrden elemento in orden.elementosOrden)
            {
                orden.price += elemento.price * elemento.quantity;
            }
            return RedirectToAction("Index");
        }

        private int getIndex(int id, OrdenCarrito orden)
        {
            for (int i=0; i < orden.elementosOrden.Count;i++)
            {
                if (orden.elementosOrden[i].prodid==id)
                {
                    return i;
                }
            }
            return -1;
        }

        private Producto getProducto(int id)
        {
            return ProductoService.buscarProductoId(id);
        }

        [AllowAnonymous]
        public PartialViewResult _VPCarrito()
        {
            ProductoController productoC = new ProductoController();
            return PartialView("_VPCarrito");
        }

        public ActionResult sumarProducto(int id)
        {
            OrdenCarrito orden = (OrdenCarrito)Session["carrito"];
            orden.elementosOrden[getIndex(id,orden)].quantity++;
            orden.price = 0;
            foreach (ElementosOrden elemento in orden.elementosOrden)
            {
                orden.price += elemento.price * elemento.quantity;
            }
            return RedirectToAction("Index");
        }

        public ActionResult restarProducto(int id)
        {
            OrdenCarrito orden = (OrdenCarrito)Session["carrito"];
            orden.elementosOrden[getIndex(id, orden)].quantity--;
            if(orden.elementosOrden[getIndex(id, orden)].quantity == 0)
            {
                orden.elementosOrden.RemoveAt(getIndex(id,orden));
            }
            orden.price = 0;
            foreach (ElementosOrden elemento in orden.elementosOrden)
            {
                orden.price += elemento.price * elemento.quantity;
            }
            return RedirectToAction("Index");
        }
    }
}