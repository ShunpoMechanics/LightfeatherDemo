using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAppApi.Models
{
    public class Supervisor : User
    {
        public Supervisor(string name, string email, string phoneNumber, string specialization) 
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Specialization = specialization;
        }
        private List<Subscriber> subscribers;
        public List<Subscriber> Subscribers
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
    }
}