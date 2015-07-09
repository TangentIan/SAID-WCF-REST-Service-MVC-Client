using System.Web;
using System.Web.Mvc;

namespace SAID_MVCWebApplication
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}