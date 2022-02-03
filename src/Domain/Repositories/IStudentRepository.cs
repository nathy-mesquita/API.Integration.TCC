using API.Integration.TCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Integration.TCC.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByEnrollmentAsync(Guid enrollment);
        Task<Student> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task AddAsync(Student student);
    }
}