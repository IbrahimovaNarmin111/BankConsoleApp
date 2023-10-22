using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Interfaces
{
    internal interface IAccount
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }

        public void Deposit(decimal amount);


        public void Withdraw(decimal amount);


    }
}
