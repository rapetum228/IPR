namespace IPR.StructurePatterns.Strategy;

/// <summary>
/// Стратегия определяет интерфейс, общий для всех вариаций алгоритма.Контекст использует этот интерфейс для вызова алгоритма.
/// </summary>
public interface IRoadStrategy
{
    void CreateRoute();
}


public class AutoRoad : IRoadStrategy
{
    public void CreateRoute()
    {
        Console.WriteLine("Уедем на машине"); 
    }
}

public class PlaneRoad : IRoadStrategy
{
    public void CreateRoute()
    {
        Console.WriteLine("Летим на самолёте");
    }
}