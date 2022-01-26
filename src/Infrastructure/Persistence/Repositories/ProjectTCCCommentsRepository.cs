using System.Collections.Generic;
using System.Threading.Tasks;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class ProjectTCCCommentsRepository : IProjectTCCCommentsRepository
    {
        public Task AddAsync(ProjectTCCComments comments)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProjectTCCComments>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}