using System;
using API.Integration.TCC.Domain.Enums;

namespace API.Integration.TCC.Domain.Entities.Users
{
    public class Coordinator : User
    {
        public Coordinator(string fullName,
                        string email,
                        string password,
                        DateTime birthDate,
                        CourseEnum course,
                        string role)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Course = course;
            Role = role;

            ConfimaTermo = false;
            Active = true;
            CreatedAt = DateTime.Now;
        }
        /// <summary>
        /// Curso que coordena
        /// </summary>
        /// <value></value>
        public CourseEnum Course { get; private set; }

        /// <summary>
        /// Papel do Coordenadors
        /// </summary>
        /// <value></value>
        public string Role { get; private set; }

        /// <summary>
        /// Confirma o termo de um projeto de tcc
        /// </summary>
        /// <value></value>
        public bool ConfimaTermo { get; private set; }

        public void ConfirmaTermo()
        {
            ConfimaTermo = true;
        }
    }
}