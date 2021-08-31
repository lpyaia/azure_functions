using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Threading.Tasks;

namespace TimerTrigger
{
    public static class TimerTrigger
    {
        private static string _connectionString = "";
        private static string _topicName = "topic";
        private static ServiceBusClient _client = new ServiceBusClient(_connectionString);
        private static ServiceBusSender _sender = _client.CreateSender(_topicName);

        [FunctionName("TimerTrigger")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var data = new CustomerDto
            {
                FirstName = "Bart",
                LastName = "Simpson",
                Age = 10
            };

            var message = new ServiceBusMessage(data.ToSerializedString());

            await _sender.SendMessageAsync(message);
        }
    }
}