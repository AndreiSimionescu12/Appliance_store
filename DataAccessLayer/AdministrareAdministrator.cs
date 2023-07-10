using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareAdministrator : IStocareAdministrator
    {

        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Administrator> GetAdministratori()
        {
            var result = new List<Administrator>();
            var dsAdministratori = SqlDBHelper.ExecuteDataSet("select * from administrator_sga", CommandType.Text);

            foreach (DataRow linieDB in dsAdministratori.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Administrator(linieDB));
            }
            return result;
        }

        public Administrator GetAdministrator(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool AddAdministrator(Administrator c)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateAdministrator(Administrator c)
        {
            throw new System.NotImplementedException();
        }
    }
}
