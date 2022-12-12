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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно быть от 3 до 50 букв")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Укажите пароль")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль Должен быть от 6 до 50 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Роль")]
        [Required(ErrorMessage = "Выберите роль")]
        public string Role { get; set; }
    }
}
