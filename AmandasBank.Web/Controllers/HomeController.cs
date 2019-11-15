using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AmandasBank.Web.Models;
using AmandasBank.Web.Models.ViewModels;

namespace AmandasBank.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var viewmodel = new CustomerAccountsViewModel
            {
                Accounts = BankRepository.Accounts,
                Customers = BankRepository.Customers
            };

            return View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
