using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class JokesController : Controller
    {
        public async Task<IActionResult> Index()
        {


            var client = new HttpClient(); // create instance of HttpClient to make HTTP requests
            
            var request = new HttpRequestMessage // Create an HttpRequestMessage for making a GET request to the joke API
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://dad-jokes.p.rapidapi.com/random/joke"),
                Headers =
                {
                    { "X-RapidAPI-Key", "414a318b87mshf6d3da03fe95b0bp135c8bjsn4b0cf8d3f76b" },
                    { "X-RapidAPI-Host", "dad-jokes.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                // Ensure response is successful
                response.EnsureSuccessStatusCode();

                // response as string
                var body = await response.Content.ReadAsStringAsync();

                // Parse JSON using Newtonsoft.Json
                JObject jsonResponse = JObject.Parse(body);
                
                // Access the "body" property of the JSON response, which contains an array of jokes
                JArray jokeArray = (JArray)jsonResponse["body"];
                
                // Convert JSON array to a List<Joke> using Newtonsoft.Json
                var jokes = jokeArray.ToObject<List<Joke>>();

                // Pass the list of jokes to the view
                return View(jokes);
            }
        }
    }
}
