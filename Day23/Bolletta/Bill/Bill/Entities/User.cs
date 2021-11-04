using System;
using System.Collections.Generic;
using System.Text;

namespace Bill.Entities
{
    public class User
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }

        public List<Bills> BillLists { get; set; } = new List<Bills>();





    }
}
