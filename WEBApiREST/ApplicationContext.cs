using Microsoft.EntityFrameworkCore;
using WEBApiREST.Configurations;
using WEBApiREST.Models;
//using WEBApiREST.Configurations;

namespace WEBApiREST
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<CollegeEntity> College { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
