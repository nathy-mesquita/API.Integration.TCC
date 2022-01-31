using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class ProjectTCCRepository : IProjectTCCRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;

        public ProjectTCCRepository(IntegrationTCCDbContext dbContext) => _dbContext = dbContext;

        public async Task AddAsync(ProjectTCC projectTCC)
        {
            await _dbContext.ProjectsTCC.AddAsync(projectTCCResult);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCommentAsync(ProjectTCCComments projectTCCComments)
        {
            await _dbContext.ProjectTCCComments.AddAsync(projectTCCComments);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectTCC>> GetAllAsync()
        {
            return await _dbContext.ProjectsTCC.ToListAsync<ProjectTCC>();
        }

        public async Task<ProjectTCC> GetByIdAsync(int id)
        {
            return await _dbContext.ProjectsTCC.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProjectTCC> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.ProjectsTCC
                .Include(p => p.Student)
                .Include(p => p.Teacher) 
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}