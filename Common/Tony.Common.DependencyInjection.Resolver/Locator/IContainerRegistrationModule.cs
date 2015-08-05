namespace Tony.Common.DependencyInjection.Locator
{
    // Common DI container registration module interface

    public interface IContainerRegistrationModule<T>

    {

        void Register(T container);

    }

}
