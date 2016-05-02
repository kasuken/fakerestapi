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
    /// <summary>
    /// The activities operations
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ActivitiesController : ApiController
    {
        IRepository repository;

        public ActivitiesController(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Gets all Activities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Activity> Get()
        {
            return repository.LoadActivities();
        }

        /// <summary>
        /// Gets the activity with the specified identifier.
        /// </summary>
        /// <param name="id">The activity identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var activity = repository.LoadActivities().Where(b => b.ID == id).FirstOrDefault();

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        /// <summary>
        /// Posts an activity.
        /// </summary>
        /// <param name="activity">The activity model.</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]Activity activity)
        {
            return Ok(activity);
        }

        /// <summary>
        /// Puts an activity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody]Activity activity)
        {
            return Ok(activity);
        }

        /// <summary>
        /// Deletes the specified activity.
        /// </summary>
        /// <param name="id">The activity identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}