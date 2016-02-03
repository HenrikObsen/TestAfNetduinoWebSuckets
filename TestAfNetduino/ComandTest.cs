using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Collections;
using SecretLabs.NETMF.Hardware.Netduino;

namespace TestAfNetduino
{
    public class Program2
    {
        public static void Main()
        {
            // write your code here
            StartUp();
        }

        private static void StartUp()
        {

            var led = new OutputPort(Pins.ONBOARD_LED, false);
            var led1 = new OutputPort(Pins.GPIO_PIN_D0, false);
            var led2 = new OutputPort(Pins.GPIO_PIN_D1, false);

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

                            if (str == "test1")
                            {
                                led1.Write(true);
                                Thread.Sleep(250);
                                led1.Write(false);
                            }
                            else if (str == "test2")
                            {
                                led2.Write(true);
                                Thread.Sleep(250);
                                led2.Write(false);
                            }
                            else
                            {
                                led1.Write(true);
                                led2.Write(true);
                                Thread.Sleep(250);
                                led1.Write(false);
                                led2.Write(false);
                            }
                            Debug.Print(str);
                        }
                    }
                }
            }


        }


    }
}



