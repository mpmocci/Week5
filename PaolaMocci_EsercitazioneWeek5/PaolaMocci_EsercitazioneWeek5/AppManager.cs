using System;
using System.Collections.Generic;
using System.Text;
using PaolaMocci_EsercitazioneWeek5.Entities;

namespace PaolaMocci_EsercitazioneWeek5
{
    public static class AppManager
    {
        public static List<Studente> studentiList = new List<Studente>();
        public static List<Esame> esameList = new List<Esame>();
        public static List<Corso> corsiList = new List<Corso>();
        public static List<CorsoLaurea> corsiLaureaList = new List<CorsoLaurea>();



        public static int GeneraMatricola()
        {
            Random rnd = new Random();
            int random = rnd.Next(1000, 5000);
            return random;
        } 

        public static int ControlloMatricola()
        {

            int matricola;
            bool continua =false;

            do
            {

                matricola = GeneraMatricola();

                foreach (var item in studentiList)
                {
                    if (item.Matricola == matricola)
                    {
                        continua = false;
                        break;
                    }
                    else
                    {
                        continua = true;
                    }
                }

            } while (continua == false);

                return matricola;

        }

        public static void AddDatiProva()
        {
            Studente stud1 = new Studente("Paola", "Mocci", 1988, true, 60, "LM38");
            Studente stud2 = new Studente("Stefania", "Sanna", 1994, false, 40, "LM38");
            Studente stud3 = new Studente("Valentina", "Maxia", 1994, false, 30, "LM39");
            //Studente stud4 = new Studente("Laurea", "Maxia", 1994, false, 30, "LM40");

            studentiList.Add(stud1);
            studentiList.Add(stud2);
            studentiList.Add(stud3);
            //studentiList.Add(stud4);

            CorsoLaurea fisica = new CorsoLaurea("LM38", NomeCorsoLaurea.Fisica, 2, 60);
            CorsoLaurea informatica = new CorsoLaurea("LM39", NomeCorsoLaurea.Informatica, 2, 50);
            CorsoLaurea ingegneria = new CorsoLaurea("LM40", NomeCorsoLaurea.Ingegneria, 2, 40);

            corsiLaureaList.Add(fisica);
            corsiLaureaList.Add(informatica);
            corsiLaureaList.Add(ingegneria);


            Corso fisicaParticelle = new Corso(01, "Fisica delle Particelle", 20, "LM38");
            Corso fisicaAstroparticelle = new Corso(02, "Fisica Astroparticellare", 20, "LM38");
            Corso fisicaTeorica = new Corso(03, "Fisica Teorica", 20, "LM38");
            Corso linguaggioC = new Corso(04, "Linguaggio C", 30, "LM39");
            Corso linguaggioOOP = new Corso(05, "Linguaggio OOP", 20, "LM39");
            Corso javascript = new Corso(06, "Linguaggio javascript", 10, "LM39");
            Corso scienzaCostruzioni = new Corso(07, "Scienza delle Costruzioni", 10, "LM40");
            Corso analisi1 = new Corso(08, "Analisi 1", 20, "LM40");
            Corso fisica1 = new Corso(09, "Fisica 1", 20, "LM40");

            corsiList.Add(fisicaParticelle);
            corsiList.Add(fisicaAstroparticelle);
            corsiList.Add(fisicaTeorica);
            corsiList.Add(linguaggioC);
            corsiList.Add(linguaggioOOP);
            corsiList.Add(javascript);

            Esame particelle = new Esame("Fisica delle particelle", 01, true);
            Esame astro_particelle = new Esame("Fisica astroparticelle", 02, true);
            Esame teorica = new Esame("Fisica teorica", 03, true);
            Esame linguaggio_c = new Esame("LinguaggioC", 04, true);
            Esame linguaggio_oop = new Esame("LinguaggioOOP", 05, true);
            Esame linguaggio_javascript = new Esame("LinguaggioJavascript", 06, true);

            esameList.Add(particelle);
            esameList.Add(astro_particelle);
            esameList.Add(teorica);
            esameList.Add(linguaggio_c);
            esameList.Add(linguaggio_oop);
            esameList.Add(linguaggio_javascript);



            //Aggiungo Lista studenti e corsi a corsi di laurea

            fisica.Studenti.Add(stud1);
            fisica.Studenti.Add(stud2);
            informatica.Studenti.Add(stud3);
            //ingegneria.Studenti.Add(stud4);

            fisica.Corsi.Add(fisicaParticelle);
            fisica.Corsi.Add(fisicaAstroparticelle);
            fisica.Corsi.Add(fisicaTeorica);
            informatica.Corsi.Add(linguaggioC);
            informatica.Corsi.Add(linguaggioOOP);
            informatica.Corsi.Add(javascript);


            //Aggiungo Lista Esami, Corso Laurea e matricola a studenti


            stud1.CorsoLaurea= fisica;
            stud2.CorsoLaurea= fisica;
            stud3.CorsoLaurea= informatica;

            stud1.Matricola = ControlloMatricola();
            stud2.Matricola = ControlloMatricola();
            stud3.Matricola = ControlloMatricola();
            //stud4.Matricola = ControlloMatricola();

            stud1.Esami.Add(particelle);
            stud1.Esami.Add(astro_particelle);
            stud1.Esami.Add(teorica);
            stud2.Esami.Add(teorica);
            stud2.Esami.Add(particelle);
            stud3.Esami.Add(linguaggio_oop);
            stud3.Esami.Add(linguaggio_javascript);
    


        }

        internal static bool CheckListExams(List<Esame> esami, string nomeEsame)
        {
            foreach(var item in esami)
            {
                if (item.NomeEsame == nomeEsame)
                {
                    return true;
                }

            }

            return false;

        }

        internal static Corso GetByIdCorso(int codiceCorso)
        {

            foreach (var item in corsiList)
            {
                if (item.IdCorso == codiceCorso)
                {
                    return item;
                }
            }

            return null;
        }

        internal static Esame GetByNomeEsame(string v)
        {

            foreach (var item in esameList)
            {
                if (item.NomeEsame == v)
                {
                    return item;
                }
            }

            return null;

        }

        internal static Studente GetByMatricola(int matricola)
        {
            foreach (var item  in studentiList)
            {
                if (item.Matricola == matricola)
                {
                    return item;
                }
            }

            return null;

        }


    }
}
