using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;
        private readonly ILogger<TeacherRepository> _logger;

        public TeacherRepository(IntegrationTCCDbContext dbContext, ILogger<TeacherRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddAsync(Teacher teacher)
        {
            _logger.LogInformation($"Iniciando o método AddAsync");
            await _dbContext.Teachers!.AddAsync(teacher);
            _logger.LogInformation($"Adicionando Professor={teacher}");
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Persistência realizada");
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            _logger.LogInformation($"Iniciando o método GetAllAsync");
            return await _dbContext.Teachers.ToListAsync<Teacher>();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Iniciando o método GetByIdAsync");
            return await _dbContext.Teachers.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Teacher> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            _logger.LogInformation($"Iniciando o método GetUserByEmailAndPasswordAsync");
            return await _dbContext.Teachers.SingleAsync(t => t.Email == email && t.Password == passwordHash);
        }

        public async Task SaveChangesAsync()
        {
            _logger.LogInformation($"Iniciando o método SaveChangesAsync");
            await _dbContext.SaveChangesAsync();
        }
    }
}