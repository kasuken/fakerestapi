using FakeRestAPI.Web.Models;
using FakeRestAPI.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeRestAPI.Web.Controllers
{
    public class UsersController : ApiController
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
        public IEnumerable<User> Get()
        {
            return repository.LoadUsers();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
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
        public IHttpActionResult Post([FromBody]User user)
        {
            return Ok(user);
        }

        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody]User user)
        {
            return Ok(user);
        }


        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}