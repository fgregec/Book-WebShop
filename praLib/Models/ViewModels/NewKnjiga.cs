using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models.ViewModels
{
    public class NewKnjiga
    {
        public int IDKnjiga { get; set; }

        [Required(ErrorMessage = "Unesite naslov knjige!")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Unesite ime i prezime autora!")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Unesite ISBN!")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Unesite cijenu kupnje knjige!")]
        public decimal CijenaKupnja { get; set; }
        [Required(ErrorMessage = "Unesite cijenu posudbe knjige!")]
        public decimal CijenaPosudba { get; set; }
        [Required(ErrorMessage = "Unesite kolicinu knjiga!")]
        public int Kolicina { get; set; }
        [Required(ErrorMessage = "Unesite putanju za sliku!")]
        public string PutanjaSlika { get; set; }
        [Required(ErrorMessage = "Unesite opis knjige!")]
        public string Opis { get; set; }
    }
}
