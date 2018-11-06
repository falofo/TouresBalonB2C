
using Entities;
using Bussines;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TouresBalonB2C.Controllers
{
    public class AccountController : ControllerUtil
    {

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Titulo = "Bienvenido a TouresBalon";
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Usuario user = AccountService.loginUser(model);
                if (user!=null)
                {                    
                    Session["user"] = user;
                    FormsAuthentication.SetAuthCookie(model.email, model.rememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El usuario o contraseña es incorrecto");
                }

                return View(model);
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult LogOff()
        {
            Session["user"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Registro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (AccountService.registerUser(model))
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(model);
                    }

                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Registration Error", "Error de registro: " + e.StackTrace);
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Update model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario user = Session["user"] as Usuario;                    
                    
                    if (AccountService.updateUser(user,model))
                    {
                        return View("Index", model);
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Error al actualizar: ");
                        return View("Index", model);
                    }

                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Registration Error", "Error de registro: " + e.StackTrace);
                }
            }

            return View("Index",model);
        }

        [Authorize]
        public ActionResult ResetPassword(bool? cambio)
        {
            if (cambio != null && (bool)cambio)
            {
                ViewBag.StaturMessage = "Su contraseña ha sido actualizada";
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ResetPassword(Contrasena model)
        {
            if (ModelState.IsValid)
            {
                bool cambioOk;
                try
                {
                    // Agregar metodo cambio de contrasena de TouresBalon
                    cambioOk = true;
                }
                catch (Exception e)
                {
                    cambioOk = false;
                }
                if (cambioOk)
                {
                    return RedirectToAction("ResetPassword", new { cambio = cambioOk });
                }
                else
                {

                }
            }

            return View(model);
        }
        
    }
}