using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp;

namespace BankApp
{
    public enum TypesOfTransaction
    {
        Credit,
        Debit
    }
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Description { get; set; }
        public TypesOfTransaction TransactionType { get; set; }
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
    }
}
