namespace IPR.StructurePatterns.Adapter;

/// <summary>
/// Интерфейс для клиента
/// </summary>
public interface IService
{
    void PrintText(string text);
}

/// <summary>
/// Адаптер для клиента
/// </summary>
public class Adapter : IService
{
    /// <summary>
    /// Ссылка на класс, к котрому клиент не имеет доступа
    /// </summary>
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    /// <summary>
    /// Клиент может вызывать недоступный ему код через доступный ему интерфейс
    /// </summary>
    /// <param name="text"></param>
    public void PrintText(string text)
    {
        _adaptee.SpecialHeaderForPrintedMessage();
        Console.WriteLine(text);
    }
}

/// <summary>
/// Сервис к которому клиент не имеет прямого доступа
/// </summary>
public class Adaptee
{
    public void SpecialHeaderForPrintedMessage()
    {
        Console.WriteLine("-_-_-_-_-_СПЕЦИАЛЬНЫЙ ЗАГОЛОВОК_-_-_-_-_-_-");
    }
}