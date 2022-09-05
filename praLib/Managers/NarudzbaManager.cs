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
    public class NarudzbaManager : IRepo<Narudzba>
    {
        public void Create(Narudzba narudzba)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Create) + nameof(Narudzba), narudzba.KupacID, narudzba.KnjigaID, narudzba.DatumKupnje, narudzba.VrstaPlacanja);
        }

        public void Delete(Narudzba narudzba)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Delete) + nameof(Narudzba), narudzba.IDNarudzba);
        }

        public Narudzba Get(int idNarudzba)
        {
            var tblNarudzba = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(Get) + nameof(Narudzba), idNarudzba).Tables[0];
            if (tblNarudzba.Rows.Count == 0) return null;

            DataRow row = tblNarudzba.Rows[0];

            return new Narudzba
            {
                IDNarudzba = (int)row[nameof(Narudzba.IDNarudzba)],
                KupacID = (int)row[nameof(Narudzba.KupacID)],
                KnjigaID = (int)row[nameof(Narudzba.KnjigaID)],
                DatumKupnje = DateTime.Parse(row[nameof(Narudzba.DatumKupnje)].ToString()),
                VrstaPlacanja = row[nameof(Narudzba.VrstaPlacanja)].ToString()
            };
        }

        public IList<Narudzba> GetAllUserOrders(int userID)
        {
            IList<Narudzba> narudzbe = new List<Narudzba>();

            var tblNarudzbe = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAllUserOrders), userID).Tables[0];
            if (tblNarudzbe == null) return null;

            foreach (DataRow row in tblNarudzbe.Rows)
            {
                narudzbe.Add(new Narudzba
                {
                    IDNarudzba = (int)row[nameof(Narudzba.IDNarudzba)],
                    KupacID = (int)row[nameof(Narudzba.KupacID)],
                    KnjigaID = (int)row[nameof(Narudzba.KnjigaID)],
                    DatumKupnje = DateTime.Parse(row[nameof(Narudzba.DatumKupnje)].ToString()),
                    VrstaPlacanja = row[nameof(Narudzba.VrstaPlacanja)].ToString()
                });
            }
            return narudzbe;
        }

        public IList<Narudzba> GetAll()
        {
            IList<Narudzba> narudzbe = new List<Narudzba>();

            var tblNarudzbe = SqlHelper.ExecuteDataset(ConnectionString.CS, nameof(GetAll) + nameof(Narudzba)).Tables[0];
            if (tblNarudzbe == null) return null;

            foreach (DataRow row in tblNarudzbe.Rows)
            {
                narudzbe.Add(new Narudzba
                {
                    IDNarudzba = (int)row[nameof(Narudzba.IDNarudzba)],
                    KupacID = (int)row[nameof(Narudzba.KupacID)],
                    KnjigaID = (int)row[nameof(Narudzba.KnjigaID)],
                    DatumKupnje = DateTime.Parse(row[nameof(Narudzba.DatumKupnje)].ToString()),
                    VrstaPlacanja = row[nameof(Narudzba.VrstaPlacanja)].ToString()
                });
            }
            return narudzbe;
        }
        public void Update(Narudzba narudzba)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CS, nameof(Update) + nameof(Narudzba),narudzba.IDNarudzba ,narudzba.KupacID, narudzba.KnjigaID, narudzba.DatumKupnje, narudzba.VrstaPlacanja);
        }
    }
}
