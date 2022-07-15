using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Data;

namespace TicketShop.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TicketShopDbContext _Context;

        public AccountRepository(TicketShopDbContext context)
        {
            _Context = context;
        }
        public IEnumerable<AccountModel> GetAccounts()
        {
            var account = _Context.Accounts;
            return account;
        }
    }
}
