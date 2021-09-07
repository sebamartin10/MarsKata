using Microsoft.AspNetCore.Mvc;
using RoverGeolocation.Models;
using RoverGeolocation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverGeolocation.Controllers
{
    public class RoverController : Controller
    {
        Rover rover;
        [HttpGet]
        public List<char> Init()
        {
            rover = new Rover();
            return rover.AcceptedCommands;
        }
        [HttpGet]
        public List<char> GetAcceptedCommands()
        {
            return rover.AcceptedCommands;
        }
        [HttpGet]
        public void ReceiveCommands(char[] commands) {
            RoverService roverServices = new RoverService(rover);
            bool areCommandsOk = roverServices.CheckCommandsIntegrity(commands);         
        }   
    }
}
