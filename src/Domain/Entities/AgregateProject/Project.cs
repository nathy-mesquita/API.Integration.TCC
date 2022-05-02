using System.Collections.Generic;
using API.Integration.TCC.Domain.Entities;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Agregate Root - Project
    /// </summary>
    public class Project : BaseEntity
    {
        public Project()
        {
            Comments = new List<ProjectComments>();
            Term = new List<Term>();
            Cronograma = new List<Topic>();
        }
        public Tcc? Tcc { get; set; }
        public Authors? Authors { get; set; }
        public List<Term>? Term { get; set; }
        public List<Topic>? Cronograma { get; set; }
        public List<ProjectComments>? Comments { get; set; }

        public void GerarCronograma(List<Topic> cronograma)
        {
            Cronograma = cronograma;
        }
    }
}