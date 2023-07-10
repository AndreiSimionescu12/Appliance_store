using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareCompanii: IStocareCompanii
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Companie> GetCompanii()
        {
            var result = new List<Companie>();
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from companii_DEV", CommandType.Text);

            foreach (DataRow linieDB in dsCompanii.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add( new Companie(linieDB));
            }
            return result;
        }

        public Companie GetCompanie(int id)
        {
            Companie result = null;
            var dsCompanii = SqlDBHelper.ExecuteDataSet("select * from companii_DEV where IdCompanie = :IdCompanie", CommandType.Text,
                new OracleParameter(":IdCompanie", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsCompanii.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsCompanii.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Companie(linieDB);
            }
            return result;
        }

        public bool AddCompanie(Companie comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO companii_DEV VALUES (seq_companii_DEV.nextval, :Nume, :Email, :Telefon, :Adresa)", CommandType.Text,
                new OracleParameter(":Nume", OracleDbType.NVarchar2, comp.Nume, ParameterDirection.Input),
                new OracleParameter(":Email", OracleDbType.NVarchar2, comp.Email, ParameterDirection.Input),
                new OracleParameter(":Telefon", OracleDbType.Int64, comp.Telefon,ParameterDirection.Input),
                new OracleParameter(":Adresa", OracleDbType.NVarchar2, comp.Adresa, ParameterDirection.Input));
        }

        public bool UpdateCompanie(Companie comp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE companii_DEV set Nume = :Nume, Email = :Email, Telefon = :Telefon, Adresa = :Adresa where IdCompanie = :IdCompanie", CommandType.Text,
                new OracleParameter(":Nume", OracleDbType.NVarchar2, comp.Nume, ParameterDirection.Input),
                new OracleParameter(":Email", OracleDbType.NVarchar2, comp.Email, ParameterDirection.Input),
                new OracleParameter(":Telefon", OracleDbType.Int64, comp.Telefon, ParameterDirection.Input),
                new OracleParameter(":Adresa", OracleDbType.NVarchar2, comp.Adresa, ParameterDirection.Input), 
                new OracleParameter(":IdCompanie", OracleDbType.Int32, comp.IdCompanie, ParameterDirection.Input));
        }
    }
}
