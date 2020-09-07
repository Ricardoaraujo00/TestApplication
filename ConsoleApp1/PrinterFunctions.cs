using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    public class PrinterFunctions
    {

        public static void PrintFunction()
        {
            //Activa letra pequena
            OutputHexa("1D 21 00");

            var output = $"echo \"Farmácia barroselas\" >/dev/ttyUSB0".Bash();

            //Send enter
            OutputHexa("0A");

            // Activa letra normal
            OutputHexa("1D 21 00");
            output = $"echo \"Farmácia barroselas\" >/dev/ttyUSB0".Bash();

            //send cut
            OutputHexa("1B 69");

            Console.ReadKey();

            //Console.WriteLine($"echo -e {BitConverter.ToString(data)} >/dev/usb/lp0");
            //var output = $"echo -e {Encoding.UTF8.GetString(data)} >/dev/usb/lp0".Bash();
        }

        public static void OutputHexa(string command)
        {
            string[] commands = command.Split(" ");
            Thread.Sleep(100);
            string strCommand = "echo -e '\\x1d";
            foreach (var item in commands)
            {
                strCommand += "\\x" + item;
            }
            strCommand += "\\x00'";
            Console.WriteLine($"{strCommand} >/dev/ttyUSB0");
            var output = $"{strCommand} >/dev/ttyUSB0".Bash();
        }

        private static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
    }
}
