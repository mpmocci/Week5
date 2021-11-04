using System;
// Realizzare un’applicazione console che consenta di gestire le bollette di un utente.

//L'utente ha Codice Fiscale, Nome, Cognome, Bollette.
//La bolletta ha Quota fissa(40 €), kWh consumati, Importo totale e Utente(intestatario).

//Un utente può avere più bollette, la bolletta ha un solo utente associato.

//Inizializziamo una lista di utenti
//All'accesso, l'utente inserisce Codice Fiscale (verifico che esista questo cliente)
//L'utente inserisce i propri dati (kwh consumati) per calcolare la nuova bolletta e aggiungerla
//al suo storico bollette.

// Il calcolo del costo della bolletta che è costituito da una quota fissa di 40€
// più il prodotto tra i kwH e 10.
//Una volta calcolata, stampare a video i valori della bolletta, inclusi nome, cognome e
//costo da pagare.

//Aggiunta:
//L'utente può visualizzare tutte le sue bollette => inserisce il suo cf e vede le sue bollette

namespace Bill
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Start();        }
    }
}
