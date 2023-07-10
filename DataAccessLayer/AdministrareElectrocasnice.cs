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
    public class AdministrareElectrocasnice : IStocareElectrocasnice
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;
        public bool AddElectrocasnic(Electrocasnice e)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into electrocasnice_sga VALUES (seq_electrocasnice_sga.nextval, :denumire, :marca, :model, :stoc, :descriere, :culoare, :pret)", CommandType.Text,
                new OracleParameter(":denumire", OracleDbType.NVarchar2, e.denumire, ParameterDirection.Input),
                new OracleParameter(":marca", OracleDbType.NVarchar2, e.marca, ParameterDirection.Input),
                new OracleParameter(":model", OracleDbType.NVarchar2, e.model, ParameterDirection.Input),
                new OracleParameter(":stoc", OracleDbType.Int32, e.stoc, ParameterDirection.Input),
                new OracleParameter(":descriere", OracleDbType.NVarchar2, e.descriere, ParameterDirection.Input),
                new OracleParameter(":culoare", OracleDbType.NVarchar2, e.culoare, ParameterDirection.Input),
                new OracleParameter(":pret", OracleDbType.Int32, e.pret, ParameterDirection.Input)
            );

        }

        

        public Electrocasnice GetElectrocasnic(int id)
        {
            Electrocasnice result = null;
            var dbElectrocasnice = SqlDBHelper.ExecuteDataSet("select * from electrocasnice_sga where IDPRODUS = :idProdus", CommandType.Text,
                new OracleParameter(":idProdus", OracleDbType.Int32, id, ParameterDirection.Input));
            if (dbElectrocasnice.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dbElectrocasnice.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Electrocasnice(linieBD);
            }
            
            
            return result;
        }

        public List<Electrocasnice> GetElectrocasnice()
        {
            var result = new List<Electrocasnice>();
            var dsElectrocasnice = SqlDBHelper.ExecuteDataSet("select * from electrocasnice_sga", CommandType.Text);

            foreach (DataRow linieDB in dsElectrocasnice.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Electrocasnice(linieDB));
            }
            return result;
        }

        public bool UpdateElectrocasnic(Electrocasnice e)
        {
            return SqlDBHelper.ExecuteNonQuery("UPDATE electrocasnice_sga set DENUMIRE=:denumire, MARCA=:marca, MODEL=:model, STOC=:stoc,DESCRIERE=:descriere, CULOARE=:culoare, PRET=:pret where IDPRODUS=:id",
                CommandType.Text,
                new OracleParameter(":denumire", OracleDbType.NVarchar2, e.denumire, ParameterDirection.Input),
                new OracleParameter(":marca", OracleDbType.NVarchar2, e.marca, ParameterDirection.Input),
                new OracleParameter(":model", OracleDbType.NVarchar2, e.model, ParameterDirection.Input),
                new OracleParameter(":stoc", OracleDbType.Int32, e.stoc, ParameterDirection.Input),
                new OracleParameter(":descriere", OracleDbType.NVarchar2, e.descriere, ParameterDirection.Input),
                new OracleParameter(":culoare", OracleDbType.NVarchar2, e.culoare, ParameterDirection.Input),
                new OracleParameter(":pret", OracleDbType.Int32, e.pret, ParameterDirection.Input),
                new OracleParameter(":id", OracleDbType.Int32, e.idprodus, ParameterDirection.Input));
        }

        public bool DeleteElectrocasnic(Electrocasnice e)
        {
            return SqlDBHelper.ExecuteNonQuery("DELETE FROM electrocasnice_sga WHERE IDPRODUS=:id", CommandType.Text,
               new OracleParameter(":id", OracleDbType.Int32, e.idprodus, ParameterDirection.Input));
        }

        public bool UpdateElectrocasnicLaCumparare(Electrocasnice e)
        {
            return SqlDBHelper.ExecuteNonQuery("UPDATE electrocasnice_sga set STOC=:stoc WHERE IDPRODUS=:id",
                CommandType.Text,
                new OracleParameter(":stoc", OracleDbType.Int32, e.stoc, ParameterDirection.Input),
                new OracleParameter(":id", OracleDbType.Int32, e.idprodus, ParameterDirection.Input)
                );
        }
    }
}
