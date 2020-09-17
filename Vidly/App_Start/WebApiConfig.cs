using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Runtime;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            JsonSerializerSettings settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
            //settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.DateFormatString = "dd-MMM-yyyy";            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Formatters.Remove(config.Formatters.JsonFormatter);            
        }
    }
}
