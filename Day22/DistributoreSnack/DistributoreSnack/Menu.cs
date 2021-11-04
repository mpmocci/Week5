using System;
using System.Collections.Generic;
using System.Text;

namespace DistributoreSnack
{
   public class Menu
    {

        public static void Start()
        {

            AppManager.AddSnacks();
            ShowMenu();

            //Console.WriteLine("\n**************MENU******************\n");
            //Console.WriteLine("Premi 1 per il Mars.");
            //Console.WriteLine("Premi 2 per il Twix.");
            //Console.WriteLine("Premi 3 per il Duplo.");
            //Console.WriteLine("Premi 4 per i Crackers.");
            //Console.WriteLine("Premi 5 per il Bounty.");
            //Console.WriteLine("Premi 6 per la Fiesta.");





            int scelta;

            do
            {
                Console.WriteLine("\nFai la tua scelta tra le possibili opzioni.\n");
            } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 1 && scelta <= 6));


            ShowPrice(scelta);


        }

        private static void ShowMenu()
        {

            Console.WriteLine("\n**************MENU******************\n");


            foreach (var item in AppManager.SnacksList)
            {
                Console.WriteLine($"Premi {item.Key} per {item.Value.Name}.\n");


            }


        }

        private static void ShowPrice(int value)
        {

            Snack snack = AppManager.GetByKey(value);
            double money;

            do
            {

                Console.WriteLine($"Prezzo: {snack.Price}. Inserire il denaro necessario.\n");

                //double money = Convert.ToDouble(Console.ReadLine());

            } while (!(double.TryParse(Console.ReadLine(), out money)));

            if(money < snack.Price)
            {

                do
                {
                    Console.WriteLine($"Denaro insufficiente. Inserire altri {snack.Price - money}\n");
                    double money2 = Convert.ToDouble(Console.ReadLine());

                    money = money + money2;


                } while (money < snack.Price);

                Console.WriteLine("Erogazione dello snack\n");


            }
            else if(money == snack.Price)
            {
                Console.WriteLine("Erogazione dello snack\n");
            }
            else if(money > snack.Price)
            {
                Console.WriteLine("Erogazione dello snack\n");
                Console.WriteLine($"Resto erogato {money-snack.Price}\n");

            }


        }





    }






}
