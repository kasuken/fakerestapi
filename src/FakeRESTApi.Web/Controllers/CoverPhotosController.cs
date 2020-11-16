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
    public class CoverPhotosController : ControllerBase
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
        [HttpGet]
        public ActionResult<IEnumerable<CoverPhoto>> Get()
        {
            return Ok(repository.LoadCoverPhotos());
        }

        /// <summary>
        /// Covers the cover photos for book.
        /// </summary>
        /// <param name="idBook">The book identifier.</param>
        /// <returns></returns>
        [HttpGet("books/covers/{idBook}")]
        public ActionResult<IEnumerable<CoverPhoto>> CoverPhotosForBook(int idBook)
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
        [HttpGet("{id}")]
        public ActionResult<CoverPhoto> Get(int id)
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
        [HttpPost]
        public ActionResult<CoverPhoto> Post([FromBody] CoverPhoto coverPhoto)
        {
            return Ok(coverPhoto);
        }

        /// <summary>
        /// Puts the cover photo.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="coverPhoto">The cover photo.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<CoverPhoto> Put(int id, [FromBody] CoverPhoto coverPhoto)
        {
            return Ok(coverPhoto);
        }

        /// <summary>
        /// Deletes the specified cover photo.
        /// </summary>
        /// <param name="id">The cover photo identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
