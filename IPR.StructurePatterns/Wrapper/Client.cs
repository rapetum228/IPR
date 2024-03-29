using System.ComponentModel;

namespace IPR.StructurePatterns.Wrapper;

public class Client
{
    // Клиентский код работает со всеми объектами, используя интерфейс
    // Компонента. Таким образом, он остаётся независимым от конкретных
    // классов компонентов, с которыми работает.
    public void ClientCode(IComponent component, string text)
    {
        component.PrintTextToConsole(text);
    }
}

public static class MyMainForWrapper
{
    public static void MyMain()
    {
        Client client = new Client(); //Создаём клиента

        var simple = new BaseComponent(); //Создаём базовый компонент, содержащий основное действие

        var text = "Просто без декоратора";

        client.ClientCode(simple, text); //Вызываем клиентский код на компоненте без декоратора

        //Создаём декоратор для красного цвета на основе простого компонента
        BaseWrapper redWrapper = new RedWrapper(simple);

        //Создаём декоратор для белого цвета на основе декоратора красного цвета
        BaseWrapper backgroundWhiteWrapper = new WhiteBackgroundWrapper(redWrapper);

        //Создаём декоратор для верхнего регистра
        IComponent upperWraper = new UpperWrapper(backgroundWhiteWrapper);

        text = "На мне три декоратора бляяя";

        //Вызываем код на декораторе для белого, который содержит красный, а красный содержит базу
        client.ClientCode(upperWraper, text);
    }
}