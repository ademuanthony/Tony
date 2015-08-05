using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Common.DependencyInjection.Locator;
using Tony.Common.DependencyInjection.Resolver;

namespace Tony.Common.DependencyInjection
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            // register service locator
            registerComponent.RegisterType<IServiceLocator, CustomUnityServiceLocator>();
        }
    }
}
