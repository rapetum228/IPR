namespace IPR.StructurePatterns.Adapter;

public class ClientAdapter
{
    public void Call(IService service, string data)
    {
        service.PrintText(data);
    }
}

public static class MyMainForAdapter
{
    public static void MyMain()
    {
        Adaptee adaptee = new Adaptee();

        IService service = new Adapter(adaptee);

        ClientAdapter clientAdapter = new ClientAdapter();

        clientAdapter.Call(service, "Привет");
       
    }
}
