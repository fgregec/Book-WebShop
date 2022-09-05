using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace praLib.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Unesite email!")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Unesite password!")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}