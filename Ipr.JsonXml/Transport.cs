namespace Ipr.JsonXml
{
    public class Transport
    {
        public int Weight { get; set; }

        public int Speed { get; set; }
    }

    public class Car : Transport
    {
        public decimal Price { get; set; }

        public string? Name { get; set; }

        public Person[] Owners { get; set; } = null!;
    }

    public class Person
    {
        public string Name { get; set; } = null!;

        public int Age { get; set; }
    }
}