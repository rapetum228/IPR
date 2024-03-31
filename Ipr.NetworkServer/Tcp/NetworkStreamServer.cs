namespace Ipr.NetworkServer.Tcp;

public static class NetworkStreamServer
{
    public static async Task Start()
    {
        var tcpListener = new TcpListener(IPAddress.Any, 9999);
       
        try
        {
            tcpListener.Start();    // запускаем сервер
            Console.WriteLine("Сервер запущен. Ожидание подключений... ");

            while (true)
            {
                // получаем подключение в виде TcpClient
                using var tcpClient = await tcpListener.AcceptTcpClientAsync();

                // получаем объект NetworkStream для взаимодействия с клиентом
                var stream = tcpClient.GetStream();

                // создаем StreamReader для чтения данных
                using var streamReader = new StreamReader(stream);

                // создаем StreamWriter для отправки данных
                using var textWriter = new StreamWriter("C:\\Users\\User\\source\\iprs\\IPR\\Ipr.NetworkServer\\gandony.txt");

                
                while (true)
                {
                    // считываем запрошенное слово
                    var word = await streamReader.ReadLineAsync();
                    textWriter.WriteLine(word);
                    await Console.Out.WriteLineAsync(word);
                }
            }
        }
        finally
        {
            tcpListener.Stop();
        }
    }
}
