using ENTITY.Models;
using System.Collections.Generic;

namespace IBLL
{
    /// <summary>
    /// 学生业务逻辑接口
    /// </summary>
    public interface IStudentBLL
    {
        /// <summary>
        /// 添加学生接口
        /// </summary>
        /// <param name="student">学生实体</param>
        /// <returns></returns>
        Student AddStudent(Student student);
        /// <summary>
        /// 获取所有学生
        /// </summary>
        /// <returns>学生列表</returns>
        IEnumerable<Student> GetAll();
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <returns>学生列表</returns>
        IEnumerable<Student> Seach(string firstName,string lastName);
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
