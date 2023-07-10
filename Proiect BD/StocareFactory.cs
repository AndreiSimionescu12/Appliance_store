using NivelAccesDate;
using System;
using System.Collections.Generic;
using System.Configuration;
using LibrarieModele;

namespace Proiect_BD
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public class StocareFactory
    {
        public IStocareFactory GetTipStocare(Type tipEntitate)
        {
            var formatSalvare = ConfigurationManager.AppSettings["FormatSalvare"];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "BazaDateOracle":

                        if (tipEntitate == typeof(Administrator))
                        {
                            return new AdministrareAdministrator();
                        }
                        if (tipEntitate == typeof(Masina))
                        {
                            return new AdministrareMasini();
                        }
                        if (tipEntitate == typeof(Clienti))
                        {
                            return new AdministrareClienti();
                        }
                        if (tipEntitate == typeof(Electrocasnice))
                        {
                            return new AdministrareElectrocasnice();
                        }
                        if (tipEntitate == typeof(Cumparaturi))
                        {
                            return new AdministrareCumparaturi();
                        }
                        break;

                    case "BIN":
                        //instantiere clase care realizeaza salvarea in fisier binar
                        break;
                }
            }
            return null;
        }
    }
}
