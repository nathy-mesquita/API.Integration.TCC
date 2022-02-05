using System;

namespace API.Integration.TCC.Application.Queries.GetAllTeacher
{
    public class TeacherViewModel
    {
        public TeacherViewModel(int id, string fullName, string email, string subjectsTaught, DateTime createdAt)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            SubjectsTaught = subjectsTaught;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string SubjectsTaught { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
