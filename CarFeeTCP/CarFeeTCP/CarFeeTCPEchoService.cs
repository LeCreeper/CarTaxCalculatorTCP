using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace CarFeeTCP
{
    class CarFeeTCPEchoService
    {

        private TcpClient connectionSocket;

        public CarFeeTCPEchoService(TcpClient connectionSocket)
        {
            this.connectionSocket = connectionSocket;
        }

        internal void DoIt()
        {

            Stream NewStream = connectionSocket.GetStream();
            StreamReader streamReader = new StreamReader(NewStream);
            StreamWriter streamWriter = new StreamWriter(NewStream);
            streamWriter.AutoFlush = true; // enable automatic flushing of messages

            Console.WriteLine("Echo Service Started.");

            string messageFromClient = streamReader.ReadLine();
            

            while (!string.IsNullOrEmpty(messageFromClient) )
            {
                
                Console.WriteLine("Client: " + messageFromClient);
                string answer = messageFromClient.ToUpper();

                if (messageFromClient == "close" || messageFromClient == "Close")
                {
                    Console.WriteLine("Client Disconnected...");
                    break;
                }

                streamWriter.WriteLine(answer);
                messageFromClient = streamReader.ReadLine();
                

            }
            NewStream.Close();
            connectionSocket.Close();

        }

    }
}
