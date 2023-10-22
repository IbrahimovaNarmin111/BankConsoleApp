using BankConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models
{
    internal class Transaction
    {
        public static int IdCount;
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }   
        public TransactionType TransactionType { get; set; }

        public Transaction(decimal amount,DateTime transactionDate,TransactionType transactionType)
        {
            Amount = amount;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
            IdCount++;
            TransactionId = IdCount;
            Console.WriteLine($"TransactionId:{TransactionId},Amount:{Amount},TransactionType:{TransactionType},TransactionDate:{TransactionDate}");
        }
    }
}
