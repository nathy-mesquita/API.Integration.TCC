using System;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Enums;

namespace API.Integration.TCC.Domain.Entities.Users
{
    public class Student : User
    {

        public Student(string? fullName,
                        string? email,
                        string? password,
                        DateTime birthDate,
                        string? role,
                        CourseEnum course)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Role = role;
            Course = course;

            Active = true;
            CreatedAt = DateTime.Now;
            Enrollment = Guid.NewGuid();

            //TODO: Retirar esta propriedade de navegação caso não seja mais necessário
            //Comments = new List<ProjectTCCComments>();
            //OwnedProject = new ProjectTCC();
        }

        /// <summary>
        /// Papel do Aluno
        /// </summary>
        /// <value></value>
        public string? Role { get; private set; }

        /// <summary>
        /// Curso matriculado
        /// </summary>
        /// <value></value>
        public CourseEnum Course { get; private set; }

        /// <summary>
        /// Matrícula do aluno
        /// </summary>
        /// <value></value>
        public Guid Enrollment { get; private set; }

        //TODO: Retirar esta propriedade de navegação caso não seja mais necessário
        /// <summary>
        /// Comentários
        /// </summary>
        /// <value></value>
        //public List<ProjectTCCComments>? Comments { get; set; }

        //TODO: Retirar esta propriedade de navegação caso não seja mais necessário
        /// <summary>
        /// Dono do Projeto
        /// </summary>
        /// <value></value>
        //public Tcc? OwnedProject { get; set; }

    }
}