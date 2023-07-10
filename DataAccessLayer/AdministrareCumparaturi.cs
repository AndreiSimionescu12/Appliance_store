using LibrarieModele;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelAccesDate
{
    public class AdministrareCumparaturi : IStocareCumparaturi
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;
        public bool AddCumparatura(Cumparaturi c)
        {
            return SqlDBHelper.ExecuteNonQuery(
               "insert into cumparaturi_sga VALUES (:nume_utilizator_client, :idprodus, :denumire, :marca, :model, :stoc, :descriere, :culoare, :pret, :total, :plata)", CommandType.Text,
               new OracleParameter(":nume_utilizator_client", OracleDbType.NVarchar2, c.nume_utilizator_client, ParameterDirection.Input),
               new OracleParameter(":idprodus", OracleDbType.Int32, c.idprodus, ParameterDirection.Input),
               new OracleParameter(":denumire", OracleDbType.NVarchar2, c.denumire, ParameterDirection.Input),
               new OracleParameter(":marca", OracleDbType.NVarchar2, c.marca, ParameterDirection.Input),
               new OracleParameter(":model", OracleDbType.NVarchar2, c.model, ParameterDirection.Input),
               new OracleParameter(":stoc", OracleDbType.Int32, c.stoc, ParameterDirection.Input),
               new OracleParameter(":descriere", OracleDbType.NVarchar2, c.descriere, ParameterDirection.Input),
               new OracleParameter(":culoare", OracleDbType.NVarchar2, c.culoare, ParameterDirection.Input),
               new OracleParameter(":pret", OracleDbType.Int32, c.pret, ParameterDirection.Input),
               new OracleParameter(":total", OracleDbType.NVarchar2, c.total, ParameterDirection.Input),
               new OracleParameter(":plata", OracleDbType.NVarchar2, c.plata, ParameterDirection.Input)
               
           );
        }

        public bool DeleteCumparatura(Cumparaturi e)
        {
            throw new NotImplementedException();
        }

        public Cumparaturi GetCumparatura(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cumparaturi> GetCumparaturi()
        {
            var result = new List<Cumparaturi>();
            var dsCumparaturi = SqlDBHelper.ExecuteDataSet("select * from cumparaturi_sga", CommandType.Text);

            foreach (DataRow linieDB in dsCumparaturi.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Cumparaturi(linieDB));
            }
            return result;
        }

        public bool UpdateCumparatura(Cumparaturi e)
        {
            throw new NotImplementedException();
        }
    }
}
