using System.Reflection;
using Microsoft.EntityFrameworkCore;
using API.Integration.TCC.Infrastructure.Persistence.Repositories;

namespace API.Integration.TCC.Infrastructure.Persistence
{
    public class IntegrationTCCDbContext : DbContext
    {
        public IntegrationTCCDbContext(DbContextOptions<IntegrationTCCDbContext> options): base(options)
        {
        }
        public DbSet<ProjectTCCRepository>? ProjectsTCC { get; set; }
        public DbSet<StudentRepository>? Students { get; set; }
        public DbSet<TeacherRepository>? Teachers { get; set; }
        public DbSet<ProjectTCCCommentsRepository>? ProjectTCCComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}