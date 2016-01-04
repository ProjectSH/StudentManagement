using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ENTITY.Models.Mapping;

namespace ENTITY.Models
{
    /// <summary>
    /// 数据库会话类
    /// </summary>
    public partial class StudentManageContext : DbContext
    {
        static StudentManageContext()
        {
            Database.SetInitializer<StudentManageContext>(null);
        }

        public StudentManageContext()
            : base("Name=StudentManageContext")
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMap());
        }
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'  
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded.   
            //Make sure the provider assembly is available to the running application.   
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.  

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }  
    }
}
