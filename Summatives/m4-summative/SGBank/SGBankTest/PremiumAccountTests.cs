using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interface;
using SGBank.Models.Responses;

namespace SGBankTest
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -800, false)]//overdraft limit(-500)
        [TestCase("22222", "Premium Account", 100, AccountType.Free, -100, false)]//Wrong type
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, 100, false)]//positive number
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -50, true)]//success
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRules();

            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.Name = name;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("22222", "Premium Account", 100, AccountType.Free, 250, 100, false)]//Wrong type
        [TestCase("22222", "Premium Account", 100, AccountType.Basic, -100, 100, false)]//Negative number entry
        [TestCase("22222", "Premium Account", 100, AccountType.Basic, 250, 350, true)]//success
        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();

            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.Name = name;
            account.Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
