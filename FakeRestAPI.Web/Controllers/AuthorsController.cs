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
    public class AuthorsController : ApiController
    {
        IRepository repository;

        public AuthorsController(IRepository _repository)
        {
            repository = _repository;
        }

        // GET api/<controller>
        public IEnumerable<Author> Get()
        {
            return repository.LoadAuthors();
        }

        [Route("authors/books/{idBook}")]
        [HttpGet]
        // GET api/<controller>/5
        public IHttpActionResult AuthorsForBook(int idBook)
        {
            var authors = repository.LoadAuthors().Where(b => b.IDBook == idBook).ToList();

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var author = repository.LoadAuthors().Where(b => b.ID == id).FirstOrDefault();

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Author author)
        {
            return Ok(author);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Author author)
        {
            return Ok(author);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}