using Microsoft.EntityFrameworkCore;

namespace MyProject.DAL
{
    public class VehicleDbContext : DbContext
    {
        //column name in sql base with migration name
        public const string MIGRATION_HISTORY = "migrationName";
        //name of shema base in sql base for tables in that base. (MyProject.VehicleMake table or MyProject.Vehicle for VehicleModels)
        public const string SCHEMA = "MyProject";

        #region Constructors
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {

        }
        #endregion

        #region DBSets
        /// <summary>
        /// Definition of model VehicleMakes for database
        /// </summary>
        public DbSet<VehicleMake> VehicleMakes { get; set; }

        /// <summary>
        /// Definition of model VehicleModels for database
        /// </summary>
        public DbSet<VehicleModel> VehicleModels
        { get; set; }
        #endregion

        #region OnConfiguring
        /// <summary>
        /// OnModelCreating metod that takes parameter of type ModelBuilder from EntityFrameworkCore
        /// and defines the shape of entities, the relationship betweenthem and how they map to the database
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(SCHEMA);
            base.OnModelCreating(builder);
            //defining OneToMany reletionship between VehicleMake and VehicleModel
            builder.Entity<VehicleModel>()
                 .HasOne(m => m.VehicleMake)
                 .WithMany(b => b.VehicleModels)
                 .IsRequired();
        }
    }
    #endregion
}
