using Bussines;
using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace TouresBalonB2C.Controllers
{
    public class ProductoController : ControllerUtil
    {
        // GET: Producto
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
            //return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult _VPProductos(string search ="")
        {
            List<Producto> productos = ProductoService.buscarProductoDesc(search);
            ViewBag.TituloVistaParcial = "Productos:";            

            return PartialView("_VPProductos", productos);
        }

        [AllowAnonymous]
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Client)]
        [ReporteLog]
        public ActionResult Details(int id)
        {
            try
            {
                Producto producto = ProductoService.buscarProductoId(id);            
                return View("Display", producto);
            }
            catch
            {
                return View("Display");
            }
            
        }

        [AllowAnonymous]
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Client)]
        public ActionResult Buscar(String searchString, String tipoBusqueda)
        {
            List<Producto> productos;
            switch (tipoBusqueda)
            {
                case "1":
                    productos = ProductoService.buscarProductoDesc(searchString);
                    ViewBag.TituloVistaParcial = "Productos:";
                    return View("_VPProductos", productos);
                case "2":
                    productos = ProductoService.buscarProductoNombre(searchString);
                    ViewBag.TituloVistaParcial = "Productos:";
                    return View("_VPProductos", productos);
                case "3":
                    int id = 0;
                    bool isId = int.TryParse(searchString, out id);
                    if (isId)
                    {
                        return RedirectToAction("Details/" + id);
                    }
                    else
                    {
                        productos = new List<Producto>();
                        return View("_VPProductos", productos);
                    }
                default:
                    productos = ProductoService.buscarProductoNombre(searchString);
                    ViewBag.TituloVistaParcial = "Productos:";
                    return View("_VPProductos", productos);
            }

        }        
        
    }    

}