using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using System.Text;

namespace TestAfNetduino
{
    public class Program3
    {
        public static void Main()
        {
            using (System.Net.Sockets.Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, 8080));
                socket.Listen(1);

                while (true)
                {
                    using (Socket newSocket = socket.Accept())
                    {
                        if (newSocket.Poll(-1, SelectMode.SelectRead))
                        {
                            byte[] bytes = new byte[newSocket.Available];
                            int count = newSocket.Receive(bytes);
                            char[] chars = Encoding.UTF8.GetChars(bytes);
                            string str = new string(chars, 0, count);

                            Debug.Print(str);
                        } 
                    }
                }
            }
        }
    }
}