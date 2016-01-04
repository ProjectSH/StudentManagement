using ENTITY.Models;
using IDAL;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    /// <summary>
    /// 数据访问层
    /// </summary>
    public class StudentDAL : IStudentDAL
    {
        ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        StudentManageContext context = null;
        public StudentDAL()
        {
            if (context == null)
            {
                context = new StudentManageContext();
            }
        }
        /// <summary>
        /// 添加学生对象
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student AddStudent(Student student)
        {
            try
            {
                context.Students.Add(student);
                context.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {
                log.Error("添加学生信息失败：" + ex);
                return null;
            }
        }
        /// <summary>
        /// 获取所有学生
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAll()
        {
            try
            {
                return context.Students.ToList();
            }
            catch (Exception ex)
            {
                log.Error("添加学生信息失败：" + ex);
                return null;
            }
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <returns>学生列表</returns>
        public IEnumerable<Student> Seach(string firstName, string lastName)
        {
            try
            {
                var query = context.Students;
                if (!string.IsNullOrEmpty(firstName))
                {
                    if (!string.IsNullOrEmpty(lastName))
                    {
                        return context.Students.Where(p => p.firstName.Contains(firstName) && p.lastName.Contains(lastName)).ToList();
                    }
                    else
                    {
                        return context.Students.Where(p => p.firstName.Contains(firstName)).ToList();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(lastName))
                    {
                        return context.Students.Where(p => p.lastName.Contains(lastName)).ToList();
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("查询失败：" + ex);
                return null;
            }

        }

        /// <summary>
        /// 根据ID获取学生对象
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns>学生对象</returns>
        public Student GetStudentById(int id)
        {
            try
            {
                return context.Students.Find(id);
            }
            catch (Exception ex)
            {
                log.Error("根据id获取学生信息失败：" + ex);
                return null;
            }
        }
        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="student">学生信息</param>
        /// <returns>是否成功 true成功 false 失败</returns>
        public bool UpdateStudent(Student student)
        {
            try
            {
                context.Entry(student).State = EntityState.Modified;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Error("更新学生信息失败：" + ex);
                return false;
            }
        }
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="Id">学生ID</param>
        /// <returns>是否成功 true成功 false 失败</returns>
        public bool DeleteStudent(int Id)
        {
            try
            {
                Student student = GetStudentById(Id);
                context.Students.Attach(student);
                context.Entry(student).State = EntityState.Deleted;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Error("删除学生信息失败：" + ex);
                return false;
            }
        }

    }
}
