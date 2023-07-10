using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibrarieModele
{
    public class Administrator
    {
        public string nume_utilizator { get; set; }
        public string parola { get; set; }

        public Administrator()
        {

        }
        public Administrator(string nume_utilizator, string parola)
        {
            this.nume_utilizator = nume_utilizator;
            this.parola = parola;
        }
        public Administrator(DataRow linieDB)
        {
            nume_utilizator = linieDB["nume_utilizator"].ToString();
            parola = linieDB["parola"].ToString();
        }
    }


}
