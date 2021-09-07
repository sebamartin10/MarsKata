using ConsoleClient.Models;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Services
{
    public class RoverService
    {
        HttpClient httpClient;
        public RoverService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }
        public RoverResponse<Rover> ReceiveDirectives(string directives) {
            RoverResponse<Rover> response = httpClient.GetFromJsonAsync<RoverResponse<Rover>>("Rover/ReceiveDirectives?directives=" + directives).Result;
            return response;
        }
    }
}
