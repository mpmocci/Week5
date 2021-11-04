using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Entities
{
    public class AccountHolder
    {
        public string Code { get; set; } //codice cliente
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}