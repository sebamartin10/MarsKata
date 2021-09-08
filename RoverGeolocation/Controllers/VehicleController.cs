using Microsoft.AspNetCore.Mvc;
using RoverGeolocation.Models;
using RoverGeolocation.Services;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverGeolocation.Controllers
{
    public class VehicleController : Controller
    {
        Vehicle vehicle;
        public VehicleController(Vehicle vehicle) {
            this.vehicle = vehicle;
        }
        [HttpGet]
        public Vehicle Init()
        {
             return vehicle;
        }
        
        [HttpGet]
        public VehicleResponse<Vehicle> ReceiveDirectives(string directives) {
            VehicleResponse<Vehicle> response = new VehicleResponse<Vehicle>();
            char[] commands = directives.ToCharArray();
            VehicleService roverServices = new VehicleService(vehicle);
            ValidationService validationServices = new ValidationService(vehicle);
            bool areCommandsOk = roverServices.CheckCommandsIntegrity(commands);
            if (!areCommandsOk) {
                response.Code = -1;
                response.Message = "Vehicle could not recognize the directives.";
                return response;
            }
            roverServices.Move(commands);
            response.VehicleStatus = vehicle;
            return response;

        }   
    }
}
