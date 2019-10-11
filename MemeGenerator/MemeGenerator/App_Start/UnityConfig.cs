using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Mvc5Resolver = Unity.Mvc5.UnityDependencyResolver;
using ApiResolver = Unity.WebApi.UnityDependencyResolver;
using System.Web.Http;
using MemeGenerator.Repositories;
using MemeGenerator.Data;

namespace MemeGenerator
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ITemplateRepository, TemplateRepository>();
            container.RegisterType<ICoordinateRepository, CoordinateRepository>();
            container.RegisterType<IMemeRepository, MemeRepository>();
            container.RegisterType<IMemeCoordinateRepository, MemeCoordinateRepository>();

            DependencyResolver.SetResolver(new Mvc5Resolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new ApiResolver(container);
        }
    }
}