using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentManagement.Data.Models;

namespace StudentManagement.ILogic
{
    public interface IUserLogic
    {
        void Create(User model);
        void Edit(User model);
        void Delete(int id);
        User Get(int id);
        bool Login(string userName, string password,out string message);
    }
}
