using API.Integration.TCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Chave primária
            builder
            .HasKey(s => s.Id);


            //O Aluno tem 0 ou 1 comentário
            //O comentário tem um aluno 
            //Chave estrangeira do relacionamento -> Id do comentário
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasMany(s => s.Comments)
            .WithOne()
            .HasForeignKey(s => s.Id)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}