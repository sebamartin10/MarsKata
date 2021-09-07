using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Services
{
    public class ValidationService
    {
        HttpClient httpClient;
        public ValidationService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }
        public bool CheckCommandIntegrity(char[] commands) {
            
            return httpClient.GetFromJsonAsync<bool>("Rover/Init").Result;
        }
    }
}
