using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using StudentManagement.Data.Models;

namespace StudentManagement.ILogic
{
    public interface IStudentLogic
    {
        void Create(Student model);
        void Edit(Student model);
        void Delete(int id);
        IEnumerable<Student> GetAll();
        Student Get(int id);
    }
}
