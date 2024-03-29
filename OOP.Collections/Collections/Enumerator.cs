using OOP.Collections.OOP;
using System.Collections;

namespace OOP.Collections.Collections;

public class MyEnumerator : IEnumerator<Person>
{
    Person[] _persons;
    public MyEnumerator(Person[] persons)
    {
        _persons = persons;
    }
    static int position = -1;

    public Person Current
    {
        get
        {
            return _persons[position];
        }
    }

    object IEnumerator.Current => _persons[position];

    public void Dispose()
    {
        //throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        if (position < _persons.Length - 1)
        {
            position++;
            return true;
        }
        else
            return false;
    }

    public void Reset()
    {
        position = -1;
    }
}


class MyEnumerable : IEnumerable
{
    List<Person> _list;
    public MyEnumerable(Person[] persons)
    {
        _list = new List<Person>(persons);
    }

    public IEnumerator GetEnumerator() => new MyEnumerator(_list.ToArray());
}
