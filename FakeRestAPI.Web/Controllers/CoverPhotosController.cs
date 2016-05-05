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

        /// <summary>
        /// Gets all cover photos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CoverPhoto> Get()
        {
            return repository.LoadCoverPhotos();
        }

        /// <summary>
        /// Covers the cover photos for book.
        /// </summary>
        /// <param name="idBook">The book identifier.</param>
        /// <returns></returns>
        [Route("books/covers/{idBook}")]
        [HttpGet]
        public IHttpActionResult CoverPhotosForBook(int idBook)
        {
            var covers = repository.LoadCoverPhotos().Where(b => b.IDBook == idBook).ToList();

            if (covers == null)
            {
                return NotFound();
            }

            return Ok(covers);
        }

        /// <summary>
        /// Gets the cover photos.
        /// </summary>
        /// <param name="id">The cover photo identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var cover = repository.LoadCoverPhotos().Where(b => b.ID == id).FirstOrDefault();

            if (cover == null)
            {
                return NotFound();
            }

            return Ok(cover);
        }

        /// <summary>
        /// Posts the cover photo.
        /// </summary>
        /// <param name="coverPhoto">The cover photo.</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]CoverPhoto coverPhoto)
        {
            return Ok(coverPhoto);
        }

        /// <summary>
        /// Puts the cover photo.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="coverPhoto">The cover photo.</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody]CoverPhoto coverPhoto)
        {
            return Ok(coverPhoto);
        }

        /// <summary>
        /// Deletes the specified cover photo.
        /// </summary>
        /// <param name="id">The cover photo identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}