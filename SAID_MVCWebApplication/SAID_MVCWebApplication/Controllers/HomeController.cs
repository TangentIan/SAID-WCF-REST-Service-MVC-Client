using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAID_MVCWebApplication.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public JsonResult GetID()
		{
			SAID_ServiceReference.SAIDGeneratorServiceClient SAID_Service = new SAID_ServiceReference.SAIDGeneratorServiceClient();

			return Json(SAID_Service.GenerateRandomSAIDNumber(), JsonRequestBehavior.AllowGet);
		}
	}
}
