using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace TestAfNetduino
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            OutputPort led01 = new OutputPort(Pins.GPIO_PIN_D0, false);

            while (true)
            {
                Thread.Sleep(250);
                led01.Write(true);
                Thread.Sleep(250);
                led01.Write(false);

            }
        }

       
    }
}
