﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmandasBank.Web.Models.ViewModels
{
    public class CustomerAccountsViewModel
    {

        public List<Customer> Customers { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
