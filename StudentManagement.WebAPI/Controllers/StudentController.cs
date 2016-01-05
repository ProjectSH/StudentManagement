using System.Collections.Generic;
using System.Web.Http;
using StudentManagement.Data.Models;
using StudentManagement.ILogic;

namespace StudentManagement.WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentLogic _studentLogic;
        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        [Route("api/student")]
        [HttpPost]
        public void Create(Student student)
        {
            _studentLogic.Create(student);
        }

        [Route("api/student")]
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _studentLogic.GetAll();
        }

        [Route("api/student/{firstName}/{lastName}")]
        [HttpGet]
        public IEnumerable<Student> QueryByName(string firstName, string lastName)
        {
            return _studentLogic.QueryByName(firstName, lastName);
        }
        [Route("api/student/{id}")]
        [HttpGet]
        public Student GetStudentById(int id)
        {
            return _studentLogic.Get(id);
        }

        [Route("api/student")]
        [HttpPut]
        public void Update(Student student)
        {
            _studentLogic.Update(student);
        }

        [Route("api/student/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _studentLogic.Delete(id);
        }
    }
}
