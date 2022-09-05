using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Unesite ime!")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Unesite prezime!")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Unesite email adresu!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Unesite datum rođenja!")]
        public DateTime BirthDate{ get; set; }
        [Required(ErrorMessage = "Unesite naziv grada!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Unesite poštanski broj!")]
        public string PostNumber { get; set; }
        [Required(ErrorMessage = "Unesite adresu!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Unesite password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
