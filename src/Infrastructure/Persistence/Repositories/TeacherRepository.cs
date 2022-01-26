using System.Threading.Tasks;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;

namespace API.Integration.TCC.Infrastructure.Persistence.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IntegrationTCCDbContext _dbContext;
        public TeacherRepository(IntegrationTCCDbContext dbContext) => _dbContext = dbContext;

        public Task AddAsync(Teacher user)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Teacher>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Teacher> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Teacher> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            throw new System.NotImplementedException();
        }
    }
}