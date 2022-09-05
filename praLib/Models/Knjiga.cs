using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models
{
    public class Knjiga
    {
        public int IDKnjiga { get; set; }
        public string Naslov { get; set; }
        public int AutorID { get; set; }
        public string ISBN { get; set; }
        public decimal CijenaKupnja { get; set; }
        public decimal CijenaPosudba { get; set; }
        public int Kolicina { get; set; }
        public string PutanjaSlika { get; set; }
        public string Opis { get; set; }
    }
}
