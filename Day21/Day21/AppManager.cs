using System;
using System.Collections.Generic;
using System.Text;

namespace Day21
{
    public static class AppManager
    {


        public static List<Prodotto> Prodotti = new List<Prodotto>();

        public static void AggiungiProdotti()
        {
            Prodotto prodotto1 = new Prodotto()
            {
                Id = 01,
                Codice = "P01",
                Nome = "Tisana Digestiva",
                Categoria = (Category)2,
                Prezzo = 2.99


            };

            Prodotti.Add(prodotto1);

            Prodotto prodotto2 = new Prodotto()
            {
                Id = 02,
                Codice = "P02",
                Nome = "Mascara Ciglia Voluminose",
                Categoria = (Category)0,
                Prezzo = 8.59


            };

            Prodotti.Add(prodotto2);

            Prodotto prodotto3 = new Prodotto()
            {
                Id = 03,
                Codice = "P03",
                Nome = "Polase",
                Categoria = (Category)1,
                Prezzo = 14.59


            };

            Prodotti.Add(prodotto3);



            Prodotto prodotto4 = new Prodotto()
            {
                Id = 04,
                Codice = "P04",
                Nome = "Supradyn",
                Categoria = (Category)1,
                Prezzo = 17.59


            };

            Prodotti.Add(prodotto4);



            Prodotto prodotto5 = new Prodotto()
            {
                Id = 05,
                Codice = "P05",
                Nome = "Rossetto Vamp",
                Categoria = (Category)0,
                Prezzo = 10.59


            };

            Prodotti.Add(prodotto5);



            Prodotto prodotto6 = new Prodotto()
            {
                Id = 06,
                Codice = "P06",
                Nome = "Tisana Buonumore",
                Categoria = (Category)2,
                Prezzo = 5.59


            };

            Prodotti.Add(prodotto6);


        }

        public static string GetCodeMaxPrice()
        {
            double max = 0;
            string code = null;

            foreach (var item in Prodotti)
            {
                if (item.Prezzo > max)
                {
                    max = item.Prezzo;
                    code = item.Codice;
                }
            }

            return code;

        }

        public static Prodotto GetByCode(string code)
        {

            foreach (Prodotto p in Prodotti)
            {

                if (p.Codice == code)
                {
                    return p;
                }

            }

            return null;

        }

        public static List<Prodotto> GetByCategory(Category category)
        {
            List<Prodotto> ProdottiCategoria = new List<Prodotto>();

            foreach (var item in Prodotti)
            {
                if (item.Categoria == category)
                {
                    ProdottiCategoria.Add(item);
                }

            }



            return ProdottiCategoria;
        }


        public static void GetListOfProducts()
        {

            foreach (var item in Prodotti)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine($"ID: {item.Id}, Codice: {item.Codice}, Nome:{item.Nome}, Categoria:{item.Categoria}, Prezzo:{item.Prezzo} €");
            }

        }


        public static Prodotto GetById(int id)
        {

            foreach (Prodotto p in Prodotti)
            {

                if (p.Id == id)
                {
                    return p;
                }

            }

            return null;
        }

        public static Prodotto ModifyPrice(int id, double price)
        {

            foreach(var item in Prodotti)
            {
                if(item.Id == id)
                {
                    item.Prezzo = price;
                    return item;
                }
                

            }

            return null;
        }

        public static List<Prodotto> GetByRange(double min, double max)
        {
            List<Prodotto> ProdottiCategoria = new List<Prodotto>();

            foreach (var item in Prodotti)
            {
                if (item.Prezzo >= min && item.Prezzo <= max)
                {
                    ProdottiCategoria.Add(item);
                }

            }



            return ProdottiCategoria;
        }

        internal static bool AddProduct(Prodotto newProduct)
        {
            if (newProduct != null)
            {
                //generare id per il nuovo prodotto
                int id = GenerateId();

                //assegno al prodotto
                newProduct.Id = id;

                //aggiungo il prodotto alla lista
                Prodotti.Add(newProduct);

                return true;
            }

            return false;
        }

        private static int GenerateId()
        {
            //verifico che la lista abbiamo almeno un elemento
            //se c'è, prendo l'ultimo elemento e il suo id e lo incremento di 1
            //altrimenti il nuovo id è 1.

            int newId = 0;

            if (Prodotti.Count != 0)
            {
                //recupero l'ultimo elemento e il suo id
                int count = Prodotti.Count;

                Prodotto p = Prodotti[count - 1];

                //genero il nuovo id come ultimo id + 1 
                newId = p.Id + 1;

                //TODO: verificare che non esiste già un prodotto con questo id
            }
            else //se la lista è vuoto
            {
                newId = 1; //il primo elemento dovrebbe essere aggiunto con id = 1 
            }

            return newId;
        }




    }


}