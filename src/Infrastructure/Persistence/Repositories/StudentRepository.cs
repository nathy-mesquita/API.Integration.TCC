using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<Student> GetByEnrollmentAsync(string enrollment)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            throw new System.NotImplementedException();
        }
    }
}