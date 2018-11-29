using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQDataModel;
using System;
using System.Text;

namespace RabbitMQProducer
{
    class Program
    {
        static void Main(string[] args)
        {

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
             {
                 var host = cfg.Host(new Uri("rabbitmq://localhost/"), hst =>
                 {
                     hst.Username("guest");
                     hst.Password("guest");
                 });


             });

            var senUri = new Uri("rabbitmq://localhost/MailQue");
            ISendEndpoint send = bus.GetSendEndpoint(senUri).Result;

            UserMail mail1 = new UserMail() { User = new User { Mail = "feyyazacet@gmail.com", Name = "feyyaz acet" }, Subject = "Sample MassTransit With RabbitMQ  ", Body = "RabbitMQ and MassTransit say Hello" };
            send.Send(mail1).Wait();

            UserMail mail2 = new UserMail() { User = new User { Mail = "feyyaz.acet@tetris-tr.com", Name = "feyyaz acet" }, Subject = "Sample MassTransit With RabbitMQ  ", Body = "RabbitMQ and MassTransit say Hello" };
            send.Send(mail2).Wait();

            Console.ReadKey();

        }
    }


}
