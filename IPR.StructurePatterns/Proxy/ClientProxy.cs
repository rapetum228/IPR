namespace IPR.StructurePatterns.Proxy;

public class ClientProxy
{
    public void Call(IService service, string data)
    {
        service.PrintTextToConsole(data);
    }
}

public static class MyMainForProxy
{
    public static void MyMain()
    {
        var data = "Супер секретная инфа";

        IService proxy = new CodeProxy();

        ClientProxy client = new ClientProxy();

        client.Call(proxy, data);
    }
}
