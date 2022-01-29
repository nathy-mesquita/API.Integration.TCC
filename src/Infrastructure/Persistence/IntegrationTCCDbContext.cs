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
        public DbSet<ProjectTCCRepository> ProjectsTCC => Set<ProjectTCCRepository>();
        public DbSet<StudentRepository> Students => Set<StudentRepository>();
        public DbSet<TeacherRepository> Teachers => Set<TeacherRepository>();
        public DbSet<ProjectTCCCommentsRepository> ProjectTCCComments => Set<ProjectTCCCommentsRepository>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFNullableReferenceTypes;Trusted_Connection=True");
    }
}