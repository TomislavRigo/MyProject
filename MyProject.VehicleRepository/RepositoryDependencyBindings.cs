using Autofac;
using MyProject.VehicleRepository.Common;

namespace MyProject.VehicleRepository
{
    public class RepositoryDependencyBindings
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>().InstancePerLifetimeScope();
        }
    }
}
