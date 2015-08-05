using System.ComponentModel.Composition;
using Tony.Accounting.Repositories;
using Tony.Accounting.Services;
using Tony.Common.DependencyInjection.Resolver;

namespace Tony.Accounting
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IIncomeRepository, IncomeRepository>();
            registerComponent.RegisterType<IExpenditureRepository, ExpenditureRepository>();
            registerComponent.RegisterType<ITransferRepository, TransferRepository>();

            registerComponent.RegisterType<IOwnerService, OwnerService>();
            registerComponent.RegisterType<IAccountService, AccountService>();
            registerComponent.RegisterType<IIncomeService, IncomeService>();
            registerComponent.RegisterType<IExpenditureService, ExpenditureService>();
            registerComponent.RegisterType<ITransferService, TransferService>();

        }
    }
}
