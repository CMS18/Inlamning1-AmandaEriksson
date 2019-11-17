using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmandasBank.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmandasBank.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(int receiverId, int senderId, int amount)
        {
            var sender = BankRepository.Accounts.SingleOrDefault(s => s.AccountId == senderId);
            var receiver = BankRepository.Accounts.SingleOrDefault(r => r.AccountId == receiverId);

            if (sender != null || receiver != null || sender != receiver)
            {
                try
                {
                    receiver.Transfer(sender, receiver, amount);
                    TempData["Message1"] = $"New balance for account {sender.AccountId}: {sender.Balance} $";
                    TempData["Message2"] = $"New balance for account {receiver.AccountId}: {receiver.Balance} $";
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    TempData["Message"] = ex.Message;
                }
            }
            return RedirectToAction("Index");

        }
    }
}
