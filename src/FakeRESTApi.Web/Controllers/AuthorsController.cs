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
    public class AuthorsController : ControllerBase
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
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return Ok(repository.LoadAuthors());
        }

        /// <summary>
        /// Authors for book.
        /// </summary>
        /// <param name="idBook">The book identifier.</param>
        /// <returns></returns>
        [HttpGet("authors/books/{idBook}")]
        public ActionResult<List<Author>> AuthorsForBook(int idBook)
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
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
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
        [HttpPost]
        public ActionResult<Author> Post([FromBody] Author author)
        {
            return Ok(author);
        }

        /// <summary>
        /// Puts an author.
        /// </summary>
        /// <param name="id">The author identifier.</param>
        /// <param name="author">The author.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<Author> Put(int id, [FromBody] Author author)
        {
            return Ok(author);
        }

        /// <summary>
        /// Deletes the specified author.
        /// </summary>
        /// <param name="id">The author identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
