using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCPIPServerTest
{
    class Client
    {
        TcpClient tcpClient;
        Client(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }
        public void run()
        {
            StreamWriter sw = new StreamWriter(tcpClient.GetStream());
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            while (true)
            {
                try
                {
                    string str = sr.ReadLine();
                    sw.WriteLine($"Server: ${str}");
                    sw.Flush();
                }
                catch
                {
                    sr.Close();
                    sw.Close();
                    tcpClient.Close();
                }
            }
        }
    }
}