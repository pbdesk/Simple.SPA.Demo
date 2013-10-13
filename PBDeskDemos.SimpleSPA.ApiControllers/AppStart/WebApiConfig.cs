using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(PBDeskDemos.SimpleSPA.ApiControllers.AppStart.WebApiConfig), "RegisterWebApiRoutes")]
namespace PBDeskDemos.SimpleSPA.ApiControllers.AppStart
{
    public static class WebApiConfig
    {
        public static void RegisterWebApiRoutes()
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "SimpleSPADemoApiV1",
                routeTemplate: "api/SimpleSPADemo/V1/{controller}/{id}",
                 defaults: new { controller = "Customers", id = RouteParameter.Optional }                
            );

        }
    }
}
