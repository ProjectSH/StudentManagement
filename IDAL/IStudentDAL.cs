using ENTITY.Models;
using System.Collections.Generic;

namespace IDAL
{
    /// <summary>
    /// 学生数据访问接口层
    /// </summary>
    public interface IStudentDAL
    {
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student AddStudent(Student student);
        /// <summary>
        /// 获取所有学生
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAll();
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <returns>学生列表</returns>
        IEnumerable<Student> Seach(string firstName, string lastName);
        /// <summary>
        /// 根据ID获取学生对象
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns>学生对象</returns>
        Student GetStudentById(int id);
        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="student">学生信息</param>
        /// <returns>是否成功 true成功 false 失败</returns>
        bool UpdateStudent(Student student);
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="Id">学生ID</param>
        /// <returns>是否成功 true成功 false 失败</returns>
        bool DeleteStudent(int Id);
    }
}
