using IBLL;

namespace Factory
{
    /// <summary>
    /// 业务逻辑层工厂，用于生成相应的业务逻辑层对象
    /// </summary>
    public sealed class BLLFactory
    {
        /// <summary>
        /// 获取学生业务逻辑层类
        /// </summary>
        /// <returns>学生业务逻辑层</returns>
        public static IStudentBLL CreateStudentBLL()
        {
            return (IStudentBLL)DependencyInjector.GetBLLObject("StudentBLL");
        }
    }
}
