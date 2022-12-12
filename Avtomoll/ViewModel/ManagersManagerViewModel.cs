using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avtomoll.ViewModel
{
    public class ManagersManagerViewModel
    {
        public List<string> Roles { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Укажите логин")]
        public string Login;

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Укажите пароль")]
        public string Password;

        [Display(Name = "Роль")]
        [Required(ErrorMessage = "Выберите роль")]
        public string Role;
    }
}
