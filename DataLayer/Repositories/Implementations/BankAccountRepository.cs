using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories.Implementations
{
    public class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(ApplicationContext storeDbContext) : base(storeDbContext) { }

        public BankAccount GetByAccountNumber(string accountNumber)
        {
            return _storeDbContext.BankAccounts.SingleOrDefault(x => x.AccountNumber == accountNumber);
        }
    }
}
