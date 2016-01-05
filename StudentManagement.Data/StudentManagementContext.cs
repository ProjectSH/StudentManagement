using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StudentManagement.Data.Models;

namespace StudentManagement.Data
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext() : base("name=StudentManageContext")
        {
        }

        public DbSet<Student> CustomerEnquiries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
