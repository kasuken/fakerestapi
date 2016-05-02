using System.Web.Http;
using WebActivatorEx;
using FakeRestAPI.Web;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FakeRestAPI.Web
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "FakeRestAPI.Web")
                           .Description("Fake Rest API on cloud for testing your application.")
                           .Contact(cc => cc
                               .Name("Emanuele B.")
                               .Url("http://www.emanuelebartolesi.com")
                               .Email("emanueleb@outlook.com"));

                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        c.IgnoreObsoleteActions();

                        c.IncludeXmlComments(GetXmlCommentsPath());

                        // Obsolete attribute 
                        c.IgnoreObsoleteProperties();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.BooleanValues(new[] { "0", "1" });
                    });
        }

        private static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\bin\FakeRestAPI.Web.XML", AppDomain.CurrentDomain.BaseDirectory);
        }

    }
}