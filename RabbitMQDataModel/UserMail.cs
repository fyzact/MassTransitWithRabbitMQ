using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQDataModel
{
   public class UserMail
    {
        public User User { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

   
}
