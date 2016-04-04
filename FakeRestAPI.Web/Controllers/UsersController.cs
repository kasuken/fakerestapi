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

        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            return repository.LoadUsers();
        }

        public IHttpActionResult Get(int id)
        {
            var user = repository.LoadUsers().Where(b => b.ID == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]User user)
        {
            return Ok(user);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]User user)
        {
            return Ok(user);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}