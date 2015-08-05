using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Common.DependencyInjection.Resolver;
using Tony.Data.Repository;

namespace Tony.Data.Services
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType(typeof(IEntityService<>), typeof(EntityService<>));
            registerComponent.RegisterType(typeof(IEntityService<,>), typeof(EntityService<,>));
        }
    }
}
