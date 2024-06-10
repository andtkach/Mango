using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Mango.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public MessageBus(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = _configuration.GetValue<string>("ServiceBus:ConnectionString");
        }
        
        public async Task PublishMessage(object message, string receiverName)
        {
            await using var client = new ServiceBusClient(_connectionString);

            ServiceBusSender sender = client.CreateSender(receiverName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding
                .UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(finalMessage);
            await client.DisposeAsync();
        }
    }
}
