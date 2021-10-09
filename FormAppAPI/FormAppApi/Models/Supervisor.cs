using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAppApi.Models
{
    public class Supervisor : User
    {
        public Supervisor(int id, string name, string email, string phoneNumber, string specialization, List<int> subscribers)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Specialization = specialization;
            Subscribers = subscribers;
        }
        private List<int> subscribers;
        public List<int> Subscribers
        {
            get { return subscribers; }
            set { subscribers = value; }
        }

        private string specialization;

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        private string subscriberString;
        public string SubscriberString
        {
            get { return subscriberString; }
            set { subscriberString = value; }
        }
    }
}