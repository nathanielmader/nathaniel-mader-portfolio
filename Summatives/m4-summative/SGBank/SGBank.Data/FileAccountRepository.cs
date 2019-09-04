using SGBank.Models;
using SGBank.Models.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private string _filePath;

        public FileAccountRepository(string filePath)//Constructor
        {
            _filePath = filePath;
        }

        List<Account> accounts = new List<Account>();

        public List<Account> List()
        {
            accounts = new List<Account>();
            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();

                    string[] columns = line.Split(',');

                    newAccount.AccountNumber = columns[0];
                    newAccount.Name = columns[1];
                    newAccount.Balance = decimal.Parse(columns[2]);

                    switch (columns[3])
                    {
                        case "F":
                            newAccount.Type = AccountType.Free;
                            break;
                        case "B":
                            newAccount.Type = AccountType.Basic;
                            break;
                        case "P":
                            newAccount.Type = AccountType.Premium;
                            break;
                        default:
                            throw new Exception("Error. Contact IT.");
                    }
                    accounts.Add(newAccount);
                }
                return accounts;
            }
        }



        public Account LoadAccount(string AccountNumber)
        {
            var list = List();
            if (list == null)
            {
                return null;
            }
            else
            {
                var LoadAccount = list.SingleOrDefault(x => x.AccountNumber == AccountNumber);
                return LoadAccount;
            }
        }

        public void SaveAccount(Account account)
        {
            //var list = List();

            accounts[accounts.IndexOf(accounts.Single(x => x.AccountNumber == account.AccountNumber))] = account;
            CreateAccountFile(accounts);
        }

        private string CreateCsvForAccount(Account account)
        {
            return string.Format("{0},{1},{2},{3}", account.AccountNumber, account.Name, account.Balance.ToString(), account.Type.ToString().First());
        }

        private void CreateAccountFile(List<Account> accounts)
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("AccountNumber,Name,Balance,Type");

                foreach (var account in accounts)//Loop through each object and convert to line
                {
                    sr.WriteLine(CreateCsvForAccount(account));
                }
            }
        }
    }
}
