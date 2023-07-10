using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Cumparaturi
    {
        public string nume_utilizator_client { get; set; }
        public int idprodus { get; set; }
        public string denumire { get; set; }
        public string marca { get; set; }
        public string model { get; set; }
        public int stoc { get; set; }
        public string descriere { get; set; }
        public string culoare { get; set; }
        public int pret { get; set; }
        public int total { get; set; }
        public string plata { get; set; }

        public Cumparaturi()
        {
            
        }

        public Cumparaturi(string nume_utilizator_client,string denumire, string marca, string model, int stoc, string descriere, string culoare, int pret,int total,string plata, int idprodus = 0)
        {
            
            this.idprodus = idprodus;
            this.nume_utilizator_client = nume_utilizator_client;
            this.denumire = denumire;
            this.marca = marca;
            this.model = model;
            this.stoc = stoc;
            this.descriere = descriere;
            this.culoare = culoare;
            this.pret = pret;
            this.total = total;
            this.plata = plata;
        }

        public Cumparaturi(DataRow linieDB)
        {
            idprodus = Convert.ToInt32(linieDB["idprodus"].ToString());
            nume_utilizator_client= linieDB["nume_utilizator"].ToString();
            denumire = linieDB["denumire"].ToString();
            marca = linieDB["marca"].ToString();
            model = linieDB["model"].ToString();
            stoc = Convert.ToInt32(linieDB["stoc"].ToString());
            descriere = linieDB["descriere"].ToString();
            culoare = linieDB["culoare"].ToString();
            pret = Convert.ToInt32(linieDB["pret"].ToString());
            total = Convert.ToInt32(linieDB["total"].ToString());
            plata= linieDB["plata"].ToString();
        }
    }
}
