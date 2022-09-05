using praLib.Dal;
using praLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;

namespace praLib.Managers
{
    public class AutorManager : IRepo<Autor>
    {
        public void Create(Autor autor)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Create) + nameof(Autor), autor.Ime, autor.Prezime, autor.OAutoru);
        }

        public void Delete(Autor autor)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Delete) + nameof(Autor), autor.IDAutor);
        }

        public Autor Get(int idAutor)
        {
            var tblAuthor = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(Get) + nameof(Autor), idAutor).Tables[0];
            if (tblAuthor.Rows.Count == 0) return null;

            DataRow row = tblAuthor.Rows[0];

            return new Autor
            {
                IDAutor = (int)row[nameof(Autor.IDAutor)],
                Ime = row[nameof(Autor.Ime)].ToString(),
                Prezime = row[nameof(Autor.Prezime)].ToString(),
                OAutoru = row[nameof(Autor.OAutoru)].ToString()
            };
        }

        public IList<Autor> GetAll()
        {
            IList<Autor> autori = new List<Autor>();

            var tblAutori = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAll) + nameof(Autor)).Tables[0];
            if (tblAutori == null) return null;

            foreach (DataRow row in tblAutori.Rows)
            {
                autori.Add(new Autor
                {
                    IDAutor = (int)row[nameof(Autor.IDAutor)],
                    Ime = row[nameof(Autor.Ime)].ToString(),
                    Prezime = row[nameof(Autor.Prezime)].ToString(),
                    OAutoru = row[nameof(Autor.OAutoru)].ToString()
                });
            }

            return autori;
        }

        public int GetAutorID(string ime, string prezime)
        {
            var tblAuthor = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAutorID), ime, prezime).Tables[0];
            if (tblAuthor.Rows.Count == 0) return 0;
            DataRow dataRow = tblAuthor.Rows[0];
            int id = (int)dataRow[nameof(Autor.IDAutor)];
            return id;
        }

        public void Update(Autor autor)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Update) + nameof(Autor), autor.IDAutor, autor.Ime, autor.Prezime, autor.OAutoru);
        }
    }
}
