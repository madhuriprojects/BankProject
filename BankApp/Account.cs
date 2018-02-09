// BankApp.Account
using BankApp;
using System;
using System.ComponentModel.DataAnnotations;

public enum AccountType
{
    Checking,
    Savings,
    Loan,
    CD
}
public class Account
{
	private static int lastAccountNumber = 0;


     [Key]
    public int AccountNumber
	{
		get;
		private set;
	}

    [StringLength(50,ErrorMessage = "Account Name must be less than 50 characters")]
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
    [Required]
	public AccountType TypeOfAccount
	{
		get;
		set;
	}

    [Required]
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
