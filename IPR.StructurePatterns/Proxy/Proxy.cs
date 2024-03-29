using System.Text;

namespace IPR.StructurePatterns.Proxy;

/// <summary>
/// Прокси который реализует клиентский сервис
/// </summary>
public class CodeProxy : IService
{
    /// <summary>
    /// содержит сылку на реальный сервис
    /// </summary>
    public IService _realService;

    public CodeProxy()
    {
        _realService = new Service();
    }

    /// <summary>
    /// Метод для клиента, который проксируем
    /// </summary>
    /// <param name="data"></param>
    public void PrintTextToConsole(string data)
    {
        data = CodeText(data);
        _realService.PrintTextToConsole(data);
    }

    /// <summary>
    /// Доп действия
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string CodeText(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);

       return Encoding.UTF32.GetString(bytes);
    }
}
