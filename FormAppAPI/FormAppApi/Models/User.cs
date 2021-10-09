using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAppApi.Models
{
    public class User
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name 
        {
            get { return name; }
            set { name = value; } 
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}