using System.Threading.Tasks;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Entities;

namespace API.Integration.TCC.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task  AddAsync(Teacher teacher);
    }
}