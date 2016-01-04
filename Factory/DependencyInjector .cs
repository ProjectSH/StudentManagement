using log4net;
using System;
using System.Configuration;
using System.Reflection;



namespace Factory
{
    /// <summary>
    /// 依赖注入提供者
    /// 使用反射机制实现
    /// </summary>
    public class DependencyInjector
    {

        /// <summary>
        /// 获取数据层访问对象
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static object GetDALObject(string className)
        {
            string dalName = ConfigurationManager.AppSettings["DAL"];
            string fullClassName = dalName + "." + className;
            //利用反射机制加载
            object dalObject = Assembly.Load(dalName).CreateInstance(fullClassName);

            return dalObject;

        }
        /// <summary>
        /// 取得业务逻辑层对象
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static object GetBLLObject(string className)
        {
            object bllObject = null;
            try
            {
                string bllName = ConfigurationManager.AppSettings["BLL"];
                string fullClassName = bllName + "." + className;
                //利用反射机制加载
                bllObject = Assembly.Load(bllName).CreateInstance(fullClassName);
                return bllObject;
            }
            catch (Exception ex)
            {
                ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("取得业务逻辑层对象错误：" + ex);
                return bllObject;
            }
        }
    }
}

