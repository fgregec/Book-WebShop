using Microsoft.ApplicationBlocks.Data;
using praLib.Dal;
using praLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Managers
{
    public class DjelatnikManager : IRepo<Djelatnik>
    {
        public void Create(Djelatnik djelatnik, string password)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Create) + nameof(Djelatnik), djelatnik.Ime, djelatnik.Prezime, djelatnik.Email, djelatnik.OIB, djelatnik.RadnoMjesto, djelatnik.Pozicija, Cryptography.HashPassword(password));
        }

        public void Delete(Djelatnik djelatnik)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Delete) + nameof(Djelatnik), djelatnik.IDDjelatnik);
        }

        public Djelatnik Get(int idDjelatnik)
        {
            var tblDjelatnik = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(Get) + nameof(Djelatnik), idDjelatnik).Tables[0];
            if (tblDjelatnik.Rows.Count == 0) return null;

            DataRow row = tblDjelatnik.Rows[0];

            return new Djelatnik
            {
               IDDjelatnik = (int)row[nameof(Djelatnik.IDDjelatnik)],
               Ime = row[nameof(Djelatnik.Ime)].ToString(),
               Prezime = row[nameof(Djelatnik.Prezime)].ToString(),
               Email = row[nameof(Djelatnik.Email)].ToString(),
               OIB = row[nameof(Djelatnik.OIB)].ToString(),
               RadnoMjesto = row[nameof(Djelatnik.RadnoMjesto)].ToString(),
               Pozicija = row[nameof(Djelatnik.Pozicija)].ToString()
            };
        }

        public void DjelatnikPasswordReset(string password, int djelatnikID)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(DjelatnikPasswordReset), djelatnikID, Cryptography.HashPassword(password));

        }

        public Djelatnik AuthDjelatnik(string email, string password)
        {
            var tblDjelatnik = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(AuthDjelatnik), email, password).Tables[0];
            if (tblDjelatnik.Rows.Count == 0) return null;

            DataRow row = tblDjelatnik.Rows[0];

            return new Djelatnik
            {
                IDDjelatnik = (int)row[nameof(Djelatnik.IDDjelatnik)],
                Ime = row[nameof(Djelatnik.Ime)].ToString(),
                Prezime = row[nameof(Djelatnik.Prezime)].ToString(),
                Email = row[nameof(Djelatnik.Email)].ToString(),
                OIB = row[nameof(Djelatnik.OIB)].ToString(),
                RadnoMjesto = row[nameof(Djelatnik.RadnoMjesto)].ToString(),
                Pozicija = row[nameof(Djelatnik.Pozicija)].ToString()
            };
        }

        public IList<Djelatnik> GetAll()
        {
            IList<Djelatnik> djelatnici = new List<Djelatnik>();

            var tblDjelatnici = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAll) + nameof(Djelatnik)).Tables[0];
            if (tblDjelatnici == null) return null;

            foreach (DataRow row in tblDjelatnici.Rows)
            {
                djelatnici.Add(new Djelatnik
                {
                    IDDjelatnik = (int)row[nameof(Djelatnik.IDDjelatnik)],
                    Ime = row[nameof(Djelatnik.Ime)].ToString(),
                    Prezime = row[nameof(Djelatnik.Prezime)].ToString(),
                    Email = row[nameof(Djelatnik.Email)].ToString(),
                    OIB = row[nameof(Djelatnik.OIB)].ToString(),
                    RadnoMjesto = row[nameof(Djelatnik.RadnoMjesto)].ToString(),
                    Pozicija = row[nameof(Djelatnik.Pozicija)].ToString()
                });
            }

            return djelatnici;
        }

        public void Update(Djelatnik djelatnik)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Update) + nameof(Djelatnik),djelatnik.IDDjelatnik ,djelatnik.Ime, djelatnik.Prezime, djelatnik.Email, djelatnik.OIB, djelatnik.RadnoMjesto, djelatnik.Pozicija);
        }

        public void Create(Djelatnik model)
        {
            throw new NotImplementedException();
        }
    }
}
