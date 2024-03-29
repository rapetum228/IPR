using BenchmarkDotNet.Attributes;

namespace BenchmarkNet7;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SelectForeachBenchmark
{
    private IEnumerable<TestData> _data;

    private int _countElements = 10000;


    [GlobalSetup]
    public void GlobalSetup()
    {
        var l = new List<TestData>();

        for (int i = 0; i < _countElements; i++)
        {
            l.Add(new TestData
            {
                Id = i,
                Name = $"Я {i}",
                Description = $"{i}{i}{i}{i}"
            });
        }

        _data = l;
    }

    [Benchmark]
    public void Select()
    {
        var list = _data.Select(x => x.Description).ToList();
        Dictionary<string, string> dictionary = new();

        var dict2 = new Dictionary<string, string>(dictionary);
    }

    [Benchmark]
    public void ForeachNewList()
    {
        var list =new List<string>();

        foreach (var item in _data)
        {
            list.Add(item.Description);
        }
    }

    [Benchmark]
    public void ForeachNewListCount()
    {
        var list = new List<string>(_data.Count());

        foreach (var item in _data)
        {
            list.Add(item.Description);
        }
    }

    //[Benchmark]
    //public void For()
    //{
    //    var list = new List<string>();

    //    for (int i = 0;i < _countElements; i++) 
    //    {
    //        list.Add(_data.Description);
    //    }
    //}
}

public class TestData
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
