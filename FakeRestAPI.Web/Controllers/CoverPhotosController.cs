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
    public class CoverPhotosController : ApiController
    {
        IRepository repository;

        public CoverPhotosController(IRepository _repository)
        {
            repository = _repository;
        }

        // GET api/<controller>
        public IEnumerable<CoverPhoto> Get()
        {
            return repository.LoadCoverPhotos();
        }

        [Route("books/covers/{idBook}")]
        [HttpGet]
        // GET api/<controller>/5
        public IHttpActionResult CoverPhotosForBook(int idBook)
        {
            var covers = repository.LoadCoverPhotos().Where(b => b.IDBook == idBook).ToList();

            if (covers == null)
            {
                return NotFound();
            }

            return Ok(covers);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var cover = repository.LoadCoverPhotos().Where(b => b.ID == id).FirstOrDefault();

            if (cover == null)
            {
                return NotFound();
            }

            return Ok(cover);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]CoverPhoto coverPhoto)
        {
            return Ok(coverPhoto);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]CoverPhoto coverPhoto)
        {
            return Ok(coverPhoto);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}