
using System.Net.Http.Headers;
using System.Web.Http;

namespace LaLigaWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // ELIMINAMOS EL FORMATEADOR DE RESPUESTAS XML
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            // HABILITAMOS EL FORMATEADOR DE RESPUESTAS JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));


            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PagJugClubesApi",
                routeTemplate: "api/fichas/{id}/{pagina}/{elementos}",
                defaults: new { controller = "JugadoresClubes", id = RouteParameter.Optional, pagina = RouteParameter.Optional, elementos = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "PagApi",
                routeTemplate: "api/{controller}/{pagina}/{elementos}",
                defaults: new { pagina = 1 }
            );
        }
    }
}
