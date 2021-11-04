using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Entities;

namespace Bank
{
    public static class Menu
    {
        internal static void Start()
        {
            bool exit = true;
            do
            {
                Console.WriteLine("\n * ****Menu * ****" +
                "\n[1] Aggiungere un nuovo conto" +
                "\n[2] Prelievo" +
                "\n[3] Versamento" +
                "\n[4] Saldo" +
                "\n[5] Chiudere un conto" +
                "\n[Q] Esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        AddNewBankAccount();
                        break;
                    case '2':
                        MoneyWithdraw();
                        break;
                    case '3':
                        PayIntoAccount();
                        break;
                    case '4':
                        ShowBalance();
                        break;
                    case '5':
                        break;
                    case '6':
                        break;
                    case 'Q':
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;

                }
            } while (exit);
        }

        private static void ShowBalance()
        {
            int number;

            //chiedo a utente banchiere il numero di conto
            do
            {
                Console.Write("\nInserisci il numero di conto: \n");

            } while (!int.TryParse(Console.ReadLine(), out number));

            //verifico che esista un conto con questo numero
            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account != null)
            {
                Console.WriteLine($"Il saldo sul tuo conto corrente è {account.Balance}.");
            }
            else
            {
                Console.WriteLine("Non esiste un conto con questo numero");
            }
        }

        //Prelievo
        private static void MoneyWithdraw()
        {
            int number;

            //chiedo a utente banchiere il numero di conto
            do
            {
                Console.Write("\nInserisci il numero di conto: \n");

            } while (!int.TryParse(Console.ReadLine(), out number));

            //verifico che esista un conto con questo numero
            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account != null)
            {
                //gestire prelievo
                decimal amount = GetAmount("prelevare");

                if(amount > account.Balance)
                {
                    int choice;

                    Console.WriteLine($"\nNon è possibile effettuare il prelievo in quanto superiore al saldo presente sul conto, pari a {account.Balance}.\n");
                    do
                    {
                        Console.WriteLine($"Si desidera prelevare {account.Balance}?Premere 1 per sì, qualunque altro tasto per uscire.\n");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out choice)));

                    if (choice==1)
                    {
                        account.Balance -= account.Balance;
                        Console.WriteLine($"\nPrelievo effettuato con successo, nuovo saldo pari a {account.Balance}.\n ");

                    }
                    else
                    {
                        return;
                    }


                }
                else
                {
                    account.Balance -= amount;
                    Console.WriteLine($"\nPrelievo effettuato con successo, nuovo saldo pari a {account.Balance}.\n ");
                }

                
                
            }
            else
            {
                Console.WriteLine("Non esiste un conto con questo numero");
            }

        }

        //3. Versamento
        private static void PayIntoAccount()
        {
            int number;

            //chiedo a utente banchiere il numero di conto
            do
            {
                Console.Write("Inserisci il numero di conto: ");

            } while (!int.TryParse(Console.ReadLine(), out number));

            //verifico che esista un conto con questo numero
            BankAccount account = BankManager.GetByAccountNumber(number);

            if (account != null)
            {
                //gestire versamento
                //recupero la cifra che il cliente vuole versare
                decimal amount = GetAmount("versare");

                account.Balance += amount;

                bool isUpdated = BankManager.UpdateAccount(account);

                if (isUpdated)
                {
                    Console.WriteLine($"Il nuovo saldo è: {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Qualcosa è andato storto");
                }
            }
            else
            {
                Console.WriteLine("Non esiste un conto con questo numero");
            }
        }

        //1. Aggiungere nuovo conto
        private static void AddNewBankAccount()
        {
            //L'utente è già cliente?
            //Se si, aggiungi info sul conto e aggiunto conto sul cliente e nella lista dei conti
            //Se no, aggiungi nuovo cliente sulla lista dei clienti e poi il nuovo conto sul cliente e sulla lista di conti

            char choice;
            string code;
            bool isAdded;
            BankAccount newBankAccount;

            do
            {
                Console.WriteLine("L'utente è già cliente?" +
                    "\n Premi S se si" +
                    "\n Premi N se no");

                choice = Console.ReadKey().KeyChar;

            } while (!(choice == 'S' || choice == 'N'));

            switch (choice)
            {
                case 'S':
                    //Recupero codice cliente
                    code = GetData("codice cliente");

                    //Verifico che il cliente sia effettivamente già cliente
                    AccountHolder accountHolder = BankManager.GetByCode(code);

                    if (accountHolder == null)
                    {
                        Console.WriteLine("Non esiste un cliente con questo codice"); //non è già cliente
                    }
                    else
                    {
                        //Procedo con l'aggiunta del conto
                        newBankAccount = new BankAccount();

                        //associo il cliente al conto
                        newBankAccount.AccountHolder = accountHolder;

                        //associo il codice cliente (fk) al conto
                        newBankAccount.AccountHolderCode = accountHolder.Code;

                        //aggiungo il nuovo conto
                        isAdded = BankManager.AddBankAccount(newBankAccount);

                        if (isAdded)
                        {
                            Console.WriteLine($"Aggiunto conto numero {newBankAccount.Number}" +
                                $" per {accountHolder.LastName} {accountHolder.FirstName}");
                        }
                        else
                        {
                            Console.WriteLine("Ops, qualcosa è andato storto...");
                        }
                    }
                    break;
                case 'N':
                    string firstName = GetData("nome");

                    string lastName = GetData("cognome");

                    AccountHolder newAccountHolder = new AccountHolder()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };

                    bool isNewAccountHolderAdded = BankManager.AddAccountHolder(newAccountHolder);

                    if (isNewAccountHolderAdded)
                    {
                        newBankAccount = new BankAccount();
                        newBankAccount.AccountHolder = newAccountHolder;
                        newBankAccount.AccountHolderCode = newAccountHolder.Code;

                        isAdded = BankManager.AddBankAccount(newBankAccount);

                        if (isAdded)
                        {
                            Console.WriteLine($"Aggiunto conto numero {newBankAccount.Number}" +
                                $" per {newAccountHolder.LastName} {newAccountHolder.FirstName}");
                        }
                        else
                        {
                            Console.WriteLine("Ops, qualcosa è andato storto...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ops, qualcosa è andato storto...");
                    }


                    break;
            }
        }
        private static decimal GetAmount(string value)
        {
            decimal amount;
            do
            {
                Console.Write($"Inserisci l'importo che vuoi {value}: ");
            } while (!decimal.TryParse(Console.ReadLine(), out amount));

            return amount;
        }
        private static string GetData(string value)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisci il {value} del cliente");
                info = Console.ReadLine();
            } while (string.IsNullOrEmpty(info));

            return info;
        }
    }
}