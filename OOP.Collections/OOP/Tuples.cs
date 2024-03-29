/*
 Кортежи
Кортеж представляет набор значений, заключенных в круглые скобки.
Обращение через поля с названиями. Автоматом ставится Item1, Item2 ..
Полям можно давать имена
Кортеж можно декомпозировать

 */

namespace OOP.Collections.OOP;

public class Tuples
{
    public static void WriteSimpleTuple()
    {
        (string, int, double) person = ("Tom", 25, 81.23);
        Console.WriteLine(person.Item1);

        (int count, string name) some = (5, "p");
        Console.WriteLine(some.name);
    }

    public static (Person, Order?) GetTupleOfPersonActorWithOrder(Company company)
    {
        var countOrders = company.Orders.Count;

        var r = new Random().Next(countOrders);

        var p =company[r];
        var o = company[p];
        return (p, o);
    }

    public static Company CreateCompany((Person[] people, Order) tuple)
    {
        Company c = new Company(tuple.people);
        c.Orders.Enqueue(tuple.Item2);

        return c;
    }
}
