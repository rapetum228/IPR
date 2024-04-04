namespace Ipr.Caching;

public class EntityContainerCached<T> where T : class
{
    public EntityContainerCached() { }

    public EntityContainerCached(T entity) 
    { 
        Entity = entity;
    }

    public T Entity { get; set; } = default!;

    public DateTimeOffset LastUpdatedAtUtc { get; set; }
}

public class User
{
    public string Name { get; set; }

    public string Surname { get; set; }
}