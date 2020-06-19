using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProject.DAL;
using MyProject.VehicleRepository;
using MyProject.VehicleRepository.Common;
using MyProject.VehicleService;
using MyProject.VehicleService.Common;
using System;

namespace MyProject.WebApi
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the ConfigureContainer method, below.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VehicleDbContext>
                (options => options.UseSqlServer("Server=localhost;Database=TestDatabase;user id='sa';password='yourStrong(!)Password';Trusted_Connection=False;"));
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Add services to the collection. Don't build or return
            // any IServiceProvider or the ConfigureContainer method
            // won't get called.
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>().InstancePerLifetimeScope();

            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
#if DEBUG
            app.UseDeveloperExceptionPage();
#endif
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}