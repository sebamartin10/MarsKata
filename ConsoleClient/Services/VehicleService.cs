using ConsoleClient.Models;
using ConsoleClient.Services.Contracts;
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
    public class VehicleService : IVehicleService
    {
        HttpClient httpClient;
        public VehicleService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }
        public VehicleResponse<Vehicle> ReceiveDirectives(string directives) {
            VehicleResponse<Vehicle> response = httpClient.GetFromJsonAsync<VehicleResponse<Vehicle>>("Vehicle/ReceiveDirectives?directives=" + directives).Result;
            return response;
        }
        public Vehicle Initialize() {
            Vehicle vehicle = httpClient.GetFromJsonAsync<Vehicle>("Vehicle/Init").Result;
            return vehicle;
        }
    }
}
