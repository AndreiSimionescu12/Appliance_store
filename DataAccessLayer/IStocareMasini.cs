using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareMasini: IStocareFactory
    {
        List<Masina> GetMasini();
        Masina GetMasina(int id);
        bool AddMasina(Masina m);

        bool UpdateMasina(Masina m);
    }
}
