using System;
using System.Collections.Generic;
using System.Text;

namespace PaolaMocci_EsercitazioneWeek5.Entities
{
    public class Esame
    {
        public string NomeEsame { get; set; }
        public int CodiceCorso { get; set; }
        public bool Passato { get; set; }


        public Esame() { }

        public Esame(string nome, int codice, bool passato) {
            NomeEsame = nome;
            CodiceCorso = codice;
            Passato = passato;
        
        }


    }
}
