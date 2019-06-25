﻿using SGBank.Models;
using SGBank.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FreeAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Free Account",
            Balance = 100.00M,
            AccountNumber = "12345",
            Type = AccountType.Free
        };

        public Account LoadAccount(string AccountNumber)
        {
            if (_account.AccountNumber == AccountNumber)
            {
                return _account;
            }
            return null;
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
