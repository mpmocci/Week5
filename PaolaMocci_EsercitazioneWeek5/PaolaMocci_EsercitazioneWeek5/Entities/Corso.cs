using System;
using System.Collections.Generic;
using System.Text;

namespace PaolaMocci_EsercitazioneWeek5.Entities
{
   public class Corso
    {
        public int IdCorso { get; set; }
        public string NomeCorso { get; set; }
        public int CfuCorso { get; set; }
        public string CodiceCorsoLaurea { get; set; }

        public Corso() { }

        public Corso(int id, string Nome, int cfu, string codiceCorsoLaurea) {
            IdCorso = id;
            NomeCorso = Nome;
            CfuCorso = cfu;
            CodiceCorsoLaurea = codiceCorsoLaurea;
        }


    }
}
