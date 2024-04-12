using System.Runtime.InteropServices;

namespace Ipr.WebApi.Services;

public class SingletonService
{
    private readonly TransientService _service;

    public SingletonService(TransientService service)
    {
        _service = service;
    }

    //private readonly ScopedService _scopedService;

    //public SingletonService(TransientService service, ScopedService scopedService)
    //{
    //    _service = service;
    //    _scopedService = scopedService;
    //}

    public int Flag { get; set; }

    public int Increment()
    {
        _service.Flag++;
        return _service.Flag;
    }
}

public class ScopedService
{
    private TransientService _service;

    public ScopedService(TransientService service)
    {
        _service = service;
    }

    public int Flag { get; set; }

    public int Increment()
    {
        Flag++;
        return Flag;
    }
}


public class TransientService
{
    //private readonly ScopedService _service;

    //public TransientService(ScopedService service)
    //{
    //    _service = service;
    //}

    public int Flag { get; set; }

    public int Increment()
    {
        Flag++;
        return Flag;
    }
}
