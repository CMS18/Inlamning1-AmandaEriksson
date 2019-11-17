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

        [TestMethod]
        public void CanTransfer()
        {
            //Arrange
            var senderAccount = new Account(1, 1, 20);
            var receiverAccount = new Account(2, 2, 10);
            var amountTransfer = 20;
            var expectedAmountSender = 0;
            var expectedAmountReciever = 30;
            // Act
            receiverAccount.Transfer(senderAccount, receiverAccount, amountTransfer);
            //Assert

            Assert.AreEqual(expectedAmountSender, senderAccount.Balance);
            Assert.AreEqual(expectedAmountReciever, receiverAccount.Balance);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TransferToBigAmount()
        {
            //Arrange
            var senderAccount = new Account(1, 1, 20);
            var receiverAccount = new Account(2, 2, 10);
            var amountTransfer = 200;
            var expectedAmountSender = 20;
            var expectedAmountReciever = 10;
            // Act
            receiverAccount.Transfer(senderAccount, receiverAccount, amountTransfer);
            //Assert

            Assert.AreEqual(expectedAmountReciever, receiverAccount.Balance); // oförändrat saldo

            Assert.AreEqual(expectedAmountSender, senderAccount.Balance); // oförändrat saldo
            // + Expects exeption
        }
    }
}
