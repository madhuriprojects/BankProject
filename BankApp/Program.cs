// BankApp.Program
using BankApp;
using System;
using System.Collections.Generic;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("************************");
		Console.WriteLine("Welcome to My Bank");
		Console.WriteLine("************************");
		while (true)
		{
			Console.WriteLine("0.Exit");
			Console.WriteLine("1.Create a New Account");
			Console.WriteLine("2.Depost");
			Console.WriteLine("3.WithDrawl");
			Console.WriteLine("4.Print All Accounts");
			Console.WriteLine("Select an Option");
			string option = Console.ReadLine();
			switch (option)
			{
			case "0":
				Console.WriteLine("Thank you for visiting");
				return;
			case "1":
			{
				Console.Write("Email Address:");
				string emailAddress = Console.ReadLine();
				string[] accountTypes = Enum.GetNames(typeof(AccountType));
				for (int i = 0; i < accountTypes.Length; i++)
				{
					Console.WriteLine(string.Format("{0}.{1}", i + 1, accountTypes[i]));
				}
				Console.WriteLine("Select an Account Type:");
                        int accountType;
                        if(!int.TryParse(Console.ReadLine(), out accountType))
                        {
                            Console.WriteLine("Invalid account Type! Try again!");
                            break;
                        }

                        if(accountType > accountTypes.Length)
                            {
                            Console.WriteLine("Invalid account Type! Try again!");
                            break;
                        }
				Console.Write("Deposit:");
				decimal amount = Convert.ToDecimal(Console.ReadLine());
                        try
                        {
                            Account account = Bank.CreateAccount(emailAddress, (AccountType)(accountType - 1), amount);
                            Console.WriteLine(string.Format("AN:{0}, ", account.AccountNumber) + string.Format("TA:{0}, ", account.TypeOfAccount) + string.Format("Balance:{0:C},", account.Balanace) + string.Format("EA:{0}", account.EmailAddress));
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"OOps! {ax.Message}");
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Something went Wrong! Please try again!");
                        }
                        finally
                        {
                            //clean up to database connections
                        }
                            break;
			}
            case "2":
                    PrintAllAccounts();
                    Console.WriteLine("Select an Account Number:");
                    var accntNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Deposit Amount:");
                    var depositAmount = Convert.ToDecimal(Console.ReadLine());
                    Bank.Deposit(accntNumber, depositAmount);
                    break;
                case "3":
                    PrintAllAccounts();
                    Console.WriteLine("Select an Account Number:");
                    accntNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Deposit Amount:");
                    var withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    Bank.Withdraw(accntNumber, withdrawAmount);
                    break;
			case "4":
                    {
                        //IEnumerable<Account> accounts = Bank.GetAccounts();
                        PrintAllAccounts();
                        break;
                    }
            }
		}
	}

    private static void PrintAllAccounts()
    {
        var accounts = Bank.GetAccounts();
        foreach (Account item in accounts)
        {
            Console.WriteLine(string.Format("AN:{0}, ", item.AccountNumber) + string.Format("TA:{0}, ", item.TypeOfAccount) + string.Format("Balance:{0:C},", item.Balanace) + string.Format("EA:{0}", item.EmailAddress));
        }
    }
}
