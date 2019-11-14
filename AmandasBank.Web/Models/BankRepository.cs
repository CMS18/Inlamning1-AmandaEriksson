using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmandasBank.Web.Models
{
    public static class BankRepository
    {
        public static List<Account> Accounts { get; set; }
        public static List<Customer> Customers { get; set; }

        public static void SetCustomers(List<Customer> customers)
        {
            Customers = customers;
            Accounts = new List<Account>();
            foreach (var cust in customers)
            {
                Accounts.AddRange(cust.Accounts);
            }
        }
        public static List<Customer> GetCustomers()
        {
            return Customers;
        }


        public static void Deposit(decimal amount, int accountId)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var account = Accounts.SingleOrDefault(a => a.AccountId == accountId);
            account.Balance += amount;


        }

        public static void Withdraw(decimal amount, int accountId)
        {
            var account = Accounts.SingleOrDefault(a => a.AccountId == accountId);
            if (amount > account.Balance || amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            account.Balance -= amount;
        }


    }
}
