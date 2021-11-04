using System;
using System.Collections.Generic;
using System.Text;
using Bill.Entities;


namespace Bill
{
   public static class AppManager
    {

        public static List<User> users = new List<User>();
        public static List<Bills> bills = new List<Bills>();

       

        public static string GenerateCode(string firstName, string lastName)
        {
            string code = null;

            do
            {
                Random random = new Random();
                int randomNum = random.Next();
                code = $"{firstName[0]}{lastName[0]}{randomNum}";
            }
            while (GetByCode(code) != null); //se trovo un cliente con il codice che è stato generato,
            //sorteggio un altro numero random e quindi genero un nuovo codice

            return code;

        }

        internal static decimal CalculateBill(decimal kwh)
        {
            Bills bill = new Bills();
            decimal cost = bill.FixedAmount + (kwh * 10);
            return cost;
        }

        internal static User GetByCode(string code)
        {
            foreach (User u in users)
            {
                if (u.Code == code)
                {
                    return u;
                }
            }

            return null;
        }

        public static void AddUsers()
        {
            User user1 = new User()
            {
                Name = "Paola",
                LastName = "Mocci",
                Code = GenerateCode("Paola","Mocci")

            };

            users.Add(user1);

            User user2 = new User()
            {
                Name = "Carla",
                LastName = "Todde",
                Code = GenerateCode("Carla", "Todde")

            };

            users.Add(user2);

            User user3 = new User()
            {
                Name = "Nicoletta",
                LastName = "Mocci",
                Code = GenerateCode("Nicoletta", "Mocci")

            };

            users.Add(user3);


            User user4 = new User()
            {
                Name = "Andrea",
                LastName = "Sini",
                Code = GenerateCode("Andrea", "Sini")

            };

            users.Add(user4);

        }

        internal static bool AddBill(Bills newBill)
        {
            if (newBill != null)
            {
                //aggiungo bolletta su lista bollette 
                bills.Add(newBill);

                //aggiungo bolletta su lista bollette dell'utente 
                newBill.BillOwner.BillLists.Add(newBill);

                return true;
            }

            return false;

        }









        }
    }
