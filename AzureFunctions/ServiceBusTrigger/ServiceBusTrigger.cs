using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;
using System;

namespace ServiceBusTrigger
{
    public static class ServiceBusTrigger
    {
        [FunctionName("ServiceBusTrigger")]
        public static void Run([ServiceBusTrigger(
            "topic",
            "subscription",
            Connection = "ServiceBusConnection")]string mySbMsg,
            ILogger log)
        {
            CustomerDto message = JsonConvert.DeserializeObject<CustomerDto>(mySbMsg);

            log.LogInformation(
                $"[{DateTime.Now}] - Received Customer: " +
                $"{message.LastName}, {message.FirstName} with {message.Age} years old.");
        }
    }
}