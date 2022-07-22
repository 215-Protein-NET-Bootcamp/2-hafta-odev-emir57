using _3_hafta.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _3_hafta.DataAccess.Concrete.Contexts
{
    public class EfPatikaDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Folder> Folder { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(getConnectionString("PostgreSqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>()
                .ToTable("folder", "dbo");
            modelBuilder.Entity<Employee>()
                .ToTable("employee", "dbo");
        }

        private string getConnectionString(string conString)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config.GetConnectionString(conString);
        }
    }
}
