namespace IPR.StructurePatterns.Wrapper;

/// <summary>
/// Базовый декоратор для вызова базового компонента
/// </summary>
public abstract class BaseWrapper: IComponent
{
    protected IComponent _wrappee;

    public BaseWrapper(IComponent wrappee)
    {
        _wrappee = wrappee;
    }

    public virtual void PrintTextToConsole(string data)
    {
        _wrappee.PrintTextToConsole(data);
    }
}

/// <summary>
/// Доп декоратор красный цвет
/// </summary>
public class RedWrapper : BaseWrapper
{
    public RedWrapper(IComponent wrappee) : base(wrappee)
    {
    }

    public override void PrintTextToConsole(string data)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        base.PrintTextToConsole(data);
        Console.ResetColor(); 
    }
}

/// <summary>
/// Доп декоратор красный цвет
/// </summary>
public class WhiteBackgroundWrapper : BaseWrapper
{
    public WhiteBackgroundWrapper(IComponent wrappee) : base(wrappee)
    {
    }

    public override void PrintTextToConsole(string data)
    {
        Console.BackgroundColor = ConsoleColor.White; 
        base.PrintTextToConsole(data);
        Console.ResetColor(); 
    }
}

/// <summary>
/// Доп декоратор красный цвет
/// </summary>
public class UpperWrapper : BaseWrapper
{
    public UpperWrapper(IComponent wrappee) : base(wrappee)
    {
    }

    public override void PrintTextToConsole(string data)
    {
        data = data.ToUpper();
        base.PrintTextToConsole(data);
    }
}