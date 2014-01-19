using System;

using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Sockets
{
    class Program
    {
        static byte[] c_buffer { get; set; }
        static Socket c_socket;


        static void Main(
            string[] args)
        {
            c_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            c_socket.Bind(new IPEndPoint(0, 1234));

            c_socket.Listen(100);

            Socket _acceptedSocket = c_socket.Accept();

            c_buffer = new byte[_acceptedSocket.SendBufferSize];

            int _bytesRead = _acceptedSocket.Receive(c_buffer);

            byte[] _formatted = new byte[_bytesRead];

            for (int i = 0; i < _bytesRead; i++)
            {
                _formatted[i] = c_buffer[i];   
            }

            string _dataString = Encoding.ASCII.GetString(_formatted);

            Console.WriteLine(_dataString + Environment.NewLine);
            Console.ReadLine();

            c_socket.Close();
            _acceptedSocket.Close();

        }
    }
}
