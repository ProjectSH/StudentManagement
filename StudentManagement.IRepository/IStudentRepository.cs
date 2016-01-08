using System.Collections.Generic;
using StudentManagement.Data.Models;

namespace StudentManagement.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> QueryByName(string firstName, string lastName);
    }
}