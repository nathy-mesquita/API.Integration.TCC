using System;

namespace API.Integration.TCC.Application.Queries.GetAllStudent
{
    public class StudentViewModel
    {
        public StudentViewModel(int id, Guid enrollment, string fullName, string course, DateTime createdAt)
        {
            Id = id;
            Enrollment = enrollment;
            FullName = fullName;
            Course = course;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public Guid Enrollment { get; set; }
        public string FullName { get; private set; }
        public string Course { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
