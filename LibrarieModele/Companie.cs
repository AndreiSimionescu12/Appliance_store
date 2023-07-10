using System;
using System.Data;

namespace LibrarieModele
{
    public class Companie
    {
        public int IdCompanie { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public long Telefon { get; set; }
        public string Adresa { get; set; }

        public Companie()
        { }

        public Companie (string nume, string email, long telefon, string adresa, int idCompanie = 0)
        {
            IdCompanie = idCompanie;
            Nume = nume;
            Email = email;
            Telefon = telefon;
            Adresa = adresa;
        }

        public Companie (DataRow linieDB)
        {
            IdCompanie = Convert.ToInt32(linieDB["idCompanie"].ToString());
            Nume = linieDB["nume"].ToString();
            Email = linieDB["email"].ToString();
            Telefon = Convert.ToInt64(linieDB["telefon"].ToString());
            Adresa = linieDB["adresa"].ToString();
        }
    }
}
