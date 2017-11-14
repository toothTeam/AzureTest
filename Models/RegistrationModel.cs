using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SoloduhaMVC.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage="Поле не может быть пустым")]
        public string Login { get; set; }

        [Required(ErrorMessage="Поле не может быть пустым")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage="Поле не может быть пустым")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}