using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models
{
    public class Narudzba
    {
        public int IDNarudzba { get; set; }
        public int KupacID { get; set; }
        public int KnjigaID { get; set; }
        public DateTime DatumKupnje { get; set; }
        public string VrstaPlacanja { get; set; }
    }
}
