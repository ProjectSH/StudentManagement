
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using StudentManagement.Data.Models;
using StudentManagement.IRepository;

namespace StudentManagement.DapperRepository
{
    public class StudentDapperRepository: IStudentRepository
    {
        

        private IDbConnection conn;
        public void Create(Student model)
        {
            using (conn=new SqlConnection(SqlHelper.GetSqlConnection()))
            {
                string sql = "insert into Student (IdentityId,FirstName,LastName,Email,Age) values(@IdentityId,@FirstName,@LastName,@Email,@Age)";
                conn.Execute(sql, model);
            }
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Student> Query()
        {
            throw new System.NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Student model)
        {
            throw new System.NotImplementedException();
        }
    }
}
