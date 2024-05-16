using System;

namespace Intergration
{
    public class Intergration
    {
        //Example method for integrating with an external service
        public void SendDataToExternalServices(string data)
        {
            //code  for sending data to an external service
            Console.WriteLine($"Sending data to external service: {data}");
        }

        //Example method for intergration with a database
        public void SaveDataToDatabase(string data)
        {
            // Code for saving data to a database
            Console.WriteLine($"Saving data to database: {data}");
        }

        //Example method for integration with an API
        public void CallExternalAPI(string endpoint)
        {
            // code For Calling an external API
            Console.WriteLine($"Calling external API: {endpoint}");
        }
    }
}