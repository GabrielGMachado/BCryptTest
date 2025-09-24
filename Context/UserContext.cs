using BCryptTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BCryptTest.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().AreUnicode(false).HaveMaxLength(250);
            base.ConfigureConventions(configurationBuilder);
        }

        public DbSet<User> users { get; set; }
       
    }
}
