using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCPIPServerTest
{
    public class Client
    {
        TcpClient tcpClient;
        StreamWriter sw;
        StreamReader sr;

		public Client(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }
        public void run()
        {
            sw = new StreamWriter(tcpClient.GetStream());
            sr = new StreamReader(tcpClient.GetStream());
            while (true)
            {
                try
                {
                    if (!Program.serverEnd)
                    {
                        string str = sr.ReadLine();
                        sw.WriteLine($"Server: ${str}");
                        sw.Flush();
                    } else
                    {
                        Close();
                        break;
                    }
                }
                catch
                {
                    Close();
                }
            }
        }

        void Close()
        {
            sr.Dispose();
            sw.Dispose();
            tcpClient.Dispose();
        }
    }
}