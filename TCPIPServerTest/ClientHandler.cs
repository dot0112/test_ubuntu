using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPIPServerTest
{
    public class ClientHandler
    {
        TcpListener tcpListener;
        public ClientHandler (TcpListener tcpListener) {
            this.tcpListener = tcpListener;
        }

        public void run() {
            while(true) {
                try {
                    if (!Program.serverEnd)
                    {
                        TcpClient tcpClient = tcpListener.AcceptTcpClient();
                        Console.WriteLine("" + tcpClient.Connected);
                        Client c = new(tcpClient);
                        Thread th = new Thread(c.run);
                        th.Start();
                    } else
                    {
                        break;
                    }
                }catch {
                   break;
                }
            }
        }
    }
}