using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class ProjectTCCCommentsRepository : IProjectTCCCommentsRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;

        public ProjectTCCCommentsRepository(IntegrationTCCDbContext dbContext) => _dbContext = dbContext;

        public Task AddAsync(ProjectTCCComments comments)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProjectTCCComments>> GetAsyncByProjectTCC(int idProjectTCC)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}