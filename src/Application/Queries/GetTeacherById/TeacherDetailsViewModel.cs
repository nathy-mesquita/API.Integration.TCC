using System;

namespace API.Integration.TCC.Application.Queries.GetTeacherById
{
    public class TeacherDetailsViewModel
    {
        public TeacherDetailsViewModel(int id, string fullName, string email, string specialty, string subjectsTaught, DateTime birthDate, DateTime createdAt, bool active)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Specialty = specialty;
            SubjectsTaught = subjectsTaught;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Specialty { get; private set; }
        public string SubjectsTaught { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
