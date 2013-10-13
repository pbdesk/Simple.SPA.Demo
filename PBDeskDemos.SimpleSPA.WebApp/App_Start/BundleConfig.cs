using System.Web;
using System.Web.Optimization;

namespace PBDeskDemos.SimpleSPA.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/toastr.js")
                .Include("~/Scripts/toastr-custom.js")
                .Include("~/Scripts/PBDeskUtils.js")
                .Include("~/Scripts/Custom.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/scripts/angular.js")
                .Include("~/scripts/angular-*")

                );


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.cerulean.css",
                      "~/Content/font-awesome.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            string strMyNGHelperAppBasePath = "~/NGApp/SimpleSPADemoApp/scripts/";
            bundles.Add(new ScriptBundle("~/bundles/SimpleSPADemoApp")
                .Include(strMyNGHelperAppBasePath + "app/SimpleSPADemoApp.js")

                .Include(strMyNGHelperAppBasePath + "services/CustomerFactory.js")

                .Include(strMyNGHelperAppBasePath + "controllers/CustomersListController.js")
                .Include(strMyNGHelperAppBasePath + "controllers/CustomersCreateController.js")
                .Include(strMyNGHelperAppBasePath + "controllers/CustomersEditController.js")                

               );

        }
    }
}
