using System;
using API.Integration.TCC.Domain.Enums;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Value Object - Comments
    /// </summary>
    public class Comments: BaseEntity
    {
        public Comments(string? content, 
                        int idProjectTCC, 
                        int idUser)
        {
            Content = content;
            IdProjectTCC = idProjectTCC;
            IdUser = idUser;

            CreatedAt = DateTime.Now;
            Status = CommentStatusEnum.Created;
        }

        public string? Content { get; private set; }
        public int IdProjectTCC { get; private set; }
        public int IdUser { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public CommentStatusEnum Status { get; private set; }

        //TODO: Retirar estas propriedades de navegação caso não seja mais necessário
        //public Student? Student { get; private set; }
        //public Teacher? Teacher { get; private set; }
        //public ProjectTCC? ProjectTCC { get; private set; }


        public void Update(string content)
        {
            if (Status == CommentStatusEnum.Created)
                Content = content;
        }

        public void Delete()
        {
            if (Status == CommentStatusEnum.Created)
                Status = CommentStatusEnum.Deleted;
        }
    }
}