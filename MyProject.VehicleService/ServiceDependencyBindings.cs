using Autofac;
using MyProject.VehicleService.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.VehicleService
{
    public class ServiceDependencyBindings
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>().InstancePerLifetimeScope();
        }
    }
}
