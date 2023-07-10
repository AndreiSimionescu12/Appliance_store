using LibrarieModele;
using System;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareAdministrator : IStocareFactory
    {
        List<Administrator> GetAdministratori();
        Administrator GetAdministrator(int id);
        bool AddAdministrator(Administrator c);
        bool UpdateAdministrator(Administrator c);
    }
}
