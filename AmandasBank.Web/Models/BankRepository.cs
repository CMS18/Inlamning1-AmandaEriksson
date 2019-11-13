using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmandasBank.Web.Models
{
    public class BankRepository
    {
        public List<Account> Accounts { get; set; }
        public List<Customer> Customers { get; set; }

        public BankRepository()
        {
            Accounts = new List<Account>
            {
                new Account(){ Balance = 100, AccountId = 1, CustomerId = 1 },
                new Account(){ Balance = 200, AccountId = 2, CustomerId = 2 },
                new Account(){ Balance = 300, AccountId = 3, CustomerId = 3 },
                new Account(){ Balance = 400, AccountId = 4, CustomerId = 3}
            };

            Customers = new List<Customer>
            {
                new Customer(){ Name = "Jolt", CustomerId = 1, Accounts = Accounts.Where(a => a.CustomerId == 1).ToList() },
                new Customer(){ Name = "Rut", CustomerId = 2,Accounts = Accounts.Where(a => a.CustomerId == 2).ToList() },
                new Customer(){ Name = "Morran", CustomerId = 3, Accounts = Accounts.Where(a => a.CustomerId == 3).ToList()}
            };
        }
    }
}
