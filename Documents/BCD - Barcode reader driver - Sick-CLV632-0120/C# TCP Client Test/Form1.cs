using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;


namespace TCPClinetTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Connect();

        }

        private void Connect()
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpclnt.Connect("192.168.1.20", 2111);
                //tcpclnt.Connect("192.168.70.28", 2111);
                // use the ipaddress as in the server program

                Console.WriteLine("Connected");
                Console.Write("Enter the string to be transmitted : ");


                // TEST COMMANDS

          
                 String str = "\x02" + "sMN mTCgateon" + "\x03";


                // String str = "\x02" + "sRI0" + "\x03"; //Console.ReadLine();
                //  String str = "\x02" + "sMN mTCstpperc" + "\x03";

                // TEST COMMANDS


                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error..... " + ex.StackTrace);
            }
        }
    }


}
