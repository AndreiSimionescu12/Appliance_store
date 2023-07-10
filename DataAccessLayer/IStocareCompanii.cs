using LibrarieModele;
using System;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareCompanii: IStocareFactory
    {
        List<Companie> GetCompanii();
        Companie GetCompanie(int id);
        bool AddCompanie(Companie c);

        bool UpdateCompanie(Companie c);
    }
}
