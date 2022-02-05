using System;

namespace API.Integration.TCC.Application.Queries.GetStudentByEnrollment
{
    public class StudentDetailsViewModel
    {
        public StudentDetailsViewModel(Guid enrollment, string fullName, string email, DateTime birthDate, DateTime createdAt, bool active)
        {
            Enrollment = enrollment;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
        }

        public Guid Enrollment { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
