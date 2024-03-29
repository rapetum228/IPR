namespace IPR.StructurePatterns.Proxy;

/// <summary>
/// Сам сервис, к которому обращается клиент (думает что обращается)
/// </summary>
public class Service : IService
{
    public void PrintTextToConsole(string data)
    {
        Console.WriteLine(data);
    }
}
