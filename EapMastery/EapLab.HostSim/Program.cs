// See https://aka.ms/new-console-template for more information
using EapLab.Transport.Logging;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");
ConsoleLogSink logSink = new ConsoleLogSink();
TcpClient tcpClient = new TcpClient("127.0.0.1", 5000);
var stream = tcpClient.GetStream();

