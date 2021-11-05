using System;
using System.Collections.Generic;
using System.Text;
using PaolaMocci_EsercitazioneWeek5.Entities;


namespace PaolaMocci_EsercitazioneWeek5
{
    public static class Menu
    {
        internal static void Start()
        {

            AppManager.AddDatiProva();

            /***************************/
            //StampareNumeriMatricola(); //per vedere le matricole dei dati di prova
            /**************************/


            bool exit = true;
            do
            {
                Console.WriteLine("\n * **** Menu *****" +
                "\n[1] Prenotarsi ad un esame." +
                "\n[2] Verbalizzare un esame." +
                "\n[Q] Esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        PrenotareEsame();
                        break;
                    case '2':

                        VerbalizzareEsame();

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

        private static void VerbalizzareEsame()
        {
            int matricola;
            do
            {
                Console.WriteLine("\nInserire numero di matricola:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out matricola)));

            Studente studente = AppManager.GetByMatricola(matricola);

            //controllo esistenza matricola
            if (studente == null)
            {
                Console.WriteLine("\nNon esiste uno studente con questo numero di matricola.\n");
            }

            else
            {
                Console.WriteLine("\nInserire nome esame da verbalizzare:\n");

                Esame esame = AppManager.GetByNomeEsame(Console.ReadLine());

                //controllo esistenza esame
                if (esame == null)
                {
                    Console.WriteLine("\nNon esiste un esame con questo nome.\n");
                }
                else
                {
                    //recupero corso
                    Corso corso = AppManager.GetByIdCorso(esame.CodiceCorso);

                    //aggiornare cfu studente
                    studente.CfuAccumulati += corso.CfuCorso;

                    //cambiare flag esame
                    esame.Passato = true;

                    Console.WriteLine("\n Esame verbalizzato correttamente.\n");

                    //verficare cfu laurea e nel caso cambiare flag laurea


                    if (studente.CfuAccumulati == studente.CorsoLaurea.CfuLaurea)
                    {

                        Console.WriteLine("\n Hai raggiunto i cfu necessari per poter fare domanda di laurea. Vuoi procedere?\n" +
                        "\n[1] Presentare domanda di laurea." +
                        "\n[q] Per uscire.");
                        char choice = Console.ReadKey().KeyChar;

                        switch (choice)
                        {
                            case '1':

                                studente.RichiestaLaurea = true;
                                Console.WriteLine("\nDomanda inoltrata correttamente!\n");

                                break;

                            case 'q':
                                studente.RichiestaLaurea = false;

                                Console.WriteLine("\nArrivederci!\n");
                                break;


                        }


                    }


                }

            }
        }

        //Stampo i numeri di matricola dei dati di prova da poter usare
        private static void StampareNumeriMatricola()
        {

            foreach (var item in AppManager.studentiList)
            {
                item.PrintInfo();
            }
        }

        private static void PrenotareEsame()
        {
            int matricola;
            do
            {
                Console.WriteLine("\nInserire numero di matricola:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out matricola)));

            Studente studente = AppManager.GetByMatricola(matricola);

            //Qua ho fatto una serie di if-else annidati per fare i controlli, 
            //nell'ordine seguente: 
            //matricola->domandaLaurea->esame->esame nel CL studente ->
            //->esame già dato o no -> cfu totali studente+Esame <cfu totali CL


            //controllo esistenza matricola
            if (studente == null)
            {
                Console.WriteLine("\nNon esiste uno studente con questo numero di matricola.\n");
            }

            else
            {

                //controllo domanda di laurea inoltrata
                if (studente.RichiestaLaurea == true)
                {
                    Console.WriteLine("Non puoi prenotare un esame perché hai già inoltrato domanda di laurea.");
                }
                else
                {
                    Console.WriteLine("\nInserire nome esame da prenotare:\n");

                    Esame esame = AppManager.GetByNomeEsame(Console.ReadLine());

                    //controllo esistenza esame
                    if (esame == null)
                    {
                        Console.WriteLine("\nNon esiste un esame con questo nome.\n");
                    }
                    else
                    {

                        Corso corso = AppManager.GetByIdCorso(esame.CodiceCorso);
                        string codiceCL = corso.CodiceCorsoLaurea;

                        //Controllo che l'esame sia presente nel CL studente
                        if (codiceCL != studente.CodiceCorsoLaurea)
                        {
                            Console.WriteLine("\n Questo esame non è presente nel tuo corso di Laurea.\n");

                        }
                        else
                        {

                            bool esamePresente = AppManager.CheckListExams(studente.Esami, esame.NomeEsame);


                            //controllo che l'esame non sia gà stato dato
                            if (esamePresente == true)
                            {
                                Console.WriteLine("\n Hai già dato questo esame.\n");
                            }

                            else
                            {
                                //controllo che i cfu dell' esame e quelli dello studente non superino cfu total CL
                                if (corso.CfuCorso + studente.CfuAccumulati > studente.CorsoLaurea.CfuLaurea)
                                {
                                    Console.WriteLine("\n Non è possibile procedere perché il numero dei cfu del corso supera quelli del corso di laurea.\n");
                                }

                                else
                                {
                                    Console.WriteLine("\nPrenotazione andata a buon fine!\n");

                                    studente.Esami.Add(esame);
                                }


                            }


                        }
                    }
                }

            }

        }


    }
}
