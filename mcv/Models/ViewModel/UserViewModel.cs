using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mcv.Models.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguañes")]
        public string ConfirPassword { get; set; }

    }
    public class EditUserViewModel
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }


        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguañes")]
        public string ConfirPassword { get; set; }

    }
}