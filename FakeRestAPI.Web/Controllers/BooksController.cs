using FakeRestAPI.Web.Models;
using FakeRestAPI.Web.Repository;
using NLipsum.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeRestAPI.Web.Controllers
{
    public class BooksController : ApiController
    {
        IRepository repository;

        public BooksController(IRepository _repository)
        {
            repository = _repository;
        }   

        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            return repository.LoadBooks();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var book = repository.LoadBooks().Where(b => b.ID == id).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Book book)
        {
            return Ok(book);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Book book)
        {
            return Ok(book);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}