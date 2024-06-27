using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPIPServerTest
{
    class ClientHandler
    {
        static TcpListener tcpListener;
        static bool serverClose = false;
        ClientHandler (TcpListener tcpListener) {
            this.tcpListener = tcpListener;
        }

        void run() {
            while(true) {
                try {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Console.WriteLine("" + tcpClient.Connected);
                    Client c = new Client(tcpClient);
                    Thread th = new Thread(c.run);
                    th.Start();
                }catch(exception e) {
                    Console.WriteLine(e.stackTrace());
                }
            }
        }
    }
}