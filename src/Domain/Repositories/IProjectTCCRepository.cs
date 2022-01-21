using System.Threading.Tasks;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Entities;

namespace API.Integration.TCC.Domain.Repositories
{
    public interface IProjectTCCRepository
    {
        Task<List<ProjectTCC>> GetAllAsync();
        Task<ProjectTCC> GetDetailsByIdAsync(int id);
        Task<ProjectTCC> GetByIdAsync(int id);
        Task AddAsync(ProjectTCC projectTCC);
        Task SaveChangesAsync();
        Task AddCommentAsync(ProjectTCCComments projectTCCComments);
    }
}