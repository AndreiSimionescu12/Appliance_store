using System;
using System.Data;

namespace LibrarieModele
{
    public class Masina
    {
        public int IdMasina { get; set; }
        public DateTime DataFabricatie { get; set; }
        public int IdCompanie { get; set; }
        public string Model { get; set; }
        public decimal Pret { get; set; }

        //entitate aditionala
        public virtual Companie Companie { get; set; }

        public Masina()
        { }
        public Masina(DateTime dataFabricatie, int idCompanie, string model, decimal pret, int idMasina = 0)
        {
            IdMasina = idMasina;
            DataFabricatie = dataFabricatie;
            IdCompanie = idCompanie;
            Model = model;
            Pret = pret;
        }

        public Masina (DataRow linieBD)
        {
            IdMasina = Convert.ToInt32(linieBD["idMasina"].ToString());
            DataFabricatie = Convert.ToDateTime(linieBD["dataFabricatie"].ToString());
            IdCompanie = Convert.ToInt32(linieBD["idCompanie"].ToString());
            Model = linieBD["model"].ToString();
            Pret = Convert.ToDecimal(linieBD["pret"].ToString());
        }
    }
}
