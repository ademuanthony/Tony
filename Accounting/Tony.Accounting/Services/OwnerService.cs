using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Data.Repository;
using Tony.Data.Services;

namespace Tony.Accounting.Services
{
    public class OwnerService:EntityService<Owner>, IOwnerService
    {
        public OwnerService(IUnitOfWork unitOfWork, IGenericRepository<Owner> repository) : base(unitOfWork, repository)
        {
        }
    }
}
