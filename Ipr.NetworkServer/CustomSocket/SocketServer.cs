using System.Text;

namespace Ipr.NetworkServer.CustomSocket;

public class SocketServer
{
    public static async Task StartTcpSocketAsync(int port)
    {
        Console.WriteLine($"Server started {port}");
        using var socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        socketServer.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
        socketServer.Listen();

        while (true)
        {
            await Task.Delay(1000);
            using var socketClient = await socketServer.AcceptAsync();

            var buffer = new byte[1024];
            var request = await socketClient.ReceiveAsync(buffer);

            var data = Encoding.UTF8.GetString(buffer);
            Console.WriteLine("=====================================");
            Console.WriteLine($"Принято \n {data}");

            var response = new List<byte>();

            await socketClient.SendAsync(Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\nAccept:application/json"));
        }
    }

    public static async Task StartUdpSocketAsync()
    {
        using var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        var localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
        
        // начинаем прослушивание входящих сообщений
        udpSocket.Bind(localIP);
        
        Console.WriteLine("UDP-сервер запущен...");

        byte[] data = new byte[256]; // буфер для получаемых данных
                                     //адрес, с которого пришли данные
                                     //можно поймать эксепшен если пришедшее сообщение больше

        EndPoint remoteIp = new IPEndPoint(IPAddress.Any, //произвольный локальный адрес
                                            0);

        // получаем данные в массив data
        var result = await udpSocket.ReceiveFromAsync(data, remoteIp);

        var message = Encoding.UTF8.GetString(data, 0, result.ReceivedBytes);

        Console.WriteLine($"Получено {result.ReceivedBytes} байт");
        Console.WriteLine($"Удаленный адрес: {result.RemoteEndPoint}");
        Console.WriteLine(message);     // выводим полученное сообщение
    }
}
