using Microsoft.Practices.Unity;
using Indigo99.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Indigo99.Web
{
    public class Bootstrapper
    {
        public static Assembly[] LoadAssemblies()
        {
            // assemblies are loaded as they are needed. but I need to load 3 assemblies to build my DI configuration.
            return new[] { Assembly.GetAssembly(typeof(DomainObjects.IMongoEntity)), Assembly.GetAssembly(typeof(IAuthenticationService)), Assembly.GetAssembly(typeof(Data.CustomerRepository)) };
        }

        public static UnityContainer RegisterTypes()
        {
            var container = new UnityContainer();
            container.RegisterTypes(AllClasses.FromAssemblies(true, LoadAssemblies()),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default,
                                    PerRequest);
            return container;
        }

        public static Func<Type, LifetimeManager> PerRequest = (x) => new TransientLifetimeManager();

        public static void Initialize()
        {
            var container = RegisterTypes();
            container.RegisterInstance<HttpContextBase>(new HttpContextWrapper(HttpContext.Current));
            DependencyResolver.SetResolver(new Unity.Mvc4.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }
    }
}