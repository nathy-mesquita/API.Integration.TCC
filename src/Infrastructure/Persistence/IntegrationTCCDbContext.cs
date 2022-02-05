using API.Integration.TCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Integration.TCC.Infrastructure.Persistence
{
    public class IntegrationTCCDbContext : DbContext
    {
        public IntegrationTCCDbContext(DbContextOptions<IntegrationTCCDbContext> options) : base(options)
        {
        }

        public DbSet<ProjectTCC>? ProjectsTCC { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<ProjectTCCComments>? ProjectTCCComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}