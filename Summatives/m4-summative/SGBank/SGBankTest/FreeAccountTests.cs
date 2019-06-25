﻿using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interface;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBankTest
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]//fail, too much deposited
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]//fail, negative number deposited
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]//fail, not a free account type
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]//success
        public void FreeAccountDepositRulesTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {

            IDeposit deposit = new FreeAccountDepositRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }

        [TestCase("12345", "Free Account", 180, AccountType.Free, 80, false)]
        [TestCase("12345", "Free Account", 180, AccountType.Free, -110, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 100, false)]
        [TestCase("12345", "Free Account", 20, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -30, true)]
        public void FreeAccountWithdrawRulesTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {

            IWithdraw withdraw = new FreeAccountWithdrawRules();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }
    }
}
