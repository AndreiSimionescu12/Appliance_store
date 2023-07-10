using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareClienti : IStocareFactory
    {
        List<Clienti> GetClienti();
        Clienti GetClient(int id);
        bool AddClient(Clienti c);
        bool UpdateClient(Clienti c);
    }
}
