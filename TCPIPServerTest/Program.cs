using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPIPServerTest
{
	public class Program
	{
	    static TcpListener server;
		public static bool serverEnd = false;
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Write("Enter IP Address: ");
				string ipAddress = Console.ReadLine();
				Console.Write("Enter Port: ");
				string port = Console.ReadLine();

				IPAddress address;
				if (IPAddress.TryParse(ipAddress, out address) && int.TryParse(port, out int portNumber))
				{
					server = new TcpListener(address, portNumber);
					try
					{
						server.Start();
						Console.WriteLine($"Server Open {ipAddress}:{port}");
						break;
					}
					catch (SocketException ex)
					{
						Console.WriteLine($"Failed to start server: {ex.Message}");
					}
				}
				else
				{
					Console.WriteLine("Invalid IP Address or Port number. Please try again.");
				}
			}
			ClientHandler ch = new(server);
			Thread th = new Thread(ch.run);
			th.Start();
			while (true)
			{
				string input = Console.ReadLine();
				if (input == "q") { serverEnd = true; server.Dispose(); break; }
			}
		}
	}
}
