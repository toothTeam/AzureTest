using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SoloduhaMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [UIHint("Boolean")]
        public bool RememberMe { get; set; }
    }
}