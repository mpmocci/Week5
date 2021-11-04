using System;
using System.Collections.Generic;
using System.Text;
using Bill.Entities;


namespace Bill
{
    public static class Menu
    {
       internal static void Start()
        {
            AppManager.AddUsers();


            bool exit = true;
            do
            {
                Console.WriteLine("\n * ****Menu * ****" +
                "\n[1] Per calcolare la tua bolletta" +
                "\n[2] Visualizzare le tue bollette" +
                "\n[3] Visualizzare dati utenti" +
                "\n[Q] Esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':

                        CalculateBill();

                        break;

                    case '2':
                        PrintBillList();

                        break;


                    case '3':

                        PrintUsersInfo();

                        break;


                }


            } while (exit);


        }

        private static void PrintBillList()
        {
            string code = GetData("Codice");

            User user = new User();

            user = AppManager.GetByCode(code);

             foreach (var item in user.BillLists)
                {
                Console.WriteLine($"Kwh:{item.Kwh}, Costo totale:{item.TotalAmount}");

                }

            }

        private static void PrintUsersInfo()
        {

            foreach (var item in AppManager.users)
            {
                Console.WriteLine($"{item.Name}, {item.LastName}, {item.Code}");
            }


        }

        private static void CalculateBill()
        {

            string code = GetData("Codice Fiscale");

            User user = AppManager.GetByCode(code);

            if (user == null)
            {
                Console.WriteLine("Non esiste un cliente con questo codice"); //non è già cliente
            }
            else
            {

                decimal kwh = Convert.ToDecimal(GetData("kwh consumati"));

                decimal cost = AppManager.CalculateBill(kwh);

                Bills newBill = new Bills();

                newBill.Kwh = kwh;
                newBill.TotalAmount = cost;
                newBill.BillOwner = user;



                bool isAdded = AppManager.AddBill(newBill);

                if (isAdded)
                {
                    //stampare a video i valori della bolletta, inclusi nome, cognome e
                    //costo da pagare.
                    Console.WriteLine(newBill + "\n"); //newBill.ToString()
                }


                else
                {
                    Console.WriteLine("Ops, qualcosa è andato storto.\n");
                }






            }

        }

        private static string GetData(string value)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisci {value} ");
                info = Console.ReadLine();
            } while (string.IsNullOrEmpty(info));

            return info;
        }
    }
}
