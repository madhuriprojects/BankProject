using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp;

namespace BankApp
{
    static class Bank
    {
        private static test.Model1 db = new test.Model1();
        //private static List<Account> accounts = new List<Account>();

        /// <summary>
        /// Creates a bank account
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="typeOfAccount"></param>
        /// <param name="initialBalance"></param>
        /// <returns>Returns the account</returns>
        /// <exception cref="System.ArgumentNullException" />
        public static Account CreateAccount(string emailAddress, 
            AccountType typeOfAccount = AccountType.Checking, 
             decimal initialBalance= 0.0M)
        {
            if(string.IsNullOrEmpty(emailAddress) ||
                     string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException("emailAddress", "Email Addres Cannot be Empty.");
            }


            var account = new Account

            {
                EmailAddress = emailAddress,
                TypeOfAccount = typeOfAccount

            };
            if(initialBalance > 0)
            account.Deposit(initialBalance);
            db.Accounts.Add(account);
            db.SaveChanges();
            db.Accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account>GetAccounts()
        {
            return db.Accounts;
        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                return null;
            return account;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            /*var account = accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
             if (account == null)
                 return;*/

            var account = GetAccountByAccountNumber(accountNumber);

            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionAmount = amount,
                Description = "Branch Deposit",
                TransactionType = TypesOfTransaction.Credit,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }


        public static void Withdraw(int accountNumber, decimal amount)
        {
           
            var account = GetAccountByAccountNumber(accountNumber);

            account.Withdraw(amount);
        }
    }
}
