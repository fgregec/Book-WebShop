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
    public class KnjigaManager : IRepo<Knjiga>
    {
        public void Create(Knjiga knjiga)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Create) + nameof(Knjiga), knjiga.Naslov, knjiga.AutorID, knjiga.ISBN, knjiga.CijenaKupnja, knjiga.CijenaPosudba, knjiga.Kolicina, knjiga.PutanjaSlika, knjiga.Opis);
        }

        public void Delete(Knjiga knjiga)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Delete) + nameof(Knjiga), knjiga.IDKnjiga);
        }

        public Knjiga Get(int idKnjiga)
        {
            var tblKnjiga = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(Get) + nameof(Knjiga), idKnjiga).Tables[0];
            if (tblKnjiga.Rows.Count == 0) return null;

            DataRow row = tblKnjiga.Rows[0];

            return new Knjiga
            {
                IDKnjiga = (int)row[nameof(Knjiga.IDKnjiga)],
                Naslov = row[nameof(Knjiga.Naslov)].ToString(),
                AutorID = (int)row[nameof(Knjiga.AutorID)],
                ISBN = row[nameof(Knjiga.ISBN)].ToString(),
                CijenaKupnja = (decimal)row[nameof(Knjiga.CijenaKupnja)],
                CijenaPosudba = (decimal)row[nameof(Knjiga.CijenaPosudba)],
                Kolicina = (int)row[nameof(Knjiga.Kolicina)],
                PutanjaSlika = row[nameof(Knjiga.PutanjaSlika)].ToString(),
                Opis = row[nameof(Knjiga.Opis)].ToString()
            };
        }

        public IList<Knjiga> GetAll()
        {
            IList<Knjiga> knjige = new List<Knjiga>();

            var tblKnjige = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAll) + nameof(Knjiga)).Tables[0];
            if (tblKnjige == null) return null;

            foreach (DataRow row in tblKnjige.Rows)
            {
                knjige.Add(new Knjiga
                {
                    Naslov = row[nameof(Knjiga.Naslov)].ToString(),
                    IDKnjiga = (int)row[nameof(Knjiga.IDKnjiga)],
                    AutorID = (int)row[nameof(Knjiga.AutorID)],
                    ISBN = row[nameof(Knjiga.ISBN)].ToString(),
                    CijenaKupnja = (decimal)row[nameof(Knjiga.CijenaKupnja)],
                    CijenaPosudba = (decimal)row[nameof(Knjiga.CijenaPosudba)],
                    Kolicina = (int)row[nameof(Knjiga.Kolicina)],
                    PutanjaSlika = row[nameof(Knjiga.PutanjaSlika)].ToString(),
                    Opis = row[nameof(Knjiga.Opis)].ToString()
                });
            }

            return knjige;
        }

        public void RemoveOneBook(int knjigaID)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(RemoveOneBook), knjigaID);
        }

        public void Update(Knjiga knjiga)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Update) + nameof(Knjiga),knjiga.IDKnjiga ,knjiga.Naslov, knjiga.AutorID, knjiga.ISBN, knjiga.CijenaKupnja, knjiga.CijenaPosudba, knjiga.Kolicina, knjiga.PutanjaSlika, knjiga.Opis);
        }

    }
}
