﻿using SGBank.Models;
using SGBank.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class WithdrawRulesFactory
    {
        public static IWithdraw Create(AccountType type)
        {
            switch (type)
            {
                case AccountType.Free:
                    return new FreeAccountWithdrawRules();
                case AccountType.Basic:
                    return new BasicAccountWithdrawRules();
                case AccountType.Premium:
                    return new PremiumAccountWithdrawRules();
            }
            throw new Exception ("Account type is not supported!");
        }
    }
}
