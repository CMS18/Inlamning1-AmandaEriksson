using AmandasBank.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AmandasBank.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeposit()
        {
            var account = new Account(1, 1, 200);
            var amount = 100;

            var expectedBalance = 300;
            account.Deposit(amount);

            var newBalance = account.Balance;

            Assert.AreEqual(expectedBalance, newBalance);
        }

        [TestMethod]
        public void TestWithdraw()
        {

            var account = new Account(1, 1, 200);
            var amount = 100;
            var expectedBalance = 100;

            account.Withdraw(amount);

            var newBalance = account.Balance;

            Assert.AreEqual(expectedBalance, newBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAmountTooHigh()
        {
            var account = new Account(1, 1, 200);
            account.Withdraw(100000);
        }
    }
}
