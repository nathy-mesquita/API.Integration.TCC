using System;

namespace API.Integration.TCC.Application.Queries.GetCommentsById
{
    public class CommentsDetailsViewModel
    {
        public CommentsDetailsViewModel(int id, int idProjectTCC, string? content, DateTime createdAt, int idUser)
        {
            Id = id;
            IdProjectTCC = idProjectTCC;
            Content = content;
            CreatedAt = createdAt;
            IdUser = idUser;
        }

        public int Id { get; private set; }
        public int IdProjectTCC { get; private set; }
        public string? Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int IdUser { get; private set; }
    }
}
