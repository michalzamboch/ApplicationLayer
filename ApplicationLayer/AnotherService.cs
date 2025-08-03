namespace ApplicationLayer;

public interface IAnotherService
{
    void AddNew();
}

public class AnotherService : IAnotherService
{
    private readonly IPersonService personService;
    
    public AnotherService(IPersonService personService)
    {
        this.personService = personService;
    }

    public void AddNew()
    {
        var person = new Person();
        personService.Add(person);
    }
}