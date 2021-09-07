using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using Newtonsoft;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true) {
                if (Console.ReadLine() == "Enter")
                {
                    try
                    {
                        System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                        client.BaseAddress = new Uri("https://localhost:44365/");
                        Console.WriteLine("Inicializando androide..");
                        List<char> response = client.GetFromJsonAsync<List<char>>("Rover/Init").Result;
                        Console.WriteLine("El androide está listo para recibir órdenes");
                        
                        
                        Console.WriteLine("Los comandos aceptados por el androide son: ");
                        for (int i = 0;i< response.Count;i++) {
                            Console.WriteLine(response[i]);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
            }
                
            
            
            
        }
    }
}
