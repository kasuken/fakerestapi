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

        /// <summary>
        /// Gets all Authors.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Author> Get()
        {
            return repository.LoadAuthors();
        }

        /// <summary>
        /// Authors for book.
        /// </summary>
        /// <param name="idBook">The book identifier.</param>
        /// <returns></returns>
        [Route("authors/books/{idBook}")]
        [HttpGet]
        public IHttpActionResult AuthorsForBook(int idBook)
        {
            var authors = repository.LoadAuthors().Where(b => b.IDBook == idBook).ToList();

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        /// <summary>
        /// Gets the specified author.
        /// </summary>
        /// <param name="id">The author identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var author = repository.LoadAuthors().Where(b => b.ID == id).FirstOrDefault();

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        /// <summary>
        /// Posts an author.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]Author author)
        {
            return Ok(author);
        }

        /// <summary>
        /// Puts an author.
        /// </summary>
        /// <param name="id">The author identifier.</param>
        /// <param name="author">The author.</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody]Author author)
        {
            return Ok(author);
        }

        /// <summary>
        /// Deletes the specified author.
        /// </summary>
        /// <param name="id">The author identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}