namespace IPR.StructurePatterns.Visitor;

public interface IVisitor
{
    void Visit(House house);

    void Visit(Bar bar);

    void Visit(Basement basement);
}

public class Volk : IVisitor
{
    public void Visit(House house)
    {
        Console.WriteLine("Сплю, сру, ссу, ем, дрочу");
    }

    public void Visit(Bar bar)
    {
        Console.WriteLine("Бухаю");
    }

    public void Visit(Basement basement)
    {
        Console.WriteLine("Колюсь, нюхаю, пыхаю");
    }
}

public class Pupil : IVisitor
{
    public void Visit(House house)
    {
        Console.WriteLine("Делаю домашку, сплю, какаю, писяю, кусяю, лимоню");
    }

    public void Visit(Bar bar)
    {
        Console.WriteLine("Бухаю с батей");
    }

    public void Visit(Basement basement)
    {
        Console.WriteLine("Сосу хуй");
    }
}