using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareElectrocasnice:IStocareFactory
    {
        List<Electrocasnice> GetElectrocasnice();
        Electrocasnice GetElectrocasnic(int id);
        bool AddElectrocasnic(Electrocasnice e);
        bool UpdateElectrocasnic(Electrocasnice e);

        bool DeleteElectrocasnic(Electrocasnice e);
        bool UpdateElectrocasnicLaCumparare(Electrocasnice e);
    }
}
