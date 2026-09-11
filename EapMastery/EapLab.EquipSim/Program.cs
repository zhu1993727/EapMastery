// See https://aka.ms/new-console-template for more information
using EapLab.Transport.Logging;
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");
var log = new ConsoleLogSink();
TcpListener listener = new TcpListener(IPAddress.Loopback, 5000);
listener.Start();
while (true) 
{
    var client =await listener.AcceptTcpClientAsync();
    log.Log(LogDir.EVT, "Equip Passive listening 127.0.0.1:5000");
    Task.Run(()=> ServerClient(client,log));
}
async Task ServerClient(TcpClient client ,ILogSink log) 
{
    var stream =client.GetStream();
    var buf =new byte[4096];
	try
	{
        while (true)
        {
            int n = await stream.ReadAsync(buf);
            if (n == 0) { log.Log(LogDir.EVT, "Host closed(FIN)"); break; }
            var text = Encoding.UTF8.GetString(buf, 0, n);
            log.Log(LogDir.TR, $"raw {n}B: {text}");   // 注意：这里一次 Read 不等于一条消息
            var echo = Encoding.UTF8.GetBytes("ACK:" + text);
            await stream.WriteAsync(echo);
            log.Log(LogDir.TX, $"echo {echo.Length}B");
        }
    }
	catch (Exception ex)
	{
        log.Log(LogDir.ERR, ex.Message);
    }
    finally { client.Dispose(); }
}