using System.Web;
using System.Web.Optimization;

namespace PBDeskDemos.SimpleSPA.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js")
                 .Include("~/Scripts/jquery-{version}.js")
                 .Include("~/Scripts/bootstrap.js")
                 .Include("~/Scripts/respond.js")
                 .Include("~/Scripts/toastr.js")
                 .Include("~/Scripts/toastr-custom.js")
                 .Include("~/Scripts/PBDeskUtils.js")
                 .Include("~/Scripts/Custom.js")
                 );

            bundles.Add(new ScriptBundle("~/bundles/angular")
               .Include("~/scripts/angular.js")
               .Include("~/scripts/angular-*")

               );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.cerulean.css",
                      "~/Content/font-awesome.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"
                      ));

            string strMyNGHelperAppBasePath = "~/NGApp/SimpleSPADemoApp/V1/scripts/";
            bundles.Add(new ScriptBundle("~/bundles/SimpleSPADemoAppV1")
                .Include(strMyNGHelperAppBasePath + "app/SimpleSPADemoApp.js")

                .Include(strMyNGHelperAppBasePath + "services/CustomerFactory.js")

                .Include(strMyNGHelperAppBasePath + "controllers/CustomersListController.js")
                .Include(strMyNGHelperAppBasePath + "controllers/CustomersCreateController.js")
                .Include(strMyNGHelperAppBasePath + "controllers/CustomersEditController.js")

               );
        }
    }
}
