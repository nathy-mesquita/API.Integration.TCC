using System.Threading.Tasks;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;
        public TeacherRepository(IntegrationTCCDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task AddAsync(Teacher teacher)
        {
            await _dbContext.Students.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _dbContext.Teacher.ToListAsync<Student>();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _dbContext.Teacher.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Teacher> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Teacher.SingleAsync(t => t.Email == email && t.Password == passwordHash);
        }
    }
}