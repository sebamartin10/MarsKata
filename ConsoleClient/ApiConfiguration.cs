using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class ApiConfiguration
    {
        public void ConfigureAPI(HttpClient httpClient) {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44365/");
        }
    }
}
