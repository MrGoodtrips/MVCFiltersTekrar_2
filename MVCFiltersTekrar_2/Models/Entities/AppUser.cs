using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFiltersTekrar_2.Models.Entities
{
    public class AppUser:BaseEntity
    {
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}