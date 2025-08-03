namespace ApplicationLayer;

public interface ICollectionService<T> where T : notnull
{
    IReadOnlyList<T> Elements { get; }
    
    void Add(T element);
    void Remove(T element);
}

public interface IPersonService : ICollectionService<Person>;

public sealed class PersonService :  IPersonService
{
    private readonly List<Person> _elements = [];
    public IReadOnlyList<Person> Elements { get; }
    
    //Paramore.Brighter.

    public PersonService()
    {
        Elements = _elements.AsReadOnly();
    }

    public void Add(Person person)
    {
        _elements.Add(person);
    }

    public void Remove(Person element)
    {
        throw new NotImplementedException();
    }
}