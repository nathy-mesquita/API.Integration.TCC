using System;
using System.Collections.Generic;

namespace API.Integration.TCC.Domain.Entities
{
    public class Teacher : User
    {
        public Teacher(string fullName,
                        string email,
                        string password,
                        DateTime birthDate,
                        string specialty,
                        string subjectsTaught)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Specialty = specialty;
            SubjectsTaught = subjectsTaught;

            Role = "IntegrationTCC_Teacher";
            Active = true;
            CreatedAt = DateTime.Now;
            Advisor = false;

            Comments = new List<ProjectTCCComments>();
            AdvisorProjects = new List<ProjectTCC>();
        }
        /// <summary>
        /// Se é Orientador
        /// </summary>
        /// <value></value>
        public bool Advisor { get; private set; }

        /// <summary>
        /// Especialidade
        /// </summary>
        /// <value></value>
        public string Specialty { get; private set; }

        /// <summary>
        /// Disciplinas Ministradas
        /// </summary>
        /// <value></value>
        public string SubjectsTaught { get; private set; }

        /// <summary>
        /// Comentários
        /// </summary>
        /// <value></value>
        public List<ProjectTCCComments> Comments { get; private set; }

        /// <summary>
        /// Orientador do Projeto
        /// </summary>
        /// <value></value>
        public List<ProjectTCC> AdvisorProjects { get; private set; }
    }
}