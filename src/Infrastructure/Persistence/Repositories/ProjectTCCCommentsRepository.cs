using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class ProjectTCCCommentsRepository : IProjectTCCCommentsRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;
        private readonly ILogger<ProjectTCCCommentsRepository> _logger;

        public ProjectTCCCommentsRepository(IntegrationTCCDbContext dbContext, ILogger<ProjectTCCCommentsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddCommentAsync(ProjectTCCComments comments)
        {
            _logger.LogInformation($"Iniciando o método AddAsync");
            await _dbContext.ProjectTCCComments!.AddAsync(comments);
            _logger.LogInformation($"Adicionando o comments={comments}");
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Persistência realizada!");
        }

        public async Task<List<ProjectTCCComments>> GetAsyncByProjectTCC(int idProjectTCC)
        {
            _logger.LogInformation($"Iniciando o método GetAsyncByProjectTCC");
            return await _dbContext.ProjectTCCComments!.Where(p => p.IdProjectTCC == idProjectTCC).ToListAsync();
        }

        public async Task<ProjectTCCComments> GetDetailsByIdAsync(int id)
        {
            _logger.LogInformation($"Iniciando o método GetDetailsByIdAsync");
            return await _dbContext.ProjectTCCComments
                .Include(c => c.Student)
                .Include(c => c.Teacher)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            _logger.LogInformation($"Iniciando o método SaveChangesAsync");
            await _dbContext.SaveChangesAsync();
        }
    }
}