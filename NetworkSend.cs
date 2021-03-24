using System;
using KaymakNetwork;

namespace SocketServerConsole
{
    enum ServerPackets
    {
        WelcomeMsg = 1,
    }
    
    internal static class NetworkSend
    {
        public static void WelcomeMsg(int connID, string msg)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPackets.WelcomeMsg);
            buffer.WriteString(msg);
            NetworkConfig.socket.SendDataTo(connID, buffer.Data, buffer.Head);

            buffer.Dispose();
        }
    }
}
