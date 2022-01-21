using System;

namespace API.Integration.TCC.Domain.Entities
{
    public class ProjectTCCComments
    {
        public ProjectTCCComments(string? content,
                                    int idProjectTCC,
                                    int idUser)
        {
            Content = content;
            IdProjectTCC = idProjectTCC;
            IdUser = idUser;

            CreatedAt = DateTime.Now;
        }

        public string? Content { get; private set; }
        public int IdProjectTCC { get; private set; }
        public ProjectTCC? ProjectTCC { get; private set; }
        public int IdUser { get; private set; }
        public User? User { get; private set; }
        public DateTime? CreatedAt { get; private set; }
    }
}