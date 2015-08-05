using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Tony.Common.DependencyInjection.Locator;

namespace Tony.Common.DependencyInjection.Dependency
{
    public class UnityRegistrationModule : IContainerRegistrationModule<IUnityContainer>

    {

        // Register dependencies in unity container

        public void Register(IUnityContainer container)

        {

            // register service locator

            container.RegisterType<IServiceLocator, CustomUnityServiceLocator>();



            // register services

            //container.RegisterType<IFooService, FooService>();

        }

    }

}
