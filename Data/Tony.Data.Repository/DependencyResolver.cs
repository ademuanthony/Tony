using System.ComponentModel.Composition;
using Tony.Common.DependencyInjection.Resolver;

namespace Tony.Data.Repository
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
            registerComponent.RegisterType(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork>();

        }
    }
}
