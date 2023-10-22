using BankConsoleApp.Exceptions;
using BankConsoleApp.Interfaces;
using BankConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models
{
    internal class Account : IAccount
    {
        public static int IdCount;
        public int AccountId { get; set; }
        private decimal _balance;
        public decimal Balance {
            get
            {
                return _balance;
            }
            set
            {
                if (value >= 0)
                {
                    
                    _balance = value;
                }
                else
                {
                    throw new InvalidAmountException("Mebleg 0-dan boyuk olmalidir.Hesab yaranmadi");
                }
            }
        }  

        private Transaction[] Transactions = new Transaction[0];
        public Account(decimal balance)
        {
            Balance = balance;
            IdCount++;
            AccountId = IdCount;
            Console.WriteLine($"AccountId:{AccountId}, Balance:{Balance}");
        }
        public void Deposit(decimal amount)
        {
            if(amount>0)
            {
                Balance += amount;
                Console.WriteLine($"AccountId:{AccountId} Balance:{Balance}");
                 
            }
            else
            {
                throw new InvalidAmountException("Mebleg 0-dan boyuk olmalidir");
            }
        }

        public void Withdraw(decimal amount)
        {
            if(amount>0 && amount<=Balance) 
            { 
                Balance -= amount;
                Console.WriteLine($"AccountId:{AccountId} Withdraw Balance:{Balance}");
            }
            else if(amount < 0)
            {
                throw new InvalidAmountException("Mebleg 0-dan boyuk olmalidir");
            }
            else if (amount > Balance)
            {
                throw new InsufficientFundsException("Mebleg balansdan boyuk olmamalidir");
            }
            
        }
        public void AddTransaction(Transaction transaction)
        {
            Array.Resize(ref Transactions,Transactions.Length+1);
            Transactions[Transactions.Length-1] = transaction;
        }
    }
}
