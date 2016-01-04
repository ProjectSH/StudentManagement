using Factory;
using System.Collections.Generic;
using IBLL;
using ENTITY.Models;
using Common;
using System;


namespace BLL
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class StudentBLL : IStudentBLL
    {
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student">学生对象</param>
        /// <returns></returns>
        public Student AddStudent(Student student)
        {
            try
            {
                if (!Utility.IsEmail(student.email))
                {
                    return null;
                }
                return DALFactory.CreateStudentDAL().AddStudent(student);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 返回所有学生
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAll()
        {
            return DALFactory.CreateStudentDAL().GetAll();
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <returns>学生列表</returns>
        public IEnumerable<Student> Seach(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return GetAll();
            }
            return DALFactory.CreateStudentDAL().Seach(firstName,lastName);
        }
        /// <summary>
        /// 根据ID获取学生对象
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns>学生对象</returns>
        public Student GetStudentById(int id)
        {
            return DALFactory.CreateStudentDAL().GetStudentById(id);
        }
        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="student">学生信息</param>
        /// <returns>是否成功 true成功 false 失败</returns>
        public bool UpdateStudent(Student student)
        {
            if (!Utility.IsEmail(student.email))
            {
                return false;
            }
            return DALFactory.CreateStudentDAL().UpdateStudent(student);
        }
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="Id">学生ID</param>
        /// <returns>是否成功 true成功 false 失败</returns>
        public bool DeleteStudent(int Id)
        {
            return DALFactory.CreateStudentDAL().DeleteStudent(Id);
        }
    }
}
