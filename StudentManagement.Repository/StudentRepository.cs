using System.Collections.Generic;
using System.Linq;
using StudentManagement.Data;
using StudentManagement.Data.Models;
using StudentManagement.IRepository;

namespace StudentManagement.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbfactory) : base(dbfactory)
        {
            
        }
        public IEnumerable<Student> QueryByName(string firstName, string lastName)
        {
            return Query().Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName));
        }
    }
}