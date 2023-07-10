using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Electrocasnice
    {
        public int idprodus { get; set; }
        public string denumire { get; set; }
        public string marca { get; set; }
        public string model { get; set; }
        public int stoc { get; set; }
        public string descriere { get; set; }
        public string culoare { get; set; }
        public int pret { get; set; }

        public Electrocasnice()
        {

        }
        public Electrocasnice(string denumire,string marca,string model,int stoc,string descriere,string culoare, int pret, int idprodus=0)
        {
            this.idprodus = idprodus;
            this.denumire = denumire;
            this.marca = marca;
            this.model = model;
            this.stoc = stoc;
            this.descriere = descriere;
            this.culoare = culoare;
            this.pret = pret;
        }
        public Electrocasnice(DataRow linieDB)
        {
            idprodus = Convert.ToInt32(linieDB["idprodus"].ToString());
            denumire = linieDB["denumire"].ToString();
            marca = linieDB["marca"].ToString();
            model = linieDB["model"].ToString();
            stoc = Convert.ToInt32(linieDB["stoc"].ToString());
            descriere = linieDB["descriere"].ToString();
            culoare = linieDB["culoare"].ToString();
            pret = Convert.ToInt32(linieDB["pret"].ToString());
        }
    }
}
