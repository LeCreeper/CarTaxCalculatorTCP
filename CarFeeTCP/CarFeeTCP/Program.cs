using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Tax;

namespace CarFeeTCP
{
    class Program
    {
        static void Main(string[] args)
        {

            //Enter relevant IP instead of shown one.
            IPAddress ip = IPAddress.Parse("192.168.1.187");
            TcpListener serverSocket = new TcpListener(ip, 6789);

            serverSocket.Start();
            Console.WriteLine("Server Has Started.");

            


            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server is activated");
                CarFeeTCPEchoService echoService = new CarFeeTCPEchoService(connectionSocket);


                Thread newThread = new Thread(echoService.DoIt);
                newThread.Start();

                

            }

            serverSocket.Stop();
            
            

        }
    }
}
