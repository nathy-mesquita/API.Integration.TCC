using System;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Entities.Users;
using API.Integration.TCC.Domain.Enums;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Value Object - Term
    /// </summary>
    public class Term : BaseEntity
    {
        public Term(string content,
                    Student emittedBy,
                    Tcc idProjectTCC)
        {
            Content = content;
            EmittedBy = emittedBy;
            IdProjectTCC = idProjectTCC;

            CreatedAt = DateTime.Now;
            Status = TermStatusEnum.Emitted;
        }

        /// <summary>
        /// Conteúdo do termo
        /// </summary>
        /// <value></value>
        public string Content { get; private set; }

        /// <summary>
        /// Emitido por <see cref="Student"/>
        /// </summary>
        /// <value></value>
        public Student EmittedBy { get; private set; }

        /// <summary>
        /// Projeto de TCC
        /// </summary>
        /// <value></value>
        public Tcc IdProjectTCC { get; private set; }

        /// <summary>
        /// Criado em 
        /// </summary>
        /// <value></value>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Aceito por <see cref="Teacher"/> Orientador
        /// </summary>
        /// <value></value>
        public Teacher? AcceptedBy { get; private set; }

        /// <summary>
        /// Aprovavo por <see cref="Coordinator"/>
        /// </summary>
        /// <value></value>
        public Coordinator? ApprovedBy { get; private set; }

        /// <summary>
        /// Projeto de TCC
        /// </summary>
        /// <value></value>
        public Tcc? ProjectTcc { get; private set; }

        /// <summary>
        /// Status do Termo
        /// </summary>
        /// <value></value>
        public TermStatusEnum Status { get; private set; }

        public void AcceptTerm(Teacher acceptedBy)
        {
            if(Status == TermStatusEnum.Emitted)
            {
                AcceptedBy = acceptedBy;
                Status = TermStatusEnum.Accepted;
            }
        }

        public void ApproveTerm(Coordinator approvedBy)
        {
            if(Status == TermStatusEnum.Accepted)
            {
                ApprovedBy = approvedBy;
                Status = TermStatusEnum.Approved;
            }
        }

        public void RejectTerm()
        {
            if ((Status == TermStatusEnum.Emitted) || (Status == TermStatusEnum.Accepted))
            {
                Status = TermStatusEnum.Rejected;
            }
        }

    }
}