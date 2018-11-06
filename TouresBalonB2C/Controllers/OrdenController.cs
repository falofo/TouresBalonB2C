using Bussines;
using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace TouresBalonB2C.Controllers
{
    public class OrdenController : ControllerUtil
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [ReporteLog]
        [Authorize]
        public ActionResult Details(String orderId)
        {
            try
            {
                Orden orden = new Orden { ordid = orderId };
                return View("Display", orden);
            }
            catch
            {
                return View("Display");
            }

        }

        [Authorize]
        public ActionResult CreateOrder()
        {
            try
            {
                OrdenCarrito orden = (OrdenCarrito)Session["carrito"];
                Usuario user = (Usuario)Session["user"];
                orden.custid = user.custid;
                foreach(ElementosOrden elemento in orden.elementosOrden)
                {
                    elemento.saledate = new DateTime();
                }
                if (OrdenService.crearOrden(orden))
                {
                    Session["carrito"] = null;
                    return View("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Carrito");
                }
            }
            catch
            {
                return View("Display");
            }

        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult _VPOrdenes()
        {
            Usuario user = Session["user"] as Usuario;
            List<Orden> ordenes = OrdenService.buscarOrdenesCust(user.custid);
            ViewBag.TituloVistaParcial = "Ordenes:";

            return PartialView("_VPOrdenes", ordenes);
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult _VPItemsOrden(Orden orden)
        {
            List<ElementosOrden> items = OrdenService.buscarItemOrden(orden.ordid);
            ViewBag.TituloVistaParcial = "Ordenes:";

            return PartialView("_VPItemsOrden", items);
        }        

    }
}