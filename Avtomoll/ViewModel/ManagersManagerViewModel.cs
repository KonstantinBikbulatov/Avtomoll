using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avtomoll.ViewModel
{
    public class ManagersManagerViewModel
    { 
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Укажите логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Укажите пароль")]
        public string Password { get; set; }

        [Display(Name = "Роль")]
        [Required(ErrorMessage = "Выберите роль")]
        public string Role { get; set; }
    }
}
