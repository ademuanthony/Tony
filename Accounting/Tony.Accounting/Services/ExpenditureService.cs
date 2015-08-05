using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Accounting.Repositories;
using Tony.Data.Repository;
using Tony.Data.Services;

namespace Tony.Accounting.Services
{
    public interface IExpenditureService : IEntityService<Expenditure>
    {
        //List<Expenditure> GetAllWithAccount();
    }

    public class ExpenditureService:EntityService<Expenditure>, IExpenditureService
    {
        public ExpenditureService(IUnitOfWork unitOfWork, IExpenditureRepository repository)
            : base(unitOfWork, repository)
        {
            Repository = repository;
        }

    }
}
