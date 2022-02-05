using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(IntegrationTCCDbContext dbContext, ILogger<StudentRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddAsync(Student student)
        {
            _logger.LogInformation($"Iniciando o método AddAsync");
            await _dbContext.Students!.AddAsync(student);
            _logger.LogInformation($"Adicionando Aluno={student}");
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Persistência realizada");
        }

        public async Task<List<Student>> GetAllAsync()
        {
            _logger.LogInformation($"Iniciando o método GetAllAsync");
            return await _dbContext.Students.ToListAsync<Student>();
        }

        public async Task<Student> GetByEnrollmentAsync(Guid enrollment)
        {
            _logger.LogInformation($"Iniciando o método GetByEnrollmentAsync");
            return await _dbContext.Students.SingleOrDefaultAsync(s => s.Enrollment == enrollment);
        }

        public async Task<Student> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            _logger.LogInformation($"Iniciando o método GetUserByEmailAndPasswordAsync");
            return await _dbContext.Students.SingleAsync(s => s.Email == email && s.Password == passwordHash);
        }
    }
}