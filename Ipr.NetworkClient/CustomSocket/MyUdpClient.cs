using System.Text;

namespace Ipr.NetworkClient.CustomSocket;

public static class MyUdpClient
{
    public static async Task Start()
    {
        using var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);

        while (true)
        {
            var message = Console.ReadLine();

            byte[] data = Encoding.UTF8.GetBytes(message);

            int bytes = await udpSocket.SendToAsync(data, remotePoint);

            Console.WriteLine($"Отправлено {bytes} байт");
        }
    }
}