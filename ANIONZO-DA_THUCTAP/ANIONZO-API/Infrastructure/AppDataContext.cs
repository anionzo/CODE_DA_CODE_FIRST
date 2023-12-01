using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ANIONZO_API.Infrastructure
{
    public sealed partial class AppDataContext : DbContext
    {
        // migrations 
        // dotnet ef migrations add Update1 -v --context AppDataContextt
        // dotnet ef database update -v --context AppDataContextt
        // dotnet ef migrations remove
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = (local); Initial Catalog = Anionzo; User Id = sa; Password = 123; Trusted_Connection = True; Trust Server Certificate = True; Integrated Security = false; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
