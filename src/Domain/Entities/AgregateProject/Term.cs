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
        public Term(string? content,
                    int emittedBy,
                    int idProjectTCC)
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
        public string? Content { get; private set; }

        /// <summary>
        /// Criado em 
        /// </summary>
        /// <value></value>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Emitido por (Aluno)
        /// </summary>
        /// <value></value>
        public int EmittedBy { get; private set; }

        /// <summary>
        /// Aluno que emite o termo
        /// </summary>
        /// <value></value>
        public Student? Student { get; private set; }

        /// <summary>
        /// Aceito por (Professor Orientador)
        /// </summary>
        /// <value></value>
        public int AcceptedBy { get; private set; }
        
        /// <summary>
        /// Professor que aceita o termo
        /// </summary>
        /// <value></value>
        public Teacher? Teacher { get; private set; }

        /// <summary>
        /// Aprovavo por (Coordenador)
        /// </summary>
        /// <value></value>
        public int ApprovedBy { get; private set; }

        /// <summary>
        /// Coordenador que aprova o termo
        /// </summary>
        /// <value></value>
        public Coordinator? Coordinator { get; private set; }

        /// <summary>
        /// Projeto de TCC
        /// </summary>
        /// <value></value>
        public int IdProjectTCC { get; private set; }

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

        public void AcceptTerm(int acceptedBy)
        {
            if(Status == TermStatusEnum.Emitted)
            {
                AcceptedBy = acceptedBy;
                Status = TermStatusEnum.Accepted;
            }
        }

        public void ApproveTerm(int approvedBy)
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