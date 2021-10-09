using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAppApi.Models
{
    public class Subscriber : User
    {
        private Supervisor supervisor;
        public Supervisor Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }
    }
}