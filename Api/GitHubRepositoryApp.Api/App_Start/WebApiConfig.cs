using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GitHubRepositoryApp.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS for the specified origin
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GitHubRepositoryAppApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable Swagger
            //config
            //    .EnableSwagger(c =>
            //    {
            //        c.SingleApiVersion("v1", "GitHubRepositoryApp Api");
            //        c.IncludeXmlComments(GetXmlCommentsPath());
            //    })
            //    .EnableSwaggerUi();
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}bin\GitHubRepositoryApp.Api.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
