using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAppApi.Models
{
    public class Subscriber : User
    {
        private int supervisorId;
        public int SupervisorId
        {
            get { return supervisorId; }
            set { supervisorId = value; }
        }
    }
}