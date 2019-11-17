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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(int accountId, decimal amount)
        {

            var account = BankRepository.Accounts.SingleOrDefault(a => a.AccountId == accountId);
            if (account != null)
            {
                try
                {
                    account.Deposit(amount);

                    TempData["Message"] = $"New balance for account {account.AccountId}:  {account.Balance} $";
                }

                catch (ArgumentOutOfRangeException)
                {
                    TempData["Message"] = "Invalid or too big amount";
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
            var account = BankRepository.Accounts.SingleOrDefault(a => a.AccountId == accountId);

            if (account != null)
            {
                try
                {
                    account.Withdraw(amount);
                    TempData["Message"] = $"New balance for account {account.AccountId}: {account.Balance} $";
                }
                catch(ArgumentOutOfRangeException)
                {
                    TempData["Message"] = "Invalid or too big amount";
                }

            }
            else 
            {
                TempData["Message"] = "Type a valid account number";
            }



            return RedirectToAction("Index");
        }

    }
}
