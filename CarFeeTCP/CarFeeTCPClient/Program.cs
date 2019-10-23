using System;
using System.IO;
using System.Net.Sockets;

namespace CarFeeTCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TcpClient clientSocket = new TcpClient("192.168.1.187", 6789);
            Console.WriteLine("Client Ready");

            Stream newStream = clientSocket.GetStream(); 
            StreamReader streamReader = new StreamReader(newStream);
            StreamWriter streamWriter = new StreamWriter(newStream);
            streamWriter.AutoFlush = true;

            Console.WriteLine("Connection Established.\nType Close to exit");

            while (true)
            {
                
                string messageForServer = Console.ReadLine();
                streamWriter.WriteLine(messageForServer);
                string serverReply = streamReader.ReadLine();
                Console.WriteLine("SERVER: " + serverReply);

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
