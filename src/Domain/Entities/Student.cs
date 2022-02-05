using System;
using System.Collections.Generic;

namespace API.Integration.TCC.Domain.Entities
{
    public class Student : User
    {

        public Student(string? fullName,
                        string? email,
                        string? password,
                        string? course,
                        DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Course = course;
            BirthDate = birthDate;

            Role = "IntegrationTCC_Student";
            Active = true;
            CreatedAt = DateTime.Now;
            Enrollment = Guid.NewGuid();

            Comments = new List<ProjectTCCComments>();
        }

        /// <summary>
        /// Curso matriculado
        /// </summary>
        /// <value></value>
        public string? Course { get; private set; }

        /// <summary>
        /// Matrícula do aluno
        /// </summary>
        /// <value></value>
        public Guid Enrollment { get; private set; }

        /// <summary>
        /// Comentários
        /// </summary>
        /// <value></value>
        public List<ProjectTCCComments>? Comments { get; set; }


        /// <summary>
        /// Dono do Projeto
        /// </summary>
        /// <value></value>
        public ProjectTCC? OwnedProject { get; set; }
    }
}