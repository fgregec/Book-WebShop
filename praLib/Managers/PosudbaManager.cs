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
    public class PosudbaManager : IRepo<Posudba>
    {
        public void Create(Posudba posudba)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Create) + nameof(Posudba), posudba.KupacID, posudba.KnjigaID, posudba.DatumPosudbe, posudba.DatumVracanja, posudba.VrstaPlacanja);
        }

        public void Delete(Posudba posudba)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Delete) + nameof(Posudba), posudba.IDPosudbe);
        }

        public Posudba Get(int idPosudba)
        {
            var tblPosudba = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(Get) + nameof(Posudba), idPosudba).Tables[0];
            if (tblPosudba.Rows.Count == 0) return null;

            DataRow row = tblPosudba.Rows[0];

            return new Posudba
            {
                IDPosudbe = (int)row[nameof(Posudba.IDPosudbe)],
                KupacID = (int)row[nameof(Posudba.KupacID)],
                KnjigaID = (int)row[nameof(Posudba.KnjigaID)],
                DatumPosudbe = DateTime.Parse(row[nameof(Posudba.DatumPosudbe)].ToString()),
                DatumVracanja = DateTime.Parse(row[nameof(Posudba.DatumVracanja)].ToString()),
                VrstaPlacanja = row[nameof(Posudba.VrstaPlacanja)].ToString()
            };
        }

        public void ReturnBook(int posudbaID)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(ReturnBook), posudbaID);
        }

        public IList<Posudba> GetAllUserLoans(int iDKupac)
        {
            IList<Posudba> posudbe = new List<Posudba>();

            var tblPosudbe = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAllUserLoans), iDKupac).Tables[0];
            if (tblPosudbe == null) return null;

            foreach (DataRow row in tblPosudbe.Rows)
            {
                posudbe.Add(new Posudba
                {
                    IDPosudbe = (int)row[nameof(Posudba.IDPosudbe)],
                    KupacID = (int)row[nameof(Posudba.KupacID)],
                    KnjigaID = (int)row[nameof(Posudba.KnjigaID)],
                    DatumPosudbe = DateTime.Parse(row[nameof(Posudba.DatumPosudbe)].ToString()),
                    DatumVracanja = DateTime.Parse(row[nameof(Posudba.DatumVracanja)].ToString()),
                    VrstaPlacanja = row[nameof(Posudba.VrstaPlacanja)].ToString()
                });
            }
            return posudbe;
        }

        public IList<Posudba> GetAll()
        {
            IList<Posudba> posudbe = new List<Posudba>();

            var tblPosudbe = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAll) + nameof(Posudba)).Tables[0];
            if (tblPosudbe == null) return null;

            foreach (DataRow row in tblPosudbe.Rows)
            {
                posudbe.Add(new Posudba
                {
                    IDPosudbe = (int)row[nameof(Posudba.IDPosudbe)],
                    KupacID = (int)row[nameof(Posudba.KupacID)],
                    KnjigaID = (int)row[nameof(Posudba.KnjigaID)],
                    IsReturned = (bool)row[nameof(Posudba.IsReturned)],
                    DatumPosudbe = DateTime.Parse(row[nameof(Posudba.DatumPosudbe)].ToString()),
                    DatumVracanja = DateTime.Parse(row[nameof(Posudba.DatumVracanja)].ToString()),
                    VrstaPlacanja = row[nameof(Posudba.VrstaPlacanja)].ToString()
                });
            }
            return posudbe;
        }

        public void UsedBook(int knjigaID)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(UsedBook), knjigaID);
        }

        public void Update(Posudba posudba)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Update) + nameof(Posudba),posudba.IDPosudbe ,posudba.KupacID, posudba.KnjigaID, posudba.DatumPosudbe, posudba.DatumVracanja, posudba.VrstaPlacanja);
        }
    }
}
