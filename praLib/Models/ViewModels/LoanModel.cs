using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models.ViewModels
{
    public class LoanModel
    {
        [Required(ErrorMessage = "Unesite ime!")]
        public string fName { get; set; }

        [Required(ErrorMessage = "Unesite prezime!")]
        public string lName { get; set; }

        [Required(ErrorMessage = "Unesite adresu!")]
        public string address { get; set; }

        [Required(ErrorMessage = "Odaberite vrstu plaćanja!")]
        public string payment { get; set; }

        [Required(ErrorMessage = "Odaberite datum posudbe!")]
        [DataType(DataType.DateTime)]

        public DateTime orderDate { get; set; }
        [Required(ErrorMessage = "Odaberite datum vraćanja knjige!")]
        [DataType(DataType.DateTime)]
        public DateTime returnDate { get; set; }
        public Kupac kupac { get; set; }
    }
}
