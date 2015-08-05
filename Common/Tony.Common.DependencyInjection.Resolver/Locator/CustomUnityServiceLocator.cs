using Microsoft.Practices.Unity;

namespace Tony.Common.DependencyInjection.Locator
{
    // Service locator based on Unity DI container

    public class CustomUnityServiceLocator : DependencyInjectionServiceLocator<IUnityContainer>
    {

        public CustomUnityServiceLocator(IUnityContainer container): base(container)
        {
            
        }
        

        // Override base method in order to get service instance based on container specific logic

        protected override T Get<T>(IUnityContainer container)
        {
            return Container.Resolve<T>();
        }

    }

}
