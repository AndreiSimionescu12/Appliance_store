using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareMasini: IStocareMasini
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Masina> GetMasini()
        {
            var result = new List<Masina>();
            var dsMasini = SqlDBHelper.ExecuteDataSet("select * from masini_DEV", CommandType.Text);

            foreach (DataRow linieBD in dsMasini.Tables[PRIMUL_TABEL].Rows)
            {
                var masina = new Masina(linieBD);
                //incarca entitatile aditionale
                masina.Companie = new AdministrareCompanii().GetCompanie(masina.IdCompanie);
                result.Add(masina);
            }
            return result;
        }

        public Masina GetMasina(int id)
        {
            Masina result = null;
            var dsMasini = SqlDBHelper.ExecuteDataSet("select * from masini_DEV where IdMasina = :IdMasina", CommandType.Text,
                new OracleParameter(":IdMasina", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsMasini.Tables[PRIMUL_TABEL].Rows.Count > 0)
            { 
                DataRow linieBD = dsMasini.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Masina(linieBD);
                //incarca entitatile aditionale
                result.Companie = new AdministrareCompanii().GetCompanie(result.IdCompanie);
            }
            return result;
        }

        public bool AddMasina(Masina m)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into masini_DEV VALUES (seq_masini_DEV.nextval, :DataFabricatie, :IdCompanie, :Model, :Pret)", CommandType.Text,
                new OracleParameter(":DataFabricatie", OracleDbType.Date, m.DataFabricatie, ParameterDirection.Input),
                new OracleParameter(":IdCompanie", OracleDbType.Int32, m.IdCompanie, ParameterDirection.Input),
                new OracleParameter(":Model", OracleDbType.NVarchar2, m.Model, ParameterDirection.Input),
                new OracleParameter(":Pret", OracleDbType.Decimal, m.Pret, ParameterDirection.Input)
            );
        }

        public bool UpdateMasina(Masina m)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE masini_DEV set dataFabricatie = :DataFabricatie, idCompanie = :IdCompanie, model =:Model, pret =:Pret where idMasina=:IdMasina", CommandType.Text,
                new OracleParameter(":DataFabricatie", OracleDbType.Date, m.DataFabricatie, ParameterDirection.Input),
                new OracleParameter(":IdCompanie", OracleDbType.Int32, m.IdCompanie, ParameterDirection.Input),
                new OracleParameter(":Model", OracleDbType.NVarchar2, m.Model, ParameterDirection.Input),
                new OracleParameter(":Pret", OracleDbType.Decimal, m.Pret, ParameterDirection.Input),
                new OracleParameter(":IdMasina", OracleDbType.Int32, m.IdMasina, ParameterDirection.Input)
            );
        }
    }
}
