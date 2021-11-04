using System;
using System.Collections.Generic;
using System.Text;

namespace Bill.Entities
{
    public class Bills
    {
        public int FixedAmount { get; set; } = 40;
        public decimal Kwh { get; set; }
        public decimal TotalAmount { get; set; }
        public User BillOwner { get; set; }


        public override string ToString()
        {
            return $"Kwh consumati:{Kwh}\n" +
                    $"Costo totale: {TotalAmount} \n" +
                    $"Utente:{BillOwner.Name} {BillOwner.LastName}";
        }

    }
}
