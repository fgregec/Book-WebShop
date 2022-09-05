using praLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models.ViewModels
{
    public class UserProfileEditModel
    {
        [Required(ErrorMessage = "Unesite ime!")]
        [RegularExpression(@"^[a-zA-Z-Č-č-Ć-ć-Š-š-Đ-đ-Ž-ž]+$", ErrorMessage = "Koristite samo slova!")]
        public string fName { get; set; }
        [Required(ErrorMessage = "Unesite prezime!")]
        [RegularExpression(@"^[a-zA-Z-Č-č-Ć-ć-Š-š-Đ-đ-Ž-ž]+$", ErrorMessage = "Koristite samo slova!")]
        public string lName { get; set; }
        [Required(ErrorMessage = "Unesite datum rođenja!")]
        public string newBirthDate { get; set; }
        [Required(ErrorMessage = "Unesite adresu!")]
        public string address { get; set; }
        [Required(ErrorMessage = "Unesite grad!")]
        public string city { get; set; }
        [Required(ErrorMessage = "Unesite poštanski broj!")]
        public int cityPostNumber { get; set; }
        public string oldBirthDate { get; set; }

        public IList<Knjiga> orderList { get; set; }
        public IList<PosudbaView> loanList { get; set; }
    }
}
