using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;
using Tax;

namespace CarFeeTCP
{
    class CarFeeTCPEchoService
    {

        private TcpClient connectionSocket;

        public CarFeeTCPEchoService(TcpClient connectionSocket)
        {
            this.connectionSocket = connectionSocket;
        }

        Tax.CarFeeClass carFeeLibrary = new CarFeeClass();

        internal void DoIt()
        {

            Stream NewStream = connectionSocket.GetStream();
            StreamReader streamReader = new StreamReader(NewStream);
            StreamWriter streamWriter = new StreamWriter(NewStream);
            streamWriter.AutoFlush = true; // enable automatic flushing of messages
            
            Console.WriteLine("Echo Service Started.");

            Tax.CarFeeClass carFeeLibrary = new CarFeeClass();

            //server gets the type of car from the client
           
            

            while (true) 
            {
                

                string messageFromClientCarType = streamReader.ReadLine();
                //server echoes back to client, and asks price of the car
                Console.WriteLine("Client: " + messageFromClientCarType);
               
                streamWriter.WriteLine(messageFromClientCarType);

                
                //Notification if client disconnects
                if (messageFromClientCarType == "close" || messageFromClientCarType == "Close")
                {
                    Console.WriteLine("Client Disconnected...");
                    break;
                }
                
                //server gets the price of the car
                string messageFromClientCarPrice = (streamReader.ReadLine());
                Console.WriteLine("Client: " + messageFromClientCarPrice);
                //streamWriter.WriteLine(messageFromClientCarPrice);

                //calculation of car fee based upon price and type
                if (messageFromClientCarType.ToLower() == "normal")
                {
                    double result = carFeeLibrary.CarFee(Convert.ToDouble(messageFromClientCarPrice));
                    streamWriter.WriteLine("The fee for your car is: " + result + " kr.");
                }
                else if (messageFromClientCarType.ToLower() == "electric")
                {
                    double result = carFeeLibrary.ElectricCarFee(Convert.ToDouble(messageFromClientCarPrice));
                    streamWriter.WriteLine("The fee for your car is: " + result + " kr.");
                }
               
                

                

            }
            NewStream.Close();
            connectionSocket.Close();

        }

    }
}
