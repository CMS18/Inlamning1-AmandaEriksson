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


    


    }
}
