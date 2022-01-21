using System.Threading.Tasks;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Entities;

namespace API.Integration.TCC.Domain.Repositories
{
    public interface IProjectTCCCommentsRepository
    {
        Task<List<ProjectTCCComments>> GetAllAsync();
        Task AddAsync(ProjectTCCComments comments);
        Task SaveChangesAsync();
    }
}