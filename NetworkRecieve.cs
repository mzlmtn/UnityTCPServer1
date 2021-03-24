using System;
using KaymakNetwork;

namespace SocketServerConsole
{
    enum ClientPackets
    {
        CPing = 1,
    }

    internal static class NetworkRecieve
    {
        internal static void PacketRouter()
        {
            NetworkConfig.socket.PacketId[(int)ClientPackets.CPing] = Packet_Ping;
        }

        private static void Packet_Ping (int connID, ref byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer(data);
            string msg = buffer.ReadString();

            Console.WriteLine(msg);

            buffer.Dispose();
        }
    }
}
