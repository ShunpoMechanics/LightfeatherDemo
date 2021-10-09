using FormAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FormAppApi.Controllers
{
    [RoutePrefix("api/Supervisor")]
    public class SupervisorController : ApiController
    {
        private List<Supervisor> supervisors = new List<Supervisor> {
            new Supervisor(1, "John Doe", "jdoe@gmail.com", "123-456-7890", "Health Care", new List<Subscriber>()), 
            new Supervisor(2, "Jane Doe", "jdoe2@gmail.com", "098-765-4321", "Software Development", new List<Subscriber>()),
            new Supervisor(3, "Robert California", "rcalifornia@dundermifflin.com", "879-645-2312", "Management", new List<Subscriber>())
        };

        private List<Subscriber> subscribers = new List<Subscriber>();

        [HttpGet]
        //[EnableCors("*", "*", "*")]
        public IHttpActionResult GetSupervisors()
        { 
            try
            {
                var data = GetAllSupervisors();
                return Ok(data);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        //[EnableCors("*", "*", "*")]
        [Route("UpdateSupervisor")]
        public IHttpActionResult UpdateSupervisorNotificationList(Subscriber subscriber) 
        {
            try
            {
                // Update Subscriber list
                var supervisor = supervisors.Where(x => subscriber.SupervisorId == x.Id).FirstOrDefault();
                if (supervisor == null)
                    return NotFound();

                var subs = supervisor.Subscribers;
                if (subs != null && subs.Any(x => x.Email == subscriber.Email))
                    return BadRequest("A user with his email is already on this subscriber list");

                if(subs != null && subs.Any(x => x.PhoneNumber == subscriber.PhoneNumber))
                    return BadRequest("A user with his phone number is already on this subscriber list");

                supervisor.Subscribers.Add(subscriber);

                // Respond with updated list of Subscribers, might be unnecessary in this demo
                var data = GetAllSupervisors();
                return Ok(data);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        private List<Supervisor> GetAllSupervisors()
        {
            return supervisors;
        }
    }
}
