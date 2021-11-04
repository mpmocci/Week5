using System;
using System.Collections.Generic;
using System.Text;

namespace Day21
{
    class Menu
    {

        public static void Start()
        {

            AppManager.AggiungiProdotti();


            bool continua = true;

            do
            {
                Console.WriteLine("\n**************MENU******************\n");
                Console.WriteLine("Premi 1 per visualizzare i dati relativi al prodotto di prezzo massimo.");
                Console.WriteLine("Premi 2 per visualizzare i dati relativi a un determinato prodotto.");
                Console.WriteLine("Premi 3 per visualizzare i prodotti relativi ad una certa categoria.");
                Console.WriteLine("Premi 4 per aggiornare il prezzo di un prodotto che ha subito un aumento.");
                Console.WriteLine("Premi 5 per stampare i dati relativi ai prodotti con prezzo compreso in un dato range.");
                Console.WriteLine("Premi 6 per aggiungere un nuovo prodotto.");
                Console.WriteLine("Premi 0 per uscire.");
                int scelta;

                do
                {
                    Console.WriteLine("\nFai la tua scelta tra le possibili opzioni.\n");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 5));


                switch (scelta)
                {

                    case 1:

                        GetProductByMaxPrice();

                        break;

                    case 2:

                        GetProductByCode();

                        break;


                    case 3:

                        GetProductByCategory();

                        break;

                    case 4:

                        ModifyPrice();

                        break;

                    case 5:
                        PrintProductsPriceRange();
                        break;


                    case 6:
                        AddNewProduct();
                        break;

                    case 0:

                        Console.WriteLine("Arrivederci!");
                        continua = false;

                        break;

                }


            }
            while (continua == true);








        }


        public static void GetProductByCode()
        {
            Console.WriteLine("\nInserisci il codice del prodotto:\n");
            string code = Console.ReadLine();
            Prodotto p = AppManager.GetByCode(code);

            if (p != null)
            {
                p.PrintInfo();
            }

            else
            {
                Console.WriteLine("Non esiste un prodotto con questo codice.");
            };

        }

        public static void GetProductByMaxPrice()
        {
            string code = AppManager.GetCodeMaxPrice();
            Prodotto p = AppManager.GetByCode(code);

            p.PrintInfo();
        }

        public static void GetProductByCategory()
        {
            Category category;
            do
            {
                Console.WriteLine("\nInserisci la categoria:\n");

            }
            while (!(Enum.TryParse<Category>(Console.ReadLine(), out category)));



            List<Prodotto> ProdottiCategoria = new List<Prodotto>();
            ProdottiCategoria = AppManager.GetByCategory(category);

            foreach (var item in ProdottiCategoria)
            {
                item.PrintInfo();
            }


        }

        public static Prodotto GetProductById()
        {

            Console.WriteLine("\nLista dei prodotti presenti nell'erboristeria:\n");
            AppManager.GetListOfProducts();

      
            int id;

            do
            {
                Console.WriteLine("\nInserire l'ID del prodotto del quale si vuole aggiornare il prezzo. \n");
            } while (!(int.TryParse(Console.ReadLine(), out id)));


            Prodotto p = AppManager.GetById(id);

            if (p != null)
            {
                p.PrintInfo();
                return p;

            }

            else
            {
                Console.WriteLine("Non esiste un prodotto con questo codice.\n");
                return null;
            };

        }

        public static void ModifyPrice()
        {
            Prodotto p = GetProductById();

            double new_price;

            do
            {
                Console.WriteLine("\nInserire il nuovo prezzo, aumentato,  del prodotto:");
            } while (!(double.TryParse(Console.ReadLine(), out new_price) && new_price > p.Prezzo));


            Prodotto item = AppManager.ModifyPrice(p.Id, new_price);
            Console.WriteLine($"\n Dati aggiornati: \n ");
            item.PrintInfo();


        }

        public static void PrintProductsPriceRange()
        {

            double min;
            double max;

            do
            {
                Console.WriteLine("Limite inferiore del range:");
            }
            while (!(double.TryParse(Console.ReadLine(), out min)));

            do
            {
                Console.WriteLine("Limite superiore del range:");
            }
            while (!(double.TryParse(Console.ReadLine(), out max) && max>min));



            List<Prodotto> ProdottiCategoria = new List<Prodotto>();
            ProdottiCategoria = AppManager.GetByRange(min, max);

            

            foreach (var item in ProdottiCategoria)
            {
                item.PrintInfo();
            }

        }

        private static void AddNewProduct()
        {
            string code = GetData("codice");

            Prodotto prodotto = AppManager.GetByCode(code);

            if(prodotto != null)
            {
                Console.WriteLine("C'è già un prodotto con questo codice.");
            }
            else
            {
                string name = GetData("Nome");

                //double price = (double)GetData("Prezzo");

                double price = GetPrice("");

                int category = GetChosenCategory();

                //Product newProduct = new Product();
                //newProduct.Code = code;
                //newProduct.Name = name;
                //newProduct.Price = price;
                //newProduct.Category = (CategoryEnum)category;

                Prodotto newProdotto = new Prodotto(code, name, price, (Category)category);

                //aggiungo prodotto alla lista
                bool isAdded = AppManager.AddProduct(newProdotto);

                if (isAdded)
                    Console.WriteLine("Aggiunta completata");
                else //altrimenti se isAdded è false
                    Console.WriteLine("Qualcosa è andato storto...");

            }


        }

        private static string GetData(string value)
        {
            string code;
            do
            {
                Console.WriteLine($"\nInserisci il {value} del prodotto:\n");
                code = Console.ReadLine();
            } while (string.IsNullOrEmpty(code));

            return code;
        }

        private static int GetChosenCategory()
        {
            int chosenCategory = 0;

            do
            {
                Console.WriteLine("Scegli la categoria" +
                $"\n Premi {(int)Category.Cosmetico} per {Category.Cosmetico}" +
                $"\n Premi {(int)Category.Integratore} per {Category.Integratore}" +
                $"\n Premi {(int)Category.Infuso} per {Category.Infuso}");

            } while (!int.TryParse(Console.ReadLine(), out chosenCategory)); //chosenCategory > 3

            return chosenCategory;
        }

        private static double GetPrice(string value)
        {
            double price;
            do
            {
                Console.WriteLine($"Inserisci il prezzo {value}");
            } while (!double.TryParse(Console.ReadLine(), out price));

            return price;
        }



    }
}
