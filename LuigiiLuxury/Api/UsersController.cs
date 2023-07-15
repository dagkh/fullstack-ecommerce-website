using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Unity;

using LuigiiLuxury.Domain.Interfaces.Services;
using LuigiiLuxury.Domain.ViewModels;

namespace LuigiiLuxury.Api
{
    public class UsersController : ApiController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: /Api/Users/GetAll
        [HttpGet]
        [Route("Api/Users/GetAll")]
        public IEnumerable<UserViewModel> Get()
        {
            var user = _usersService.GetAll();

            return user;
        }


        // GET: /Api/Users/GetByRole
        [HttpGet]
        [Route("Api/Users/GetByRole")]
        public IEnumerable<UserViewModel> GetByRole(string roleCode, RoleViewModel role)
        {
            var user = _usersService.GetByRole(roleCode);

            return user;
        }


        // GET: /Api/Users/GetById
        [HttpGet]
        [Route("Api/Users/GetById")]
        public IHttpActionResult GetById(int userId)
        {
            var user = _usersService.Get(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }


        // GET: /Api/Users/Login
        [HttpGet]
        [Route("Api/Users/Login")]
        public UserViewModel Login(LoginViewModel loginForm)
        {
            var user = _usersService.Login(loginForm);

            if (user != null)
                return user;
            return null;
        }


        // POST: /Api/Users/Register
        [HttpPost]
        [Route("Api/Users/Register")]
        public IHttpActionResult Register(RegisterViewModel registerForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                _usersService.Register(registerForm);

                return Created(new Uri(Request.RequestUri + "/" + registerForm.Id), registerForm);
            }
        }


        // PUT: /Api/Users/Update
        [HttpPut]
        [Route("Api/Users/Update")]
        public IHttpActionResult Update(int userId, UserFormViewModel userForm)
        {
            _usersService.Update(userId, userForm);

            return Ok(userForm);
        }


        // PUT: /Api/Users/ChangePassword
        [HttpPut]
        [Route("Api/Users/ChangePassword")]
        public IHttpActionResult ChangePassword(ChangePasswordFormViewModel changePasswordForm)
        {
            _usersService.ChangePassword(changePasswordForm);

            return Ok(changePasswordForm);
        }


        // PUT: /Api/Users/SetRole
        [HttpPut]
        [Route("Api/Users/SetRole")]
        public IHttpActionResult SetRole(SetRoleFormViewModel roleForm)
        {
            _usersService.SetRole(roleForm);

            return Ok(roleForm);
        }


        // DELETE: /Api/Users/Delete
        [HttpDelete]
        [Route("Api/Users/Delete")]
        public void Delete(int userId)
        {
            var user = _usersService.Get(userId);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _usersService.Delete(user.Id);
        }
    }
}
