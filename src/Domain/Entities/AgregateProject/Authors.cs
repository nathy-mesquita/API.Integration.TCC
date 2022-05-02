using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Entities.Users;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Value Object - Authors
    /// </summary>
    public class Authors : BaseEntity
    {
        public Authors(int idStudent)
        {
            IdStudent = idStudent;
        }

        /// <summary>
        /// Id do Aluno
        /// </summary>
        /// <value></value>
        public int IdStudent { get; set; }

        /// <summary>
        /// Aluno
        /// </summary>
        /// <value></value>
        public Student? Student { get; set; }

        /// <summary>
        /// Id do Professor
        /// </summary>
        /// <value></value>
        public int IdTeacher { get; private set; }

        /// <summary>
        /// Professor
        /// </summary>
        /// <value></value>
        public Teacher? Teacher { get; private set; }

        public void UpdateTeacher(int idTeacher)
        {
            IdTeacher = idTeacher;
        }
    }
}