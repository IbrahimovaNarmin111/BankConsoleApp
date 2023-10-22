using BankConsoleApp.Exceptions;
using BankConsoleApp.Models;
using BankConsoleApp.Utilities;
using System.ComponentModel.Design;

namespace BankConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Bank bank = new Bank();
            //Account account = new Account(1500);
            //Account account1 = new Account(1000);
            //bank.CreateAccount(account);
            //bank.CreateAccount(account1);
            //try  //Hesaba pul yatirma
            //{
            //    bank.DepositMoney(1, 500);
            //    bank.DepositMoney(2, 400);
            //}
            //catch(InvalidAmountException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(AccountNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //try //Hesabdan pul cixartma
            //{
            //    bank.WithdrawMoney(1, 200);

            //}
            //catch(InvalidAmountException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(InsufficientFundsException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(AccountNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //try //Hesabdan hesaba pul transferi
            //{
            //    bank.TransferMoney(1, 2, 300);
            //}
            //catch(InvalidAmountException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(InsufficientFundsException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(AccountNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //bank.GetAllAccounts();
            //Transaction transaction = new Transaction(100, DateTime.Now, TransactionType.Deposit);
            //Transaction transaction1=new Transaction(200,DateTime.Now, TransactionType.Deposit);
            bool check = true;
            do
            {
                Console.WriteLine("======Xos Gelmisiniz======");
                Console.WriteLine("1.Create Account");
                Console.WriteLine("2.Deposit Money");
                Console.WriteLine("3.Withdraw Money");
                Console.WriteLine("4.Get All Accounts");
                Console.WriteLine("5.Transfer Money");
                Console.WriteLine("0.Quit");
                string choice=Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        Console.WriteLine("Balansi daxil edin:");
                        if(bank!=null)
                        {
                           
                            string AccountBalance = Console.ReadLine();
                            decimal Balance;
                            decimal.TryParse(AccountBalance, out Balance);
                            {
                                try
                                {
                                    bank.CreateAccount(new Account(Balance));
                                    Console.WriteLine("Hesab yarandi");
                                }
                                catch(InvalidAmountException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                           
                            
                        }
                        
                       
                        else
                        {
                            Console.WriteLine("Ilk once bank olmalidir");
                        }
                        break;
                        case "2":
                        Console.WriteLine("Account Id daxil edin:");
                        if(bank!=null)
                        {
                            string AccountId = Console.ReadLine();
                            int Id;
                            int.TryParse(AccountId, out Id);
                            Console.WriteLine("Meblegi daxil edin:");
                            string DepositAmount=Console.ReadLine();
                            decimal Amount;
                            decimal.TryParse(DepositAmount, out Amount);
                            {
                                try
                                {
                                    bank.DepositMoney(Id, Amount);
                                    Console.WriteLine("Pul yatirildi");
                                }
                                catch(InvalidAmountException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch(AccountNotFoundException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ilk once bank yaradin");
                        }

                        break;
                        case "3":
                        Console.WriteLine("Account Id daxil edin:");
                        if (bank != null)
                        {
                            string AccountId = Console.ReadLine();
                            int Id;
                            int.TryParse(AccountId, out Id);
                            Console.WriteLine("Meblegi daxil edin:");
                            string WithdrawAmount = Console.ReadLine();
                            decimal Amount;
                            decimal.TryParse(WithdrawAmount, out Amount);
                            {
                                try
                                {
                                    bank.WithdrawMoney(Id, Amount);
                                    Console.WriteLine("Pul cixarildi");
                                }
                                catch(InvalidAmountException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch(InsufficientFundsException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch(AccountNotFoundException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                

                            }
                           

                        }
                       
                        else
                        {
                            Console.WriteLine("Ilk once bank yaradin");
                        }
                        break;
                        case "4":
                        if(bank!=null)
                        {
                            bank.GetAllAccounts();
                        }
                        else
                        {
                            Console.WriteLine("Ilk once bank yaradin");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Esas Id daxil edin:");
                        if(bank!=null)
                        {
                            string fromAccountId = Console.ReadLine();
                            int Id;
                            int.TryParse(fromAccountId, out Id);
                            Console.WriteLine("Gonderilecek Id daxil edin:");
                            string toAccountId = Console.ReadLine();
                            int AccountId;
                            int.TryParse(toAccountId, out AccountId);
                            Console.WriteLine("Meblegi daxil edin:");
                            string TransferMoneyAmount = Console.ReadLine();
                            decimal Amount;
                            decimal.TryParse(TransferMoneyAmount, out Amount);
                            {
                                try
                                {
                                    bank.TransferMoney(Id, AccountId, Amount);
                                    Console.WriteLine("Transfer gerceklesdi");
                                }
                                catch(InvalidAmountException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch(InsufficientFundsException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch(AccountNotFoundException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Ilk once bank yaradin");
                        }
                        break;
                    case "0":
                        return;
                        
                }
            }
            while (check);



            
        }
    }
}