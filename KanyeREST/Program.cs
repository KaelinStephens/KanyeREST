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
           
            Console.WriteLine("How many exchanges should Kanye West and Ron Swanson have?"); //asks user for conversation length
            int exchanges = int.Parse(Console.ReadLine());      //saves desired conversation length to variable
            Console.WriteLine();
            Console.WriteLine(".......................................");
            Console.WriteLine();
            for (int i = 1; i <= exchanges; i++)            //for every exchange in the conversation, until desired length is reached
            {
                var x = i;
                var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;             //API called to get a Kanye quote
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();                     //retrieves just the quote from data received from API and parses to a string
                var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;        //API called to get a Ron quote
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();        //retrieves just the quote from data received from API, removes the [], adds a space to the beginning of the quote, and parses to a string
                Console.WriteLine($"Kanye: {kanyeQuote}");          //prints Kanye quote to console
                Console.WriteLine($"Ron: {ronQuote}");              //prints Ron quote to console
            }   
        }
    }
}
