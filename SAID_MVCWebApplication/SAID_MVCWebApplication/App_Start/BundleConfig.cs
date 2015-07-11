using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.Web;
using System.Web.Optimization;

namespace SAID_MVCWebApplication
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			var cssTransformer = new StyleTransformer();
			var jsTransformer = new ScriptTransformer();
			var nullOrderer = new NullOrderer();

			var css = new Bundle("~/bootstrap/css").Include(
				"~/Content/bootstrap/bootstrap.less");

			css.Transforms.Add(cssTransformer);
			css.Orderer = nullOrderer;

			bundles.Add(css);

			var jquery = new Bundle("~/bundles/jquery").Include(
							"~/Scripts/jquery-{version}.js",
							"~/Scripts/modernizr-{version}.js",
							"~/Scripts/bootstrap.min.js"
							);

			jquery.Transforms.Add(jsTransformer);
			jquery.Orderer = nullOrderer;

			bundles.Add(jquery);

			BundleTable.EnableOptimizations = true; 
		}
	}
}