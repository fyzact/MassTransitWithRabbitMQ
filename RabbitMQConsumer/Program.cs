using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace RabbitMQConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(p =>
            {
                var host = p.Host(new Uri("rabbitmq://localhost/"),
                    x=> {
                        x.Password("guest");
                        x.Password("guest");
                        }) ;


                p.ReceiveEndpoint(host, "MailQue", e =>
       e.Consumer<UserMailConsumer>());

            });

            bus.Start();
            Console.WriteLine("Started consuming.");
            Console.ReadKey();
        }

        
    }
}
