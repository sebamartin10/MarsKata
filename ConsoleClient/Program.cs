using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using ConsoleClient.Models;
using ConsoleClient.Services;
using ConsoleClient.Services.Contracts;
using Newtonsoft;
using SharedLibrary;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Initial configuration
                ApiConfiguration apiConfig = new ApiConfiguration();
                HttpClient httpClient = apiConfig.ConfigureAPI();
                Console.ForegroundColor = ConsoleColor.White;
                bool isVehicleInitialized = false;
                List<string> acceptedCommands = new List<string>();
                Vehicle vehicle = new Vehicle();
                IVehicleService vehicleService = new VehicleService(httpClient);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Mother: Welcome to Mars commander, please type 'start' to drive vehicle.");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Mother: You can leave the remote control of the vehicle at any time by typing 'quit'");
                Console.WriteLine("Mother: The vehicle moves on the Cartesian axis [X, Y]");
                #endregion

                while (true)
                {
                    string directives = Console.ReadLine().ToLower();

                    if (isVehicleInitialized)
                    {
                        Console.WriteLine("Mother: Sending directives to vehicle...");
                        
                        VehicleResponse<Vehicle> response = vehicleService.ReceiveDirectives(directives);
                        if (response.Code != 0)
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(response.Message);
                            
                        }
                        else
                        {
                            Console.WriteLine("Mother: Vehicle is moving...");
                            Console.WriteLine("Mother: Now the vehicle is in the position [" + response.VehicleStatus.PositionX + "," + response.VehicleStatus.PositionY + "]");
                            Console.WriteLine("Mother: Actual Orientation --> " + response.VehicleStatus.CardinalOrientation);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Mother: Vehicle waiting for directives...");
                        }


                    }
                    else
                    {
                        if (directives == "start")
                        {
                            isVehicleInitialized = true;

                            Console.WriteLine("Mother: Initializing vehicle...");
                            vehicle = vehicleService.Initialize();

                            Console.WriteLine("Mother: Vehicle is ready to receive orders.");

                            Console.WriteLine("Mother: The vehicle accepts the following directives:");
                            for (int i = 0; i < vehicle.AcceptedCommands.Count; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(vehicle.AcceptedCommands[i]);
                            }
                            Console.ResetColor();
                            Console.WriteLine("Mother: Now, the vehicle is in the position [" + vehicle.PositionX + "," + vehicle.PositionY + "]");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Mother: Vehicle waiting for directives...");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Mother: Sorry commander, you must first type 'start' to be able to drive the vehicle.");
                        }


                    }

                    if (directives.ToLower() == "quit")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Mother: Shutting down...");
                        Environment.Exit(0);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ups! Server is not responding.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            
                
            
            
            
        }
    }
}
