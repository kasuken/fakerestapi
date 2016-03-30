using FakeRestAPI.Web.Models;
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
        List<User> Users = new List<User>();

        public UsersController()
        {
            for (int i = 1; i < 11; i++)
            {
                var user = new User();
                user.ID = i;
                user.UserName = string.Format("User {0}", i.ToString());
                user.Password = string.Format("Password{0}", i.ToString());

                Users.Add(user);
            }
        }

        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            return Users;
        }

        public IHttpActionResult Get(int id)
        {
            var user = Users.Where(b => b.ID == id).FirstOrDefault();

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