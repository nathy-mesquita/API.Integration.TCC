using Microsoft.EntityFrameworkCore;
using API.Integration.TCC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            //Chave primária
            builder
            .HasKey(u => u.Id);
        }
    }
}