using ENTITY.Models;
using Factory;
using IBLL;
using log4net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    public class StudentController : ApiController
    {
        /// <summary>
        /// 添加学生信息
        /// post /api/student
        /// </summary>
        /// <param name="student">学生信息 </param>
        /// <returns></returns>
        public HttpResponseMessage Add(Student student)
        {
            try
            {
                IStudentBLL studentBll = BLLFactory.CreateStudentBLL();
                studentBll.AddStudent(student);
                var response = Request.CreateResponse<Student>(HttpStatusCode.Created, student);
                string uri = Url.Link("DefaultApi", new { id = student.Id });
                response.Headers.Location = new Uri(uri);
               
                return response;
            }
            catch (Exception ex)
            {
                ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("添加学生错误：" + ex);
                return null;
            }
        }
        /// <summary>
        /// 获取所有学生信息
        /// get /api/student
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAll()
        {
            try
            {
                 IStudentBLL studentBll = BLLFactory.CreateStudentBLL();
                 return studentBll.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("获取学生列表错误：" + ex);
                return null;
            }
        }
        /// <summary>
        /// 获取所有学生信息
        /// get /api/student?firstName=&lastName=
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Student> Seach(string firstName,string lastName)
        {
            try
            {
                IStudentBLL studentBll = BLLFactory.CreateStudentBLL();
                return studentBll.Seach(firstName,lastName);
            }
            catch (Exception ex)
            {
                ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("获取学生列表错误：" + ex);
                return null;
            }
        }
        /// <summary>
        /// 根据学生编号获取学生信息
        /// get /api/student/id
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <returns>学生信息</returns>
        public Student GetStudentById(int id)
        {
            try
            {
                IStudentBLL studentBll = BLLFactory.CreateStudentBLL();
                return studentBll.GetStudentById(id);
            }
            catch (Exception ex)
            {
                ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("获取学生信息错误：" + ex);
                return null;
            }
        }
        /// <summary>
        /// 更新学生信息
        /// put api/student
        /// </summary>
        /// <param name="student">学生信息</param>
        /// <returns>是否成功</returns>
        [HttpPut]
        public bool UpdateStudent(Student student)
        {
            try
            {
                IStudentBLL studentBll = BLLFactory.CreateStudentBLL();
                return studentBll.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("更新学生信息错误：" + ex);
                return false;
            }
        }
        /// <summary>
        /// 删除学生信息
        /// delete api/student/id
        /// </summary>
        /// <param name="id">学生编号</param>
        /// <returns>是否成功</returns>
        public bool DeleteStudent(int id)
        {
            try
            {
                IStudentBLL studentBll = BLLFactory.CreateStudentBLL();
                return studentBll.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("删除学生信息错误：" + ex);
                return false;
            }
        }
    }
}
