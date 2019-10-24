using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CarFeeTCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TcpClient clientSocket = new TcpClient("10.200.121.125", 6789);
            


            Console.WriteLine("Client Ready");

            

            Stream newStream = clientSocket.GetStream();
            StreamReader streamReader = new StreamReader(newStream);
            StreamWriter streamWriter = new StreamWriter(newStream);
            streamWriter.AutoFlush = true;
            
            Console.WriteLine("Connection Established.\nType Close to exit");

            Console.WriteLine("What is the type of car? Normal or Electric?");

            while (true)
            {

                ////Client tells server the type of car
                string messageForServer = Console.ReadLine();
                streamWriter.WriteLine(messageForServer);

                
                //client gets reply from server
                string serverReply = streamReader.ReadLine();
                Console.WriteLine("SERVER: " + serverReply);

                Console.WriteLine("\nWhat is the price of the car?");
                
                //messageForServer = Console.ReadLine();
                //streamWriter.WriteLine(messageForServer);

                //serverReply = streamReader.ReadLine();
                //Console.WriteLine("SERVER: " + serverReply);

                //check to close connection with server
                if (messageForServer == "close" || messageForServer == "Close")
                {
                    break;
                }

                
                
            }

            Console.WriteLine("Connection Terminated: Press Enter To Quit...");
            Console.ReadLine();

            newStream.Close();
            clientSocket.Close();


        }
    }
}
