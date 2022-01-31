using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class ProjectTCCCommentsRepository : IProjectTCCCommentsRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;

        public ProjectTCCCommentsRepository(IntegrationTCCDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task AddAsync(ProjectTCCComments comments)
        {
            await _dbContext.ProjectTCCComments.AddAsync(comments);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<ProjectTCCComments>> GetAllAsync()
        {
            return await _dbContext.ProjectTCCComments.SingleOrDefaultAsync(p => p.IdProjectTCC == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}