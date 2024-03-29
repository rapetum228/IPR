namespace IPR.StructurePatterns.AbstarctFactory;

public interface IHumanFactory
{
    Passport GetPassport();

    Body GetBody();
}


public class PidorFactory : IHumanFactory
{
    public Body GetBody()
    {
        return new PidorBody();
    }

    public Passport GetPassport()
    {
        return new PidorPassport();
    }
}

public class HumanFactory : IHumanFactory
{
    public Body GetBody()
    {
        return new HumanBody();
    }

    public Passport GetPassport()
    {
        return new GeteroPassport();
    }
}

public class PoluhuyFactory : IHumanFactory
{
    public Body GetBody()
    {
        return new HumanBody();
    }

    public Passport GetPassport()
    {
        return new PidorPassport();
    }
}
/*
 Абстрактная фабрика — это порождающий паттерн проектирования, который позволяет создавать семейства связанных объектов, 
                       не привязываясь к конкретным классам создаваемых объектов.

 + Гарантирует сочетаемость создаваемых продуктов.
 + Избавляет клиентский код от привязки к конкретным классам продуктов.
 + Выделяет код производства продуктов в одно место, упрощая поддержку кода.
 + Упрощает добавление новых продуктов в программу.
 + Реализует принцип открытости/закрытости.
 - Усложняет код программы из-за введения множества дополнительных классов.
 - Требует наличия всех типов продуктов в каждой вариации.
 
 */