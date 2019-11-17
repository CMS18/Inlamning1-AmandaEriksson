using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmandasBank.Web.Models
{
    public class Account
    {
        public Account(int accountid, int customerid, int balance)
        {
            AccountId = accountid;
            CustomerId = customerid;
            Balance = balance;
        }
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance || amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Balance -= amount;
        }

        public void Transfer(Account sender, Account reciever, int amount)
        { 

            if(amount > 0 && sender.Balance >= amount)
            {
                sender.Withdraw(amount);
                reciever.Deposit(amount);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "the transferamount can not be a negative number or extend the balance");
            }
           
        }
    }
}
