using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class ProjectTCCRepository : IProjectTCCRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;
        private readonly ILogger<ProjectTCCRepository> _logger;

        public ProjectTCCRepository(IntegrationTCCDbContext dbContext, ILogger<ProjectTCCRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddAsync(ProjectTCC projectTCC)
        {
            await _dbContext.ProjectsTCC!.AddAsync(projectTCC);
            await _dbContext.SaveChangesAsync();
        }

        //TODO: é necessário esse metodo aqui?
        public async Task AddCommentAsync(ProjectTCCComments projectTCCComments)
        {
            await _dbContext.ProjectTCCComments!.AddAsync(projectTCCComments);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectTCC>> GetAllAsync()
        {
            _logger.LogInformation($"Iniciando o método GetAllAsync");
            return await _dbContext.ProjectsTCC.ToListAsync<ProjectTCC>();
        }

        public async Task<ProjectTCC> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Iniciando o método GetByIdAsync");
            return await _dbContext.ProjectsTCC.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProjectTCC> GetDetailsByIdAsync(int id)
        {
            _logger.LogInformation($"Iniciando o método GetDetailsByIdAsync");
            return await _dbContext.ProjectsTCC
                .Include(p => p.Student)
                .Include(p => p.Teacher)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            _logger.LogInformation($"Iniciando o método SaveChangesAsync");
            await _dbContext.SaveChangesAsync();
        }
    }
}