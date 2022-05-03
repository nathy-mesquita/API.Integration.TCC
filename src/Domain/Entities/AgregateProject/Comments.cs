using System;
using API.Integration.TCC.Domain.Enums;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Value Object - Comments
    /// </summary>
    public class Comments: BaseEntity
    {
        public Comments(string content, 
                        Tcc idProjectTCC,
                        Authors idUser)
        {
            Content = content;
            IdProjectTCC = idProjectTCC;
            IdUser = idUser;

            CreatedAt = DateTime.Now;
            Status = CommentStatusEnum.Created;
        }

        /// <summary>
        /// Conteúdo
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Identificador do projeto de <see cref="Tcc"/>
        /// </summary>
        public Tcc IdProjectTCC { get; private set; }

        /// <summary>
        /// Identificador do autor do comentário <see cref="Authors.IdStudent"/> ou <see cref="Authors.IdTeacher"/>
        /// </summary>
        public Authors IdUser { get; private set; }

        /// <summary>
        /// Criado em 
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Status do comentário <see cref="CommentStatusEnum.Created"/> ou <see cref="CommentStatusEnum.Deleted"/>
        /// </summary>
        public CommentStatusEnum Status { get; private set; }


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