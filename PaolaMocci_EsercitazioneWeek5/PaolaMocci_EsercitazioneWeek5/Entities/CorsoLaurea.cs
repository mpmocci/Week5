using System;
using System.Collections.Generic;
using System.Text;

namespace PaolaMocci_EsercitazioneWeek5.Entities
{
    public class CorsoLaurea
    {
        public string CodiceCorsoLaurea { get; set; }
        public NomeCorsoLaurea NomeCorsoLaurea { get; set; }
        public int AnniCorso { get; set; }
        public int CfuLaurea { get; set; }
        public List<Studente> Studenti { get; set; } = new List<Studente>();
        public List<Corso> Corsi { get; set; } = new List<Corso>();


        public CorsoLaurea()
        {

        }

        public CorsoLaurea( string codice, NomeCorsoLaurea nome, int anni, int cfu) 
        {

            CodiceCorsoLaurea = codice;
            NomeCorsoLaurea = nome;
            AnniCorso = anni;
            CfuLaurea = cfu;

        
        }

    }

  



    public enum NomeCorsoLaurea
    {
        Fisica = 1,
        Informatica = 2,
        Ingegneria =3,
        Lettere = 4,
        Matematica = 5

    }
}
