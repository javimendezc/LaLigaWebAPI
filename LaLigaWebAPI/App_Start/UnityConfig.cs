using Conexion;
using LaLigaWebAPI.DAO;
using LaLigaWebAPI.DAO.Interfaces;
using LaLigaWebAPI.Gestores;
using LaLigaWebAPI.Gestores.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace LaLigaWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //Configuración del contenedor de IoC
            container.RegisterType<IClubesDAO, ClubesDAO>();
            container.RegisterType<IJugadoresDAO, JugadoresDAO>();
            container.RegisterType<IJugadoresClubesDAO, JugadoresClubesDAO>();
            container.RegisterType<IGestorClubes, GestorClubes>();
            container.RegisterType<IGestorJugadores, GestorJugadores>();
            container.RegisterType<IGestorJugadoresClubes, GestorJugadoresClubes>();
            container.RegisterType<ILaLigaEntities, LaLigaEntities>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}