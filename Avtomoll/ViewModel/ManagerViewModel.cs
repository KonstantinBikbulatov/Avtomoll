using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avtomoll.Models
{
    public class ManagerViewModel
    {

        public long ManagerId { get; set; }

        [Required(ErrorMessage = "Выберите роль")]
        [Display(Name = "Выберите роль менеджера")]
        public string RoleManager { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно быть от 3 до 50 букв")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль Должен быть от 6 до 50 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        public string PasswordConfirmation { get; set; }
    }
}
