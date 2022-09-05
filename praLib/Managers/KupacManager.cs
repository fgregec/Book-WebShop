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
    public class KupacManager : IRepo<Kupac>
    {
        public void Create(Kupac kupac)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Create) + nameof(Kupac), kupac.Ime, kupac.Prezime, kupac.Email, kupac.DatumRodenja, kupac.PostanskiBroj, kupac.PostanskaAdresa, kupac.Grad);
        }

        public void NewKupac(Kupac kupac, string password)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(NewKupac), kupac.Ime, kupac.Prezime, kupac.Email, kupac.DatumRodenja, kupac.PostanskiBroj, kupac.PostanskaAdresa, kupac.Grad, Cryptography.HashPassword(password)); ;
        }

        public void Delete(Kupac kupac)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Delete) + nameof(Kupac), kupac.IDKupac);
        }

        public Kupac Get(int idKupac)
        {
            var tblKupac = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(Get) + nameof(Kupac), idKupac).Tables[0];
            if (tblKupac.Rows.Count == 0) return null;

            DataRow row = tblKupac.Rows[0];

            return new Kupac
            {
                IDKupac = (int)row[nameof(Kupac.IDKupac)],
                Ime = row[nameof(Kupac.Ime)].ToString(),
                Prezime = row[nameof(Kupac.Prezime)].ToString(),
                Email = row[nameof(Kupac.Email)].ToString(),
                DatumRodenja = row[nameof(Kupac.DatumRodenja)].ToString(),
                PostanskiBroj = (int)row[nameof(Kupac.PostanskiBroj)],
                PostanskaAdresa = row[nameof(Kupac.PostanskaAdresa)].ToString(),
                Grad = row[nameof(Kupac.Grad)].ToString()
            };
        }

        public Kupac AuthKupac(string email, string password)
        {
            var tblKupac = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(AuthKupac), email, password).Tables[0];
            if (tblKupac.Rows.Count == 0) return null;

            DataRow row = tblKupac.Rows[0];

            return new Kupac
            {
                IDKupac = (int)row[nameof(Kupac.IDKupac)],
                Ime = row[nameof(Kupac.Ime)].ToString(),
                Prezime = row[nameof(Kupac.Prezime)].ToString(),
                Email = row[nameof(Kupac.Email)].ToString(),
                DatumRodenja = row[nameof(Kupac.DatumRodenja)].ToString(),
                PostanskiBroj = (int)row[nameof(Kupac.PostanskiBroj)],
                PostanskaAdresa = row[nameof(Kupac.PostanskaAdresa)].ToString(),
                Grad = row[nameof(Kupac.Grad)].ToString()
            };
        }

        public void KupacPasswordReset(string password, int id)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(KupacPasswordReset), id, Cryptography.HashPassword(password));
        }

        public IList<Kupac> GetAll()
        {
            IList<Kupac> kupci = new List<Kupac>();

            var tblKupci = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAll) + nameof(Kupac)).Tables[0];
            if (tblKupci == null) return null;

            foreach (DataRow row in tblKupci.Rows)
            {
                kupci.Add(new Kupac
                {
                    IDKupac = (int)row[nameof(Kupac.IDKupac)],
                    Ime = row[nameof(Kupac.Ime)].ToString(),
                    Prezime = row[nameof(Kupac.Prezime)].ToString(),
                    Email = row[nameof(Kupac.Email)].ToString(),
                    DatumRodenja = row[nameof(Kupac.DatumRodenja)].ToString(),
                    PostanskiBroj = (int)row[nameof(Kupac.PostanskiBroj)],
                    PostanskaAdresa = row[nameof(Kupac.PostanskaAdresa)].ToString(),
                    Grad = row[nameof(Kupac.Grad)].ToString()
                });
            }

            return kupci;
        }

        public void Update(Kupac kupac)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Update) + nameof(Kupac),kupac.IDKupac ,kupac.Ime, kupac.Prezime, kupac.DatumRodenja, kupac.PostanskiBroj, kupac.PostanskaAdresa, kupac.Grad);
        }
    }
}
