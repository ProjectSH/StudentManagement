using System;
using System.Text.RegularExpressions;

namespace Common
{
    public class Utility
    {
        /// <summary>
        /// 判断是否数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(string value)
        {
            try
            {
                return Regex.IsMatch(value, @"^[+-]?\d*$");
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 验证邮箱格式是否合法
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(String email)
        {
            try
            {
                Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");

                if (r.IsMatch(email))
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
                return false;
            }
        }
    }
}
