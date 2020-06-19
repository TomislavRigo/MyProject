using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyProject.DAL
{
    public class DbContextFactory : IDesignTimeDbContextFactory<VehicleDbContext>
    {
        public VehicleDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();
            var builder = new DbContextOptionsBuilder<VehicleDbContext>();
            var connectionString = "Data Source=localhost;Database=TestDatabase;user id='sa';password='yourStrong(!)Password';Integrated Security=False";
            builder.UseSqlServer(connectionString, o => o.MigrationsHistoryTable(VehicleDbContext.MIGRATION_HISTORY, VehicleDbContext.SCHEMA));
            return new VehicleDbContext(builder.Options);
        }
    }
}
