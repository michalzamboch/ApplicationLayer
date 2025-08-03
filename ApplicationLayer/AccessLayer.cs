namespace ApplicationLayer;

internal sealed class AccessLayer
{
    public T Get<T>() where T : notnull
    {
        throw new NotImplementedException();
    }

    public void Register<T, TU>(TU implementation)
        where T : notnull
        where TU : notnull, T
    {
        throw new NotImplementedException();
    }
}
