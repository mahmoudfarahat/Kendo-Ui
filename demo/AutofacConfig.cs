using Autofac;
using Autofac.Integration.Mvc;
using demo.Controllers;
using demo.Models;
using demo.Repositories.Implementions;
using demo.Repositories.Interfaces;
using demo.Services.Implementions;
using demo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Register controllers
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterControllers(typeof(VisitsController).Assembly);

            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();

            // Register other dependencies
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerRequest();

            builder.RegisterType<VisitRepository>().As<IVisitRepository>().InstancePerRequest();

            builder.RegisterType<VisitsService>().As<IVisitsService>().InstancePerRequest();

            // Build the container
            var container = builder.Build();

            // Set the dependency resolver to be Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}