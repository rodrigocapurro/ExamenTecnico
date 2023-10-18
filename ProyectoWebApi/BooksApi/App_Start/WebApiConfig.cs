using BooksApi.Models;
using BooksBusiness.BooksValidations;
using BooksBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace BooksApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            var cors = new EnableCorsAttribute("*", "*", "*"); // Permitir cualquier origen, método y encabezado
            config.EnableCors(cors);

            var container = new UnityContainer();
            container.RegisterType<IBookBus, BookBus>();
            config.DependencyResolver = new UnityResolver(container);
            
            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
