using System.Text;

namespace Ipr.NetworkServer.Udp;

public static class MyUdpServer
{
    public static async Task Start()
    {
        using var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        var localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);

        // начинаем прослушивание входящих сообщений
        udpSocket.Bind(localIP);

        Console.WriteLine("UDP-сервер запущен...");

        while (true)
        {
            byte[] data = new byte[25]; // буфер для получаемых данных

            //адрес, с которого пришли данные
            EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
            try
            {

                // получаем данные в массив data
                var result = await udpSocket.ReceiveFromAsync(data, remoteIp);

                var message = Encoding.UTF8.GetString(data, 0, result.ReceivedBytes);

                Console.WriteLine();
                Console.Write($"Получено {result.ReceivedBytes} байт. ");
                Console.Write($"Удаленный адрес: {result.RemoteEndPoint}. ");
                Console.Write(message);     // выводим полученное сообщение
            }
            catch (SocketException ex)
            {
                Console.WriteLine();
                Console.WriteLine("ВЫ ГАНДОНЫ ЕБАНЫЕ У МЕНЯ В ОЧКО СТОЛЬКО ЧЛЕНОВ НЕ ВЛЕЗАЕТ " + ex.Message);
            }
        }
    }
}