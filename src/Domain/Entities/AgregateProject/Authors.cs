using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Entities.Users;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Value Object - Authors
    /// </summary>
    public class Authors : BaseEntity
    {
        public Authors(Student idStudent)
        {
            IdStudent = idStudent;
        }

        /// <summary>
        /// Id do Aluno
        /// </summary>
        /// <value></value>
        public Student IdStudent { get; private set; }

        /// <summary>
        /// Id do Professor
        /// </summary>
        /// <value></value>
        public Teacher? IdTeacher { get; private set; }


        public void SetTeacher(Teacher idTeacher) 
            => IdTeacher = idTeacher;
    }
}