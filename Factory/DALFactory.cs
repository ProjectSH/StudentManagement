using IDAL;


namespace Factory
{
    /// <summary>
    /// 数据访问层工厂，用于生成相应的数据访问层对象
    /// </summary>
    public sealed class DALFactory
    {
        /// <summary>
        /// 获取学生数据访问层类
        /// </summary>
        /// <returns>学生数据访问层</returns>
        public static IStudentDAL CreateStudentDAL()
        {
            return (IStudentDAL)DependencyInjector.GetDALObject("StudentDAL");
        }
    }
}
