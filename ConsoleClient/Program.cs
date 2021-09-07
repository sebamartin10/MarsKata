using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using ConsoleClient.Models;
using ConsoleClient.Services;
using Newtonsoft;
using SharedLibrary;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44365/");
            Console.ForegroundColor = ConsoleColor.White;
            bool isVehicleInitialized = false;
            List<string> acceptedCommands = new List<string>();
            Rover rover = new Rover();
            RoverService roverService = new RoverService(httpClient);
            Console.WriteLine("Mother: Welcome to Mars commander, please type 'start' to drive vehicle.");
            Console.WriteLine("Mother: You can leave the remote control of the vehicle at any time by typing 'quit'");
            while (true) {
                string directives = Console.ReadLine().ToLower();

                if (isVehicleInitialized)
                {
                    Console.WriteLine("Mother: Sending directives to vehicle...");
                    Console.WriteLine("Mother: Vehicle is moving...");
                    RoverResponse<Rover> response = roverService.ReceiveDirectives(directives);
                    if (response.Code != 0)
                    {
                        Console.WriteLine(response.Message);
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.WriteLine("Mother: Now the vehicle is in the position " + response.Rover.PositionX + " in X, " + response.Rover.PositionY + " in Y.");
                        Console.WriteLine("Mother: Actual Orientation --> " + response.Rover.CardinalOrientation);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Mother: Vehicle waiting for directives...");
                    }


                }

                if (!isVehicleInitialized)
                {
                    if (directives == "start")
                    {
                        isVehicleInitialized = true;

                        Console.WriteLine("Mother: Initializing vehicle...");
                        rover = httpClient.GetFromJsonAsync<Rover>("Rover/Init").Result;

                        Console.WriteLine("Mother: Vehicle is ready to receive orders.");

                        Console.WriteLine("Mother: The vehicle accepts the following directives:");
                        for (int i = 0; i < rover.AcceptedCommands.Count; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(rover.AcceptedCommands[i]);
                        }
                        Console.ResetColor();
                        Console.WriteLine("Mother: Now, the vehicle is in the position [" + rover.PositionX + "," + rover.PositionY + "]");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Mother: Vehicle waiting for directives...");
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Mother: Sorry commander, you must first type 'start' to be able to drive the vehicle.");
                    }
                    

                }
               
                if (directives.ToLower()=="quit") {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Mother: Shutting down...");
                    Environment.Exit(0);
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
                
            
            
            
        }
    }
}
