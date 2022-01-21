using System.Threading.Tasks;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Entities;

namespace API.Integration.TCC.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task  AddAsync(Student user);
    }
}