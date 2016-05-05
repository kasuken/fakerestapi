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

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> Get()
        {
            return repository.LoadBooks();
        }

        /// <summary>
        /// Gets the specified book.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
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
        public IHttpActionResult Post([FromBody]Book book)
        {
            return Ok(book);
        }

        /// <summary>
        /// Puts the specified book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody]Book book)
        {
            return Ok(book);
        }

        /// <summary>
        /// Deletes the specified book.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}