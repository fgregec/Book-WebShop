using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace praLib.Models.ViewModels
{
    public class MailModel
    {

        [Required(ErrorMessage = "Unesite email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Unesite naslov poruke!")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Unesite poruku!")]
        public string Message { get; set; }
    }
}