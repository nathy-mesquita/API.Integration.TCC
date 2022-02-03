using System;

namespace API.Integration.TCC.Domain.Entities
{
    public class ProjectTCCComments : BaseEntity
    {
        public ProjectTCCComments(string content,
                                    int idProjectTCC,
                                    int idStudent,
                                    int idTeacher)
        {
            Content = content;
            IdProjectTCC = idProjectTCC;
            IdStudent = idStudent;
            IdTeacher = idTeacher;

            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public int IdProjectTCC { get; private set; }
        public ProjectTCC ProjectTCC { get; private set; }
        public int IdStudent { get; private set; }
        public Student Student { get; private set; }
        public int IdTeacher { get; private set; }
        public Teacher Teacher { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}