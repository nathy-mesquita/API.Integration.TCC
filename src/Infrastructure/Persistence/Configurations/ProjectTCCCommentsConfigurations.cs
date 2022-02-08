using API.Integration.TCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        }
    }
}