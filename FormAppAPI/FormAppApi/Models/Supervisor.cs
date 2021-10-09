using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAppApi.Models
{
    public class Supervisor : User
    {
        public Supervisor(string name, string email, string phoneNumber) 
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        private List<Subscriber> subscribers;
        private List<Subscriber> Subscribers
        { 
            get { return subscribers; }
            set { subscribers = value; }
        }
    }
}