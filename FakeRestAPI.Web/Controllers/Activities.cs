using FakeRestAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeRestAPI.Web.Controllers
{
    public class Activities : ApiController
    {
        List<Activity> _Activities = new List<Activity>();

        public Activities()
        {
            for (int i = 1; i < 31; i++)
            {
                var activity = new Activity();
                activity.ID = i;
                activity.Title = string.Format("Activity {0}", i.ToString());
                activity.DueDate = DateTime.Now.AddHours(i);

                _Activities.Add(activity);
            }
        }

        // GET api/<controller>
        public IEnumerable<Activity> Get()
        {
            return _Activities;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var activity =_Activities.Where(b => b.ID == id).FirstOrDefault();

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