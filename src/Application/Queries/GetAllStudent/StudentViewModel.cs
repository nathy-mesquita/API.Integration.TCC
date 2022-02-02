using System;

namespace API.Integration.TCC.Application.Queries.GetAllStudent
{
    public class StudentViewModel
    {
        public StudentViewModel(Guid enrollment, string fullName, string email, string role, DateTime createdAt)
        {
            Enrollment = enrollment;
            FullName = fullName;
            Email = email;
            Role = role;
            CreatedAt = createdAt;
        }

        public Guid Enrollment { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
