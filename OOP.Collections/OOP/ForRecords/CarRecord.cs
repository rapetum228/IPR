namespace OOP.Collections.OOP.ForRecords;

/*
 Неизменяемые типы. Чтобы так действительно было нужно юзануть init вместо set
По умолчанию record - class, можно не указывать тогда. Для структуры указать.
Сравнение в records происходит по значениям, а не ссылкам как в классах.
Инициализация с помощью with - позволяет создать одну record на основе другой record,
указывается оператор with, после которого в фигурных скобках указываются значения отличающихся свойств
Могут быть позиционными, record без {}, а сразу конструктором в одну строку. У классов по умолчанию init, у структур set.
Чтобы у структуры нужен init, нужно указать readonly.
Могут наследоваться.
ToString выводит имя record-a и в фиг скобках имя свойств с значениями.
 */

public record CarRecordClass(int MaxImmutableSpeed)
{
    public string CarName { get; set; }

    public void Deconstruct(out string name, out int speed) => (name, speed) = (CarName, MaxImmutableSpeed);
}

public record struct CarRecordStruct
{
    public string CarName { get; set; }

    public int MaxImmutableSpeed { get; init; }
}

// по умолчанию init
public record PersonClassReadonly(string Name, int Age);



// по умолчанию set
public record struct PersonStruct(string Name, int Age);

// init
public readonly record struct PersonStructReadonly(string Name, int Age);

public record SuperCarClass(int MaxImmutableSpeed, int LevelOfCool) : CarRecordClass(MaxImmutableSpeed);