namespace OOP.Collections.OOP
{
    public partial class Person
    {
        public partial void SayName()
        {
            Console.WriteLine($"Я {Name}");
        }
    }

    public partial record CarRecordClass
    {
        public  string Bla { get; init; }

        public string MaxImmutableSpeed { get; set; }
    }
}
