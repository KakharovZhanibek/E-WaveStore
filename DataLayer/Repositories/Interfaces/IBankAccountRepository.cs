using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories.Interfaces
{
    public interface IBankAccountRepository : IBaseRepository<BankAccount>
    {
        BankAccount GetByAccountNumber(string accountNumber);
    }
}
