using FakeRestAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeRestAPI.Web.Controllers
{
    public class ActivitiesController : ApiController
    {
        List<Activity> Activities = new List<Activity>();

        public ActivitiesController()
        {
            for (int i = 1; i < 31; i++)
            {
                var activity = new Activity();
                activity.ID = i;
                activity.Title = string.Format("Activity {0}", i.ToString());
                activity.DueDate = DateTime.Now.AddHours(i);

                Activities.Add(activity);
            }
        }

        /// <summary>
        /// Gets all Activities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Activity> Get()
        {
            return Activities;
        }

        /// <summary>
        /// Gets the activity with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var activity = Activities.Where(b => b.ID == id).FirstOrDefault();

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Activity activity)
        {
            return Ok(activity);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Activity activity)
        {
            return Ok(activity);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}