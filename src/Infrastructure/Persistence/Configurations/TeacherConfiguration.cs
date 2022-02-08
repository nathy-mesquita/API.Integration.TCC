using API.Integration.TCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            //Chave primária
            builder
            .HasKey(t => t.Id);


            //O Professor tem 0 ou 1 comentário
            //O comentário tem um professor 
            //Chave estrangeira do relacionamento -> Id do comentário
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasMany(t => t.Comments)
            .WithOne()
            .HasForeignKey(t => t.Id)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}