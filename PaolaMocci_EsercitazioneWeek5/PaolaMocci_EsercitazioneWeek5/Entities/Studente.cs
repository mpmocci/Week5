using System;
using System.Collections.Generic;
using System.Text;

namespace PaolaMocci_EsercitazioneWeek5.Entities
{
    public class Studente
    {

        public int Matricola { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoNascita { get; set; }
        public bool RichiestaLaurea { get; set; }
        public int CfuAccumulati { get; set; }
        public string CodiceCorsoLaurea { get; set; }
        public CorsoLaurea CorsoLaurea { get; set; }
        public List<Esame> Esami { get; set; } = new List<Esame>() { };


        public Studente(){

            }

        public Studente(string nome, string cognome, int annoNascita, bool richiestaLaurea, int cfuAccumulati, string codiceLaurea) {
            Nome = nome;
            Cognome = cognome;
            AnnoNascita = annoNascita;
            RichiestaLaurea = richiestaLaurea;
            CfuAccumulati = cfuAccumulati;
            CodiceCorsoLaurea = codiceLaurea;

        
        
        }


        public  void PrintInfo()
        {
            Console.WriteLine($"\nStudente:{Nome} {Cognome}, Matricola:{Matricola}.\n");
        }

    }
}
