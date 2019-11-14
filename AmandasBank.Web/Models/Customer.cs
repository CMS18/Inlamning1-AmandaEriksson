using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmandasBank.Web.Models
{
    public class Customer
    {
        public Customer(int id, string name, List<Account> accounts)
        {
            CustomerId = id;
            Name = name;
            Accounts = accounts;
        }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
