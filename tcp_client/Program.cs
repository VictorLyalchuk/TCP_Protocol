using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using Shared_Data;

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

            try
            {
                Request requst = new Request();
                do
                {
                    Console.Write("Enter A:");
                    requst.A = double.Parse(Console.ReadLine());
                    Console.Write("Enter B:");
                    requst.B = double.Parse(Console.ReadLine());
                    Console.Write("Enter Operation [1-4]:");
                    requst.Operation = (OperationType)Enum.Parse(typeof(OperationType), Console.ReadLine());

                    NetworkStream ns = client.GetStream();

                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ns, requst);

                    StreamReader sr = new StreamReader(ns);
                    string response = sr.ReadLine();

                    Console.WriteLine("server response: " + response);

                } while (requst.A != 0 || requst.B !=0);
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
