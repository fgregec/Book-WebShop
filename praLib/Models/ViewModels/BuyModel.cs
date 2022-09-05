using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace praLib.Models
{
    public class BuyModel
    {
        [Required(ErrorMessage = "Unesite ime!")]
        public string fName { get; set; }

        [Required(ErrorMessage = "Unesite prezime!")]
        public string lName { get; set; }

        [Required(ErrorMessage = "Unesite adresu!")]
        public string address { get; set; }       
        
        [Required(ErrorMessage = "Unesite grad!")]
        public string city { get; set; }

        [Required(ErrorMessage = "Unesite poštanski broj!")]
        public string postNumber { get; set; }


        [Required(ErrorMessage = "Odaberite vrstu plaćanja!")]
        public string payment { get; set; }

        public Kupac kupac { get; set; }

    }
}