namespace Tony.Common.DependencyInjection.Locator
{
    public interface IServiceLocator
    {
        T Get<T>();
    }
}
