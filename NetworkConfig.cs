using System;
using KaymakNetwork.Network;

namespace SocketServerConsole
{
    internal static class NetworkConfig
    {
        private static Server _socket;

        internal static Server socket
        {
            get { return _socket; }
            set
            {
                if (_socket != null)
                {
                    _socket.ConnectionReceived -= Socket_ConnectionRecieved;
                    _socket.ConnectionLost -= Socket_ConnectionLost;
                }
                _socket = value;

                if (_socket != null)
                {
                    _socket.ConnectionReceived += Socket_ConnectionRecieved;
                    _socket.ConnectionLost += Socket_ConnectionLost;
                }
            }
        }

        internal static void InitializeNetwork()
        {
            if (!(socket == null))
            {
                return;
            }
            socket = new Server(100)
            {
                BufferLimit = 2048000,
                PacketAcceptLimit = 100,
                PacketDisconnectCount = 150,
            };

            NetworkRecieve.PacketRouter();
        }

        internal static void Socket_ConnectionRecieved(int connID)
        {
            Console.WriteLine("Connection recieved on index " + connID);
            NetworkSend.WelcomeMsg(connID, "Welcome to the server!");
        }

        internal static void Socket_ConnectionLost(int connID)
        {
            Console.WriteLine("Connection lost on index " + connID);
        }

    }
}
