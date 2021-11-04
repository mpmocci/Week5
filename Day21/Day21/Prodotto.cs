using System;
using System.Collections.Generic;
using System.Text;

namespace Day21
{
    public class Prodotto
    {

      
            public int Id { get; set; }
            public string Codice { get; set; }
            public string Nome { get; set; }

            public Category Categoria { get; set; }
            public double Prezzo { get; set; }



        public Prodotto(string code, string name, double price, Category category)
        {
            Codice = code;
            Nome = name;
            Prezzo = price;
            Categoria = category;
        }



        public void PrintInfo()
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine($"ID: {Id}, Codice: {Codice}, Nome:{Nome}, Categoria:{Categoria}, Prezzo:{Prezzo} €");



        }



    }

    public enum Category
    {
        Cosmetico,
        Integratore,
        Infuso

    }



}
