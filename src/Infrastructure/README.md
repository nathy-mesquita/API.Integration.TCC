
### Camada de `Infraestructure`



### Configurações de persistência utilizando `Migrations`



> Para não ficar com a classe de DbContext com várias configurações contendo todas as tabelas (entidades) e suas propriedades. 

>Realizamos a  implementação do `IEntityTypeConfiguration<T>`, onde T é a classe a ser configurada, e migrar o código para o ela. 

Exemplo: `ProjectTCC`

Criando a classe e implementado `IEntityTypeConfiguration<T>` 

```csharp
using Microsoft.EntityFrameworkCore;
using API.Integration.TCC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectTCCConfigurations : IEntityTypeConfiguration<ProjectTCC>
    {
        public void Configure(EntityTypeBuilder<ProjectTCC> builder)
        {
        }
    }
}
```

O `builder` é o objeto direto daquela entidade, então não precisaremos utilizar o `modelBuilder.Entity<ProjectTCC>()` 

```csharp
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
```

Na classe IntegrationTCCDbContext dentro do método `OnModelCreating` Utilizar reflection para pegar as configurações implementadas por Assembly


`IntegrationTCCDbContext` refatorado: 

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{            
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
```

### Modelo de Entidade Relacionamento - MER 