using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Models.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<AccountModel> GetAccounts();
    }
}
