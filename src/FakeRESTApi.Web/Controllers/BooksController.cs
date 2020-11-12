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
    public class BooksController : ControllerBase
    {
        IRepository repository;

        public BooksController(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return repository.LoadBooks();
        }

        /// <summary>
        /// Gets the specified book.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = repository.LoadBooks().Where(b => b.ID == id).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Posts the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            return Ok(book);
        }

        /// <summary>
        /// Puts the specified book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            return Ok(book);
        }

        /// <summary>
        /// Deletes the specified book.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
