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
    public class ActivitiesController : ControllerBase
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
        [HttpGet]
        public ActionResult<IEnumerable<Activity>> Get()
        {
            return Ok(repository.LoadActivities());
        }

        /// <summary>
        /// Gets the activity with the specified identifier.
        /// </summary>
        /// <param name="id">The activity identifier.</param>
        /// <returns></returns>
        
        [HttpGet("{id}")]
        public ActionResult<Activity> Get(int id)
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
        [HttpPost]
        public ActionResult<Activity> Post([FromBody] Activity activity)
        {
            return Ok(activity);
        }

        /// <summary>
        /// Puts an activity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="activity">The activity.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<Activity> Put(int id, [FromBody] Activity activity)
        {
            return Ok(activity);
        }

        /// <summary>
        /// Deletes the specified activity.
        /// </summary>
        /// <param name="id">The activity identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
