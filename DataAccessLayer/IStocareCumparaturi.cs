using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareCumparaturi:IStocareFactory
    {
        List<Cumparaturi> GetCumparaturi();
        Cumparaturi GetCumparatura(int id);
        bool AddCumparatura(Cumparaturi c);
        bool UpdateCumparatura(Cumparaturi c);

        bool DeleteCumparatura(Cumparaturi c);
    }
}
