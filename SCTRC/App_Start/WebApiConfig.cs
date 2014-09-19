using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace SCTRC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "PriceTagsForBar",
            //    routeTemplate: "api/PriceTagsForBar/{id}",
            //    defaults: new { controller = "PriceTags", action = "PriceTagsById", id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "confirmPriceTag",
            //    routeTemplate: "api/confirmPriceTag/{id}",
            //    defaults: new { controller = "PriceTags", action = "ConfirmPriceTag", id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "getBarsWithinBounds",
            //    routeTemplate: "api/GetBarsWithinBounds",
            //    defaults: new { controller = "Bars", action = "GetBars" }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "getEvents",
            //    routeTemplate: "api/events",
            //    defaults: new { controller = "Events", action = "GetEvents" },
            //    constraints: new { method = "GET" }
            //);
            config.Routes.MapHttpRoute(
                name: "eventsForUser",
                routeTemplate: "api/eventsforuser",
                defaults: new { controller = "Events", action = "EventsForUser" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
