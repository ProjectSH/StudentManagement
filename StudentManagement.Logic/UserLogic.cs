using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Data.Models;
using StudentManagement.ILogic;
using StudentManagement.Infrustructure;
using StudentManagement.IRepository;
using StudentManagement.Repository;

namespace StudentManagement.Logic
{
    public class UserLogic:IUserLogic
    {
        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private IUserRepository _userRepository = null;
        public void Create(User model)
        {
            _userRepository=new UserRepository(null);
        }

        public void Edit(User model)
        {

        }

        public void Delete(int id)
        {

        }

        public User Get(int id)
        {
            User user = null;
            return user;
        }

        public bool Login(string userName, string password)
        {
            bool result = false;
            var user = _userRepository.Get(userName);
            if (user!=null&&user.Password.Equals(Cryptography.Encrypt(password)))
            {
                result = true;
            }

            return result;
        }
    }
}
