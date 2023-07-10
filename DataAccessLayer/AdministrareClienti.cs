using System;
using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareClienti : IStocareClienti
    {

        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;


        public bool AddClient(Clienti c)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into clienti_sga VALUES (:nume_utilizator_client, :email_client, :parola_client, :numar_de_telefon_client)", CommandType.Text,
                new OracleParameter(":nume_utilizator_client", OracleDbType.NVarchar2, c.nume_utilizator_client, ParameterDirection.Input),
                new OracleParameter(":email_client", OracleDbType.NVarchar2, c.email_client, ParameterDirection.Input),
                new OracleParameter(":parola_client", OracleDbType.NVarchar2, c.parola_client, ParameterDirection.Input),
                new OracleParameter(":numar_de_telefon_client", OracleDbType.NVarchar2, c.numar_de_telefon_client, ParameterDirection.Input)
            );
        }

        public Clienti GetClient(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clienti> GetClienti()
        {
            var result = new List<Clienti>();
            var dsClienti = SqlDBHelper.ExecuteDataSet("select * from clienti_sga", CommandType.Text);

            foreach (DataRow linieDB in dsClienti.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Clienti(linieDB));
            }
            return result;
        }

        public bool UpdateClient(Clienti c)
        {
            throw new NotImplementedException();
        }
    }
}
