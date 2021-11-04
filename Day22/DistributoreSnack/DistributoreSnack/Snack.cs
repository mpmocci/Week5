using System;
using System.Collections.Generic;
using System.Text;

namespace DistributoreSnack
{
   public class Snack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Snack()
        {

        }

        public Snack(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }







    }
}
