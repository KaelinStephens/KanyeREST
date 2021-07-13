using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeREST
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
           
            Console.WriteLine("How many exchanges should Kanye West and Ron Swanson have?");
            int exchanges = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(".......................................");
            Console.WriteLine();
            for (int i = 1; i <= exchanges; i++)
            {
                var x = i;
                var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
                Console.WriteLine($"Kanye: {kanyeQuote}");
                Console.WriteLine($"Ron: {ronQuote}");
            }
        }
    }
}
