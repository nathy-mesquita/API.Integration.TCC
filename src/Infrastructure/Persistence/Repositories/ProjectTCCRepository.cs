using System.Collections.Generic;
using System.Threading.Tasks;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class ProjectTCCRepository : IProjectTCCRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;

        public ProjectTCCRepository(IntegrationTCCDbContext dbContext) => _dbContext = dbContext;

        public Task AddAsync(ProjectTCC projectTCC)
        {
            throw new System.NotImplementedException();
        }

        public Task AddCommentAsync(ProjectTCCComments projectTCCComments)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ProjectTCC>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjectTCC> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjectTCC> GetDetailsByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}