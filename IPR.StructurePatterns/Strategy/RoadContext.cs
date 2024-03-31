namespace IPR.StructurePatterns.Strategy;

/// <summary>
/// Контекст всегда работает со стратегиями через общий интерфейс. Он не знает, какая именно стратегия ему подана.
/// Во время выполнения программы контекст получает вызовы от клиента и делегирует их объекту конкретной стратегии.
/// </summary>
public class RoadContext
{
    private IRoadStrategy _strategy;

    public RoadContext(IRoadStrategy strategy)
    {
        _strategy = strategy;
    }

    public void CreateRoute()
    {
        _strategy.CreateRoute();
    }

    public void Set(IRoadStrategy strategy)
    {
        _strategy = strategy;
    }
}

public static class StrategyClient
{
    public static void Start()
    {
        var auto = new AutoRoad();

        var plane = new PlaneRoad();

        var context = new RoadContext(auto);

        context.CreateRoute();

        context.Set(plane);

        context.CreateRoute();
    }
}

/*

   Стратегия — это поведенческий паттерн проектирования, который определяет семейство схожих алгоритмов и 
               омещает каждый из них в собственный класс, после чего алгоритмы можно взаимозаменять прямо во время исполнения программы. 


 + Горячая замена алгоритмов на лету.
 + Изолирует код и данные алгоритмов от остальных классов.
 + Уход от наследования к делегированию.
 + Реализует принцип открытости/закрытости.
 - Усложняет программу за счёт дополнительных классов.
 - Клиент должен знать, в чём состоит разница между стратегиями, чтобы выбрать подходящую.
 
 */