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
            var cors = new EnableCorsAttribute(
                  origins: "*",
                  headers: "*",
                  methods: "*"
              );
            config.EnableCors(cors);


            // Web API routes
            config.MapHttpAttributeRoutes();



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Change from XML to JSON
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        
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
