
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using StudentManagement.Data.Models;
using StudentManagement.IRepository;

namespace StudentManagement.DapperRepository
{
    public class StudentDapperRepository: AbstractDapperMapper<Student>, IStudentRepository
    {
        protected override string TableName
        {
            get { return "Student"; }
        }
        public void Create(Student model)
        {
            using (IDbConnection conn = Connection )
            {
                string sql = "insert into Student (IdentityId,FirstName,LastName,Email,Age) values(@IdentityId,@FirstName,@LastName,@Email,@Age)";
                conn.Execute(sql, model);
            }
        }

        public override Student Map(dynamic result)
        {
            return new Student
            {
                Id = result.Id,
                Age = result.Age,
                Email = result.Email,
                FirstName = result.FirstName,
                IdentityId = result.IdentityId,
                LastName = result.LastName
            };
        }
        
       

        public Student Get(int id)
        {
            return FindSingle("SELECT * FROM Users WHERE ID=@ID", new { ID = id });
        }

        public void Edit(Student model)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "UPDATE Student SET IdentityId = @IdentityId,FirstName = @FirstName ,LastName=@LastName,Email = @Email ,Age = @Age WHERE Id=@Id";
                conn.Execute(sql, model);
            }
        }

        public IEnumerable<Student> QueryByName(string firstName, string lastName)
        {
            var items = new List<Student>();

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                
                if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                {
                    return Query();
                }

                string sql = "SELECT * FROM " + TableName + " where 1=1 ";
                dynamic obj=new System.Dynamic.ExpandoObject();
                if (!string.IsNullOrEmpty(firstName))
                {
                    sql += " and FirstName like @FirstName ";
                    obj.FirstName = "%"+firstName+"%";
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    sql += " and LastName like @LastName ";
                    obj.LastName = "%"+lastName+"%";
                }
                var results = cn.Query(sql, (object)obj).ToList();

                for (int i = 0; i < results.Count(); i++)
                {
                    items.Add(Map(results.ElementAt(i)));
                }
            }

            return items;
        }
    }
}
