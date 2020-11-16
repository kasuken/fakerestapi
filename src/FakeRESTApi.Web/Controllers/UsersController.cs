using FakeRestAPI.Models;
using FakeRestAPI.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeRESTApi.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IRepository repository;

        public UsersController(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(repository.LoadUsers());
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = repository.LoadUsers().Where(b => b.ID == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Posts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            return Ok(user);
        }

        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            return Ok(user);
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
