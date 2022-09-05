using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models
{
    public class Djelatnik
    {
        public int IDDjelatnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string OIB { get; set; }
        public string RadnoMjesto { get; set; }
        public string Pozicija { get; set; }
    }
}
