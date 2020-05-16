using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Moi nhap UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Moi nhap PassWord")]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}