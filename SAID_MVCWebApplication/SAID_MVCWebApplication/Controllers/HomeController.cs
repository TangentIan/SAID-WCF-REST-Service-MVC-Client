using SAID_MVCWebApplication.SAID_ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAID_MVCWebApplication.Controllers
{
	public class HomeController : Controller
	{
		//Renders the Home View.
		public ActionResult Index()
		{
			return View();
		}
		//Gets a valid, randomly generated SA ID number from the WCF REST service.
		[HttpGet]
		public JsonResult GetRandomIDNumber()
		{
			try
			{
				SAID_ServiceReference.SAIDGeneratorServiceClient SAID_Service = new SAID_ServiceReference.SAIDGeneratorServiceClient();
				return Json(SAID_Service.GenerateRandomSAIDNumber(), JsonRequestBehavior.AllowGet); //Return the succesfully generated ID number.
			}
			catch //Error - return an error message in the appropriate/expected format.
			{
				SAIDGeneratorResponse ErrorResponse = new SAIDGeneratorResponse();
				ErrorResponse.Success = false;
				ErrorResponse.Message = "Error - An unforseen error prevented a valid SA ID number from being generated/retrieved. Please try again.";

				return Json(ErrorResponse); //Return the error to the view.
			}
		}
		//Send a user entered ID number to the WCF REST service for validation.
		[HttpGet]
		public JsonResult ValidateIDNumber(string IDNumber)
		{
			try
			{
				SAID_ServiceReference.SAIDGeneratorServiceClient SAID_Service = new SAID_ServiceReference.SAIDGeneratorServiceClient();
				return Json(SAID_Service.ValidateSAIDNumber(IDNumber), JsonRequestBehavior.AllowGet); //Return the validation result.
			}
			catch //Error - return an error message in the appropriate/expected format.
			{
				SAIDGeneratorResponse ErrorResponse = new SAIDGeneratorResponse();
				ErrorResponse.Success = false;
				ErrorResponse.Message = "Error - An unforseen error prevented the provided ID number from being validated. Please try again.";

				return Json(ErrorResponse); //Return the error to the view.
			}
		}
	}
}
