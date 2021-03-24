using System;

namespace SocketServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkConfig.InitializeNetwork();
            NetworkConfig.socket.StartListening(5555, 20, 10);
            Console.WriteLine("Network Started.");
            Console.ReadLine();
        }
    }
}
