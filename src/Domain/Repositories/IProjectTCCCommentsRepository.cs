using API.Integration.TCC.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Integration.TCC.Domain.Repositories
{
    public interface IProjectTCCCommentsRepository
    {
        Task<List<ProjectTCCComments>> GetAsyncByProjectTCC(int idProjectTCC);
        Task<ProjectTCCComments> GetDetailsByIdAsync(int id);
        Task AddCommentAsync(ProjectTCCComments comments);
        Task SaveChangesAsync();
    }
}