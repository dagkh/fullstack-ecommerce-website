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
    public class RolesController : ApiController
    {
        private readonly IRolesService _roleService;

        public RolesController(IRolesService roleService)
        {
            _roleService = roleService;
        }

        // GET: /Api/Roles/GetAll
        [HttpGet]
        [Route("Api/Roles/GetAll")]
        public IEnumerable<RoleViewModel> GetAll()
        {
            var roles = _roleService.GetAll();

            return roles;
        }


        // GET: /Api/Roles/GetById
        [HttpGet]
        [Route("Api/Roles/GetById")]
        public IHttpActionResult GetById(int roleId)
        {
            var role = _roleService.Get(roleId);

            if (role == null)
                return NotFound();

            return Ok(role);
        }


        // POST: /Api/Roles/Create
        [HttpPost]
        [Route("Api/Roles/Create")]
        public IHttpActionResult Create(RoleFormViewModel roleForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                _roleService.Add(roleForm);

                return Created(new Uri(Request.RequestUri + "/" + roleForm.Code), roleForm);
            }
        }


        // PUT: /Api/Roles/Update
        [HttpPut]
        [Route("Api/Roles/Update")]
        public IHttpActionResult Update(string code, RoleFormViewModel roleForm)
        {
            _roleService.Update(code, roleForm);

            return Ok(roleForm);
        }


        // DELETE: /Api/Roles/Delete
        [HttpDelete]
        [Route("Api/Roles/Delete")]
        public void Delete(int roleId)
        {
            var role = _roleService.Get(roleId);

            if (role == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _roleService.Delete(role.Code);
        }
    }
}
