using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json; // remember to add nuget package: Newtonsoft.Json
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Models
{
    public class Joke
    {
        public string Setup { get; set; }
        public string Punchline { get; set; }
    }
}