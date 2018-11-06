using Entities;
using Bussines;
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
    public class CampaignController : ControllerUtil
    {     

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult _VPCampaign(string search = "")
        {
            List<Campaign> campaigns = CampaignService.buscarCampaign();
            ViewBag.TituloVistaParcial = "Campañas:";
            if (campaigns != null)
            {
                return PartialView("_VPCampaign", campaigns);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [AllowAnonymous]
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Client)]
        public ActionResult Details(int id)
        {
            try
            {
                Campaign campaign = CampaignService.buscarCampaignId(id);
                return View("Display", campaign);
            }
            catch
            {
                return HttpNotFound();
            }

        }

        
    }
}