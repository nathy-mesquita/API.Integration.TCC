using Microsoft.EntityFrameworkCore;
using API.Integration.TCC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectTCCCommentsConfigurations : IEntityTypeConfiguration<ProjectTCCComments>
    {
        public void Configure(EntityTypeBuilder<ProjectTCCComments> builder)
        {
            //Chave primária
            builder
            .HasKey(p => p.Id);

            //O ProjectTCCComments contem 1 projeto
            //O ProjectTCCComments contem muitos comentários 
            //Chave estrangeira do relacionamento -> IdProject
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.ProjectTCC)
            .WithMany(p => p!.Comments)
            .HasForeignKey(p => p.IdProjectTCC)
            .OnDelete(DeleteBehavior.Restrict);


            //!Verificar se essa configuração obriga ter os dois tipos de usuário para o comentário existir.
            //O ProjectTCCComments é criado por 1 Professor
            //O Professor cria 1 ou muitos comentários 
            //Chave estrangeira do relacionamento -> IdTeacher
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.Teacher)
            .WithMany(p => p!.Comments)
            .HasForeignKey(p => p.IdTeacher)
            .OnDelete(DeleteBehavior.Restrict);

            //O ProjectTCCComments é criado por 1 Aluno
            //O Aluno cria 1 ou muitos comentários 
            //Chave estrangeira do relacionamento -> IdStudent
            //Caso um relacionamento seja deletado, retringir o procedimento
            builder
            .HasOne(p => p.Student)
            .WithMany(p => p!.Comments)
            .HasForeignKey(p => p.IdStudent)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}