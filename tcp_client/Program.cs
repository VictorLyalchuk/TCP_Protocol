using System;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace tcp_client
{
    class Program
    {
        static int port = 8080;
        static string address = "127.0.0.1";
        static void Main(string[] args)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            TcpClient client = new TcpClient();
            client.Connect(ipPoint);

            string message = "";
            try
            {
                while (message != "end")
                {
                    Console.Write("Enter a message:");
                    message = Console.ReadLine();

                    NetworkStream ns = client.GetStream();
                    StreamWriter sw = new StreamWriter(ns);
                    sw.WriteLine(message);
                    sw.Flush(); 
                    StreamReader sr = new StreamReader(ns);
                    string response = sr.ReadLine();

                    Console.WriteLine("server response: " + response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
