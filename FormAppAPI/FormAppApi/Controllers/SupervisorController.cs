using FormAppApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FormAppApi.Controllers
{
    [RoutePrefix("api/Supervisor")]
    public class SupervisorController : ApiController
    {
        protected string supervisorPath = HttpContext.Current.Server.MapPath($"~/App_Data/supervisors.json");
        protected string subscriberPath = HttpContext.Current.Server.MapPath($"~/App_Data/subscribers.json");

        [HttpGet]
        public IHttpActionResult GetSupervisors()
        { 
            try
            {
                var data = GetAllSupervisors();
                var subs = GetAllSubscribers();
                foreach(var sup in data)
                {
                    string str = "";
                    foreach(int id in sup.Subscribers)
                    {
                        str += subs.Where(x => x.Id == id).FirstOrDefault().Name + ", ";
                    }
                    sup.SubscriberString = str.Substring(0, str.Length - 2);
                }
                return Ok(data);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [Route("UpdateSupervisor")]
        public IHttpActionResult UpdateSupervisorNotificationList(Subscriber subscriber) 
        {
            try
            {
                // Update Subscriber list
                var supervisors = GetAllSupervisors();
                var subscribers = GetAllSubscribers();

                var supervisor = supervisors.Where(x => subscriber.SupervisorId == x.Id).FirstOrDefault();
                if (supervisor == null)
                    return NotFound();

                // Check if the Subscriber already exists
                subscriber.Id = CheckIfSubscriberExists(subscribers, subscriber);

                if (subscriber.Id == -1)
                {
                    subscriber.Id = subscribers.Count;
                    AddNewSubscriberToJson(subscriber); 
                }

                // Get list of subscriber objects
                var subs = subscribers.Where(x => supervisor.Subscribers.Any(y => y == x.Id)).ToList();

                if (subs != null && subs.Any(x => x.Email == subscriber.Email))
                    return BadRequest("A user with this email is already on this subscriber list");

                if(subs != null && subs.Any(x => x.PhoneNumber == subscriber.PhoneNumber))
                    return BadRequest("A user with this phone number is already on this subscriber list");

                supervisor.Subscribers.Add(subscriber.Id);
                //Write new sub list to json
                var fileData = File.ReadAllText(HttpContext.Current.Server.MapPath($"~/App_Data/supervisors.json"));
                var data = JsonConvert.DeserializeObject<List<Supervisor>>(fileData);
                data[data.FindIndex(x => x.Id == supervisor.Id)] = supervisor;

                // Save supervisors
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(HttpContext.Current.Server.MapPath($"~/App_Data/supervisors.json"), json);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        private List<Supervisor> GetAllSupervisors()
        {
            // read json
            var fileData = File.ReadAllText(supervisorPath);
            return JsonConvert.DeserializeObject<List<Supervisor>>(fileData);
        }

        private List<Subscriber> GetAllSubscribers()
        {
            // read json
            var fileData = File.ReadAllText(subscriberPath);
            return JsonConvert.DeserializeObject<List<Subscriber>>(fileData);
        }

        private int CheckIfSubscriberExists(List<Subscriber> subscribers, Subscriber newSub) 
        {
            if (subscribers.Any(x => x.Email == newSub.Email))
                return subscribers.Where(x => x.Email == newSub.Email).FirstOrDefault().Id;
            else if (subscribers.Any(x => x.PhoneNumber == newSub.PhoneNumber))
                return subscribers.Where(x => x.PhoneNumber == newSub.PhoneNumber).FirstOrDefault().Id;
            else
                return -1;
        }

        private void AddNewSubscriberToJson(Subscriber subscriber)
        {
            //Write new sub list to json
            var fileData = File.ReadAllText(HttpContext.Current.Server.MapPath($"~/App_Data/subscribers.json"));
            var data = JsonConvert.DeserializeObject<List<Subscriber>>(fileData); ;
            data.Add(subscriber);

            // Save supervisors
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(HttpContext.Current.Server.MapPath($"~/App_Data/subscribers.json"), json);
        }
    }
}
