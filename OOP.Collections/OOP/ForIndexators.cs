namespace OOP.Collections.OOP;


//Можно хранить в многомерном массиве и обращаться по нескольким индексам
//Индексы не обязательно int

public partial class Person
{
    public string Name { get; }

    public int Age { get; set; } = 20;
    public Person(string name) => Name = name;

    private int _id = new Random().Next();

    /*
        Такой метод не может возвращать:
       Значение null, константу, enum, свойство, поле readonly
    */
    public ref int GetRefOnPersonId(Person person)
    {
        return ref _id;
    }

    //частичный метод (только void, yе могут иметь out-параметры,
    //не могут иметь модификаторы virtual, override, sealed, new или extern
    public partial void SayName();
}

public class Order
{
    public Order(Person actor)
    {
        OrderId = Guid.NewGuid();
        OrderDetails = new(10);
        Actor = actor;
    }

    public Person Actor { get; set; }

    public Guid OrderId { get; }

    public List<string> OrderDetails { get; set; } = null!;

    public string this[int index]
    {
        get => OrderDetails[index];
        set
        {
            if(index >= OrderDetails.Count)
            {
                OrderDetails.Add($"{OrderDetails.Count+1}: {value}");
                return;
            }
            OrderDetails[index] = $"{index+1}: {value}";
        }
    }
}
public class Company
{
    public Person[] Personal { get; set; }
    
    public Queue<Order> Orders { get; set; } = null!;

    public Company(Person[] people)
    {
        Personal = people;
        Orders = new Queue<Order>();
    }


    // индексатор
    public Order? this[Person person]
    {
        get => Orders.FirstOrDefault(x => x.Actor == person);
        set
        {
            Orders.Enqueue(new Order(person));
        }
    }

    //перегрузка
    public Person this[int index]
    {
        get => Personal[index];
        set => Personal[index] = value;
    }
}