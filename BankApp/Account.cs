// BankApp.Account
using BankApp;
using System;

internal enum AccountType
{
    Checking,
    Savings,
    Loan,
    CD
}
internal class Account
{
	private static int lastAccountNumber = 0;

	public int AccountNumber
	{
		get;
		private set;
	}

	public string AccountName
	{
		get;
		set;
	}

	public DateTime CreatedDate
	{
		get;
		private set;
	}

	public decimal Balanace
	{
		get;
		private set;
	}

	public AccountType TypeOfAccount
	{
		get;
		set;
	}

	public string EmailAddress
	{
		get;
		set;
	}

	public Account()
	{
		this.AccountNumber = ++Account.lastAccountNumber;
		this.CreatedDate = DateTime.Now;
	}

	public Account(string emailAddress)
	{
	}

	public void Deposit(decimal amount)
	{
		this.Balanace += amount;
	}

	public decimal Withdraw(decimal amount)
	{
		this.Balanace -= amount;
		return this.Balanace;
	}
}
