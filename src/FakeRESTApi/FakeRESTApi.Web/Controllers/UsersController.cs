using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FakeRESTApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeRESTApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        /// <summary>
        /// Retrieves 50 fake users
        /// </summary> 
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var userIds = 0;
            var testUsers = new Faker<User>()
                .RuleFor(u => u.Id, f => userIds++)
                .RuleFor(u => u.Username, (f, u) => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Avatar, f => f.Internet.Avatar());
                
            var users = testUsers.Generate(50);

            return users;
        }

        /// <summary>
        /// Retrieves a specific user by id.
        /// </summary>
        /// <param name="id"></param>  
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var testUser = new Faker<User>()
                .RuleFor(u => u.Id, f => id)
                .RuleFor(u => u.Username, (f, u) => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Avatar, f => f.Internet.Avatar());

            var user = testUser.Generate();

            return Ok(user);
        }

    }
}