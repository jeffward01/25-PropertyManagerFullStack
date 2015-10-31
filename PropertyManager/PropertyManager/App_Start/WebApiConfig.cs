using AutoMapper;
using PropertyManager.Core.Domain;
using PropertyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PropertyManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
        //    var corsAttr = new EnableCorsAttribute("http://example.com", "/API/", "Properties");
       //     config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            SetupAutoMapper();
        }

        //Initilize AutoMapper
        public static void SetupAutoMapper()
        {
            Mapper.CreateMap<Property, PropertyModel>();
            Mapper.CreateMap<Tenant, TenantModel>();
            Mapper.CreateMap<Lease, LeaseModel>();
        }
    }
}
