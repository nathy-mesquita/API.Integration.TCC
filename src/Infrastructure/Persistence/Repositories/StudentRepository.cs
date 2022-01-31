using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;

        public StudentRepository(IntegrationTCCDbContext dbContext) => _dbContext = dbContext;

        public async Task AddAsync(Student student)
        {
            await _dbContext.Students!.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _dbContext.Students.ToListAsync<Student>();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            return await _dbContext.Students.SingleOrDefaultAsync(s => s.Enrollment == enrollment);
        }

        public async Task<Student> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Student.SingleAsync(s => s.Email == email && s.Password == passwordHash);
        }
    }
}