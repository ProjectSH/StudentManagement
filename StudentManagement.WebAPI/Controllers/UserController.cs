using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagement.Data.Models;
using StudentManagement.ILogic;

namespace StudentManagement.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [Route("api/user")]
        [HttpPost]
        public void Create(User user)
        {
            _userLogic.Create(user);
        }

        [Route("api/user")]
        [HttpPut]
        public void Update(User user)
        {
            _userLogic.Edit(user);
        }

        [Route("api/user/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _userLogic.Delete(id);
        }

        [Route("api/user/{id}")]
        [HttpGet]
        public User GetUserById(int id)
        {
            return _userLogic.Get(id);
        }
        [Route("api/user/login")]
        [HttpPost]
        public HttpResponseMessage Login(string userName, string password)
        {
            string msg;
            bool result = _userLogic.Login(userName, password, out msg);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.StatusCode = HttpStatusCode.OK;
            if (!result)
            {
                response.Content = new StringContent(msg);
            }
            return response;
        }

    }
}
