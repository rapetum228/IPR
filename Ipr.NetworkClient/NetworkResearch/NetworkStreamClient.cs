namespace Ipr.NetworkClient.NetworkResearch;

public static class NetworkStreamClient
{
    public static async Task Start()
    {

        using TcpClient tcpClient = new TcpClient();

        await tcpClient.ConnectAsync("127.0.0.1", 8888);

        // получаем NetworkStream для взаимодействия с сервером
        var stream = tcpClient.GetStream();

        // создаем StreamReader для чтения данных
        using var streamReader = new StreamReader(stream);

        // создаем StreamWriter для отправки данных
        using var streamWriter = new StreamWriter(stream);

        var startCommand = Console.ReadLine();

        if (startCommand == "go" || startCommand == "го")
        {
            var i = 1000;
            while (i>0)
            {
                i--;
                var word = Guid.NewGuid().ToString();
                await streamWriter.WriteLineAsync(word);
                await streamWriter.FlushAsync();
            }
        }
        await streamWriter.WriteLineAsync("нахуй иди");
        await streamWriter.FlushAsync();

    }
}

