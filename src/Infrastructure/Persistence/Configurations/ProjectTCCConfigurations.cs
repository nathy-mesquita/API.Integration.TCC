using Microsoft.EntityFrameworkCore;
using API.Integration.TCC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectTCCConfigurations : IEntityTypeConfiguration<ProjectTCC>
    {
        public void Configure(EntityTypeBuilder<ProjectTCC> builder)
        {
            //Chave primária
            builder
            .HasKey(p => p.Id);

             //O projeto é criado por 1 Aluno 
            //Um Aluno tem um único projeto que ele é dono (OwnedProject)
            //Chave estrangeira do relacionamento -> IdStudent
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.Student)
            .WithOne(s => s!.OwnedProject!)
            .OnDelete(DeleteBehavior.Restrict);
            //.HasForeignKey(p => p.IdStudent)

            //O projeto é orientado por 0 ou 1 Professor 
            //Um professor orienta muitos projetos
            //Chave estrangeira so relacionamento -> IdTeacher
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.Teacher)
            .WithMany(t => t!.AdvisorProject!)
            .HasForeignKey(p => p.IdTeacher)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}