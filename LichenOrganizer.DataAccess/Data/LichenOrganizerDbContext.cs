using LichenOrganizer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LichenOrganizer.DataAccess.Data
{
    public class LichenOrganizerDbContext : DbContext
    {
        //private IConfiguration _configuration {  get;  }
        //public LichenOrganizerDbContext(IConfiguration configuration  ) : base()
        //{
        //    _configuration = configuration;
        //}

        //public LichenOrganizerDbContext(DbContextOptions options) : base(options)
        //{

        //}

        public LichenOrganizerDbContext() : base()
        {

        }

        //DB Sets
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Lichen> Lichens { get; set; }
        public DbSet<UTM> UTMEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LichenOrganizer;Integrated Security=True;");
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LichenOrganizer;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API Constraints - Entity also offers the TypeConfiguration class, which can be used as shown below.
            //modelBuilder.Entity<Friend>()
            //     .Property(f => f.FirstName)
            //     .IsRequired()
            //     .HasMaxLength(50);
        }

    }


    //DEMONSTRATION OF TYPECONFIGURATION IMPLEMENTATION
    //Once the configuration code is complete, it can be added to the modelbuilder by : 
    //modelBuilder.Configurations.Add(new FriendConfiguration());
    //public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    //{
    //    public FriendConfiguration()
    //    {

    //    }

    //    public void Configure(EntityTypeBuilder<Friend> builder)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

}
