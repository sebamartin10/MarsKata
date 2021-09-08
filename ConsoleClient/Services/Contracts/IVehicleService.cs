using ConsoleClient.Models;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Services.Contracts
{
    public interface IVehicleService
    {
        public Vehicle Initialize();
        public VehicleResponse<Vehicle> ReceiveDirectives(string directives);
    }
}
