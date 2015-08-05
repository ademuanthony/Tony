using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tony.Accounting.Models;
using Tony.Data.Repository;

namespace Tony.Accounting.Repositories
{
    public interface ITransferRepository : IGenericRepository<Transfer> { }

    public class TransferRepository:GenericRepository<Transfer>, ITransferRepository
    {
        public TransferRepository(DbContext context) : base(context) { }
    }
}
