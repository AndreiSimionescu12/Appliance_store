using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibrarieModele
{
    public class Clienti
    {

        public string nume_utilizator_client { get; set; }
        public string email_client { get; set; }
        public string parola_client { get; set; }
        public string numar_de_telefon_client { get; set; }

        public Clienti()
        {

        }

        public Clienti(string nume_utilizator_client,string email_client, string parola_client,string numar_de_telefon_client)
        {
            this.nume_utilizator_client = nume_utilizator_client;
            this.email_client = email_client;
            this.parola_client = parola_client;
            this.numar_de_telefon_client = numar_de_telefon_client;
        }

        public Clienti(DataRow linieDB)
        {
            nume_utilizator_client = linieDB["nume_utilizator"].ToString();
            email_client = linieDB["email"].ToString();
            parola_client = linieDB["parola"].ToString();
            numar_de_telefon_client = linieDB["numar_telefon"].ToString();
        }
    }
}
