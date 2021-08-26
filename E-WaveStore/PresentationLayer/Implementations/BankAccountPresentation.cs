using AutoMapper;
using DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.PresentationLayer.Implementations
{
    public class BankAccountPresentation : IBankAccountPresentation
    {
        private IBankAccountRepository _bankAccountRepository;
        private IMapper _mapper;

        public BankAccountPresentation(IBankAccountRepository bankAccountRepository, IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
        }
        public bool GetBankAccountVM(BankAccountVM bankAccountModel)
        {
            var accountNumber = bankAccountModel.AccountNumber;
            var bankAccount = _bankAccountRepository.GetByAccountNumber(accountNumber);

            var bankAccountVM = _mapper.Map<BankAccountVM>(bankAccount);

            // bool flag = false;
            //flag = bankAccountModel.Equals(bankAccountVM) ? true : false;
            /*
                      if (bankAccountModel.Equals(bankAccountVM))
                      {
                          flag = true;
                      }
                      else
                      {
                          flag = false;
                      }

                                  if (bankAccountModel.AccountNumber == bankAccountVM.AccountNumber &&
                                     bankAccountModel.AccountCvv == bankAccountVM.AccountCvv &&
                                     bankAccountModel.AccountDate == bankAccountVM.AccountDate)
                                  {
                                      flag = true;
                                  }
                                  else
                                  {
                                      flag = false;
                                  }*/

            return bankAccountModel.AccountNumber == bankAccountVM.AccountNumber &&
                   bankAccountModel.AccountCvv == bankAccountVM.AccountCvv &&
                   bankAccountModel.AccountDate == bankAccountVM.AccountDate ? true : false;

            //return _mapper.Map<BankAccountVM>(bankAccount);
        }
    }
}
