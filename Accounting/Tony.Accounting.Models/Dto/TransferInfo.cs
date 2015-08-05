using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tony.Accounting.Models.Dto
{
    public class TransferInfo
    {
        public Transfer Transfer { get; set; }

        public Account ToAccount { get; set; }

    }
}
