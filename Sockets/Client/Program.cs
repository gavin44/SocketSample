using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Client
{
    class Program
    {
        static Socket c_socket;


        static void Main(
            string[] args)
        {
            c_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint _endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                c_socket.Connect(_endPoint);
            }
            catch
            {
                
                Console.WriteLine("Unable to connect to local endpoint!!!!");
                Main(args);
            }

            Console.WriteLine("Enter text : ");

            string _input = Console.ReadLine();

            byte[] _data = Encoding.ASCII.GetBytes(_input);

            c_socket.Send(_data);

            Console.WriteLine("Data sent!!!!");
            Console.WriteLine("Press any key to continue.....");
            Console.ReadLine();

            c_socket.Close();
        }
    }
}
