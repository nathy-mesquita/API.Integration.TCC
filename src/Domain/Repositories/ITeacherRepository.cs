using API.Integration.TCC.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Integration.TCC.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task AddAsync(Teacher teacher);
    }
}