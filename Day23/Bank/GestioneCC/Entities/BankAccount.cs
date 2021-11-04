using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Entities
{
    public class BankAccount
    {
        public int Number { get; set; } //PK
        public decimal Balance { get; set; } = 0;

        public string AccountHolderCode { get; set; } //FK

        public AccountHolder AccountHolder { get; set; } //Navigation property

    }
}