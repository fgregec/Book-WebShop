using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models
{
    public class Posudba
    {
        public int IDPosudbe { get; set; }
        public int KupacID { get; set; }
        public int KnjigaID { get; set; }
        public DateTime DatumPosudbe { get; set; }
        public DateTime DatumVracanja { get; set; }
        public bool VracenoRanije { get; set; }
        public string VrstaPlacanja { get; set; }
        public int Zakasnina { get; set; }
        public bool IsReturned { get; set; }
        public string Returned { get; set; }
    }
}
