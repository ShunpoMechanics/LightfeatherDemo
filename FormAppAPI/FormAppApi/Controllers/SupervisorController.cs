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
        private List<Supervisor> supervisors = new List<Supervisor> {new Supervisor("John Doe", "jdoe@gmail.com", "123-456-7890", "Health Care"), new Supervisor("Jane Doe", "jdoe2@gmail.com", "098-765-4321", "Software Development")};

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
        public IHttpActionResult UpdateSupervisorNotificationList(Supervisor supervisor) 
        {
            try
            {
                // Update Subscriber list

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
