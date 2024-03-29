namespace IPR.StructurePatterns.FactoryMethod;

/*
 Создатель объявляет фабричный метод, который должен возвращать новые объекты продуктов. 
Важно, чтобы тип результата совпадал с общим интерфейсом продуктов.
Может реализовывать ещё какой-то общий код или возвращать дефолтный объект.
 */

public abstract class ProductCreator
{
    public void Say()
    {
        Console.WriteLine("Пошла возня");
        Console.WriteLine(GetProduct().GetName());
    }

    protected abstract IProduct GetProduct();
}

public class PovidloCreator : ProductCreator
{
    protected override IProduct GetProduct()
    {
        Console.WriteLine("Ой бля, насрал в трусы, выдавливаю из них коричнегаго змея, экономия яблок 👍🏻");
        return new Povidlo();
    }
}

public class AppleCreator : ProductCreator
{
    protected override IProduct GetProduct()
    {
        Console.WriteLine("Пошла в лес надёргать яблоко, а мне кончили на ебало 💦 👩🏻, баляяяяяяяяять");
        return new Apple();
    }
}
