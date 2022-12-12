﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Avtomoll.ViewModel
{
    public class ManagersManagerViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

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
