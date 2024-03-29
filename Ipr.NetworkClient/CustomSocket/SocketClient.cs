using System.Text;

namespace Ipr.NetworkClient.CustomSocket;

public class SocketClient
{
    public async Task StartSocketTcpClientAsync(int port)
    {
        using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        await socket.ConnectAsync(IPAddress.Any, port);
    }

    public async Task SendUdpMessageAsync(string message, int port)
    {
        using var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        byte[] data = Encoding.UTF8.GetBytes(message);

        EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);

        int bytes = await udpSocket.SendToAsync(data, remotePoint);

        Console.WriteLine($"Отправлено {bytes} байт");
    }


    public async Task SenMessageAsync(string mesage, int port)
    {
        //адрес по протоколу IPv4, 
        using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        await socket.ConnectAsync(IPAddress.Parse("127.0.0.1"), port);

        byte[] data = Encoding.UTF8.GetBytes(mesage);

        // отправляем данные
        await socket.SendAsync(data);
    }


    /*
     Dgram:         сокет будет получать и отправлять дейтаграммы по протоколу Udp. 
                    Данный тип сокета работает в связке с типом протокола - Udp и значением AddressFamily.InterNetwork

     Raw:           сокет имеет доступ к нижележащему протоколу транспортного уровня и может использовать для 
                    передачи сообщений такие протоколы, как ICMP и IGMP
     
     Rdm:           сокет может взаимодействовать с удаленными хостами без установки постоянного подключения. 
                    В случае, если отправленные сокетом сообщения невозможно доставить, то сокет получит об этом уведомление
     
     Seqpacket:     обеспечивает надежную двустороннюю передачу данных с установкой постоянного подключения
     
     Stream:        обеспечивает надежную двустороннюю передачу данных с установкой постоянного подключения. 
                    Для связи используется протокол TCP, поэтому этот тип сокета используется в паре с типом протокола Tcp 
                    значением AddressFamily.InterNetwork
     
     Unknown:       адрес NetBios
     */
    public static Socket CreateSocket()
    {
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Rdm, ProtocolType.Ggp);
        return socket;
    }
}
