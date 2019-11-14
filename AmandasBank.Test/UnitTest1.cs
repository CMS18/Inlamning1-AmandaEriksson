using AmandasBank.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;

namespace AmandasBank.Test
{
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeposit()
        {
            var bank = new BankRepository();


            var account = bank.Accounts.SingleOrDefault(x => x.AccountId == 1);
            var balanceBelore = account.Balance;

            bank.Deposit(100, 1);

            var result = account.Balance;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual((balanceBelore + 100), result);
        }

        [TestMethod]
        public void TestWithdraw()
        {
            var bank = new BankRepository();


            var account = bank.Accounts.SingleOrDefault(x => x.AccountId == 1);
            var balanceBelore = account.Balance;

            bank.Withdraw(100, 1);

            var result = account.Balance;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual((balanceBelore - 100), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAmountTooHigh()
        {
            var bank = new BankRepository();
            bank.Withdraw(100000, 1);
        }


    }
}
