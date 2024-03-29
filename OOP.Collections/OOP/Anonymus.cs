/*
 Анонимный тип определяется с помощью ключевого слова var и инициализатора объектов
Их св-ва только для чтения. 
Во время компиляции компилятор сам будет создавать для него имя типа и использовать это имя при обращении к объекту, например,  "<>f__AnonymousType0'2".
Для CLR импредставляют ссылочный тип.
Если есть неск анонов с одинак св-вами, то компилятор создаст один тип.
Их нельзя преобразовать к другому типу.
Вне инициализатора присвоить им значение нельзя.
есть инициализация с проекцией

 */

namespace OOP.Collections.OOP;

public static class Anonymous
{
    public static void WriteType()
    {
        var age = 12;
        var user = new { Name = "Pidor", Lastname = "Vasya" };
        var user1 = new { user.Name, age }; 
        var user2 = new { Name = user.Lastname, user1.age };

        var t = user.GetType().ToString();
        var t1 = user1.GetType().ToString();
        var t2 = user2.GetType().ToString();

        Console.WriteLine($"{t}");
        Console.WriteLine($"{t1}");
        Console.WriteLine($"{t2}");
    }

    public static void E(ref int x)
    {
        x = 100;
    }

    public static void E1(int x)
    {
        x = 100;
    }
}
