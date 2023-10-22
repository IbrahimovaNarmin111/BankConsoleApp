using BankConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models
{
    internal class Bank
    {
        private Account[] Accounts = new Account[0];
        public void CreateAccount(Account account)
        {
            
            
                Array.Resize(ref Accounts, Accounts.Length + 1);
                Accounts[Accounts.Length - 1] = account;
            
            
        }
        public void DepositMoney(int accountId, decimal amount)
        {
            Account account = GetAccount(accountId);
            if(account!=null)
            {
                try
                {
                    account.Deposit(amount);
                }
                catch(InvalidAmountException)
                {
                    throw new InvalidAmountException("Mebleg 0-dan boyuk olmalidir");
                }
            }
            else
            {
                throw new AccountNotFoundException("Hesab tapilmadi");
            }
        }
        private Account GetAccount(int accountId)
        {
            foreach (var account in Accounts)
            {
                if(account.AccountId == accountId)
                {
                    return account;
                }
            }
            return null;
        }
        public void WithdrawMoney(int accountId, decimal amount)
        {
            Account account = GetAccount(accountId);
            if(account!=null)
            {
                try
                {
                    account.Withdraw(amount);
                        
                }
                catch(InvalidAmountException)
                {
                    throw new InvalidAmountException("Mebleg 0-dan boyuk olmalidir");
                }
                catch(InsufficientFundsException)
                {
                    throw new InsufficientFundsException("Mebleg balansdan boyuk olmamalidir");
                }
            }
            else
            {
                throw new AccountNotFoundException("Hesab tapilmadi");
            }
        }
        public void TransferMoney(int fromAccountId,int toAccountId,decimal amount)
        {
            Account fromAccount=GetAccount(fromAccountId);
            Account toAccount=GetAccount(toAccountId);
            if(fromAccount==null || toAccount==null)
            {
                throw new AccountNotFoundException("Hesab tapilmadi");
            }
            else
            {
                try
                {
                    fromAccount.Withdraw(amount);
                    toAccount.Deposit(amount);
                }
                catch (InvalidAmountException)
                {
                    throw new InvalidAmountException("Mebleg 0-dan boyuk olmalidir");
                }
                catch(InsufficientFundsException)
                {
                    throw new InsufficientFundsException("Mebleg balansdan boyuk olmamalidir");
                }
            }
            
        }
        public void GetAllAccounts()
        {
            foreach(var account in Accounts)
            {
                Console.WriteLine($"AccountId:{account.AccountId},Balance:{account.Balance}");
            }
        }
    }
}
