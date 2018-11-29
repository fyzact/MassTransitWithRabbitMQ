using MassTransit;
using RabbitMQDataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    public class UserMailConsumer : IConsumer<UserMail>
    {
        public Task Consume(ConsumeContext<UserMail> context)
        {
           Console.WriteLine($"{ context.Message.User.Name} için {context.Message.User.Mail} üzerinden {context.Message.Subject} başlığıyla {context.Message.Body} maili gönderildi");

            return context.ConsumeCompleted;
        }
    }
}
