using FakeRestAPI.Web.Models;
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
        List<Book> Books = new List<Book>();

        public BooksController()
        {
            var rawText = Lipsums.Decameron;
            var lipsum = new LipsumGenerator(rawText, false);

            for (int i = 1; i < 201; i++)
            {
                var book = new Book();
                book.ID = i;
                book.Title = string.Format("Book {0}", i.ToString());
                book.Description = lipsum.GenerateLipsum(1);
                book.Excerpt = lipsum.GenerateLipsum(5);
                book.PublishDate = DateTime.Now.AddDays(-i);
                book.PageCount = i * 100;

                Books.Add(book);
            }
        }   

        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            return Books;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var book = Books.Where(b => b.ID == id).FirstOrDefault();

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