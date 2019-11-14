using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmandasBank.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmandasBank.Web.Controllers
{
    public class BankController : Controller
    {
        BankRepository bank = new BankRepository();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(int accountId, decimal amount)
        {
            if (AccountExists(accountId))
            {
                try
                {
                    bank.Deposit(amount, accountId);
                    var account = bank.Accounts.SingleOrDefault(x => x.AccountId == accountId);
                    TempData["Message"] = $"New balance for account {account.AccountId}:  {account.Balance} $";
                }
                catch
                {
                    TempData["Message"] = "Invalid amount";
                }
            }
            else
            {
                TempData["Message"] = "Type a valid account number";
            }


            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Withdraw(int accountId, decimal amount)
        {
            if (AccountExists(accountId))
            {
                try
                {
                    bank.Withdraw(amount, accountId);
                    var account = bank.Accounts.SingleOrDefault(x => x.AccountId == accountId);
                    TempData["Message"] = $"New balance for account {account.AccountId}: {account.Balance} $";
                }
                catch
                {
                    TempData["Message"] = "Invalid amount";
                }

            }
            else
            {
                TempData["Message"] = "Type a valid account number";
            }



            return RedirectToAction("Index");
        }

        public bool AccountExists(int accountId)
        {
            return bank.Accounts.Any(x => x.AccountId == accountId);
        }
    }
}
