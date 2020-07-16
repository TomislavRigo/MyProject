using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProject.DAL;
using MyProject.DTO.AutoMapperProfiles;
using MyProject.VehicleRepository;
using MyProject.VehicleService;
using System;
using MyProject.AutoMapperProfilesWebApi;

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
            services.AddAutoMapper(typeof(AutoMapperProfileDTO), typeof(AutoMapperProfileWebApi));

            var builder = new ContainerBuilder();
            builder.Populate(services);
            ServiceDependencyBindings.RegisterServices(builder);
            RepositoryDependencyBindings.RegisterServices(builder);

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