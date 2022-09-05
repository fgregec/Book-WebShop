using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models.ViewModels
{
    public class NewDjelatnik
    {
        public int IDDjelatnik { get; set; }
        [Required(ErrorMessage = "Unesite ime djelatnika!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unesite prezime djelatnika!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Unesite email djelatnika!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Unesite OIB djelatnika!")]
        public string OIB { get; set; }
        [Required(ErrorMessage = "Unesite radno mjesto djelatnika!")]
        public string RadnoMjesto { get; set; }
        [Required(ErrorMessage = "Unesite poziciju djelatnika!")]
        public string Pozicija { get; set; }
        [Required(ErrorMessage = "Unesite lozinku novog djelatnika!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
