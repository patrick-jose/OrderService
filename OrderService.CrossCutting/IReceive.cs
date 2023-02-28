using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.CrossCutting
{
    public interface IReceive
    {
        public string ReceiveMessage();
    }
}
