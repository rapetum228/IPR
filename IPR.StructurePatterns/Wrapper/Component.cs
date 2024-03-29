namespace IPR.StructurePatterns.Wrapper;

/// <summary>
/// Интерфейс для компонента и декораторов
/// </summary>
public interface IComponent
{
    void PrintTextToConsole(string data);
}

/// <summary>
/// Сам компонент без декоратора
/// </summary>
public class BaseComponent : IComponent
{
    public void PrintTextToConsole(string data)
    {
        Console.WriteLine(data);
    }
}
