using System;
using System.Net;
using System.Net.Sockets;


namespace SocketSample
{
    public class Program
    {
        public static void Main(
            string[] args)
        {
        string _name = (args.Length < 1) ? Dns.GetHostName() : args[0];

        try
        {
            IPAddress[] _ipAddresses = Dns.GetHostEntry(_name).AddressList;

            foreach (IPAddress _ipAddresss in _ipAddresses)
            {
                Console.WriteLine("{0}/{1}", _name, _ipAddresss);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
        }


