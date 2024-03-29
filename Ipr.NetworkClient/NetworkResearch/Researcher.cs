using System.Net.NetworkInformation;

namespace Ipr.NetworkClient.NetworkResearch;

public static class Researcher
{
    public static async Task UriResearchAsync(string uriPath = "https://user:password@www.somesite.com:443/home/index?q1=v1&q2=v2#fragmentName")
    {
        Uri uri = new Uri(uriPath);
        Console.WriteLine(uriPath +"\n\n");
        Console.WriteLine($"1) абсолютный путь URI: {uri.AbsolutePath}\n");
        Console.WriteLine($"2) имя хоста в соответствии с системой доменных имен DNS, либо IP-адрес и порт сервера: {uri.Authority}\n");
        Console.WriteLine($"3) возвращает абсолютный адрес URI: {uri.AbsoluteUri} \n");
        Console.WriteLine($"4) фрагмент адреса URI: {uri.Fragment}\n");
        Console.WriteLine($"5) хост: {uri.Host}\n");
        Console.WriteLine($"6) IsAbsoluteUri: {uri.IsAbsoluteUri}\n");
        Console.WriteLine($"7) возвращает true, если адрес URI использует порт по умолчанию для своей схемы: {uri.IsDefaultPort}\n");
        Console.WriteLine($"8) возвращает true, если адрес Uri представляет адрес файла: {uri.IsFile}\n");
        Console.WriteLine($"9) true, если адрес Uri указывает на локальный хост: {uri.IsLoopback}\n");
        Console.WriteLine($"10) возвращает оригинальную строку адреса URI: {uri.OriginalString}\n");
        Console.WriteLine($"11) AbsolutePath и Query, разделяя их вопросительным знаком (?): {uri.PathAndQuery}\n");
        Console.WriteLine($"12) Port: {uri.Port}\n");
        Console.WriteLine($"13) строку запроса из текущего адреса URI: {uri.Query}\n");
        Console.WriteLine($"14) схему текущего адреса URI: {uri.Scheme} \n");
        Console.WriteLine($"15) массив сегментов пути для текущего адреса URI. Каждый сегмент представляет часть пути, которая ограничена слешами: {string.Join(", ", uri.Segments)}\n");
        Console.WriteLine($"16) UserInfo: {uri.UserInfo} \n");

        //UriBuilder uriBuilder1 = new UriBuilder("https", "metanit.com", 443, "sharp/net");
        //Uri url1 = uriBuilder1.Uri;
        //Console.WriteLine(url1);
    }

    public static async Task DnsResearchAsync(string dnsAdress = "google.com")
    {
        //опрашивает DNS-сервер и возвращает все ip-адреса для определенного имени хоста
        var hostEntry = await Dns.GetHostEntryAsync("google.com");

        Console.WriteLine(hostEntry.HostName);

        foreach (var ip in hostEntry.AddressList)
        {
            Console.WriteLine(ip);
        }
    }

    public static async Task ResearchNetworkInterface()
    {
        var adapters = NetworkInterface.GetAllNetworkInterfaces();
        Console.WriteLine($"Обнаружено {adapters.Length} устройств");
        foreach (NetworkInterface adapter in adapters)
        {
            Console.WriteLine("=====================================================================");
            Console.WriteLine();
            Console.WriteLine($"ID устройства: ------------- {adapter.Id}");
            Console.WriteLine($"Имя устройства: ------------ {adapter.Name}");
            Console.WriteLine($"Описание: ------------------ {adapter.Description}");
            Console.WriteLine($"Тип интерфейса: ------------ {adapter.NetworkInterfaceType}");
            Console.WriteLine($"Физический адрес: ---------- {adapter.GetPhysicalAddress()}");
            Console.WriteLine($"Статус: -------------------- {adapter.OperationalStatus}");
            Console.WriteLine($"Скорость байт в секунду: --- {adapter.Speed}");

            IPInterfaceStatistics stats = adapter.GetIPStatistics();
            Console.WriteLine("IP статистика");
            Console.WriteLine($"Получено: ----------------- {stats.BytesReceived}");
            Console.WriteLine($"Отправлено: --------------- {stats.BytesSent}");
            Console.WriteLine($"Полученные пакеты с ошибками:{stats.IncomingPacketsWithErrors}");
        }
    }

    public static async Task GetInfoByActiveTcpConnections()
    {
        var ipProps = IPGlobalProperties.GetIPGlobalProperties();
        var tcpConnections = ipProps.GetActiveTcpConnections();

        Console.WriteLine($"Всего {tcpConnections.Length} активных TCP-подключений");
        Console.WriteLine();
        foreach (var connection in tcpConnections)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"Локальный адрес: {connection.LocalEndPoint.Address}:{connection.LocalEndPoint.Port}");
            Console.WriteLine($"Адрес удаленного хоста: {connection.RemoteEndPoint.Address}:{connection.RemoteEndPoint.Port}");
            Console.WriteLine($"Состояние подключения: {connection.State}");
        }
    }

    public static async Task MonitoringTraffic()
    {
        var ipProps = IPGlobalProperties.GetIPGlobalProperties();
        var ipStats = ipProps.GetIPv4GlobalStatistics();

        var unicasts = ipProps.GetUnicastAddresses();

        Console.WriteLine(ipProps.DomainName);
        Console.WriteLine($"Входящие пакеты: {ipStats.ReceivedPackets}");
        Console.WriteLine($"Исходящие пакеты: {ipStats.OutputPacketRequests}");
        Console.WriteLine($"Отброшено входящих пакетов: {ipStats.ReceivedPacketsDiscarded}");
        Console.WriteLine($"Отброшено исходящих пакетов: {ipStats.OutputPacketsDiscarded}");
        Console.WriteLine($"Ошибки фрагментации: {ipStats.PacketFragmentFailures}");
        Console.WriteLine($"Ошибки восстановления пакетов: {ipStats.PacketReassemblyFailures}");
    }
}