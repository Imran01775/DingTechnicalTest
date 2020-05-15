using Ding.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml;

namespace DingConsole
{
    class DingTopUpClient
    {
        public static int MessageID = 1000;
        static void Main(string[] args)
        {
            ProcessTopup();
            Console.ReadKey();
        }
        public async static void ProcessTopup()
        {
            var requestModel = new RequestModel(MessageID);
            Console.WriteLine("Enter Your MessageID :");
            requestModel.MessageID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Your Phone Number :");
            requestModel.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Your Amount :");
            requestModel.Amount = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Execution Start..........................");
            Console.WriteLine();
            var response = await Communication.ProcessTopup(requestModel);
            Console.WriteLine("Your TransactionID :" + response.TransactionID);
            Console.WriteLine("Your TransactionNumber :" + response.TransactionNumber);
            Console.WriteLine("Your Phone Number :" + response.PhoneNumber);
            Console.WriteLine("Your Amount :" + response.Amount);
            Console.WriteLine("Result :" + response.Result);
            Console.WriteLine();
            Console.WriteLine("Execution Complete...");
          
        }
    }
}
