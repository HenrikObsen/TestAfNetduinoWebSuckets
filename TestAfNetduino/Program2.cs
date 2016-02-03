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
    public class Program4
    {
        public static void Main()
        {
            // write your code here
            MorseListen();
        }
 
        private static void MorseListen()
        {
            var currentIp = IPAddress.Parse(Microsoft.SPOT.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0].IPAddress);
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            socket.Bind(new IPEndPoint(currentIp, 9999)); 
            socket.Listen(10);
             
            var message = new ArrayList();
            var led = new OutputPort(Pins.ONBOARD_LED, false);
            var led2 = new OutputPort(Pins.GPIO_PIN_D0, false);
            while(true)
            {
                using (var client = socket.Accept())
                {
                    //If connected, turn on the LED
                    if (SocketConnected(client))
                    {
                        led.Write(true);

                        led2.Write(true);
                        //Get the data from the connection
                        while (SocketConnected(client))
                        {
                            var availablebytes = client.Available;
                            var buffer = new byte[availablebytes];
                            client.Receive(buffer);
 
                            if (buffer.Length <= 0) continue;
 
                            var received = Encoding.UTF8.GetChars(buffer);
 
                            //Add the received chars to our message array list
                            for (var i = 0; i < received.Length; i++)
                                message.Add(received[i]);
                        }
 
                        //Done receiving, turn off the LED and wait 2 seconds
                        led.Write(false);
                        led2.Write(false);
                        Thread.Sleep(2000);
 
                        //Do the morse Code
                        for (var i = 0; i < message.Count; i++)
                        {
                            Debug.Print(message[i].ToString());
                            var code = MorseChar.FromChar((char)message[i]);
 
                            for (var j = 0; j < code.Code.Length; j++)
                            {
                                var bval = (code.Code[j] != 0);
                                led.Write(bval);
                                led2.Write(bval);
                                Thread.Sleep(75);
                            }
                        }
 
                        //Clear the array list
                        message.Clear();
 
                        Thread.Sleep(5000);
                    }
                }  
            }
        }
 
        static bool SocketConnected(Socket s) 
        {            
            return !(s.Poll(1000, SelectMode.SelectRead) & (s.Available == 0));
        }
    }
}
 

