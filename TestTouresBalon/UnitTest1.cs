using System;
using System.Collections.Generic;
using Bussines;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTouresBalon
{
    [TestClass]
    public class UnitTestAccount
    {
        [TestMethod]
        public void TestLogin()
        {
            Login login = new Login("falozano@javeriana.edu.co","12345");
            Usuario usuario = AccountService.loginUser(login);
            Assert.AreEqual(usuario.fname,"Fabiani");
        }

        [TestMethod]
        public void TestRegister()
        {
            Registro usuario = new Registro();
            Boolean registro = AccountService.registerUser(usuario);
            Assert.IsTrue(registro);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Usuario user = new Usuario();
            Update model = new Update();
            Boolean update = AccountService.updateUser(user, model);
            Assert.IsTrue(update);
        }
    }

    [TestClass]
    public class UnitTestCampaign
    {
        [TestMethod]
        public void buscarCampaignId()
        {
            int id = 1;
            Campaign campaign = CampaignService.buscarCampaignId(id);
            Assert.AreEqual(campaign.id, id);
        }

        [TestMethod]
        public void buscarCampaign()
        {
            List<Campaign> campaigns = CampaignService.buscarCampaign();
            Assert.IsTrue(campaigns.Count>0);
        }
    }

    [TestClass]
    public class UnitTestOrden
    {
        [TestMethod]
        public void buscarOrdenesCust()
        {
            string idCust = "1";
            List<Orden> ordenes = OrdenService.buscarOrdenesCust(idCust);
            Assert.IsTrue(ordenes.Count>0);
        }

        [TestMethod]
        public void buscarItemOrden()
        {
            string orderId = "1";
            List<ElementosOrden> items = OrdenService.buscarItemOrden(orderId);
            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void crearOrden()
        {

        }
    }

    [TestClass]
    public class UnitTestProducto
    {
        [TestMethod]
        public void buscarProductoId()
        {
            int productoId = 1;
            Producto producto = ProductoService.buscarProductoId(productoId);
            Assert.AreEqual(producto.id, productoId);
        }

        [TestMethod]
        public void buscarProductoDesc()
        {
            string productoDesc = "prueba";
            List<Producto> producto = ProductoService.buscarProductoDesc(productoDesc);
            Assert.IsTrue(producto.Count>0);
        }

        [TestMethod]
        public void buscarProductoNombre()
        {
            string productoNombre = "prueba";
            List<Producto> producto = ProductoService.buscarProductoNombre(productoNombre);
            Assert.IsTrue(producto.Count > 0);
        }
    }
}
