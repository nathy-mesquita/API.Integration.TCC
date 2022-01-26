using System.Collections.Generic;
using System.Threading.Tasks;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;

        public StudentRepository(IntegrationTCCDbContext dbContext) => _dbContext = dbContext;

        public Task AddAsync(Student user)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Student>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            throw new System.NotImplementedException();
        }
    }
}