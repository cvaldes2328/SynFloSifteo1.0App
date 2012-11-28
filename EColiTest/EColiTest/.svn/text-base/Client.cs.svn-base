using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace EColiTest
{
    public class Client
    {
        private const string _serverIP = "149.130.194.39";
        private const int _serverPort = 3068;
        public string tagValue = "";

        public Client() 
        {

        }

        public void SendString(string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(message);
            SendBytes(buffer);
        }

        public void SendPhoto(string filepath)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(filepath);
            SendBytes(buffer);
        }

        public void ReceiveTag()
        {
            try
            {
                TcpClient client = new TcpClient();
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(_serverIP), _serverPort);
                Console.WriteLine("Waiting for connection");
                client.Connect(serverEndPoint);
                Console.WriteLine("Connection successful");
                NetworkStream clientStream = client.GetStream(); //grab info sent by server
                byte[] buffer = new byte[6];
                clientStream.Read(buffer, 0, 6);
                string tag = "";
                //Converts bytes received from stream to tag Value 
                foreach (byte b in buffer)
                {
                    tag = tag + (char)b;
                }
                tagValue = tag;
                Console.WriteLine("Tag: " + tag);
                clientStream.Flush();
                clientStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("recieve didn't work..." + e.Message);
            }
        }

        private void SendBytes(byte[] buffer)
        {
            try
            {
                TcpClient client = new TcpClient();
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(_serverIP), _serverPort);
                Console.WriteLine("Waiting for connection");
                client.Connect(serverEndPoint);
                Console.WriteLine("Connection successful");
                NetworkStream clientStream = client.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Wrote " + buffer.Length + " bytes total");
                clientStream.Flush();
                clientStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }

/*        NetworkStream clientStream = client.GetStream();

        ASCIIEncoding encoder = new ASCIIEncoding();
        byte[] buffer = encoder.GetBytes("Hello Server!");

        clientStream.Write(buffer, 0 , buffer.Length);
        clientStream.Flush();*/

    }
}

