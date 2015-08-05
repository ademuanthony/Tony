using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Extenssions;
using Tony.Accounting.Models;
using Tony.Accounting.Models.Dto;
using Tony.Accounting.Repositories;
using Tony.Common.DependencyInjection.Locator;
using Tony.Data.Repository;
using Tony.Data.Services;

namespace Tony.Accounting.Services
{
    public interface ITransferService : IEntityService<Transfer>
    {
        List<TransferInfo> GetTransferInfos();
    }

    public class TransferService:EntityService<Transfer>, ITransferService
    {
        private IAccountService _accountService;

        public TransferService(IUnitOfWork unitOfWork, ITransferRepository repository, IServiceLocator serviceLocator) : base(unitOfWork, repository)
        {
            Repository = repository;
            _accountService = serviceLocator.Get<IAccountService>();
        }

        public List<TransferInfo> GetTransferInfos()
        {
            var transfers = GetAll();
            var accounts = _accountService.GetAll().ToList();
            return transfers.Select(t => t.ToTransferInfo(accounts)).ToList();
        }
    }
}
