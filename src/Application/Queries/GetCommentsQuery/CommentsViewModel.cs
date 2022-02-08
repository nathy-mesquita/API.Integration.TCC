using System;

namespace API.Integration.TCC.Application.Queries.GetCommentsQuery
{
    public class CommentsViewModel
    {
        public CommentsViewModel(int idProjectTCC, string? content, DateTime createdAt, string? fullName, int idUser)
        {
            IdProjectTCC = idProjectTCC;
            Content = content;
            CreatedAt = createdAt;
            FullName = fullName;
            IdUser = idUser;
        }

        public int IdProjectTCC { get; private set; }
        public string? Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? FullName { get; private set; }
        public int IdUser { get; private set; }
    }
}
