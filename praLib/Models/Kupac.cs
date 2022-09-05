using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models
{
    public class Kupac
    {
        public int IDKupac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string DatumRodenja { get; set; }
        public int PostanskiBroj { get; set; }
        public string Grad { get; set; }
        public string PostanskaAdresa { get; set; }
    }
}
