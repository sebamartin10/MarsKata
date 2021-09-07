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
    public class RoverController : Controller
    {
        Rover rover;
        public RoverController(Rover rover) {
            this.rover = rover;
        }
        [HttpGet]
        public Rover Init()
        {
             return rover;
        }
        
        [HttpGet]
        public RoverResponse<Rover> ReceiveDirectives(string directives) {
            RoverResponse<Rover> response = new RoverResponse<Rover>();
            char[] commands = directives.ToCharArray();
            RoverService roverServices = new RoverService(rover);
            bool areCommandsOk = roverServices.CheckCommandsIntegrity(commands);
            if (!areCommandsOk) {
                response.Code = -1;
                response.Message = "Vehicle could not recognize the directives.";
                return response;
            }
            roverServices.Move(commands);
            response.Rover = rover;
            return response;

        }   
    }
}
