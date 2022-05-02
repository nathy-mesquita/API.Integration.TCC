using System;
using System.Collections.Generic;

namespace API.Integration.TCC.Domain.Entities.Users
{
    public class Teacher : User
    {
        public Teacher(string? fullName,
                        string? email,
                        string? password,
                        DateTime birthDate,
                        string? role,
                        string? specialty,
                        string? subjectsTaught)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Role = role;
            Specialty = specialty;
            SubjectsTaught = subjectsTaught;

            Active = true;
            CreatedAt = DateTime.Now;
            Advisor = false;

            //TODO: Retirar esta propriedade de navegação caso não seja mais necessário
            //Comments = new List<ProjectTCCComments>();
            //AdvisorProjects = new List<Tcc>();
        }
        /// <summary>
        /// Papel do Professor
        /// </summary>
        /// <value></value>
        public string? Role { get; private set; }

        /// <summary>
        /// Se é Orientador
        /// </summary>
        /// <value></value>
        public bool Advisor { get; private set; }

        /// <summary>
        /// Especialidade
        /// </summary>
        /// <value></value>
        public string? Specialty { get; private set; }

        /// <summary>
        /// Disciplinas Ministradas
        /// </summary>
        /// <value></value>
        public string? SubjectsTaught { get; private set; }

        //TODO: Retirar esta propriedade de navegação caso não seja mais necessário
        /// <summary>
        /// Comentários
        /// </summary>
        /// <value></value>
        //public List<ProjectTCCComments> Comments { get; private set; }

        //TODO: Retirar esta propriedade de navegação caso não seja mais necessário
        /// <summary>
        /// Orientador do Projeto
        /// </summary>
        /// <value></value>
        //public List<Tcc> AdvisorProjects { get; private set; }

        public void UpdateTeacherAdvisor()
        {
            if (Active)
                Advisor = true;
        }
    }
}